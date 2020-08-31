using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataAccess;
using TestService.Implementations;
using TestService.Interfaces;
using TestUnitOfWork;

namespace ConsoleUINetFramework.Infraestructure
{
    public class ConfigurationInstallerFacade : IWindsorInstaller
    {
        private readonly string _bdConString;
        public ConfigurationInstallerFacade(string bdConString)
        {
            if (string.IsNullOrEmpty(bdConString))
            {
                throw new Exception("No se puede inicializar este contenedor sin una cadena de conexion de base de datos");
            }
            _bdConString = bdConString;
        }
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>()
                                    .ImplementedBy<UnitOfWork>()
                                    .DependsOn(Dependency.OnValue("connection", _bdConString)));

            container.Register(Component.For<ITestLogic>().ImplementedBy<TestLogic>());
        }
    }
}
