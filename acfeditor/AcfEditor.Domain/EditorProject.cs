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
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using AdaptiveConsole.DesignModel;

namespace AcfEditor.Domain
{
    /// <summary>
    /// Represents the programming language of the source code.
    /// </summary>
    public enum ProgrammingLanguage
    {
        /// <summary>
        /// C# language.
        /// </summary>
        CSharp = 0,
        /// <summary>
        /// Visual Basic language.
        /// </summary>
        VisualBasic
    }

    /// <summary>
    /// Represents the ACF Editor Project.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public class EditorProject : AttributeEventProvider
    {

        #region Private Fields
        /// <summary>
        /// Name of the editor project.
        /// </summary>
        private string name = string.Empty;
        /// <summary>
        /// Creation date of the project.
        /// </summary>
        private DateTime createdDate = DateTime.Now;
        /// <summary>
        /// The application provider settings.
        /// </summary>
        private ApplicationProviderSettings applicationProviderSettings 
            = new ApplicationProviderSettings();
        /// <summary>
        /// The application contract settings.
        /// </summary>
        private ApplicationContractSettings applicationContractSettings
            = new ApplicationContractSettings();
        /// <summary>
        /// The referenced assembly settings.
        /// </summary>
        private ReferencedAssembliesSettings referencedAssembliesSettings
            = new ReferencedAssembliesSettings();
        /// <summary>
        /// The programming language which is used in the project.
        /// </summary>
        private ProgrammingLanguage language = ProgrammingLanguage.CSharp;
        /// <summary>
        /// The title of the assembly.
        /// </summary>
        private string assemblyTitle = string.Empty;
        /// <summary>
        /// The description of the assembly.
        /// </summary>
        private string assemblyDescription = string.Empty;
        /// <summary>
        /// The company of the assembly.
        /// </summary>
        private string assemblyCompany = string.Empty;
        /// <summary>
        /// The product of the assembly.
        /// </summary>
        private string assemblyProduct = string.Empty;
        /// <summary>
        /// The copyright information of the assembly.
        /// </summary>
        private string assemblyCopyright = string.Empty;
        /// <summary>
        /// The version information of the assembly.
        /// </summary>
        private string assemblyVersion = string.Empty;
        /// <summary>
        /// The directory on which the project is working.
        /// </summary>
        private string projectDirectory = string.Empty;

        #endregion

        #region Public Constants
        /// <summary>
        /// The regular expression pattern which identifies a object name.
        /// (The first character is a letter or underscore, and all other
        /// letters could be a letter, a digit or underscore)
        /// </summary>
        public const string NAME_PATTERN = "^[a-zA-Z_][a-zA-Z0-9_]*";
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuppressRaisePropertyChangedEvent(object sender,
            AdaptiveConsole.DesignModel.PropertyChangedEventArgs e)
        {
            this.Modified = true;
        }
        
        /// <summary>
        /// Update status and raise the event when the property of any object
        /// within the project is updated.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event argument.</param>
        private void RaisePropertyChangedEvent(object sender, 
            AdaptiveConsole.DesignModel.PropertyChangedEventArgs e)
        {
            this.SuppressRaisePropertyChangedEvent(sender, e);
            this.DoPropertyChanged(sender, e);
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Initialzes and Attaches the event handler to each of the object
        /// within the project.
        /// </summary>
        internal void InitAttachEventHandler()
        {
            this.PropertyChanged += SuppressRaisePropertyChangedHandler;

            this.applicationProviderSettings.PropertyChanged += RaisePropertyChangedHandler;
            this.applicationContractSettings.PropertyChanged += RaisePropertyChangedHandler;

            foreach (ContractSetting contractSetting in this.applicationContractSettings)
            {
                foreach (OptionSetting optionSetting in contractSetting.ContractOptionSettings)
                {
                    optionSetting.PropertyChanged += RaisePropertyChangedHandler;
                    optionSetting.Attributes.PropertyChanged += RaisePropertyChangedHandler;
                }
                contractSetting.PropertyChanged += RaisePropertyChangedHandler;
                contractSetting.Attributes.PropertyChanged += RaisePropertyChangedHandler;
                contractSetting.ContractOptionSettings.PropertyChanged += RaisePropertyChangedHandler;
            }

            this.referencedAssembliesSettings.PropertyChanged += RaisePropertyChangedHandler;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the file name of the project.
        /// </summary>
        [XmlIgnore]
        [Browsable(true)]
        [Description("Represents the file name of the project.")]
        [Category("Basic Information")]
        [ReadOnly(true)]
        public string FileName
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets the value which indicates if the programming language
        /// used by the project is case sensitive.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public bool CaseSensitive
        {
            get { return this.language == ProgrammingLanguage.CSharp; }
        }
        /// <summary>
        /// Gets or sets the event handler for handling the changing of the
        /// properties.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public EventHandler<AdaptiveConsole.DesignModel.PropertyChangedEventArgs> 
            RaisePropertyChangedHandler { get; set; }

        /// <summary>
        /// Gets or sets the event handler which suppress the raising of the
        /// event.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public EventHandler<AdaptiveConsole.DesignModel.PropertyChangedEventArgs>
            SuppressRaisePropertyChangedHandler { get; set; }

        /// <summary>
        /// Gets or sets the value which indicates if the project has been changed.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public bool Modified { get; set; }
        /// <summary>
        /// Gets or sets the name of the editor project.
        /// </summary>
        [XmlElement(Order = 0)]
        [Description("The name of the project, it is just for identifying " +
                     "the editor project. It is not the name of the console " +
                     "application that you wish to build.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Trim().Equals(string.Empty))
                    throw new ArgumentNullException("The name of the project cannot be empty.");
                if (!(new Regex(EditorProject.NAME_PATTERN).Match(value)).Success)
                    throw new ArgumentException("The name of the project must be in the specific format.");
                string oldValue = this.name;
                this.name = value;
                this.NotifyPropertyChanged("Name", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the creation date of the editor project.
        /// </summary>
        [XmlElement(Order = 1)]
        [Description("The creation date of the project.")]
        [Category("Basic Information")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Creation Date")]
        public DateTime CreatedDate
        {
            get
            {
                return this.createdDate;
            }
            set
            {
                DateTime oldValue = this.createdDate;
                this.createdDate = value;
                this.NotifyPropertyChanged("CreatedDate", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the settings of the console application provider.
        /// </summary>
        [XmlElement(Order = 2)]
        [Browsable(false)]
        public ApplicationProviderSettings ApplicationProviderSettings
        {
            get
            {
                return this.applicationProviderSettings;
            }
            set
            {
                this.applicationProviderSettings = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the settings of the application contracts.
        /// </summary>
        [XmlArray(Order = 3)]
        [Browsable(false)]
        public ApplicationContractSettings ApplicationContractSettings
        {
            get
            {
                return this.applicationContractSettings;
            }
            set
            {
                this.applicationContractSettings = value;
            }
        }

        /// <summary>
        /// Gets or sets the referenced assemblies list.
        /// </summary>
        [XmlArray(Order = 4)]
        [XmlArrayItem(ElementName = "ReferencedAssembly")]
        [Browsable(false)]
        public ReferencedAssembliesSettings ReferencedAssembliesSettings
        {
            get
            {
                return this.referencedAssembliesSettings;
            }
            set
            {
                this.referencedAssembliesSettings = value;
            }
        }

        /// <summary>
        /// Gets or sets the programming language of the source code.
        /// </summary>
        [XmlElement(Order = 5)]
        [Description("The programming language of the source code " +
            "which is going to be generated.")]
        [Category("Compiler Options")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue(ProgrammingLanguage.CSharp)]
        public ProgrammingLanguage Language
        {
            get
            {
                return this.language;
            }
            set
            {
                ProgrammingLanguage oldValue = this.language;
                this.language = value;
                this.NotifyPropertyChanged("Language", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the title of the entry assembly.
        /// </summary>
        [XmlElement(Order = 6)]
        [Description("Specifies the value of AssemblyTitleAttribute for the entry assembly.")]
        [Category("Assembly Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [DisplayName("Title")]
        public string AssemblyTitle
        {
            get
            {
                return this.assemblyTitle;
            }
            set
            {
                string oldValue = this.assemblyTitle;
                this.assemblyTitle = value;
                this.NotifyPropertyChanged("AssemblyTitle", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the description of the entry assembly.
        /// </summary>
        [XmlElement(Order = 7)]
        [Description("Specifies the value of AssemblyDescriptionAttribute for the entry assembly.")]
        [Category("Assembly Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [DisplayName("Description")]
        public string AssemblyDescription
        {
            get { return this.assemblyDescription; }
            set
            {
                string oldValue = this.assemblyDescription;
                this.assemblyDescription = value;
                this.NotifyPropertyChanged("AssemblyDescription", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the company information of the entry assembly.
        /// </summary>
        [XmlElement(Order = 8)]
        [Description("Specifies the value of AssemblyCompanyAttribute for the entry assembly.")]
        [Category("Assembly Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [DisplayName("Company")]
        public string AssemblyCompany
        {
            get { return this.assemblyCompany; }
            set
            {
                string oldValue = this.assemblyCompany;
                this.assemblyCompany = value;
                this.NotifyPropertyChanged("AssemblyCompany", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the product information of the entry assembly.
        /// </summary>
        [XmlElement(Order = 9)]
        [Description("Specifies the value of AssemblyProductAttribute for the entry assembly.")]
        [Category("Assembly Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [DisplayName("Product")]
        public string AssemblyProduct
        {
            get { return this.assemblyProduct; }
            set
            {
                string oldValue = this.assemblyProduct;
                this.assemblyProduct = value;
                this.NotifyPropertyChanged("AssemblyProduct", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the copyright information of the entry assembly.
        /// </summary>
        [XmlElement(Order = 10)]
        [Description("Specifies the value of AssemblyCopyrightAttribute for the entry assembly.")]
        [Category("Assembly Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [DisplayName("Copyright")]
        public string AssemblyCopyright
        {
            get { return this.assemblyCopyright; }
            set
            {
                string oldValue = this.assemblyCopyright;
                this.assemblyCopyright = value;
                this.NotifyPropertyChanged("AssemblyCopyright", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the version information of the entry assembly.
        /// </summary>
        [XmlElement(Order = 11)]
        [Description("Specifies the value of AssemblyVersionAttribute for the entry assembly.")]
        [Category("Assembly Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("1.0.0.0")]
        [DisplayName("Version")]
        public string AssemblyVersion
        {
            get { return this.assemblyVersion; }
            set
            {
                string oldValue = this.assemblyVersion;
                this.assemblyVersion = value;
                this.NotifyPropertyChanged("AssemblyVersion", oldValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the project working directory.
        /// </summary>
        [XmlElement(Order=12)]
        [Description("Specifies the working directory of the project.")]
        [Category("Basic Information")]
        [ReadOnly(false)]
        [Browsable(true)]
        [DefaultValue("")]
        [DisplayName("Project Directory")]
        [Editor(typeof(System.Windows.Forms.Design.FolderNameEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        public string ProjectDirectory
        {
            get { return this.projectDirectory; }
            set
            {
                string oldValue = this.projectDirectory;
                this.projectDirectory = value;
                this.NotifyPropertyChanged("ProjectDirectory", oldValue, value);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the new instance.
        /// </summary>
        protected EditorProject()
        {
            RaisePropertyChangedHandler 
                = new EventHandler<AdaptiveConsole.DesignModel.PropertyChangedEventArgs>(this.RaisePropertyChangedEvent);
            SuppressRaisePropertyChangedHandler
                = new EventHandler<AdaptiveConsole.DesignModel.PropertyChangedEventArgs>(this.SuppressRaisePropertyChangedEvent);
            this.CreatedDate = DateTime.Now;
            this.Name = "NONAME";
            this.FileName = string.Empty;
            this.Modified = false;
            this.language = ProgrammingLanguage.CSharp;
            this.assemblyVersion = "1.0.0.0";
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Serialzes and saves the project.
        /// </summary>
        /// <param name="fileName">The file to which the project is saved.</param>
        /// <param name="project">The project which is going to be saved.</param>
        public static void Save(string fileName, EditorProject project)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(EditorProject));
                serializer.Serialize(fileStream, project);
                project.Modified = false;
                project.FileName = fileName;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        /// <summary>
        /// Deserializes and loads the project.
        /// </summary>
        /// <param name="fileName">The file from which the project is loaded.</param>
        /// <returns>The loaded project.</returns>
        public static EditorProject Load(string fileName)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(EditorProject));
                EditorProject result = (EditorProject)serializer.Deserialize(fileStream);
                result.InitAttachEventHandler();
                result.Modified = false;
                result.FileName = fileName;
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }
        /// <summary>
        /// Initializes and creates a new instance of the editor project
        /// by using the default name.
        /// </summary>
        /// <returns>The newly created instance object.</returns>
        [Obsolete("This method is now obsolete.", false)]
        public static EditorProject Create()
        {
            EditorProject editorProject = new EditorProject();
            editorProject.Language = ProgrammingLanguage.CSharp;
            editorProject.ReferencedAssembliesSettings = new ReferencedAssembliesSettings();
            editorProject.ApplicationContractSettings = new ApplicationContractSettings();
            editorProject.ApplicationProviderSettings = new ApplicationProviderSettings();
            editorProject.InitAttachEventHandler();
            return editorProject;
        }

        /// <summary>
        /// Initializes and creates a new instance of the editor project
        /// by the given project name.
        /// </summary>
        /// <param name="name">Name of the project.</param>
        /// <returns>The newly created instance object.</returns>
        public static EditorProject Create(string name)
        {
            EditorProject editorProject = new EditorProject();
            editorProject.Language = ProgrammingLanguage.CSharp;
            editorProject.ReferencedAssembliesSettings = new ReferencedAssembliesSettings();
            editorProject.ApplicationContractSettings = new ApplicationContractSettings();
            editorProject.ApplicationProviderSettings = new ApplicationProviderSettings();
            editorProject.Name = name;
            editorProject.InitAttachEventHandler();
            return editorProject;
        }
        #endregion
    }
}
