using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            DetajeUsers = new HashSet<DetajeUser>();
            Lejes = new HashSet<Leje>();
            UserAftesis = new HashSet<UserAftesi>();
            UserCertifikates = new HashSet<UserCertifikate>();
            UserEdukims = new HashSet<UserEdukim>();
            UserPervojePunes = new HashSet<UserPervojePune>();
            UserProjekts = new HashSet<UserProjekt>();
            UserRolis = new HashSet<UserRoli>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserFirstname { get; set; } = null!;
        public string UserLastname { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int BalancaLeje { get; set; }
        public bool UserIsActive { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public virtual ICollection<DetajeUser> DetajeUsers { get; set; }
        public virtual ICollection<Leje> Lejes { get; set; }
        public virtual ICollection<UserAftesi> UserAftesis { get; set; }
        public virtual ICollection<UserCertifikate> UserCertifikates { get; set; }
        public virtual ICollection<UserEdukim> UserEdukims { get; set; }
        public virtual ICollection<UserPervojePune> UserPervojePunes { get; set; }
        public virtual ICollection<UserProjekt> UserProjekts { get; set; }
        public virtual ICollection<UserRoli> UserRolis { get; set; }
    }
}
