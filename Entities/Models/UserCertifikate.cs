using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserCertifikate
    {
        public DateTime? DataFituar { get; set; }
        public DateTime? DataSkadence { get; set; }
        public Guid UserId { get; set; }
        public Guid CertId { get; set; }
        public byte[]? DokumentCertifikate { get; set; }

        public virtual Certifikate Cert { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
