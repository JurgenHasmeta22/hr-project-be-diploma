using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Leje
    {
        public Guid LejeId { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime DataMbarim { get; set; }
        public string TipiLeje { get; set; } = null!;
        public Guid UserId { get; set; }
        public int? Aprovuar { get; set; }

        public virtual AppUser User { get; set; } = null!;
    }
}
