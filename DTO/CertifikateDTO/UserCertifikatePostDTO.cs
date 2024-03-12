using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DTO.CertifikateDTO
{
    public class UserCertifikatePostDTO
    {
        public DateTime DataFituar { get; set; }
        public DateTime DataSkadence { get; set; }
        //public IFormFile DokumentCertifikate { get; set; } = null!;
    }
}
