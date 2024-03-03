using AutoMapper;
using DTO.AccountDTO;
using DTO.CertifikateDTO;
using DTO.EdukimDTO;
using DTO.PervojePuneDTO;
using DTO.RoleDTO;
using DTO.UpdateDTO;
using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserXDTO;
using UserCertifikateDTO = DTO.CertifikateDTO.UserCertifikateDTO;
using UserEdukimDTO = DTO.UserDTO.UserEdukimDTO;
using UserEdukimDTOED = DTO.EdukimDTO.UserEdukimDTO;
namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        #region User
        public GeneralProfile()
        {
            #region userDTO
            CreateMap<AppUser, UserDTO>().ReverseMap();
            #endregion

            CreateMap<Projekt, ProjektDTO>().ReverseMap();
            CreateMap<ProjektPostDTO, Projekt>().ReverseMap();
            CreateMap<UserProjekt, UserProjektDTO>().ReverseMap();
            CreateMap<UserProjekt, UserProjektPostDTO>().ReverseMap();
            CreateMap<Edukim, EdukimDTO>().ReverseMap();
            CreateMap<EdukimPostDTO, Edukim>().ReverseMap();
            CreateMap<UserEdukim, UserEdukimPostDTO>().ReverseMap();
            CreateMap<UserEdukim, UserEdukimDTO>().ReverseMap();
            CreateMap<UserEdukim, UserEdukimDTOED>().ReverseMap();
            CreateMap<Edukim, EdukimDTO2>().ReverseMap();
            CreateMap<Certifikate, DTO.UserDTO.AftesiPostDTO>().ReverseMap();

            CreateMap<Certifikate, CertifikateDTO>().ReverseMap();
            CreateMap<CertifikatePostDTO, Certifikate>().ReverseMap();

            CreateMap<UserCertifikate, UserCertifikateDTO>().ReverseMap();
            CreateMap<UserCertifikate, UserCertifikateDTOUser>().ReverseMap();

            CreateMap<UserCertifikate, UserCertifikatePostDTO>().ReverseMap();
            CreateMap<Certifikate, CertifikateDTO1>().ReverseMap();

            CreateMap<Roli, RoleDTO>().ReverseMap();
            CreateMap<PervojePune, PervojePuneDTO>().ReverseMap();
            CreateMap<UserPervojePune, UserPPDTO>().ReverseMap();
            CreateMap<PushimetZyrtare, PushimeDTO>().ReverseMap();
            CreateMap<PushimetZyrtare, PushimePostDTO>().ReverseMap();
            CreateMap<Leje, LejeDTO>().ReverseMap();
            CreateMap<Leje, LejePostDTO>().ReverseMap();
            CreateMap<UserRoli, UserRoliDTO>().ReverseMap();
            CreateMap<AppUser, UserPostDTO>().ReverseMap();
            CreateMap<Roli, RoliDTO>().ReverseMap();
            CreateMap<Projekt, Projekt1DTO>().ReverseMap();
            CreateMap<Edukim, EdukimDTO1>().ReverseMap();


            CreateMap<Aftesi, AftesiDTO>().ReverseMap();
            CreateMap<Aftesi, AftesiPostDTO>().ReverseMap();

            CreateMap<UserAftesi, UserAftesiPostDTO>().ReverseMap();
            CreateMap<UserAftesi, UserAftesiDTO>().ReverseMap();


            CreateMap<UserProjekt, UserProjekt1DTO>().ReverseMap();
            CreateMap<UserEdukim, UserEdukimDTO1>().ReverseMap();
            CreateMap<UserAftesi, UserAftesiDTO>().ReverseMap();
            CreateMap<UserCertifikate, UserCertifikateDTO1>().ReverseMap();
            CreateMap<UserPervojePune, UserPervojePuneDTO>().ReverseMap();
            CreateMap<DetajeUser, DetajeUserDTO>().ReverseMap();
            //CreateMap<DokumentaDetajeUser, DokumentaDetajeUserDTO>().ReverseMap();
            CreateMap<PervojePune, PervojePuneDTO1>().ReverseMap();
            CreateMap<AppUser, UserDTO1>().ReverseMap();
            
            CreateMap<Leje, LejeDTOwithUser>().ReverseMap();

            CreateMap<UserAftesi, UserAftesiPutDTO>().ReverseMap();
            CreateMap<UserEdukim, UserEdukimPutDTO>().ReverseMap();
            CreateMap<UserRoli, UserRoliPutDTO>().ReverseMap();
            CreateMap<UserCertifikate, UserCertifikatePutDTO>().ReverseMap();
            CreateMap<UserPervojePune, UserPervojePunePutDTO>().ReverseMap();
            CreateMap<UserProjekt, UserProjektPutDTO>().ReverseMap();



            CreateMap<UserRoli, UserRoleDTO>().ReverseMap();
            CreateMap<RegisterDTO, AppUser>().ReverseMap();
            CreateMap<PostPutPPDTO, PervojePune>().ReverseMap();
            CreateMap<PostPutRoleDTO, Roli>().ReverseMap();


            CreateMap<UserEdukimDTOX, UserEdukim>().ReverseMap();
            CreateMap<UserAftesiDTOX, UserAftesi>().ReverseMap();
            CreateMap<UserCertifikateDTOX, UserCertifikate>().ReverseMap();
            CreateMap<UserRoliDTOX, UserRoli>().ReverseMap();
            CreateMap<UserProjektDTOX, UserProjekt>().ReverseMap();
            CreateMap<UserPervojePuneDTOX, UserPervojePune>().ReverseMap();


        }

        #endregion


    }
}
