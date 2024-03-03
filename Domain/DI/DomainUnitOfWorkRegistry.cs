using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UoW;
using Lamar;

namespace Domain.DI
{
    public class DomainUnitOfWorkRegistry : ServiceRegistry
    {
        public DomainUnitOfWorkRegistry()
        {
            For<IDomainUnitOfWork>().Use<DomainUnitOfWork>();
        }
    }
}
