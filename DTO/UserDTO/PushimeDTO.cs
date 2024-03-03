using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class PushimeDTO
    {
    
        public DateTime Dita { get; set; }
        public string PershkrimiDita { get; set; } = null!;
        public Guid PushimId { get; set; }
    }

}
