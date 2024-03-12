using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class ProjektDTO
    {
        public Guid ProjektId { get; set; }
        public string EmriProjekt { get; set; } = null!;
        public string PershkrimProjekt { get; set; } = null!;
        public virtual ICollection<UserProjekt1DTO> UserProjekts { get; set; } = null!;
    }
}
