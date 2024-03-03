using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserEdukim
    {
        public double Mesatarja { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string? LlojiMaster { get; set; } = null!;
        public byte[]? DokumentDiplome { get; set; }
        public Guid UserId { get; set; }
        public Guid EduId { get; set; }

        public virtual Edukim Edu { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
