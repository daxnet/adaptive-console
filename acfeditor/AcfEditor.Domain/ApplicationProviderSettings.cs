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
using System.Xml.Serialization;
using AdaptiveConsole.DesignModel;

namespace AcfEditor.Domain
{
    /// <summary>
    /// Represents the settings of the application provider.
    /// </summary>
    [Serializable]
    public class ApplicationProviderSettings : AttributeEventProvider
    {
        #region Private Fields
        /// <summary>
        /// Holds the logo of the console application.
        /// </summary>
        private string logo = string.Empty;
        /// <summary>
        /// Holds the description of the console application.
        /// </summary>
        private string description = string.Empty;
        /// <summary>
        /// Holds the banner template string of the console application.
        /// </summary>
        private string bannerTemplate = string.Empty;
        /// <summary>
        /// Holds the help body template string of the console application.
        /// </summary>
        private string helpbodyTemplate = string.Empty;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the Logo of the console application.
        /// </summary>
        [XmlElement(Order = 0)]
        [Description("The logo of the console application.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        public string Logo
        {
            get
            {
                return this.logo;
            }
            set
            {
                string oldValue = this.logo;
                this.logo = value;
                this.NotifyPropertyChanged("Logo", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the Description of the console application.
        /// </summary>
        [XmlElement(Order = 1)]
        [Description("The description of the console application.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                string oldValue = this.description;
                this.description = value;
                this.NotifyPropertyChanged("Description", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the template string of the banner.
        /// </summary>
        [XmlElement(Order = 2)]
        [Description("The template of the banner.")]
        [Category("Templates")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string BannerTemplate
        {
            get
            {
                return this.bannerTemplate;
            }
            set
            {
                string oldValue = this.bannerTemplate;
                this.bannerTemplate = value;
                this.NotifyPropertyChanged("BannerTemplate", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the template string of the help body.
        /// </summary>
        [XmlElement(Order = 3)]
        [Description("The template of the help body.")]
        [Category("Templates")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string HelpBodyTemplate
        {
            get
            {
                return this.helpbodyTemplate;
            }
            set
            {
                string oldValue = this.helpbodyTemplate;
                this.helpbodyTemplate = value;
                this.NotifyPropertyChanged("HelpBodyTemplate", oldValue, value);
            }
        }
        #endregion
    }
}
