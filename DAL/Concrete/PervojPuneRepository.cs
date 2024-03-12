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
    internal class PervojPuneRepository : BaseRepository<PervojePune, Guid>, IPervojPuneRepository
    {

#pragma warning disable CS8603 // Possible null reference return.

        public PervojPuneRepository(HRDBContext dbContext) : base(dbContext)
        {
        }

        public override PervojePune GetById(Guid PPId)
        {
            var workExp = context.Include(x => x.UserPervojePunes).ThenInclude(x => x.User).Where(x => x.Ppid == PPId).FirstOrDefault();
            return workExp;
        }

        public PervojePune GetByName(string PPName)
        {
            var workExp = context.Where(x => x.Ppemri == PPName).FirstOrDefault();
            return workExp;
        }

        public bool Contains(Guid PPId)
        {
            if (context.Contains<PervojePune>(GetById(PPId)))
                return true;
            return false;
        }

        public ICollection<UserPervojePune> GetUsersOfPP(Guid ppId)
        {
            var role = GetById(ppId);

            // prohibit referenceException
            if (role == null)
                return null;

            var mapping = role.UserPervojePunes;
            return mapping;
        }

        public IEnumerable<PervojePune> Paginate(int currentPage, int resultPerPage, int pageCnt)
        {
            var list = context.Skip((currentPage - 1) * resultPerPage)
                .Take(resultPerPage)
                .ToList();
            return list.AsEnumerable();
        }
    }
}