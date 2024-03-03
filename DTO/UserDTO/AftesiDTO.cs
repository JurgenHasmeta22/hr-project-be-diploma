using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class AftesiDTO
    {
        public Guid AftesiId { get; set; }
        public string LlojiAftesise { get; set; } = null!;
    }
}
