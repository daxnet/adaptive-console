using System;
using System.Collections.Generic;
using System.Reflection;
using AdaptiveConsole;

namespace Catool.Contracts
{
    [
        OptionContract(
            Argument="/version;/ver",
            Description="Display the version information",
            Type=ContractType.Exact)
    ]
    public class DisplayVersionContract : OptionContractBase
    {
        public override void Execute(
            ConsoleApplicationBase consoleApplication, 
            IList<ArgumentInfo> args)
        {
            Console.WriteLine(Assembly
                .GetEntryAssembly()
                .GetName()
                .Version
                .ToString());
        }
    }
}
