using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AccountDTO {
	public class PasswordChangeDTO {
		public Guid UserId { get; set; }
		public string oldPassword { get; set; }
		public string newPassword { get; set; }
		public string confirmNewPassword { get; set; }
	}
}
