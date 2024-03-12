using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EdukimDTO
{
    public class UserEdukimDTO1
    {
        public double Mesatarja { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string LlojiMaster { get; set; } = null!;

        // public byte[]? DokumentDiplome { get; set; } = null!;


        public Guid UserId { get; set; }
        public Guid EduId { get; set; }
        public virtual UserDTO1 User { get; set; } = null!;

    }
}
