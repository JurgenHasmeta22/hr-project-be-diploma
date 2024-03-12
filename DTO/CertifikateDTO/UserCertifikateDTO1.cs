using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.UserDTO;

namespace DTO.CertifikateDTO
{
    public class UserCertifikateDTO1
    {
        public DateTime DataFituar { get; set; }
        public DateTime DataSkadence { get; set; }

        // public IFormFile DokumentCertifikate { get; set; } = null!;

        public Guid UserId { get; set; }
        public Guid CertId { get; set; }
        public virtual UserDTO1 User { get; set; } = null!;
    }
}
