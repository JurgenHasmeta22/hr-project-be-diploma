using Entities.Models;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class AftesiRepository : BaseRepository<Aftesi, Guid>, IAftesiRepository
    {

        public AftesiRepository( HRDBContext dbContext) : base(dbContext)
        {
        }
        public Aftesi GetById(Guid id)
        {
            var Aftesi = context.Include(x => x.UserAftesis).ThenInclude(x => x.User).Where(x => x.AftesiId == id).FirstOrDefault();
            return Aftesi;
        }

    }

}
