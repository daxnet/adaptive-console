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
 * 11/27/2008    Created                                3.5.3253.15384  Sunny Chen
 * ---------------------------------------------------------------------------- */

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveConsole.Config
{
    /// <summary>
    /// Represents a configuration element for the repository.
    /// </summary>
    public class RepositoryConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name of the repository.
        /// </summary>
        [ConfigurationProperty("name", IsRequired=true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        /// <summary>
        /// Gets or sets the assembly which provides the repository.
        /// </summary>
        [ConfigurationProperty("assembly", IsRequired=true)]
        public string Assembly
        {
            get { return (string)base["assembly"]; }
            set { base["assembly"] = value; }
        }
    }
}
