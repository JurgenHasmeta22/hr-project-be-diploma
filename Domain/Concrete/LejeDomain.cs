using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class LejeDomain : DomainBase, ILejeDomain
    {
        public LejeDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private ILejeRepository lejeRepository => _unitOfWork.GetRepository<ILejeRepository>();
        private IUserRepository userRepository => _unitOfWork.GetRepository<IUserRepository>();

        public LejeDTO AddLeje(Guid UserId,LejePostDTO leje)
        {
            var lejeEntity = _mapper.Map<Leje>(leje);
            lejeEntity.LejeId = Guid.NewGuid();
            lejeEntity.UserId = UserId;

            var lejeFinal = lejeRepository.Add(lejeEntity);

            var lejeToReturn = _mapper.Map<LejeDTO>(lejeFinal);
            _unitOfWork.Save();
            return lejeToReturn;
        }

        public void DeleteLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            if (leje is null)
                throw new Exception();              

            lejeRepository.Remove(LejeId);
            _unitOfWork.Save();
        }

        public IList<LejeDTOwithUser> getAllLeje()
        {
            IEnumerable<Leje> lejet = lejeRepository.GetAllLeje();

            return _mapper.Map<IList<LejeDTOwithUser>>(lejet);
           
        }

        public LejeDTO GetLejeById(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            return _mapper.Map<LejeDTO>(leje);
        }

        public void PutLeje(Guid LejeId, LejePostDTO leje)
        {

            var lejeEntity = lejeRepository.GetById(LejeId);

            if (lejeEntity is null)
                throw new Exception();
            lejeEntity = _mapper.Map<LejePostDTO, Leje>(leje, lejeEntity);

            lejeRepository.Update(lejeEntity);
            _unitOfWork.Save();
        }
    }
}
