using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AccountDTO {
	public class TokenDTO {
		public string Username { get; set; } = null!;
		public string Token { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
