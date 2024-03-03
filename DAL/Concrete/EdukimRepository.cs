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
    internal class EdukimRepository:BaseRepository<Edukim,Guid>,IEdukimRepository
    {
        public EdukimRepository(HRDBContext dbContext) : base(dbContext)
        { }
            public Edukim GetById(Guid id)
            {
                var Edukim = context.Include(x => x.UserEdukims).ThenInclude(x => x.User).Where(x => x.EduId == id).FirstOrDefault();
                return Edukim;
            }

        
    }
}
