using DTO.DokumentDto;
using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public  interface IUserDokumentDomain
    {
        void AddUserDokument(Guid UserId, Guid Duid, DokumentPostDTO dokument);

        IEnumerable<DokumentDTO> GetDokumentbyUserId(Guid UserId);

        IEnumerable<UserDTO> GetUsersByDokument(Guid Duid);
    }
}
