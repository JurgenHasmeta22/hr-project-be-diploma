using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUserPervojePuneRepository : IRepository<UserPervojePune, Guid>
    {
        public UserPervojePune GetByUserIdAndPPId(Guid userId, Guid ppId);
    }
}
