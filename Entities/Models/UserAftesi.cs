using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserAftesi
    {
        public Guid UserId { get; set; }
        public Guid AftesiId { get; set; }
        public DateTime? DataPerfitimit { get; set; }

        public virtual Aftesi Aftesi { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
