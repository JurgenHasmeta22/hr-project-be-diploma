using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DAL.Contracts
{
    public interface IUserRoliRepository : IRepository<UserRoli, Guid>
    {
        public UserRoli GetByUserIdAndRoliId(Guid userId, Guid roliId);
    }
}
