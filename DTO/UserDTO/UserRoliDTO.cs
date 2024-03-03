using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class UserRoliDTO
    {
        public Guid UserId { get; set; }
        public Guid RoliId { get; set; }
        public DateTime? DataCaktimit { get; set; }
        public virtual RoliDTO Roli { get; set; } = null!;

    }
}
