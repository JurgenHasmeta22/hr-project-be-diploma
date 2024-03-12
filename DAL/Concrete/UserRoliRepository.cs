using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using Entities.Models;

namespace DAL.Concrete
{
    internal class UserRoliRepository : BaseRepository<UserRoli, Guid>, IUserRoliRepository
    {
        public UserRoliRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public UserRoli GetByUserIdAndRoliId(Guid userId, Guid roliId)
        {
            return context.Where(x => x.UserId == userId && x.RoliId == roliId).FirstOrDefault();
        }
    }
}
