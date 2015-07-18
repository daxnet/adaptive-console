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
 * 11/27/2008    Modified                               3.5.3253.15384  Sunny Chen
 * 7/18/2015     Modified                               4.5             Sunny Chen
 * ---------------------------------------------------------------------------- */

using System.Configuration;

namespace AdaptiveConsole.Config
{
    /// <summary>
    /// Provides the configuration handler for the AdaptiveConsole application.
    /// </summary>
    public class AdaptiveConsoleConfiguration : ConfigurationSection
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the configuration of the console application provider.
        /// </summary>
        [ConfigurationProperty("provider", IsRequired = true)]
        public string Provider
        {
            get { return (string)base["provider"]; }
            set { base["provider"] = value; }
        }

        ///// <summary>
        ///// Gets or sets the template string of the Banner.
        ///// </summary>
        //[ConfigurationProperty("bannerTemplate", IsRequired = false)]
        //public string BannerTemplate
        //{
        //    get { return (string)base["bannerTemplate"]; }
        //    set { base["bannerTemplate"] = value; }
        //}

        ///// <summary>
        ///// Gets or sets the template string of the syntax description lines.
        ///// </summary>
        //[ConfigurationProperty("syntaxDescriptionTemplate", IsRequired = false)]
        //public string SyntaxDescriptionTemplate
        //{
        //    get { return (string)base["syntaxDescriptionTemplate"]; }
        //    set { base["syntaxDescriptionTemplate"] = value; }
        //}

        ///// <summary>
        ///// Gets or sets the configuration of the contract repository.
        ///// </summary>
        // Sunny Chen Commented Begin (3.5.3253.15384: 11/27/2008): 
        // Use multiple repositories rather than one.
        //
        //[ConfigurationProperty("contractRepository", IsRequired=true)]
        //public string ContractRepository
        //{
        //    get { return (string)base["contractRepository"]; }
        //    set { base["contractRepository"] = value; }
        //}
        //
        // Sunny Chen Commented End
        
        /// <summary>
        /// Gets or sets the collection of the configuration elements.
        /// </summary>
        [ConfigurationProperty("repositories", IsRequired=true)]
        public RepositoryConfigElementCollection Repositories
        {
            get { return (RepositoryConfigElementCollection)base["repositories"]; }
            set { base["repositories"] = value; }
        }
        #endregion
    }
}
