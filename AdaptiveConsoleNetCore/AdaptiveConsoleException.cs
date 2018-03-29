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

namespace AdaptiveConsole
{
    /// <summary>
    /// The base exception class for all AdaptiveConsole exceptions.
    /// </summary>
    public class AdaptiveConsoleException : Exception
    {
        #region Constructors
        /// <summary>
        /// Gets the general exception message.
        /// </summary>
        public const string GENERAL_EXCEPTION_MESSAGE = @"General exception occurred.";
        /// <summary>
        /// Initializes the exception with the given message.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public AdaptiveConsoleException(string message) : base(message) { }
        /// <summary>
        /// Initializes the exception with the given message and its inner exception.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception instance.</param>
        public AdaptiveConsoleException(string message, Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// Initializes the exception with the formatting string and the parameters.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arguments">Parameters.</param>
        public AdaptiveConsoleException(string format, params object[] arguments) : base(string.Format(format, arguments)) { }
        #endregion
    }
}
