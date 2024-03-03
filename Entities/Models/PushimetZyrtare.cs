using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class PushimetZyrtare
    {
        public Guid PushimId { get; set; }
        public DateTime Dita { get; set; }
        public string? PershkrimiDita { get; set; }
    }
}
