using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserPervojePune
    {
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string Pppozicion { get; set; } = null!;
        public string? Konfidencialiteti { get; set; }
        public string? PershkrimiPunes { get; set; }
        public Guid Ppid { get; set; }
        public Guid UserId { get; set; }

        public virtual PervojePune Pp { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
