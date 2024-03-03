using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class UserProjekt1DTO
    {
        public DateTime? DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjektId { get; set; }
        public virtual UserDTO1 User { get; set; } = null!;
    }
}
