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
    internal class CertifikateRepository : BaseRepository<Certifikate, Guid>, ICertifikateRepository
    {
        public CertifikateRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public Certifikate GetbyId(Guid id)
        {
            var Certifikates = context
                .Include(x => x.UserCertifikates)
                .ThenInclude(x => x.User)
                .Where(x => x.CertId == id)
                .FirstOrDefault();
            return Certifikates;
        }
    }
}
