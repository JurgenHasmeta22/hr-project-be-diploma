using System;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IProjektRepository:IRepository<Projekt, Guid>
    {

        
        Projekt GetById(Guid id);

    }
}
