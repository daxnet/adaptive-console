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
    /// Represents the setting of an option contract.
    /// </summary>
    [Serializable]
    public class ContractSetting : AdaptiveConsole.DesignModel.AttributeEventProvider
    {
        #region Private Fields
        /// <summary>
        /// Name of the contract.
        /// </summary>
        private string name;
        /// <summary>
        /// The attribute settings of the contract.
        /// </summary>
        private OptionContractAttribute attributes;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the instance of the EditorProject to which
        /// the contract setting is attached.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public EditorProject Project { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the option contract. This will be used
        /// for the class name of the contract.
        /// </summary>
        [XmlElement(Order = 0)]
        [Description("The name of the option contract. This will be used " +
                    "for the class name of the contract.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Trim().Equals(string.Empty))
                    throw new ArgumentNullException("The name of the contract cannot be empty.");
                if (!(new Regex(EditorProject.NAME_PATTERN).Match(value)).Success)
                    throw new ArgumentException("The name of the contract must be in the specific format.");
                string oldValue = this.name;
                this.name = value;
                this.NotifyPropertyChanged("Name", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the detailed settings of the option contract.
        /// </summary>
        [XmlElement(Order = 1)]
        [Description("The detailed settings of the option contract.")]
        [Category("Settings")]
        [ReadOnly(false)]
        [Browsable(true)]
        public OptionContractAttribute Attributes
        {
            get { return this.attributes; }
            set
            {
                OptionContractAttribute oldValue = this.attributes;
                this.attributes = value;
                this.NotifyPropertyChanged("Attributes", oldValue, value);
            }
        }
        /// <summary>
        /// Gets or sets the instance which holds a collection of the option settings.
        /// </summary>
        [XmlArray(Order = 2)]
        [Browsable(false)]
        public ContractOptionSettings ContractOptionSettings { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the contract setting composite. This will also
        /// initializes all the sub objects within it.
        /// </summary>
        internal ContractSetting()
        {
            this.Attributes = new OptionContractAttribute();
            this.ContractOptionSettings = new ContractOptionSettings();
        }

        /// <summary>
        /// Initializes the contract setting composite with the given
        /// EditorProject instance. This will attach the event handler
        /// to the EditorProject's PropertyChangedHandler.
        /// </summary>
        /// <param name="project">The EditorProject instance
        /// to which the contract setting is attached.</param>
        public ContractSetting(EditorProject project)
            : this()
        {
            this.Project = project;
            this.PropertyChanged += project.RaisePropertyChangedHandler;
            this.attributes.PropertyChanged += project.RaisePropertyChangedHandler;
        }

        /// <summary>
        /// Initializes the contract setting composite with the given
        /// EditorProject instance and name. This will attach the event
        /// handler to the EditorProject's PropertyChangedHandler, and
        /// give a name to the contract.
        /// </summary>
        /// <param name="project">The EditorProject instance to
        /// which the contract setting is attached.</param>
        /// <param name="name">The name of the contract.</param>
        public ContractSetting(EditorProject project, string name)
            : this(project)
        {
            this.Name = name;
        }
        #endregion
    }
}
