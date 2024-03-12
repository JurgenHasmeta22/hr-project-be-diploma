using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.CertifikateDTO;

namespace DTO.UserDTO
{
    public class CertifikateDTO
    {
        [Required(ErrorMessage = "Please Enter Certifikate Id")]
        [Display(Name = "Certifikate Id")]
        public Guid CertId { get; set; }

        [Display(Name = "Emri i Certifikates")]
        public string CertEmri { get; set; } = null!;

        [Display(Name = "Pershkrimi i Certifikates")]
        public string CertPershkrim { get; set; } = null!;
        public virtual ICollection<UserCertifikateDTO1> Usercertifikates { get; set; } = null!;
    }
}
