using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.UserDTO
{
    public class Projekt1DTO
    {
        public Guid ProjektId { get; set; }
        public string EmriProjekt { get; set; } = null!;
        public string PershkrimProjekt { get; set; } = null!;
       
    }
}
