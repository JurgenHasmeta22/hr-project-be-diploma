using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
using DAL.Contracts;
using Lamar;

namespace DAL.DI
{
    public class RepositoryRegistry : ServiceRegistry
    {
        public RepositoryRegistry()
        {
            IncludeRegistry<UnitOfWorkRegistry>();

            For<IUserRepository>().Use<UserRepository>();
            For<IAftesiRepository>().Use<AftesiRepository>();
            For<ICertifikateRepository>().Use<CertifikateRepository>();
            For<IDetajeUserRepository>().Use<DetajeUserRepository>();

            For<IEdukimRepository>().Use<EdukimRepository>();
            For<ILejeRepository>().Use<LejeRepository>();
            For<IPervojPuneRepository>().Use<PervojPuneRepository>();
            For<IProjektRepository>().Use<ProjektRepository>();
            For<IRoliRepository>().Use<RoliRepository>();

            For<IUserAftesiRepository>().Use<UserAftesiRepository>();
            For<IUserCertifikateRepository>().Use<UserCertifikateRepository>();
            For<IUserRoliRepository>().Use<UserRoliRepository>();
            For<IUserEdukimRepository>().Use<UserEdukimRepository>();
            For<IUserPervojePuneRepository>().Use<UserPervojePuneRepository>();
            For<IUserProjektRepository>().Use<UserProjektRepository>();

            For<IPushimetZyrtareRepository>().Use<PushimetZyrtareRepository>();
        }
    }
}
