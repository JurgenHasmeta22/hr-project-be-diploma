using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DokumentDto
{
    public  class DokumentDTO
    {
        public Guid DokumentId { get; set; }
        public Guid Duid { get; set; }
        public byte[] Dokument { get; set; } = null!;

    }
}
