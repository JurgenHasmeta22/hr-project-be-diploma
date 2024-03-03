using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Aftesi
    {
        public Aftesi()
        {
            UserAftesis = new HashSet<UserAftesi>();
        }

        public Guid AftesiId { get; set; }
        public string LlojiAftesise { get; set; } = null!;

        public virtual ICollection<UserAftesi> UserAftesis { get; set; }
    }
}
