using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EdukimDTO
{
    public class UserEdukimPostDTO
    {
        public double Mesatarja { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string LlojiMaster { get; set; } = null!;
        // public byte[]? DokumentDiplome { get; set; }
    }
}
