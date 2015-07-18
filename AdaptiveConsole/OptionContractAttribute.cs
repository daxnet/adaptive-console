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
 * ---------------------------------------------------------------------------- */

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace AdaptiveConsole
{
    #region Public Enumeration
    /// <summary>
    /// Type of the contract.
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// Indicates that the contract will match
        /// the optional command line argument.
        /// </summary>
        Patternized,
        /// <summary>
        /// Indicates that the contract will match
        /// the exact command line argument.
        /// </summary>
        Exact,
        /// <summary>
        /// Indicates that the contract will match
        /// the command without any argument.
        /// </summary>
        None,
        /// <summary>
        /// Indicates that the contract will match
        /// the command in which the arguments are
        /// all Parameter.
        /// </summary>
        Free
    }
    #endregion

    /// <summary>
    /// Represents the custom attribute that identifies an option contract.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class OptionContractAttribute : DesignModel.AttributeEventProvider
    {
        #region Private Fields
        private ContractType type = ContractType.Patternized;
        private string argument = string.Empty;
        private bool caseSensitive = false;
        private string description = string.Empty;
        private int parameters = -1;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the type of the contract. Default value is Patternized.
        /// </summary>
        [XmlElement(Order = 0)]
        [Description("Type of the option contract.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(ContractType.Patternized)]
        public ContractType Type
        {
            get { return this.type; }
            set
            {
                ContractType oldValue = this.type;
                this.type = value;
                this.NotifyPropertyChanged("Type", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the argument of the contract. It must be specified when the
        /// type of the contract is Exact. It can be ignored when the
        /// type of the contract is not Exact.
        /// </summary>
        [XmlElement(Order = 1)]
        [Description("The argument of the contract.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        public string Argument
        {
            get { return this.argument; }
            set
            {
                string oldValue = this.argument;
                this.argument = value;
                this.NotifyPropertyChanged("Argument", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets a System.Boolean value that indicates whether the argument
        /// should be case sensitive.
        /// </summary>
        [XmlElement(Order = 2)]
        [Description("Indicates if the option contract is case-sensitive.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool CaseSensitive
        {
            get { return this.caseSensitive; }
            set
            {
                bool oldValue = this.caseSensitive;
                this.caseSensitive = value;
                this.NotifyPropertyChanged("CaseSensitive", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the description of the contract. This description will be
        /// used to generate the help documentation.
        /// </summary>
        [XmlElement(Order = 3)]
        [Description("The description of the option contract.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string Description
        {
            get { return this.description; }
            set
            {
                string oldValue = this.description;
                this.description = value;
                this.NotifyPropertyChanged("Description", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets an integral value that indicates the number of parameters
        /// within the option contract syntax.
        /// </summary>
        [XmlElement(Order = 4)]
        [Description("Indicates the number of parameters.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(-1)]
        public int Parameters
        {
            get { return this.parameters; }
            set
            {
                int oldValue = this.parameters;
                this.parameters = value;
                this.NotifyPropertyChanged("Parameters", oldValue, value);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the attribute with default values.
        /// </summary>
        public OptionContractAttribute()
        {
            //this.Type = ContractType.Patternized;
            //this.Argument = string.Empty;
            //this.CaseSensitive = false;
            //this.Description = string.Empty;
            //this.Parameters = -1;
        }
        #endregion
    }
}
