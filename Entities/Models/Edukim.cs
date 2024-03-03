using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Edukim
    {
        public Edukim()
        {
            UserEdukims = new HashSet<UserEdukim>();
        }

        public Guid EduId { get; set; }
        public string EduName { get; set; } = null!;

        public virtual ICollection<UserEdukim> UserEdukims { get; set; }
    }
}
