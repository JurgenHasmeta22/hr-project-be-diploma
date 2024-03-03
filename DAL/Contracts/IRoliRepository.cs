using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

	public interface IRoliRepository : IRepository<Roli, Guid> {
		Roli GetById(Guid id);  // given role id return role
		Guid GetRoleId(string roleName); // given role name return its id
		Roli GetByName(string roleName);    // given role name return role
		bool Contains(Guid id); // check if role exists
		ICollection<UserRoli> GetUsersOfRole(Guid roleId); // return mapping collection for role 
		IEnumerable<Roli> Paginate(int currentPage, int resultPerPage, int pageCnt);
	}
}
