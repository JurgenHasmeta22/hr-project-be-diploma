using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using Entities.Models;

namespace DAL.Concrete
{
    internal class UserEdukimRepository : BaseRepository<UserEdukim, Guid>, IUserEdukimRepository
    {
        public UserEdukimRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public UserEdukim GetByUserIdAndEdukimId(Guid userId, Guid eduId)
        {
            return context.Where(x => x.UserId == userId && x.EduId == eduId).FirstOrDefault();
        }
    }
}
