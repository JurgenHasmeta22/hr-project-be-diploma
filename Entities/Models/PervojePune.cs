using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class PervojePune
    {
        public PervojePune()
        {
            UserPervojePunes = new HashSet<UserPervojePune>();
        }

        public Guid Ppid { get; set; }
        public string Ppemri { get; set; } = null!;

        public virtual ICollection<UserPervojePune> UserPervojePunes { get; set; }
    }
}
