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
 * 9/20/2008     Added Default field on option          3.5.3182.35766  Sunny Chen
 * ---------------------------------------------------------------------------- */

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace AdaptiveConsole
{
    #region Public Enumeration
    /// <summary>
    /// Type of the option.
    /// </summary>
    public enum OptionType
    {
        /// <summary>
        /// Indicates the option is a single value option.
        /// </summary>
        /// <example>
        /// Following examples are the single value options:
        /// 
        /// /output:test.xml
        /// /type:classes
        /// /language:vb
        /// </example>
        SingleValue,
        /// <summary>
        /// Indicates the option is a value list option. That means
        /// the option carries multiple values.
        /// </summary>
        /// <example>
        /// Following examples are the value list options:
        /// 
        /// /input:a.xsd,b.xsd,c.xsd
        /// /include:stdio.h,stdlib.h
        /// /references:System.dll,System.Configuration.dll
        /// </example>
        ValueList,
        /// <summary>
        /// Indicates the option is a switch.
        /// </summary>
        /// <example>
        /// Followings are the switches:
        /// 
        /// /verbose
        /// /nologo
        /// /silent
        /// </example>
        Switch
    }
    #endregion

    /// <summary>
    /// Represents the custom attribute that identifies an option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class OptionAttribute : DesignModel.AttributeEventProvider
    {
        #region Private Fields
        private string name = string.Empty;
        private string description = string.Empty;
        private OptionType type = OptionType.SingleValue;
        private bool required = true;
        private bool caseSensitive = false;
        private char valueSeparator = ',';
        private string @default = string.Empty;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the name of the option.
        /// </summary>
        [XmlElement(Order = 0)]
        [Description("Name of the option.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        public string Name
        {
            get { return this.name; }
            set
            {
                string oldValue = this.name;
                this.name = value;
                this.NotifyPropertyChanged("Name", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the description of the option. This description will be 
        /// used to generate help documentation.
        /// </summary>
        [XmlElement(Order = 1)]
        [Description("Description of the option.")]
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
        /// Gets or sets the type of the option. Default value is SingleValue.
        /// </summary>
        [XmlElement(Order = 2)]
        [Description("Type of the option")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(OptionType.SingleValue)]
        public OptionType Type
        {
            get { return this.type; }
            set
            {
                OptionType oldValue = this.type;
                this.type = value;
                this.NotifyPropertyChanged("Type", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets a System.Boolean value that indicates whether the option
        /// is required. Default value is True.
        /// </summary>
        [XmlElement(Order = 3)]
        [Description("Indicates if the option is required.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool Required
        {
            get { return this.required; }
            set
            {
                bool oldValue = this.required;
                this.required = value;
                this.NotifyPropertyChanged("Required", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets a System.Boolean value that indicates whether the option
        /// is case sensitive. Default value is False.
        /// </summary>
        [XmlElement(Order = 4)]
        [Description("Indicates if the option is case-sensitive.")]
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
        /// Gets or sets the separator character which will be used by the option
        /// with the type of ValueList.
        /// </summary>
        [XmlElement(Order = 5)]
        [Description("Specifies the separator character which will be used " +
                    "by ValueList options.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(',')]
        public char ValueSeparator
        {
            get { return this.valueSeparator; }
            set
            {
                char oldValue = this.valueSeparator;
                this.valueSeparator = value;
                this.NotifyPropertyChanged("ValueSeparator", oldValue, value);
            }
        }
        // Sunny Chen Added Begin - 9/20/2008 - Added for handling the Default field on the option.
        /// <summary>
        /// Gets or sets a value which is for providing the default value when
        /// the option is not required.
        /// </summary>
        [XmlElement(Order = 6)]
        [Description("Specifies the default value of the option when its Required " +
                    "property is set to false.")]
        [Category("Behavior")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        public string Default
        {
            get { return this.@default; }
            set
            {
                string oldValue = this.@default;
                this.@default = value;
                this.NotifyPropertyChanged("Default", oldValue, value);
            }
        }
        // Sunny Chen Added End
        #endregion

        #region Constructors

        #endregion
    }
}
