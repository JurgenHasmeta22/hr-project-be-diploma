using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.CertifikateDTO;
using DTO.EdukimDTO;
using Entities.Models;

namespace DTO.UserDTO
{
    public class UserDTO
    {
        // mos fshi gje se prish mappimet

        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserFirstname { get; set; } = null!;
        public string UserLastname { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int BalancaLeje { get; set; }
        public bool UserIsActive { get; set; }

        public virtual ICollection<DetajeUserDTO> DetajeUsers { get; set; } = null!;
        public virtual ICollection<LejeDTO> Lejes { get; set; } = null!;
        public virtual ICollection<UserAftesiDTO> UserAftesis { get; set; } = null!;
        public virtual ICollection<UserCertifikateDTOUser> UserCertifikates { get; set; } = null!;
        public virtual ICollection<UserEdukimDTO> UserEdukims { get; set; } = null!;
        public virtual ICollection<UserPervojePuneDTO> UserPervojePunes { get; set; } = null!;
        public virtual ICollection<UserProjektDTO> UserProjekts { get; set; } = null!;
        public virtual ICollection<UserRoliDTO> UserRolis { get; set; } = null!;
    }
}
