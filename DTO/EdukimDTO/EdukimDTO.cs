using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EdukimDTO
{
    public class EdukimDTO
    {
        public Guid EduId { get; set; }
        public string EduName { get; set; } = null!;
        public virtual ICollection<UserEdukimDTO1> UserEdukims { get; set; } = null!;
    }
}
