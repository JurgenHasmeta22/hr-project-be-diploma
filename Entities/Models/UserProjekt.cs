using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserProjekt
    {
        public DateTime? DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjektId { get; set; }

        public virtual Projekt Projekt { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
