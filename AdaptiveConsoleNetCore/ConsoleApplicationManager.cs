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
using System.Collections.Generic;
using System.Linq;

namespace AdaptiveConsole
{
    /// <summary>
    /// Console application manager which manages the creating and running of a console application.
    /// </summary>
    public class ConsoleApplicationManager
    {
        #region Public Methods

        public static void RunApplication<TApplication>(string relativeCommandSite, string[] args)
            where TApplication : ConsoleApplicationBase
        {
            ConsoleApplicationBase app;
            try
            {
                var parameters = new List<object> { relativeCommandSite };
                parameters.AddRange(args);

                app = (ConsoleApplicationBase)Activator.CreateInstance(typeof(TApplication), parameters.ToArray());
            }
            catch (Exception e)
            {
                throw new AdaptiveConsoleException(AdaptiveConsoleException.GENERAL_EXCEPTION_MESSAGE, e);
            }

            RunApplication(app);
        }

        /// <summary>
        /// Runs the application.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="args">The arguments.</param>
        public static void RunApplication<TApplication>(TApplication adaptiveConsoleApp)
            where TApplication : ConsoleApplicationBase
        {
            adaptiveConsoleApp.Init();
            adaptiveConsoleApp.Run();
            adaptiveConsoleApp.Done();
        }

        #endregion
    }
}
