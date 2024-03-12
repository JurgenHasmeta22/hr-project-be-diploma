using System;
using System.Collections.Generic;

namespace UserXDTO
{
    public class UserCertifikateDTOX
    {
        public DateTime? DataFituar { get; set; }
        public DateTime? DataSkadence { get; set; }
        public Guid UserId { get; set; }
        public Guid CertId { get; set; }
        public byte[]? DokumentCertifikate { get; set; }
    }
}
