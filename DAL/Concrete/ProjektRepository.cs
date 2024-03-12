using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class ProjektRepository : BaseRepository<Projekt, Guid>, IProjektRepository
    {
        public ProjektRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public Projekt GetById(Guid id)
        {
            var project = context
                .Include(x => x.UserProjekts)
                .ThenInclude(x => x.User)
                .Where(x => x.ProjektId == id)
                .FirstOrDefault();
            return project;
        }
    }
}
