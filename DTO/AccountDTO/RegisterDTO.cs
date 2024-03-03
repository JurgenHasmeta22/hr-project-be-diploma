using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AccountDTO {
	public class RegisterDTO {
		public string UserName { get; set; } = null!;
		public string UserFirstname { get; set; } = null!;
		public string UserLastname { get; set; } = null!;
		public string UserEmail { get; set; } = null!;
		public IEnumerable<string> roles { get; set; }
		public string Password { get; set; } = null!;
	}
}
