using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using Entities.Models;

namespace DAL.Concrete
{
    internal class PushimetZyrtareRepository : BaseRepository<PushimetZyrtare, Guid>, IPushimetZyrtareRepository
    {
        public PushimetZyrtareRepository(HRDBContext dbContext)
            : base(dbContext) { }

        public PushimetZyrtare GetByDate(DateTime date)
        {
            return context.Where(x => x.Dita == date).FirstOrDefault();
        }
    }
}
