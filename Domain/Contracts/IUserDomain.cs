using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.CertifikateDTO;
using DTO.EdukimDTO;
using DTO.UpdateDTO;
using DTO.UserDTO;
using Entities.Models;
using UserXDTO;

namespace Domain.Contracts
{
    public interface IUserDomain
    {
        IList<UserDTO1> GetAllUsers();

        UserDTO GetUserById(Guid id);
        UserDTO PutUser(Guid UserId, UserPostDTO user);
        void AddUserProject(Guid UserId, Guid ProjektId, UserProjektPostDTO userprojekt);
        void DeleteUserProject(Guid UserId, Guid ProjektId);

        // LejeDTOwithUser AddLeje(Guid UserId, LejePostDTO leje);
        bool KerkoLeje(Guid UserId, LejePostDTO leje);
        void DeleteLeje(Guid UserId);
        void AddUserEdukim(Guid UserId, Guid eduId, UserEdukimPostDTO useredukim);
        void DeleteUserEdukim(Guid UserId, Guid eduId);
        void AddUserCertifikate(Guid UserId, Guid CertId, UserCertifikatePostDTO userCertifikate);
        void DeleteUserCertifikate(Guid UserId, Guid CertId);
        void UpdateLeje(Guid UserId, LejePostDTO leje);
        public void UpdateBalance(Guid userId);
        public int KontrolloLejen(Leje leje);
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru);
        void ApproveLeje(Guid LejeId);
        void DisapproveLeje(Guid LejeId);

        void AddUserAftesi(Guid UserId, Guid aftesiId, UserAftesiPostDTO useraftesi);
        void DeleteUserAftesi(Guid UserId, Guid aftesiId);
        void DeleteUserPervojePune(Guid UserId, Guid PPId);

        UserPervojePuneDTOX UpdateUserPervojePune(Guid UserId, Guid PPId, UserPervojePunePutDTO ppDTO);
        UserAftesiDTOX UpdateUserAftesi(Guid UserId, Guid AftesiId, UserAftesiPutDTO aftesiDTO);
        UserCertifikateDTOX UpdateUserCertifikate(Guid UserId, Guid CertId, UserCertifikatePutDTO certDTO);
        UserEdukimDTOX UpdateUserEdukim(Guid UserId, Guid EduId, UserEdukimPutDTO eduDTO);
        UserProjektDTOX UpdateUserProjekt(Guid UserId, Guid ProjektId, UserProjektPutDTO projektDTO);
        UserRoliDTOX UpdateUserRoli(Guid UserId, Guid RoliId, UserRoliPutDTO roliDTO);

        // IList<UserDTO1> GetAllUsers1();
    }
}
