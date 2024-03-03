using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class DetajeUserRepository : BaseRepository<DetajeUser, Guid>, IDetajeUserRepository
    {

        public DetajeUserRepository(HRDBContext dbContext) : base(dbContext)
        {
        }

        


    }


}
