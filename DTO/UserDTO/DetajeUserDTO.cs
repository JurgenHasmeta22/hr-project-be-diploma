using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class DetajeUserDTO
    {
        public Guid Duid { get; set; }
        public int? GrupiPunes { get; set; }
        public string? PunaCaktuarNeGrup { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime? DataLargim { get; set; }
        public string? ArsyeLargim { get; set; }
        public byte[]? FotoProfili { get; set; }
        public string Adresa { get; set; } = null!;
        public string NumerTelefoni { get; set; } = null!;
        public string? PershkrimiVetes { get; set; }
        public Guid UserId { get; set; }
    }
}
