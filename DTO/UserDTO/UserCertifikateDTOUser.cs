using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using DTO.UserDTO;
using DTO.CertifikateDTO;

namespace DTO.UserDTO
{
    public class UserCertifikateDTOUser
    {
        public DateTime? DataFituar { get; set; }
        public DateTime? DataSkadence { get; set; }
        public byte[]? DokumentCertifikate { get; set; }

        public Guid UserId { get; set; }
        public Guid CertId { get; set; }

        public virtual CertifikateDTO1 Cert { get; set; } = null!;
    }
}

