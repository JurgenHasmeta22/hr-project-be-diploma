using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.EdukimDTO;
namespace DTO.UserDTO
{
    public class UserEdukimDTO
    {
        public double Mesatarja { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string? LlojiMaster { get; set; } = null!;

        public byte[]? DokumentDiplome { get; set; } = null!;


        public Guid UserId { get; set; }
        public Guid EduId { get; set; }
        public virtual EdukimDTO2 Edu { get; set; } = null!;

    }
}
