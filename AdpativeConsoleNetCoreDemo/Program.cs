using AdaptiveConsole;
using System;

namespace AdpativeConsoleNetCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var app = new CatoolApplication(args);
                ConsoleApplicationManager.RunApplication(app);
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
