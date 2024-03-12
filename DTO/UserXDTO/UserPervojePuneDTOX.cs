using System;
using System.Collections.Generic;

namespace UserXDTO
{
    public class UserPervojePuneDTOX
    {
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string Pppozicion { get; set; } = null!;
        public string? Konfidencialiteti { get; set; }
        public string? PershkrimiPunes { get; set; }
        public Guid Ppid { get; set; }
        public Guid UserId { get; set; }
    }
}
