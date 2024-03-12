using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using Entities.Models;

namespace DAL.Concrete
{
    internal class UserCertifikateRepository : BaseRepository<UserCertifikate, Guid>, IUserCertifikateRepository
    {
        public UserCertifikateRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public UserCertifikate GetByUserIdAndCertifikateId(Guid userId, Guid certId)
        {
            return context.Where(x => x.UserId == userId && x.CertId == certId).FirstOrDefault();
        }
    }
}
