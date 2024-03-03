using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts {

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

	public interface IPervojPuneRepository : IRepository<PervojePune, Guid> {
		PervojePune GetById(Guid PPId);     // find by id
		PervojePune GetByName(string PPName);	// find entity by name
		bool Contains(Guid PPId);       // check if entity exists
		ICollection<UserPervojePune> GetUsersOfPP(Guid ppId);
		IEnumerable<PervojePune> Paginate(int currentPage, int resultPerPage, int pageCnt);
	}
}