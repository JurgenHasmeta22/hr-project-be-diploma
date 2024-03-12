using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DAL.Contracts
{
    public interface IUserCertifikateRepository : IRepository<UserCertifikate, Guid>
    {
        public UserCertifikate GetByUserIdAndCertifikateId(Guid userId, Guid certId);
    }
}
