using System;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IAftesiRepository : IRepository <Aftesi, Guid>
    {
        Aftesi GetById(Guid id);
    }
    
}
