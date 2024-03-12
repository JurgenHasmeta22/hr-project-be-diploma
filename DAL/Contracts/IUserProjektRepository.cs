using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DAL.Contracts
{
    public interface IUserProjektRepository : IRepository<UserProjekt, Guid>
    {
        public UserProjekt GetByUserIdAndProjektId(Guid userId, Guid projektId);
    }
}
