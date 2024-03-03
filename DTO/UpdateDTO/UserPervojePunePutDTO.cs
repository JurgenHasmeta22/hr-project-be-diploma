using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UpdateDTO
{
    public class UserPervojePunePutDTO
    {
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string Pppozicion { get; set; } = null!;
        public string? Konfidencialiteti { get; set; }
        public string? PershkrimiPunes { get; set; } = null!;

    }
}
