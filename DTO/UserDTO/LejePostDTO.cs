using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class LejePostDTO
    {
        //public Guid LejeId { get; set; }
        public DateTime DataFillim { get; set; }
        public DateTime DataMbarim { get; set; }
        public string TipiLeje { get; set; } = null!;
        
       
        

        
    }
}
