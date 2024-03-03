using DTO.AccountDTO;
using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts {
	public interface IAccountDomain {
		TokenDTO Register(RegisterDTO registerDTO);
		TokenDTO Login(LoginDTO loginDTO);
		void ChangePassword(PasswordChangeDTO passwordChangeDTO);
	}
}
