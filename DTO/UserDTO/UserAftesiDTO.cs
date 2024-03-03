using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
namespace DTO.UserDTO
{
    public class UserAftesiDTO
    {
        public Guid UserId { get; set; }
        public Guid AftesiId { get; set; }
        public DateTime? DataPerfitimit { get; set; }

        public virtual AftesiDTO Aftesi { get; set; } = null!;
    }
}
