using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdaptiveConsole;

namespace Catool.Contracts
{
    [
        OptionContract(
            Type=ContractType.Patternized,
            Description="Performs arithmetic calculation",
            Parameters=2)
    ]
    public class CalculationContract : OptionContractBase
    {
        [
            Option(
                Name="/method;/m",
                Type=OptionType.SingleValue,
                Description="Specifies the calculation method\n"+
                            "\t\tadd: Performs an addition calculation\n"+
                            "\t\tsub: Performs a subtraction calculation\n"+
                            "\t\tmul: Performs a multiplication calculation\n"+
                            "\t\tdiv: Performs a division calculation",
                Required=true)
        ]
        public string Method { get; set; }

        [
            Option(
                Name="/nologo",
                Type=OptionType.Switch,
                Description="Suppress the display of banner information")
        ]
        public bool NoLogo { get; set; }

        public override void Execute(
            ConsoleApplicationBase consoleApplication, 
            IList<ArgumentInfo> args)
        {
            var integers = from arg in args
                           where arg.Category == ArgumentCategory.Parameter
                           select arg.Argument;
            int num1, num2, result;
            try
            {
                num1 = int.Parse(integers.ElementAt(0));
                num2 = int.Parse(integers.ElementAt(1));
            }
            catch
            {
                consoleApplication.PrintHelpMessage();
                return;
            }
            if (!this.NoLogo)
                consoleApplication.PrintBanner();
            try
            {
                switch (this.Method.ToUpper())
                {
                    case "ADD":
                        result = num1 + num2;
                        break;
                    case "SUB":
                        result = num1 - num2;
                        break;
                    case "MUL":
                        result = num1 * num2;
                        break;
                    case "DIV":
                        result = num1 / num2;
                        break;
                    default:
                        consoleApplication.PrintHelpMessage();
                        return;
                }
                Console.WriteLine(result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Divided by zero error caught.");
                return;
            }
        }
    }
}
