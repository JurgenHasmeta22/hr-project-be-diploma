using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserProjektRepository : BaseRepository<UserProjekt, Guid>, IUserProjektRepository
    {

        public UserProjektRepository(HRDBContext dbContext) : base(dbContext)
        {
        }

        public UserProjekt GetByUserIdAndProjektId(Guid userId, Guid projektId)
        {
            return context.Where(x => x.UserId == userId && x.ProjektId == projektId).FirstOrDefault();
        }


    }


}
