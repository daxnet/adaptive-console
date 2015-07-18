/* ----------------------------------------------------------------------------
 * ACF Editor - The Editor for Adaptive Console Framework
 * Copyright (C) 2007-2009 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 12/30/2008
 * 
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION         UPDATED_BY
 * 12/30/2008    Created                                3.5.3286.17617  Sunny Chen
 * ---------------------------------------------------------------------------- */

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using AdaptiveConsole;

namespace AcfEditor.Domain
{
    /// <summary>
    /// Represents different types of contract options.
    /// </summary>
    [Serializable]
    public enum ContractOptionTypes
    {
        /// <summary>
        /// The System.String type.
        /// </summary>
        String = 0,
        /// <summary>
        /// The System.Array type.
        /// </summary>
        Array,
        /// <summary>
        /// The System.Boolean type.
        /// </summary>
        Boolean
    }

    /// <summary>
    /// Represents the settings for an option.
    /// </summary>
    [Serializable]
    public class OptionSetting : AdaptiveConsole.DesignModel.AttributeEventProvider
    {
        #region Public Fields
        /// <summary>
        /// The types of contract options represented by System.Type type.
        /// </summary>
        public static readonly Type[] OptionTypes = new Type[]
            {
                typeof(string),
                typeof(Array),
                typeof(bool)
            };
        #endregion

        #region Private Fields
        /// <summary>
        /// Name of the property which represents the option.
        /// </summary>
        private string propertyName = string.Empty;
        /// <summary>
        /// Type of the property which represents the option.
        /// </summary>
        private ContractOptionTypes propertyType = ContractOptionTypes.String;
        /// <summary>
        /// The detailed option attribute settings.
        /// </summary>
        private OptionAttribute attributes = new OptionAttribute();
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the instance of the EditorProject to which
        /// the option setting is attached.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public EditorProject Project { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the property which identifies an option.
        /// </summary>
        [XmlElement(Order = 0)]
        [Description("Name of the property which identifies an option.")]
        [Category("Property Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DisplayName("Name")]
        public string PropertyName
        {
            get { return this.propertyName; }
            set
            {
                if (value.Trim().Equals(string.Empty))
                    throw new ArgumentNullException("The name of the option cannot be empty.");
                if (!(new Regex(EditorProject.NAME_PATTERN).Match(value)).Success)
                    throw new ArgumentException("The name of the option must be in the specific format.");
                string oldValue = this.propertyName;
                this.propertyName = value;
                this.NotifyPropertyChanged("PropertyName", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        [XmlElement(Order = 1)]
        [Description("Type of the property. This value will be changed automatically " +
            "when you have changed the type of the option attribute.")]
        [Category("Property Information")]
        [DefaultValue(ContractOptionTypes.String)]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Type")]
        public ContractOptionTypes PropertyType
        {
            get { return this.propertyType; }
            set
            {
                ContractOptionTypes oldValue = this.propertyType;
                this.propertyType = value;
                this.NotifyPropertyChanged("PropertyType", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the detailed settings of the option.
        /// </summary>
        [XmlElement(Order = 2)]
        [Description("The detailed settings of the option.")]
        [Category("Settings")]
        [ReadOnly(false)]
        [Browsable(true)]
        public OptionAttribute Attributes
        {
            get { return this.attributes; }
            set
            {
                OptionAttribute oldValue = this.attributes;
                this.attributes = value;
                this.NotifyPropertyChanged("Attributes", oldValue, value);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the option setting composite with default values.
        /// </summary>
        internal OptionSetting()
        {
            this.PropertyType = ContractOptionTypes.String;
            this.Attributes = new OptionAttribute();
        }

        /// <summary>
        /// Initializes the option setting composite with default values
        /// and the EditorProject instance to which the option setting
        /// is attached.
        /// </summary>
        /// <param name="project">The instance of EditorProject.</param>
        public OptionSetting(EditorProject project)
            : this()
        {
            this.Project = project;
            this.PropertyChanged += project.RaisePropertyChangedHandler;
            this.Attributes.PropertyChanged += project.RaisePropertyChangedHandler;
        }

        /// <summary>
        /// Initializes the option setting composite with default values
        /// and the given property name, and attach the option setting to
        /// the specified EditorProject's instance.
        /// </summary>
        /// <param name="project">The EditorProject's instance to which
        /// the option setting is attached.</param>
        /// <param name="propertyName">Name of the property which will
        /// be given to the option setting.</param>
        public OptionSetting(EditorProject project, string propertyName)
            : this(project)
        {
            this.propertyName = propertyName;
        }
        #endregion

    }
}
