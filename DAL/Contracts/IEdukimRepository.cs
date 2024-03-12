using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DAL.Contracts
{
    public interface IEdukimRepository : IRepository<Edukim, Guid>
    {
        Edukim GetById(Guid id);
    }
}
