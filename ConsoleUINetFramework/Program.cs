using System;
using System.Configuration;
using TestInfraestructure;
using TestService.Interfaces;

namespace ConsoleUINetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["pgConnection"].ConnectionString;
            
            ResolverType.Initialize();
            ResolverType.MyContainer().Install(new ConfigurationInstallerFacade(connectionString));
            ResolverType.MyContainer().Install(new AutoMapperInstaller());

            var logic = ResolverType.GetLogicFactory<ITestLogic>();

            var cuentas = logic.GetCuentaContable();
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"Cuenta :{ cuenta.NumeroCuenta } - Descripción: { cuenta.Descripcion }");
            }
            Console.ReadKey();

        }
    }
}
