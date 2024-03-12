using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.PervojePuneDTO
{
    public class PervojePunePaginate
    {
        public IEnumerable<PervojePuneDTO> list { get; set; }
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
