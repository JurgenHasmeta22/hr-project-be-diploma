using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class UserPervojePuneDTO
    {
        public DateTime DataFillim { get; set; }
        public DateTime DataMbarim { get; set; }
        public string Pppozicion { get; set; } = null!;
        public string? Konfidencialiteti { get; set; }
        public string PershkrimiPunes { get; set; } = null!;
        public Guid Ppid { get; set; }
        public Guid UserId { get; set; }

        public virtual PervojePuneDTO1 Pp { get; set; } = null!;
       
    }
}
