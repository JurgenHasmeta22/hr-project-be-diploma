using DTO.PervojePuneDTO;
using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts {
	public interface IPervojePuneDomain {
		PervojePuneDTO AddPervojePune(PostPutPPDTO ppDTO);
		IEnumerable<PervojePuneDTO> GetAllPervojePune();
		PervojePuneDTO GetPervojePune(Guid ppId);
		PervojePuneDTO GetPervojePune(string ppName);
		void RemovePervojePune(Guid ppId);
		void UpdatePervojePune(Guid ppId, PostPutPPDTO ppDTO);
		void AssignPPToUser(UserPPDTO userPPDTO);
		IEnumerable<PervojePuneDTO> GetPPs(Guid userId);
		IEnumerable<UserDTO> GetUsers(Guid ppId);
		PervojePunePaginate Paginate(int page);
	}
}
