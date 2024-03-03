using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Certifikate
    {
        public Certifikate()
        {
            UserCertifikates = new HashSet<UserCertifikate>();
        }

        public Guid CertId { get; set; }
        public string CertEmri { get; set; } = null!;
        public string CertPershkrim { get; set; } = null!;

        public virtual ICollection<UserCertifikate> UserCertifikates { get; set; }
    }
}
