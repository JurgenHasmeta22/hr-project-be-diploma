using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
namespace DTO.UserDTO
{
    public class DokumentaDetajeUserDTO
    {
        public Guid DokumentId { get; set; }
        public Guid Duid { get; set; }
        public byte[] Dokument { get; set; } = null!;
    }
}
