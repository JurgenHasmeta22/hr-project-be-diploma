using AutoMapper;
using DAL.UoW;
using Domain.Contracts;
using DTO.DokumentDto;
using DTO.UserDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class UserDokumentDomain : DomainBase, IUserDokumentDomain
    {
        public UserDokumentDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public void AddUserDokument(Guid UserId, Guid Duid, DokumentPostDTO dokument)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DokumentDTO> GetDokumentbyUserId(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetUsersByDokument(Guid Duid)
        {
            throw new NotImplementedException();
        }
    }
}
