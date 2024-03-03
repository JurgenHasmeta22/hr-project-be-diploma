using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Roli
    {
        public Roli()
        {
            UserRolis = new HashSet<UserRoli>();
        }

        public Guid RoliId { get; set; }
        public string RoliEmri { get; set; } = null!;
        public string RoliPershkrim { get; set; } = null!;

        public virtual ICollection<UserRoli> UserRolis { get; set; }
    }
}
