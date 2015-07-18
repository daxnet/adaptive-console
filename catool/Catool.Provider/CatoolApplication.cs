using AdaptiveConsole;

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
    }
}
