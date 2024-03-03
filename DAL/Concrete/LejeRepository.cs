using DAL.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class LejeRepository : BaseRepository<Leje, Guid>, ILejeRepository
    {
        public LejeRepository(HRDBContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Leje> GetAllLeje()
        {
            return context.Include(x => x.User).AsEnumerable();
        }

    }
}
