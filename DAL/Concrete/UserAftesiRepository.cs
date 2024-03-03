using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserAftesiRepository : BaseRepository<UserAftesi, Guid>, IUserAftesiRepository
    {

        public UserAftesiRepository(HRDBContext dbContext) : base(dbContext)
        {
        }
        public UserAftesi GetByUserIdAndAftesiId(Guid userId, Guid aftesiId)
        {
          return context.Where(x => x.UserId == userId && x.AftesiId == aftesiId).FirstOrDefault();
        }
 }}




    



