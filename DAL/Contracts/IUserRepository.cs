using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUserRepository : IRepository<AppUser, Guid>
    {
        AppUser GetById(Guid id);
        AppUser GetById1(Guid id);
        AppUser GetByUserName(string username);
        bool IsRegistered(Guid id);
        IEnumerable<AppUser> getAllusers();
        ICollection<UserRoli> GetRolesOfUser(Guid userId);
        ICollection<UserPervojePune> GetPPOfUser(Guid userId);

    }

    namespace DAL.Contracts
    {
        public interface IUserRepository : IRepository<AppUser, Guid>
        {
            AppUser GetById(Guid id);
            AppUser GetByUserName(string username);
            bool IsRegistered(Guid id);
           // ICollection<UserRoli> GetRolesOfUser(Guid userId);
          //  ICollection<UserPervojePune> GetPPOfUser(Guid userId);
        }
    }
}
