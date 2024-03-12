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
    internal class UserRepository : BaseRepository<AppUser, Guid>, IUserRepository
    {
        public UserRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public AppUser GetById1(Guid id)
        {
            return context.Where(x => x.UserId == id).FirstOrDefault();
        }

        public AppUser GetById(Guid id)
        {
            return context
                .Include(x => x.UserProjekts)
                .ThenInclude(x => x.Projekt)
                .Include(x => x.UserRolis)
                .ThenInclude(x => x.Roli)
                .Include(x => x.UserPervojePunes)
                .ThenInclude(x => x.Pp)
                .Include(x => x.UserEdukims)
                .ThenInclude(x => x.Edu)
                .Include(x => x.UserCertifikates)
                .ThenInclude(x => x.Cert)
                .Include(x => x.UserAftesis)
                .ThenInclude(x => x.Aftesi)
                .Include(x => x.Lejes)
                // .ThenInclude(x => x.Le)
                .Include(x => x.DetajeUsers)
                //.ThenInclude(x => x.)
                .Where(x => x.UserId == id)
                .FirstOrDefault();
        }

        public AppUser GetByUserName(string username)
        {
            var user = context.Where(x => x.UserName == username).FirstOrDefault();
            return user;
        }

        public bool IsRegistered(Guid id)
        { // check if user exists in context
            if (context.Contains<AppUser>(GetById(id)))
                return true;
            return false;
        }

        public IEnumerable<AppUser> getAllusers()
        {
            return context.Where(x => x.UserIsActive == true);
        }

        public ICollection<UserRoli> GetRolesOfUser(Guid userId)
        {
            var user = GetById(userId);

            // prohibit referenceException
            if (user == null)
                return null;

            var mapping = user.UserRolis;
            return mapping;
        }

        public ICollection<UserPervojePune> GetPPOfUser(Guid userId)
        {
            var user = GetById(userId);

            // prohibit referenceException
            if (user == null)
                return null;

            var mapping = user.UserPervojePunes;
            return mapping;
        }
    }
}
