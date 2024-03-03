using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class UserProjektDTO
    {
        public DateTime? DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjektId { get; set; }
        public virtual Projekt1DTO Projekt { get; set; } = null!;
        
    }
}
