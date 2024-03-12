using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.CertifikateDTO;
using DTO.EdukimDTO;
using DTO.UpdateDTO;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using UserXDTO;

namespace Domain.Concrete
{
    internal class UserDomain : DomainBase, IUserDomain
    {
        public UserDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, httpContextAccessor) { }

        private IUserRepository userRepository => _unitOfWork.GetRepository<IUserRepository>();
        private IProjektRepository projektRepository => _unitOfWork.GetRepository<IProjektRepository>();
        private ILejeRepository lejeRepository => _unitOfWork.GetRepository<ILejeRepository>();
        private IDetajeUserRepository detajeUserRepository => _unitOfWork.GetRepository<IDetajeUserRepository>();
        private IPushimetZyrtareRepository pushimeRepository => _unitOfWork.GetRepository<IPushimetZyrtareRepository>();
        private IEdukimRepository edukimRepository => _unitOfWork.GetRepository<IEdukimRepository>();
        private ICertifikateRepository certifikateRepository => _unitOfWork.GetRepository<ICertifikateRepository>();
        private IAftesiRepository aftesiRepository => _unitOfWork.GetRepository<IAftesiRepository>();
        private IPervojPuneRepository pervojePuneRepository => _unitOfWork.GetRepository<IPervojPuneRepository>();
        private IUserAftesiRepository userAftesiRepository => _unitOfWork.GetRepository<IUserAftesiRepository>();
        private IUserCertifikateRepository userCertifikateRepository =>
            _unitOfWork.GetRepository<IUserCertifikateRepository>();
        private IUserProjektRepository userProjektRepository => _unitOfWork.GetRepository<IUserProjektRepository>();
        private IUserRoliRepository userRoliRepository => _unitOfWork.GetRepository<IUserRoliRepository>();
        private IUserPervojePuneRepository userPervojePuneRepository =>
            _unitOfWork.GetRepository<IUserPervojePuneRepository>();
        private IUserEdukimRepository userEdukimRepository => _unitOfWork.GetRepository<IUserEdukimRepository>();

        private IRoliRepository roliRepository => _unitOfWork.GetRepository<IRoliRepository>();

        public IList<UserDTO1> GetAllUsers()
        {
            IEnumerable<AppUser> user = userRepository.getAllusers();

            var test = _mapper.Map<IList<UserDTO1>>(user);

            return test;
        }

        public UserDTO GetUserById(Guid id)
        {
            AppUser user = userRepository.GetById(id);

            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO PutUser(Guid UserId, UserPostDTO user)
        {
            var userentity = userRepository.GetById(UserId);

            if (userentity is null)
                throw new Exception();
            userentity = _mapper.Map<UserPostDTO, AppUser>(user, userentity);

            userRepository.Update(userentity);
            _unitOfWork.Save();
            return _mapper.Map<UserDTO>(userentity);
        }

        public void AddUserProject(Guid UserId, Guid ProjektId, UserProjektPostDTO userprojekt)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (projektRepository.GetById(ProjektId) == null)
                throw new ArgumentException("Project does not exist");

            var userprojektentity = _mapper.Map<UserProjekt>(userprojekt);
            userprojektentity.UserId = UserId;
            userprojektentity.ProjektId = ProjektId;

            if (user.UserProjekts.Contains(userprojektentity) == true)
                throw new ArgumentException("User already has project");

            user.UserProjekts.Add(userprojektentity);
            _unitOfWork.Save();
        }

        public void DeleteUserProject(Guid UserId, Guid ProjektId)
        {
            var user = userRepository.GetById(UserId);
            var userprojects = user.UserProjekts;
            foreach (var userproject in userprojects)
            {
                if (userproject.UserId == UserId && userproject.ProjektId == ProjektId)
                    userprojects.Remove(userproject);
            }
            _unitOfWork.Save();
        }

        public bool KerkoLeje(Guid UserId, LejePostDTO leje)
        {
            //UpdateBalance(UserId);
            var user = userRepository.GetById(UserId);
            int balanca = user.BalancaLeje;
            int diteLeje = 0;
            foreach (var leja in user.Lejes)
            {
                if (leja.Aprovuar == 2)
                    diteLeje += KontrolloLejen(_mapper.Map<Leje>(leja));
            }
            diteLeje += KontrolloLejen(_mapper.Map<Leje>(leje));

            //int diteLeje = (int)(leje.DataMbarim - leje.DataFillim).TotalDays;

            if (diteLeje <= balanca)
            {
                var lejeEntity = _mapper.Map<Leje>(leje);
                lejeEntity.LejeId = Guid.NewGuid();
                lejeEntity.UserId = UserId;
                lejeEntity.Aprovuar = 2;
                //lejeEntity.DokumentLeje = _photoDomain.AddPhoto(leje.DokumentLeje);

                var lejeFinal = lejeRepository.Add(lejeEntity);

                _unitOfWork.Save();
                return true;
            }
            else
                return false;
        }

        public void DeleteLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            if (leje is null)
                throw new Exception();

            lejeRepository.Remove(LejeId);

