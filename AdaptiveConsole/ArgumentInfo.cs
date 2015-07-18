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

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveConsole
{
    /// <summary>
    /// Console application argument categories.
    /// </summary>
    public enum ArgumentCategory
    {
        /// <summary>
        /// Indicates that the argument is an option.
        /// </summary>
        Option,
        /// <summary>
        /// Indicates that the argument is a parameter.
        /// </summary>
        Parameter
    }

    /// <summary>
    /// The object which holds the command line argument and its argument type.
    /// </summary>
    public class ArgumentInfo
    {
        #region Public Properties
        /// <summary>
        /// The command line argument.
        /// </summary>
        public string Argument { get; set; }
        /// <summary>
        /// The argument type.
        /// </summary>
        public ArgumentCategory Category { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Parameterized constructor for building the object instance with
        /// specified parameters.
        /// </summary>
        /// <param name="argument">The command line argument.</param>
        /// <param name="type">The argument type.</param>
        public ArgumentInfo(string argument, ArgumentCategory type)
        {
            this.Argument = argument;
            this.Category = type;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the string identifier of the object.
        /// </summary>
        /// <returns>The string identifier.</returns>
        public override string ToString()
        {
            return string.Format("Argument={0}, Type={1}", this.Argument, this.Category);
        }
        #endregion
    }

    /// <summary>
    /// The extension methods holder for IList&lt;ArgumentInfo&gt; generic type.
    /// </summary>
    public static class IListArgumentInfoGenericExtender
    {
        /// <summary>
        /// Checks if the argument list contains the arguments which are of Parameter type.
        /// </summary>
        /// <param name="args">The argument list to check.</param>
        /// <returns>True if the argument list contains the argument which are of Parameter type.
        /// Otherwise false.</returns>
        public static bool HasParameterArgument(this IList<ArgumentInfo> args)
        {
            var query = from p in args
                        where p.Category == ArgumentCategory.Parameter
                        select p;
            return query.Any();
        }

        /// <summary>
        /// Converts the argument list to the command-line-like argument string (Each argument
        /// element is separated by the space character).
        /// </summary>
        /// <param name="args">The list of arguments to be converted.</param>
        /// <returns>The command-line-like argument string.</returns>
        internal static string ToArgumentString(this IList<ArgumentInfo> args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ArgumentInfo s in args)
            {
                sb.Append(s.Argument);
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
    }
}
