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
    internal class RoliRepository : BaseRepository<Roli, Guid>, IRoliRepository
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.

        public RoliRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public override Roli GetById(Guid id)
        {
            var role = context
                .Include(x => x.UserRolis)
                .ThenInclude(x => x.User)
                .Where(x => x.RoliId == id)
                .FirstOrDefault();
            return role;
        }

        public Roli GetByName(string roleName)
        {
            var role = context.Where(x => x.RoliEmri == roleName).FirstOrDefault();
            return role;
        }

        public Guid GetRoleId(string roleName)
        {
            var role = context.Where(x => x.RoliEmri == roleName).FirstOrDefault();
            return role.RoliId;
        }

        public bool Contains(Guid id)
        {
            if (context.Contains<Roli>(GetById(id)))
                return true;
            return false;
        }

        public ICollection<UserRoli> GetUsersOfRole(Guid roleId)
        {
            var role = GetById(roleId);

            // prohibit referenceException
            if (role == null)
                return null;

            var mapping = role.UserRolis;
            return mapping;
        }

        public IEnumerable<Roli> Paginate(int currentPage, int resultPerPage, int pageCnt)
        {
            var list = context.Skip((currentPage - 1) * resultPerPage).Take(resultPerPage).ToList();
            return list.AsEnumerable();
        }
    }
}
