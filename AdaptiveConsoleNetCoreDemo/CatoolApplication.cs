using AdaptiveConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdpativeConsoleNetCoreDemo
{
    public class CatoolApplication : ConsoleApplicationBase
    {
        protected override string Description
        {
            get
            {
                return "A demonstration of " +
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

        public CatoolApplication(string[] args) : base("Commands", args) { }
    }
}
