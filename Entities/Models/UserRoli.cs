using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserRoli
    {
        public Guid UserId { get; set; }
        public Guid RoliId { get; set; }
        public DateTime? DataCaktimit { get; set; }

        public virtual Roli Roli { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
