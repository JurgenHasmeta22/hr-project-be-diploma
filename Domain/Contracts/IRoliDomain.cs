using DTO.RoleDTO;
using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts {
	public interface IRoliDomain {
		RoleDTO AddRole(PostPutRoleDTO roleDTO);
		IEnumerable<RoleDTO> GetAllRoles();
		RoleDTO GetRoleById(Guid id);
		RoleDTO GetRoleByName(string roleName);
		void RemoveRole(Guid id);
		void UpdateRole(Guid id, PostPutRoleDTO roleDTO);
		void AssignRoleToUser(UserRoleDTO userRoleDTO);
		IEnumerable<UserDTO> GetUsers(Guid roleId);
		IEnumerable<RoleDTO> GetRoles(Guid userId);
		RolePaginate Paginate(int page);
	}
}
