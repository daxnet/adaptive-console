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
 * 9/23/2008     BUG FIX #1                             3.5.3189.17673  Sunny Chen
 * 12/1/2008     Modified                               3.5.3253.15384  Sunny Chen
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdaptiveConsole
{
    /// <summary>
    /// The base class for all the option contracts.
    /// </summary>
    public abstract class OptionContractBase
    {
        #region Public Methods
        /// <summary>
        /// Executes the contract.
        /// </summary>
        /// <param name="consoleApplication">The console application instance on which the contract is executed.</param>
        /// <param name="args">The argument list carried with the argument information.</param>
        public abstract void Execute(ConsoleApplicationBase consoleApplication, IList<ArgumentInfo> args);
        #endregion

        #region Internal Methods
        /// <summary>
        /// Executes the contract.
        /// </summary>
        /// <param name="consoleApplicationBase">The console application instance on which the contract is executed.</param>
        /// <param name="iList">The argument list carried with the argument information.</param>
        internal void DoExecute(ConsoleApplicationBase consoleApplicationBase, IList<ArgumentInfo> iList)
        {
            OptionContractAttribute attrib = this.Attribute;

            if (attrib.Parameters != -1 && attrib.Type == ContractType.Patternized)
            {
                var query = from arg in iList
                            where arg.Category == ArgumentCategory.Parameter
                            select arg;
                if (query.Count() != attrib.Parameters)
                {
                    consoleApplicationBase.PrintHelpMessage();
                    return;
                }
            }
            this.Execute(consoleApplicationBase, iList);
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// Gets the attribute instance of the contract.
        /// </summary>
        protected OptionContractAttribute Attribute
        {
            get
            {
                Type type = this.GetType();
                //var query = from attribute in type.GetCustomAttributes(false)
                //            where (attribute is OptionContractAttribute)
                //            select attribute;
                //return query.First() as OptionContractAttribute;
                object[] customAttributes = type.GetCustomAttributes(typeof(OptionContractAttribute), false);
                if (customAttributes.Length > 0)
                {
                    return (customAttributes.First() as OptionContractAttribute);
                }
                return null;
            }
        }
        /// <summary>
        /// Gets the attributes for all the options within the contract.
        /// </summary>
        protected IList<OptionAttribute> OptionAttributes
        {
            get
            {
                IList<OptionAttribute> ret = new List<OptionAttribute>();
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    //foreach (object customAttribute in property.GetCustomAttributes(false))
                    //{
                    //    if (customAttribute is OptionAttribute)
                    //    {
                    //        ret.Add(customAttribute as OptionAttribute);
                    //        break;
                    //    }
                    //}
                    object[] customAttributes = property.GetCustomAttributes(typeof(OptionAttribute), false);
                    if (customAttributes.Length > 0)
                    {
                        ret.Add(customAttributes.First() as OptionAttribute);
                    }
                }
                return ret;
            }
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the help text of the contract.
        /// </summary>
        public virtual string HelpText
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                OptionContractAttribute attrib = this.Attribute;

                if (attrib == null)
                    return null;

                if (attrib.Type == ContractType.None)
                    sb.Append("> Calling the application without arguments\n");
                else if (attrib.Type == ContractType.Free)
                    sb.Append("> Calling the application with any arguments\n");
                else
                    sb.Append(string.Format("> {0}\n", attrib.Description));

                switch (attrib.Type)
                {
                    case ContractType.None:
                    case ContractType.Free:
                        sb.Append(string.Format("  {0}", attrib.Description));
                        break;
                    case ContractType.Exact:
                        sb.Append(string.Format("  {0}:\n\t{1}", attrib.Argument.Replace(ConsoleApplicationBase.OPTION_CONTRACT_ARGUMENT_SEP, '|'),
                            attrib.Description));
                        break;
                    default:
                        Type type = this.GetType();
                        foreach (PropertyInfo property in type.GetProperties())
                        {
                            foreach (object customAttribute in property.GetCustomAttributes(false))
                            {
                                if (customAttribute is OptionAttribute)
                                {
                                    OptionAttribute oa = customAttribute as OptionAttribute;
                                    switch (oa.Type)
                                    {
                                        case OptionType.Switch:
                                            sb.Append(string.Format("  [{0}]:\n\t", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            break;
                                        case OptionType.SingleValue:
                                            if (oa.Required)
                                                sb.Append(string.Format("  {0}:value (required):\n\t", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            else
                                                sb.Append(string.Format("  {0}:value :\n\t", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            break;
                                        default:
                                            if (oa.Required)
                                                sb.Append(string.Format("  {0}:v1[,v2[,v3]] (required):\n\t", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            else
                                                sb.Append(string.Format("  {0}:v1[,v2[,v3]] :\n\t", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            break;
                                    }
                                    sb.Append(oa.Description);
                                    sb.Append("\n\n");
                                }
                            }
                        }
                        break;
                }

                return sb.ToString().Trim();
            }
        }
        /// <summary>
        /// Gets the syntax description of the contract.
        /// </summary>
        public virtual string Syntax
        {
            get
            {
                if (this.Attribute == null)
                    return null;

                switch (this.Attribute.Type)
                {
                    case ContractType.None:
                    case ContractType.Free:
                        return null;
                    case ContractType.Exact:
                        return this.Attribute.Argument.Replace(ConsoleApplicationBase.OPTION_CONTRACT_ARGUMENT_SEP, '|');
                    default:
                        StringBuilder sb = new StringBuilder();
                        Type type = this.GetType();
                        foreach (PropertyInfo property in type.GetProperties())
                        {
                            foreach (object customAttribute in property.GetCustomAttributes(false))
                            {
                                if (customAttribute is OptionAttribute)
                                {
                                    OptionAttribute oa = customAttribute as OptionAttribute;
                                    switch (oa.Type)
                                    {
                                        case OptionType.Switch:
                                            sb.Append(string.Format("[{0}] ", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            break;
                                        default:
                                            if (oa.Required)
                                                sb.Append(string.Format("<{0}:> ", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            else
                                                sb.Append(string.Format("[{0}:] ", oa.Name.Replace(ConsoleApplicationBase.OPTION_ATTRIBUTE_NAME_SEP, '|')));
                                            break;
                                    }
                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < this.Attribute.Parameters; i++)
                            sb.Append(string.Format("p{0} ", i + 1));
                        return sb.ToString().Trim();
                }
            }
        }
        #endregion

        
    }
}
