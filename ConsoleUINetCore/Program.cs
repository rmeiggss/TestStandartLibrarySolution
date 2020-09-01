using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using TestInfraestructure;
using TestService.Interfaces;

namespace ConsoleUINetCore
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            //Console.WriteLine("Hello World!");
        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            ResolverType.Initialize();
            ResolverType.MyContainer().Install(new ConfigurationInstallerFacade(configuration.GetConnectionString("pgConnection")));
            ResolverType.MyContainer().Install(new AutoMapperInstaller());
        }
        static async Task MainAsync(string[] args)
        {
            try
            {
                ServiceCollection serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                var logic = ResolverType.GetLogicFactory<ITestLogic>();

                var cuentas = logic.GetCuentaContable();
                foreach (var cuenta in cuentas)
                {
                    Console.WriteLine($"Cuenta :{ cuenta.NumeroCuenta } - Descripción: { cuenta.Descripcion }");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
