using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DI;
using Domain.Concrete;
using Domain.Contracts;
using Lamar;
using Microsoft.AspNetCore.Http;

namespace Domain.DI
{
    public class DomainRegistry : ServiceRegistry
    {
        public DomainRegistry()
        {
            IncludeRegistry<DomainUnitOfWorkRegistry>();

            For<IUserDomain>().Use<UserDomain>();
            For<IProjektDomain>().Use<ProjektDomain>();

            For<IEdukimDomain>().Use<EdukimDomain>();
            For<ICertifikateDomain>().Use<CertifikateDomain>();
            For<IAftesiDomain>().Use<AftesiDomain>();
            For<IAccountDomain>().Use<AccountDomain>();
            For<ITokenService>().Use<TokenService>();
            For<IRoliDomain>().Use<RoliDomain>();
            For<IPervojePuneDomain>().Use<PervojePuneDomain>();
            //  For<IUserPervojePuneDomain>().Use<UserPervojePuneDomain>();
            For<IPushimetZyrtareDomain>()
                .Use<PushimetZyrtareDomain>();
            For<ILejeDomain>().Use<LejeDomain>();

            AddRepositoryRegistries();
            AddHttpContextRegistries();
        }

        private void AddRepositoryRegistries()
        {
            IncludeRegistry<RepositoryRegistry>();
        }

        private void AddHttpContextRegistries()
        {
            For<IHttpContextAccessor>().Use<HttpContextAccessor>();
        }
    }
}
