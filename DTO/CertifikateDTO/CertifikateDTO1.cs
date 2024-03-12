using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CertifikateDTO
{
    public class CertifikateDTO1
    {
        public Guid CertId { get; set; }
        public string CertEmri { get; set; } = null!;
        public string CertPershkrim { get; set; } = null!;
    }
}
