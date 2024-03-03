using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Projekt
    {
        public Projekt()
        {
            UserProjekts = new HashSet<UserProjekt>();
        }

        public Guid ProjektId { get; set; }
        public string EmriProjekt { get; set; } = null!;
        public string PershkrimProjekt { get; set; } = null!;

        public virtual ICollection<UserProjekt> UserProjekts { get; set; }
    }
}
