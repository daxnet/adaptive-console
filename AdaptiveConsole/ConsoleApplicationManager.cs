/* ----------------------------------------------------------------------------
 * AdaptiveConsole - A flexable console application framework.
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 9/16/2008
 * 
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION         UPDATED_BY
 * 9/16/2008     Created                                3.5.3182.35766  Sunny Chen
 * ---------------------------------------------------------------------------- */

using System;
using System.Configuration;
using AdaptiveConsole.Config;

namespace AdaptiveConsole
{
    /// <summary>
    /// Console application manager which manages the creating and running of a console application.
    /// </summary>
    public class ConsoleApplicationManager
    {
        #region Private Methods
        /// <summary>
        /// Gets the instance of the console application by its type definition in the configuration file.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>The instance of the console application.</returns>
        private static ConsoleApplicationBase GetApplication(string[] args)
        {
            //try
            //{
            //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //    AdaptiveConsoleConfiguration configHandler = (AdaptiveConsoleConfiguration)config.GetSection("AdaptiveConsole");
            //    Type type = Type.GetType(configHandler.Provider);
            //    object[] objargs = { args };
            //    return (ConsoleApplicationBase)Activator.CreateInstance(type, objargs);
            //}
            //catch (Exception e)
            //{
            //    throw new AdaptiveConsoleException(AdaptiveConsoleException.GENERAL_EXCEPTION_MESSAGE, e);
            //}
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var configHandler = (AdaptiveConsoleConfiguration) config.GetSection("AdaptiveConsole");
                return GetApplication(configHandler, args);
            }
            catch (AdaptiveConsoleException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new AdaptiveConsoleException(AdaptiveConsoleException.GENERAL_EXCEPTION_MESSAGE, e);
            }
            
        }

        private static ConsoleApplicationBase GetApplication(AdaptiveConsoleConfiguration configuration, string[] args)
        {
            try
            {
                var type = Type.GetType(configuration.Provider);
                var objargs = new object[] { configuration, args };
                return (ConsoleApplicationBase) Activator.CreateInstance(type, objargs);
            }
            catch (Exception e)
            {
                throw new AdaptiveConsoleException(AdaptiveConsoleException.GENERAL_EXCEPTION_MESSAGE, e);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Runs the console application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void RunApplication(string[] args)
        {
            ConsoleApplicationBase consoleApplication = GetApplication(args);
            consoleApplication.Init();
            consoleApplication.Run();
            consoleApplication.Done();
        }

        /// <summary>
        /// Runs the application.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="args">The arguments.</param>
        public static void RunApplication(AdaptiveConsoleConfiguration configuration, string[] args)
        {
            var consoleApplication = GetApplication(configuration, args);
            consoleApplication.Init();
            consoleApplication.Run();
            consoleApplication.Done();
        }
        //public static void RunApplication()
        #endregion
    }
}
