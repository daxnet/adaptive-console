using System;
using AdaptiveConsole;

namespace catool
{
    class Program
    {
        static void Main(string[] args)
        {
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
