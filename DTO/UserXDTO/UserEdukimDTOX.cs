using System;
using System.Collections.Generic;

namespace UserXDTO
{
    public class UserEdukimDTOX
    {
        public double Mesatarja { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataMbarim { get; set; }
        public string? LlojiMaster { get; set; } = null!;
        public byte[]? DokumentDiplome { get; set; }
        public Guid UserId { get; set; }
        public Guid EduId { get; set; }
    }
}