            _unitOfWork.Save();
        }

        public void UpdateLeje(Guid LejeId, LejePostDTO leje)
        {
            var lejeEntity = lejeRepository.GetById(LejeId);

            if (lejeEntity is null)
                throw new Exception();
            lejeEntity = _mapper.Map<LejePostDTO, Leje>(leje, lejeEntity);

            lejeRepository.Update(lejeEntity);
            _unitOfWork.Save();
        }

        public void UpdateBalance(Guid userId)
        {
            var user = userRepository.GetById(userId);
            IEnumerable<Leje> lejet = user.Lejes;

            var detajet = user.DetajeUsers.First();
            int count = 0;

            foreach (var x in lejet)
            {
                if (x.Aprovuar == 1)
                {
                    count += KontrolloLejen(x);
                    //count = count + (int)(x.DataMbarim - x.DataFillim).TotalDays;
                }
            }
            if (detajet != null)
            {
                int shtimiBalances;
                double months = Math.Abs(
                    (detajet.DataFillim.Month - DateTime.Now.Month) + 12 * (detajet.DataFillim.Year - DateTime.Now.Year)
                );
                if (months > 12)
                {
                    shtimiBalances = (int)Math.Round(months * 1.7) - 20;
                    user.BalancaLeje += shtimiBalances;
                    user.BalancaLeje -= count;
                    userRepository.Update(user);
                    _unitOfWork.Save();
                }
                else
                {
                    user.BalancaLeje -= count;
                    userRepository.Update(user);
                    _unitOfWork.Save();
                }
            }
        }

        public int KontrolloLejen(Leje leje)
        {
            int count = 0;
            foreach (DateTime day in EachDay(leje.DataFillim, leje.DataMbarim.AddDays(-1)))
            {
                if (pushimeRepository.GetByDate(day) == null)
                {
                    if ((day.DayOfWeek == DayOfWeek.Saturday) || (day.DayOfWeek == DayOfWeek.Sunday))
                        continue;
                    else
                        ++count;
                }
                else { }
            }
            return count;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void ApproveLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            leje.Aprovuar = 1;
            lejeRepository.Update(leje);
            _unitOfWork.Save();
            UpdateBalance(leje.UserId);
            _unitOfWork.Save();
        }

        public void DisapproveLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            leje.Aprovuar = 0;
            //UpdateBalance(leje.UserId);
            lejeRepository.Update(leje);
            _unitOfWork.Save();
        }

        public void AddUserEdukim(Guid UserId, Guid eduId, UserEdukimPostDTO useredukim)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (edukimRepository.GetById(eduId) == null)
                throw new ArgumentException("Edukim does not exist");

            var userEdukimEntity = _mapper.Map<UserEdukim>(useredukim);
            userEdukimEntity.UserId = UserId;
            userEdukimEntity.EduId = eduId;

            if (user.UserEdukims.Contains(userEdukimEntity) == true)
                throw new ArgumentException("user has already this edukim");

            user.UserEdukims.Add(userEdukimEntity);
            _unitOfWork.Save();
        }

        public void DeleteUserEdukim(Guid UserId, Guid eduId)
        {
            var user = userRepository.GetById(UserId);
            var useredukims = user.UserEdukims;
            foreach (var useredukim in useredukims)
            {
                if (useredukim.UserId == UserId && useredukim.EduId == eduId)
                    useredukims.Remove(useredukim);
            }
            _unitOfWork.Save();
        }

        public void DeleteUserCertifikate(Guid UserId, Guid CertId)
        {
            var user = userRepository.GetById(UserId);
            var usercertifikates = user.UserCertifikates;
            foreach (var usercertifikate in usercertifikates)
            {
                if (usercertifikate.UserId == UserId && usercertifikate.CertId == CertId)
                    usercertifikates.Remove(usercertifikate);
            }
            _unitOfWork.Save();
        }

        public void AddUserCertifikate(Guid UserId, Guid CertId, UserCertifikatePostDTO userCertifikate)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (certifikateRepository.GetById(CertId) == null)
                throw new ArgumentException("Certifikate does not exist");

            var UserCertifikateEntity = _mapper.Map<UserCertifikate>(userCertifikate);
            UserCertifikateEntity.UserId = UserId;
            UserCertifikateEntity.CertId = CertId;

            if (user.UserCertifikates.Contains(UserCertifikateEntity) == true)
                throw new ArgumentException("user has already this certifikate");

            user.UserCertifikates.Add(UserCertifikateEntity);
            _unitOfWork.Save();
        }

        public void AddUserAftesi(Guid UserId, Guid aftesiId, UserAftesiPostDTO useraftesi)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (aftesiRepository.GetById(aftesiId) == null)
                throw new ArgumentException("Aftesi does not exist");

            var userAftesiEntity = _mapper.Map<UserAftesi>(useraftesi);
            userAftesiEntity.UserId = UserId;
            userAftesiEntity.AftesiId = aftesiId;

            if (user.UserAftesis.Contains(userAftesiEntity) == true)
                throw new ArgumentException("user has already this aftesi");

            user.UserAftesis.Add(userAftesiEntity);
            _unitOfWork.Save();
        }

        public void DeleteUserAftesi(Guid UserId, Guid aftesiId)
        {
            var user = userRepository.GetById(UserId);
            var useraftesis = user.UserAftesis;
            foreach (var useraftesi in useraftesis)
            {
                if (useraftesi.UserId == UserId && useraftesi.AftesiId == aftesiId)
                    useraftesis.Remove(useraftesi);
            }
            _unitOfWork.Save();
        }

        public void DeleteUserPervojePune(Guid UserId, Guid PPId)
        {
            var user = userRepository.GetById(UserId);
            var userPervojePune = user.UserPervojePunes;
            foreach (var userPP in userPervojePune)
            {
                if (userPP.UserId == UserId && userPP.Ppid == PPId)
                    userPervojePune.Remove(userPP);
            }
            _unitOfWork.Save();
        }

        public UserPervojePuneDTOX UpdateUserPervojePune(Guid UserId, Guid PPId, UserPervojePunePutDTO ppDTO)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (pervojePuneRepository.GetById(PPId) == null)
                throw new ArgumentException("PervojePune does not exist");

            var userPervojePuneEntity = userPervojePuneRepository.GetByUserIdAndPPId(UserId, PPId);
            userPervojePuneEntity = _mapper.Map<UserPervojePunePutDTO, UserPervojePune>(ppDTO, userPervojePuneEntity);

            userPervojePuneRepository.Update(userPervojePuneEntity);
            _unitOfWork.Save();
            return _mapper.Map<UserPervojePuneDTOX>(userPervojePuneEntity);
        }

        public UserAftesiDTOX UpdateUserAftesi(Guid UserId, Guid aftesiId, UserAftesiPutDTO aftesiDTO)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (aftesiRepository.GetById(aftesiId) == null)
                throw new ArgumentException("Aftesi does not exist");

            var userAftesiEntity = userAftesiRepository.GetByUserIdAndAftesiId(UserId, aftesiId);
            userAftesiEntity = _mapper.Map<UserAftesiPutDTO, UserAftesi>(aftesiDTO, userAftesiEntity);

            userAftesiRepository.Update(userAftesiEntity);
            _unitOfWork.Save();
            return _mapper.Map<UserAftesiDTOX>(userAftesiEntity);
        }

        public UserCertifikateDTOX UpdateUserCertifikate(Guid UserId, Guid CertId, UserCertifikatePutDTO certDTO)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (certifikateRepository.GetById(CertId) == null)
                throw new ArgumentException("Certifikate does not exist");

            var userCertifikateEntity = userCertifikateRepository.GetByUserIdAndCertifikateId(UserId, CertId);
            userCertifikateEntity = _mapper.Map<UserCertifikatePutDTO, UserCertifikate>(certDTO, userCertifikateEntity);

            userCertifikateRepository.Update(userCertifikateEntity);
            _unitOfWork.Save();
            return _mapper.Map<UserCertifikateDTOX>(userCertifikateEntity);
        }

        public UserEdukimDTOX UpdateUserEdukim(Guid UserId, Guid EduId, UserEdukimPutDTO eduDTO)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (edukimRepository.GetById(EduId) == null)
                throw new ArgumentException("Edukim does not exist");

            var userEdukimEntity = userEdukimRepository.GetByUserIdAndEdukimId(UserId, EduId);
            userEdukimEntity = _mapper.Map<UserEdukimPutDTO, UserEdukim>(eduDTO, userEdukimEntity);

            userEdukimRepository.Update(userEdukimEntity);
            _unitOfWork.Save();
            return _mapper.Map<UserEdukimDTOX>(userEdukimEntity);
        }

        public UserProjektDTOX UpdateUserProjekt(Guid UserId, Guid ProjektId, UserProjektPutDTO projektDTO)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (projektRepository.GetById(ProjektId) == null)
                throw new ArgumentException("Projekt does not exist");

            var userProjektEntity = userProjektRepository.GetByUserIdAndProjektId(UserId, ProjektId);
            userProjektEntity = _mapper.Map<UserProjektPutDTO, UserProjekt>(projektDTO, userProjektEntity);

            userProjektRepository.Update(userProjektEntity);
            _unitOfWork.Save();
            return _mapper.Map<UserProjektDTOX>(userProjektEntity);
        }

        public UserRoliDTOX UpdateUserRoli(Guid UserId, Guid RoliId, UserRoliPutDTO roliDTO)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (roliRepository.GetById(RoliId) == null)
                throw new ArgumentException("Roli does not exist");

            var userRoliEntity = userRoliRepository.GetByUserIdAndRoliId(UserId, RoliId);
            userRoliEntity = _mapper.Map<UserRoliPutDTO, UserRoli>(roliDTO, userRoliEntity);

            userRoliRepository.Update(userRoliEntity);
            _unitOfWork.Save();

            return _mapper.Map<UserRoliDTOX>(userRoliEntity);
        }
    }
}
