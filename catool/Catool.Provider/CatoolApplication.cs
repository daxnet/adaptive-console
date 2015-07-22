using AdaptiveConsole;
using AdaptiveConsole.Config;

namespace Catool.Provider
{
    public class CatoolApplication : ConsoleApplicationBase
    {
        protected override string Description
        {
            get 
            { 
                return "A demonstration of "+
                       "Adaptive Console Framework"; 
            }
        }

        protected override string Logo
        {
            get 
            {
                return @"catool";
            }
        }

        public CatoolApplication(string[] args) : base(args) { }

        public CatoolApplication(AdaptiveConsoleConfiguration configuration, string[] args) : base(configuration, args)
        {
        }
    }
}
