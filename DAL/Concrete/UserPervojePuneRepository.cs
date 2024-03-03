using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserPervojePuneRepository : BaseRepository<UserPervojePune, Guid>, IUserPervojePuneRepository
    {

        public UserPervojePuneRepository(HRDBContext dbContext) : base(dbContext)
        {
        }

        public UserPervojePune GetByUserIdAndPPId(Guid userId, Guid PPId)
        {
            return context.Where(x => x.UserId == userId && x.Ppid == PPId).FirstOrDefault();
        }


    }


}
