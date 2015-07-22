using System;
using System.Configuration;
using AdaptiveConsole;
using AdaptiveConsole.Config;
using Catool.Contracts;
using Catool.Provider;

namespace catool
{
    class Program
    {
        static void Main(string[] args)
        {
            //var configuration = new AdaptiveConsoleConfiguration();
            //configuration.Provider = typeof (CatoolApplication).AssemblyQualifiedName;
            //configuration.Repositories = new ContractRepositoryElementCollection();
            //configuration.Repositories.Add(new ContractRepositoryElement
            //{
            //    Assembly = typeof(CalculationContract).Assembly.FullName,
            //    Name = "Contracts"
            //});
            
            try
            {
                ConsoleApplicationManager.RunApplication(args);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
