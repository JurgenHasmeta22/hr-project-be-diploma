using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using DTO.UserDTO;

namespace DTO.CertifikateDTO
{
    public class UserCertifikateDTO
    {
        public DateTime DataFituar { get; set; }
        public DateTime DataSkadence { get; set; }
        public IFormFile DokumentCertifikate { get; set; } = null!;

        public Guid UserId { get; set; }
        public Guid CertId { get; set; }

        public virtual CertifikateDTO1 Certifikate { get; set; } = null!;
    }
}
