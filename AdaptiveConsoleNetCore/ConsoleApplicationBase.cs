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
 * 9/20/2008     Added Default field on the option.     3.5.3182.35766  Sunny Chen
 * 9/23/2008     BUG FIX #1                             3.5.3189.17673  Sunny Chen
 * 11/27/2008    Modified                               3.5.3253.15384  Sunny Chen
 * 7/18/2015     Refactored                             4.5.5681.19881  Sunny Chen
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdaptiveConsole
{
    /// <summary>
    /// The base class for all console applications which use AdaptiveConsole framework.
    /// </summary>
    public abstract class ConsoleApplicationBase
    {
        #region Internal Constants
        /// <summary>
        /// The separator character which is used for separating the arguments that are defined on the option contracts.
        /// </summary>
        internal const char OPTION_CONTRACT_ARGUMENT_SEP = ';';
        /// <summary>
        /// The separater character which is used for separating the arguments that are defined on the option names.
        /// </summary>
        internal const char OPTION_ATTRIBUTE_NAME_SEP = ';';
        /// <summary>
        /// The template for assembly version.
        /// </summary>
        internal const string TEMPLATE_ASSEMBLY_VERSION = "<%app_asm_ver%>";
        /// <summary>
        /// The template for assembly title.
        /// </summary>
        internal const string TEMPLATE_ASSEMBLY_TITLE = "<%app_asm_title%>";
        /// <summary>
        /// The template for assembly description.
        /// </summary>
        internal const string TEMPLATE_ASSEMBLY_DESCRIPTION = "<%app_asm_desc%>";
        /// <summary>
        /// The template for assembly product information.
        /// </summary>
        internal const string TEMPLATE_ASSEMBLY_PRODUCT = "<%app_asm_product%>";
        /// <summary>
        /// The template for assembly copyright information.
        /// </summary>
        internal const string TEMPLATE_ASSEMBLY_COPYRIGHT = "<%app_asm_copyright%>";
        /// <summary>
        /// The template for assembly company information.
        /// </summary>
        internal const string TEMPLATE_ASSEMBLY_COMPANY = "<%app_asm_company%>";
        /// <summary>
        /// The template for the replacement of application logo.
        /// </summary>
        internal const string TEMPLATE_APPLICATION_LOGO = "<%app_logo%>";
        /// <summary>
        /// The template for the replacement of application description.
        /// </summary>
        internal const string TEMPLATE_APPLICATION_DESCRIPTION = "<%app_desc%>";
        /// <summary>
        /// The template for the replacement of application syntax lines.
        /// </summary>
        internal const string TEMPLATE_APPLICATION_SYNTAX_LINES = "<%app_syn_lines%>";
        /// <summary>
        /// The template for the replacement of application syntax description.
        /// </summary>
        internal const string TEMPLATE_APPLICATION_SYNTAX_DESCRIPTIONS = "<%app_syn_descs%>";

        #endregion

        #region Private Constants
        /// <summary>
        /// The separater charater which is used for separating the values within the ValueList argument.
        /// </summary>
        private const char OPTION_NAME_VALUE_SEP = ':';
        /// <summary>
        /// Represents the name of the configuration section.
        /// </summary>
        private const string CONFIG_SECTION_NAME = @"AdaptiveConsole";
        #endregion

        #region Private Fields

        /// <summary>
        /// Refers to the methods that takes the option contract, contract property information and
        /// option information as parameters, and has no return values.
        /// </summary>
        /// <param name="target">The option contract which holds the property.</param>
        /// <param name="property">The reflection information of the property.</param>
        /// <param name="attribute">The option attribute which describes the property.</param>
        private delegate void OptionTraversalEventHandler(OptionContractBase target, PropertyInfo property, OptionAttribute attribute);

        /// <summary>
        /// The entry assembly of the console application.
        /// </summary>
        private readonly Assembly entryAssembly = Assembly.GetEntryAssembly();

        private readonly string relativeCommandSite;
        #endregion

        #region Private Properties
        /// <summary>
        /// Gets or sets the option contract repository. Each contract information contains a instance of
        /// the option contract and its attribute information.
        /// </summary>
        private IList<OptionContractInfo> OptionContractRepository { get; set; }

        /// <summary>
        /// Gets the version of the assembly.
        /// </summary>
        private string AssemblyVersion
        {
            get
            {
                return entryAssembly.GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gets the title of the assembly.
        /// </summary>
        private string AssemblyTitle
        {
            get
            {
                object[] attributes = entryAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(entryAssembly.CodeBase);
            }
        }

        /// <summary>
        /// Gets the description of the assembly.
        /// </summary>
        private string AssemblyDescription
        {
            get
            {
                object[] attributes = entryAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the product information of the assembly.
        /// </summary>
        private string AssemblyProduct
        {
            get
            {
                object[] attributes = entryAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the copyright information of the assembly.
        /// </summary>
        private string AssemblyCopyright
        {
            get
            {
                object[] attributes = entryAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Gets the company information of the assembly.
        /// </summary>
        private string AssemblyCompany
        {
            get
            {
                object[] attributes = entryAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Checks if the name of an option contains the specified argument.
        /// </summary>
        /// <param name="name">Name of the option.</param>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="caseSensitive">Indicates whether should perform a case-sensitive check.</param>
        /// <param name="sep">The separator for the elements in the name.</param>
        /// <returns>True if the specified argument is within the option name, otherwise false.</returns>
        private bool ContainsOption(string name, string argument, bool caseSensitive, char sep)
        {
            string[] options = name.Split(sep);
            foreach (string opt in options)
            {
                if (caseSensitive)
                {
                    if (opt.Trim().Equals(argument))
                        return true;
                }
                else
                {
                    if (opt.Trim().ToUpper().Equals(argument.ToUpper()))
                        return true;
                }
            }
            return false;
        }
 
        /// <summary>
        /// Gets the option name and value from a SingleValue option.
        /// </summary>
        /// <param name="argument">The command line argument from which the option name and value should be retrieved.</param>
        /// <param name="optionName">Name of the option.</param>
        /// <param name="optionValue">Value of the option</param>
        /// <param name="sep">The separator for the command line argument.</param>
        /// <returns>True if successfully get the name and value, otherwise false.</returns>
        /// <example>
        /// For example, when dealing with the argument "/output:a.xml", the option name might be "/output" and
        /// the option value might be "a.xml".
        /// </example>
        private bool GetSingleValue(string argument, ref string optionName, ref string optionValue, char sep)
        {
            int pos = argument.IndexOf(sep);
            if (pos == -1)
            {
                optionName = string.Empty;
                optionValue = string.Empty;
                return false;
            }
            optionName = argument.Substring(0, pos);
            optionValue = argument.Substring(pos + 1);
            return true;
        }

        /// <summary>
        /// Gets the option name and a list of values from a ValueList option.
        /// </summary>
        /// <param name="argument">The command line argument from which the option name and values should be retrieved.</param>
        /// <param name="optionName">Name of the option.</param>
        /// <param name="optionValues">Values of the option</param>
        /// <param name="sep">The separator for the command line argument.</param>
        /// <param name="valueSep">The separator for the values.</param>
        /// <returns>True if successfully get the name and values, otherwise false.</returns>
        /// <example>
        /// For example, when dealing with the argument "/input:a.xsd,b.xsd,c.xsd", the option name might be "/input" and
        /// the option values are "a.xsd", "b.xsd", "c.xsd".
        /// </example>
        private bool GetMultipleValues(string argument, ref string optionName, ref string[] optionValues, char sep, char valueSep)
        {
            int pos = argument.IndexOf(sep);
            if (pos == -1)
            {
                optionName = string.Empty;
                optionValues = null;
                return false;
            }
            optionName = argument.Substring(0, pos);
            optionValues = argument.Substring(pos + 1).Split(valueSep);
            return true;
        }

        /// <summary>
        /// Traverses through each option within an option contract and performs specific operation.
        /// </summary>
        /// <param name="optionContract">The option contract to be traversed.</param>
        /// <param name="handler">The operation which should be taken on the option.</param>
        private void TraverseOptions(OptionContractBase optionContract, OptionTraversalEventHandler handler)
        {
            foreach (PropertyInfo property in optionContract.GetType().GetProperties())
            {
                //foreach (object customAttribute in property.GetCustomAttributes(false))
                //{
                //    if (customAttribute is OptionAttribute)
                //    {
                //        handler(optionContract, property, customAttribute as OptionAttribute);
                //        break;
                //    }
                //}
                object[] customAttributes = property.GetCustomAttributes(typeof(OptionAttribute), false);
                if (customAttributes.Length > 0)
                {
                    OptionAttribute optionAttribute = customAttributes.First() as OptionAttribute;
                    handler(optionContract, property, optionAttribute);
                }
            }
        }

        /// <summary>
        /// Populates the property of a patternized contract with the values which come from the 
        /// command line argument.
        /// </summary>
        /// <param name="target">The instance of an option contract to be populated.</param>
        /// <param name="property">The reflection information of the property to which the value should be populated.</param>
        /// <param name="attribute">The option attribute on the property.</param>
        /// <exception cref="AdaptiveConsole.ArgumentMissingException">Throws when an option is a required option but it is not specified in the command line arguments.</exception>
        /// <exception cref="AdaptiveConsole.InvalidOptionException">Throws when an invalid option type is provided.</exception>
        private void PopulateContractOption(OptionContractBase target, PropertyInfo property, OptionAttribute attribute)
        {
            bool containsOption = false;
            string optionName = string.Empty;

            switch (attribute.Type)
            {
                // If the option is a swith, and there is an occurrence in the command line argument,
                // that means the swith is turn on and we set the property to True. If there is no
                // occurrence of the option in the command line argument, it means that the switch
                // is turn off.
                case OptionType.Switch:
                    foreach (ArgumentInfo arg in this.Arguments)
                    {
                        if (this.ContainsOption(attribute.Name, arg.Argument, attribute.CaseSensitive, OPTION_ATTRIBUTE_NAME_SEP))
                        {
                            arg.Category = ArgumentCategory.Option;
                            containsOption = true;
                            break;
                        }
                    }
                    if (containsOption)
                        property.SetValue(target, true, null);
                    else
                        property.SetValue(target, false, null);
                    break;
                // If the option is a single value option, for each command line argument, we firstly
                // try getting the option name and value from the argument. If failed in getting the name
                // and value, that means current argument is not a single value option, we iterates to
                // the next command line argument. If we successfully get the name and value from the
                // single value option, we then check if the option name contains the name of the argument.
                // If it does, that means this is the command line argument that we want and we should populate
                // the option value to the property of the option.
                case OptionType.SingleValue:
                    optionName = string.Empty; 
                    string optionValue = string.Empty;
                    foreach (ArgumentInfo arg in this.Arguments)
                    {
                        if (!this.GetSingleValue(arg.Argument, ref optionName, ref optionValue, OPTION_NAME_VALUE_SEP))
                            continue;
                        if (this.ContainsOption(attribute.Name, optionName, attribute.CaseSensitive, OPTION_ATTRIBUTE_NAME_SEP))
                        {
                            arg.Category = ArgumentCategory.Option;
                            containsOption = true;
                            break;
                        }
                    }
                    if (containsOption)
                        property.SetValue(target, optionValue, null);
                    else
                    {
                        if (!attribute.Required)
                        {
                            // Sunny Chen Modified Begin - 9/20/2008 - Added for handling the Default field of the option.
                            if (!attribute.Default.Equals(string.Empty))
                                property.SetValue(target, attribute.Default, null);
                            else
                                property.SetValue(target, string.Empty, null);
                            // Sunny Chen Modified End
                        }
                        else
                            throw new ArgumentMissingException("Argument {0} is required.", attribute.Name);
                    }
                    break;
                // If the option is a multiple value option, for each command line argument, we firstly
                // try getting the option name and values from the argument. If failed in getting the name
                // and values, that means current argument is not a multiple value option, we iterates to
                // the next command line argument. If we successfully get the name and values from the
                // multiple value option, we then check if the option name contains the name of the argument.
                // If it does, that means this is the command line argument that we want and we should populate
                // the option values to the property of the option.
                case OptionType.ValueList:
                    optionName = string.Empty;
                    string[] optionValues = null;
                    foreach (ArgumentInfo arg in this.Arguments)
                    {
                        if (!this.GetMultipleValues(arg.Argument, ref optionName, ref optionValues, OPTION_NAME_VALUE_SEP, attribute.ValueSeparator))
                            continue;
                        if (this.ContainsOption(attribute.Name, optionName, attribute.CaseSensitive, OPTION_ATTRIBUTE_NAME_SEP))
                        {
                            arg.Category = ArgumentCategory.Option;
                            containsOption = true;
                            break;
                        }
                    }
                    if (containsOption)
                        property.SetValue(target, optionValues, null);
                    else
                    {
                        if (!attribute.Required)
                            property.SetValue(target, null, null);
                        else
                            throw new ArgumentMissingException("Argument {0} is required.", attribute.Name);
                    }
                    break;
                default:
                    throw new InvalidOptionException("The option is of the invalid type.");
            }
        }

        /// <summary>
        /// Checks if the command line argument matches the given contract.
        /// </summary>
        /// <param name="optionContractInfo">The contract information to be matched.</param>
        /// <returns>True if matches, otherwise false.</returns>
        private bool MatchContract(OptionContractInfo optionContractInfo)
        {
            switch (optionContractInfo.ContractAttribute.Type)
            {
                // If the contract is an Exact contract, checks if the command line argument exactly matches
                // the argument provided by the contract.
                case ContractType.Exact:
                    if (this.ContainsOption(optionContractInfo.ContractAttribute.Argument,
                        this.Arguments.ToArgumentString(),
                        optionContractInfo.ContractAttribute.CaseSensitive,
                        OPTION_CONTRACT_ARGUMENT_SEP))
                        return true;
                    return false;

                // If the contract is a None contract, that means no argument is required to run the console
                // application. So simply returns true when no argument is provided.
                case ContractType.None:
                    if (this.Arguments == null ||
                        this.Arguments.Count == 0)
                        return true;
                    return false;

                // If the contract is a Free contract, that means all the arguments will be considered as
                // parameters other than options. In such case, there must be at least one argument in the
                // argument list. This is for distinguishing the Free contract from None contract.
                case ContractType.Free:
                    if (this.Arguments == null ||
                        this.Arguments.Count == 0)
                        return false;
                    return true;

                // This is a patternized contract. For the patternized contract, the option properties will
                // be populated by command line arguments and the type of the argument will be set to Option
                // properly.
                default:
                    try
                    {
                        TraverseOptions(optionContractInfo.OptionContract,
                            PopulateContractOption);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// Validates the option contracts.
        /// </summary>
        /// <exception cref="AdaptiveConsole.InvalidContractException">
        /// Throws when:
        /// 1. The option contract is an Exact contract but with no argument specified.
        /// 2. The Exact contract with the given argument already exists.
        /// 3. The contract repository has registered more than one None contract.
        /// 4. The contract repository has registered more than one Free contract.
        /// 5. The contract repository has registered both Free and Patternized contracts.
        /// </exception>
        /// <exception cref="AdaptiveConsole.InvalidOptionException">
        /// Throws when:
        /// 1. The option has not the name been specified.
        /// 2. The option with specific name already exists.
        /// 3. The option is a Swith option but the corresponding property is not a System.Boolean property.
        /// 4. The option is a SingleValue option but the corresponding property is not a System.String property.
        /// 5. The option is a ValueList option but the corresponding property is not a System.Array property.
        /// </exception>
        private void ValidateOptionContracts()
        {
            int noneContracts = 0;
            int freeContracts = 0;
            int exactContracts = 0;
            int patternizedContracts = 0;
            HashSet<string> exactArgumentSet = new HashSet<string>();
            foreach (OptionContractInfo oci in this.OptionContractRepository)
            {
                switch (oci.ContractAttribute.Type)
                {
                    case ContractType.None:
                        noneContracts++;
                        break;
                    case ContractType.Free:
                        freeContracts++;
                        break;
                    case ContractType.Exact:
                        exactContracts++;
                        if (oci.ContractAttribute.Argument == null ||
                            oci.ContractAttribute.Argument.Trim().Equals(string.Empty))
                            throw new InvalidContractException("The option contract is an Exact contract but the contract argument is missing.");

                        /* Sunny Chen Modified: 12/19/2008 --> */
                        /* 
                        if (exactArgumentSet.Contains(oci.ContractAttribute.Argument))
                            throw new InvalidContractException("The exact contract with the argument of {0} already exists.", oci.ContractAttribute.Argument);
                        else
                            exactArgumentSet.Add(oci.ContractAttribute.Argument);
                         * */
                        string argument = oci.ContractAttribute.Argument;
                        if (oci.ContractAttribute.CaseSensitive)
                        {
                            if (exactArgumentSet.Contains(argument))
                                throw new InvalidContractException("The exact contract with the argument of {0} already exists.", argument);
                            else
                                exactArgumentSet.Add(argument);
                        }
                        else
                        {
                            var query = from exactArgument in exactArgumentSet
                                        where exactArgument.ToUpper().Equals(argument.ToUpper())
                                        select exactArgument;
                            if (query.Any())
                                throw new InvalidContractException("The exact contract with the argument of {0} already exists.", argument);
                            else
                                exactArgumentSet.Add(argument);
                        }
                        /* <-- Sunny Chen Modified */
                        break;
                    default:
                        patternizedContracts++;
                        TraverseOptions(
                            oci.OptionContract,
                            delegate(OptionContractBase target, PropertyInfo property, OptionAttribute attribute)
                            {
                                HashSet<string> optionNameSet = new HashSet<string>();
                                if (attribute.Name == null ||
                                    attribute.Name.Trim().Equals(string.Empty))
                                    throw new InvalidOptionException("Option contract {0} contains options that have no name specified.", target);
                                
                                if (optionNameSet.Contains(attribute.Name))
                                    throw new InvalidOptionException("The option {0} has already been defined.", attribute);
                                else
                                    optionNameSet.Add(attribute.Name);

                                switch (attribute.Type)
                                {
                                    case OptionType.Switch:
                                        if (!property.PropertyType.FullName.Equals("System.Boolean"))
                                            throw new InvalidOptionException("Property {0} refers to a Switch option but it is not a System.Boolean property.", property);
                                        // Sunny Chen Added Begin - 9/20/2008 - Added for handling the Default field of option.
                                        if (!attribute.Default.Equals(string.Empty))
                                            throw new InvalidOptionException("Cannot specify the Default field on the Switch option.");
                                        // Sunny Chen Added End
                                        break;
                                    case OptionType.SingleValue:
                                        if (!property.PropertyType.FullName.Equals("System.String"))
                                            throw new InvalidOptionException("Property {0} refers to a SingleValue option but it is not a System.String property.", property);
                                        break;
                                    default:
                                        if (!property.PropertyType.FullName.Equals("System.Array"))
                                            throw new InvalidOptionException("Property {0} refers to a ValueList option but it is not a System.Array property.", property);
                                        // Sunny Chen Added Begin - 9/20/2008 - Added for handling the Default field of option.
                                        if (!attribute.Default.Equals(string.Empty))
                                            throw new InvalidOptionException("Cannot specify the Default field on the ValueList option.");
                                        // Sunny Chen Added End
                                        break;
                                }
                            });
                        break;
                }
            }
            if (noneContracts > 1)
                throw new InvalidContractException("A contract repository can only have one contract which is the type of None.");
            if (freeContracts > 1)
                throw new InvalidContractException("A contract repository can only have one contract which is the type of Free.");
            if (freeContracts == 1 && (patternizedContracts > 0))
                throw new InvalidContractException("A contract repository cannot have any Patternized contracts while there is a Free contract in it.");
            /* Sunny Chen Added 12/12/2008: BUG FIX #3 --> */
            if (freeContracts == 1 && (exactContracts > 0))
                throw new InvalidContractException("A contract repository cannot have any Exact contract while there is a Free contract in it.");
            /* <-- Sunny Chen Added 12/12/2008 */
        }

        /// <summary>
        /// Generates the syntax lines from each contract defined.
        /// </summary>
        /// <returns>The syntax lines represented by the returned string.</returns>
        private string GenerateSyntaxLines()
        {
            StringBuilder sb = new StringBuilder();
            var query = from p in this.OptionContractRepository
                        orderby p.ContractAttribute.Type
                        select p;

            foreach (OptionContractInfo optionContractInfo in query)
            {
                string syntax = optionContractInfo.OptionContract.Syntax;
                if (syntax != null)
                {
                    sb.Append(string.Format("{0} {1}", this.ApplicationName, syntax));
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates the syntax descriptions from each contract defined.
        /// </summary>
        /// <returns>The syntax descriptions represented by the returned string.</returns>
        private string GenerateSyntaxDescriptions()
        {
            StringBuilder sb = new StringBuilder();
            var query = from p in this.OptionContractRepository
                        orderby p.ContractAttribute.Type
                        select p;

            foreach (OptionContractInfo optionContractInfo in query)
            {
                string helpText = optionContractInfo.OptionContract.HelpText;
                if (helpText != null && !helpText.Equals(string.Empty))
                {
                    sb.Append(helpText);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// Gets a replaced string according to the given template.
        /// </summary>
        /// <param name="template">The template in which the macros need to be replaced.</param>
        /// <returns>The replaced string.</returns>
        private string GetReplacedString(string template)
        {
            return template
                .Replace("<%<%", "<~%")
                .Replace("%>%>", "%~>")
                .Replace(TEMPLATE_APPLICATION_LOGO, this.Logo)
                .Replace(TEMPLATE_APPLICATION_DESCRIPTION, this.Description)
                .Replace(TEMPLATE_APPLICATION_SYNTAX_LINES, this.GenerateSyntaxLines())
                .Replace(TEMPLATE_ASSEMBLY_COMPANY, this.AssemblyCompany)
                .Replace(TEMPLATE_ASSEMBLY_COPYRIGHT, this.AssemblyCopyright)
                .Replace(TEMPLATE_ASSEMBLY_DESCRIPTION, this.AssemblyDescription)
                .Replace(TEMPLATE_ASSEMBLY_PRODUCT, this.AssemblyProduct)
                .Replace(TEMPLATE_ASSEMBLY_TITLE, this.AssemblyTitle)
                .Replace(TEMPLATE_ASSEMBLY_VERSION, this.AssemblyVersion)
                .Replace(TEMPLATE_APPLICATION_SYNTAX_DESCRIPTIONS, this.GenerateSyntaxDescriptions())
                .Replace("<~%", "<%")
                .Replace("%~>", "%>");
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// Gets or sets the list of command line argument information. Each element
        /// contains the information about the command line argument and its argument type.
        /// </summary>
        protected IList<ArgumentInfo> Arguments { get; set; }

        /// <summary>
        /// Gets the template string which defines the banner format of the help screen.
        /// </summary>
        protected virtual string BannerTemplate
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<%app_logo%>");
                sb.Append(Environment.NewLine);
                sb.Append("<%app_asm_copyright%>");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("<%app_desc%>");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the template string which defines the body format of the help screen.
        /// </summary>
        protected virtual string HelpBodyTemplate
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<%app_syn_lines%>");
                sb.Append(Environment.NewLine);
                sb.Append("<%app_syn_descs%>");
                return sb.ToString();
            }
        }


        /// <summary>
        /// Gets or sets the Logo of the console application.
        /// </summary>
        protected abstract string Logo { get; }

        /// <summary>
        /// Gets or sets the description text of the console application.
        /// </summary>
        protected abstract string Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleApplicationBase"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="args">The arguments.</param>
        protected ConsoleApplicationBase(string relativeCommandSite, string[] args)
        {
            this.relativeCommandSite = relativeCommandSite;

            // Creates the argument information list.
            this.Arguments = new List<ArgumentInfo>();
            // Populates the argument information list. Initially each argument is the type of Parameter.
            foreach (string arg in args)
                this.Arguments.Add(new ArgumentInfo(arg, ArgumentCategory.Parameter));

            // Creates the option contract repository.
            this.OptionContractRepository = new List<OptionContractInfo>();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the full file name of the console application.
        /// </summary>
        public string ApplicationFullName
        {
            get { return Process.GetCurrentProcess().MainModule.FileName; }
        }

        /// <summary>
        /// Gets the file name of the console application.
        /// </summary>
        public string ApplicationName
        {
            get { return Path.GetFileName(ApplicationFullName); }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes the console application.
        /// </summary>
        /// <exception cref="AdaptiveConsole.AdaptiveConsoleException">Throws when failed to initialize the application.</exception>
        public virtual void Init()
        {
            try
            {
                // Populates the contract repository.
                // Assembly assembly = Assembly.Load(this.AdaptiveConsoleConfig.ContractRepository);
                //foreach (Type type in assembly.GetTypes())
                //{
                //    object[] customAttributes = type.GetCustomAttributes(false);
                //    bool hasAttribute = false;
                //    OptionContractAttribute contractAttribute = null;

                //    foreach (object customAttribute in customAttributes)
                //    {
                //        if (customAttribute is OptionContractAttribute)
                //        {
                //            hasAttribute = true;
                //            contractAttribute = (customAttribute as OptionContractAttribute);
                //            break;
                //        }
                //    }

                //    if (!hasAttribute) continue;

                //    this.OptionContractRepository.Add(new OptionContractInfo((OptionContractBase)Activator.CreateInstance(type), contractAttribute));
                //}
                var commandSiteDirectory = Path.Combine(Path.GetDirectoryName(this.entryAssembly.Location), this.relativeCommandSite);
                var commandSiteDirectoryInfo = new DirectoryInfo(commandSiteDirectory);

                IList<Assembly> assemblies = new List<Assembly>();

                foreach (var assemblyFile in commandSiteDirectoryInfo.EnumerateFiles("*.dll", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        assemblies.Add(Assembly.LoadFrom(assemblyFile.FullName));
                    }
                    catch
                    {
                        continue;
                    }
                }
                foreach (Assembly assembly in assemblies)
                {
                    foreach (Type type in assembly.GetExportedTypes())
                    {
                        object[] customAttributes = type.GetCustomAttributes(typeof(OptionContractAttribute), false);
                        if (customAttributes != null && customAttributes.Length > 0)
                        {
                            OptionContractAttribute optionContractAttribute = (customAttributes.First() as OptionContractAttribute);
                            this.OptionContractRepository.Add(new OptionContractInfo((OptionContractBase)Activator.CreateInstance(type), optionContractAttribute));
                        }
                        else
                            continue;
                    }
                }
                // Validates the contract repository, if failed to validate, exceptions will be thrown
                // and the console application will output the exception message.
                this.ValidateOptionContracts();
            }
            catch (AdaptiveConsoleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AdaptiveConsoleException(AdaptiveConsoleException.GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Runs the console application.
        /// </summary>
        /// <exception cref="AdaptiveConsole.AdaptiveConsoleException">Throws when failed to run the application.</exception>
        public virtual void Run()
        {
            try
            {
                // Checks each option contract with the given command line argument.
                // If successfully matched the contract, execute the contract with the given arguments.
                foreach (OptionContractInfo optionContractInfo in this.OptionContractRepository)
                {
                    if (this.MatchContract(optionContractInfo))
                    {
                        optionContractInfo.OptionContract.DoExecute(this, this.Arguments);
                        return;
                    }
                }
                this.PrintHelpMessage();
            }
            catch (AdaptiveConsoleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AdaptiveConsoleException(AdaptiveConsoleException.GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Finalizes the console application.
        /// </summary>
        public virtual void Done() { }

        /// <summary>
        /// Prints the Logo and description to the screen.
        /// </summary>
        public void PrintBanner()
        {
            Console.Write(GetReplacedString(this.BannerTemplate));
        }

        /// <summary>
        /// Prints the body of the help screen.
        /// </summary>
        public void PrintHelpBody()
        {
            Console.Write(GetReplacedString(this.HelpBodyTemplate));
        }

        /// <summary>
        /// Prints the help message.
        /// </summary>
        public void PrintHelpMessage()
        {
            // bool syntaxPrinted = false;
            // Prints the logo
            this.PrintBanner();
            //// Dumps the syntax text from each option contract and prints the syntax definitions
            //// to the screen.
            //foreach (OptionContractInfo optionContractInfo in this.OptionContractRepository)
            //{
            //    string syntax = optionContractInfo.OptionContract.Syntax;
            //    if (syntax != null)
            //    {
            //        syntaxPrinted = true;
            //        Console.WriteLine("{0} {1}", this.ApplicationName, syntax);
            //    }
            //}

            //if (syntaxPrinted)
            //    Console.WriteLine();
            
            //// Displays the detailed information about the contract.
            //foreach (OptionContractInfo optionContractInfo in this.OptionContractRepository)
            //{
            //    string helpText = optionContractInfo.OptionContract.HelpText;
            //    if (helpText != null && !helpText.Equals(string.Empty))
            //    {
            //        Console.WriteLine(optionContractInfo.OptionContract.HelpText);
            //        Console.WriteLine();
            //    }
            //}
            this.PrintHelpBody();
        }

        
        #endregion
    }
}
