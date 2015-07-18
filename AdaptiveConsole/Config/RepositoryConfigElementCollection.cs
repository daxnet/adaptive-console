using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AdaptiveConsole.Config
{
    /// <summary>
    /// Represents a collection of repository configuration element.
    /// </summary>
    [ConfigurationCollection(typeof(RepositoryConfigElement),
        CollectionType = ConfigurationElementCollectionType.BasicMap,
        AddItemName = "repository")]
    public class RepositoryConfigElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets or sets a repository configuration element by its index in the collection.
        /// </summary>
        /// <param name="index">Index of the element in the collection.</param>
        /// <returns>The repository configuration element.</returns>
        public RepositoryConfigElement this[int index]
        {
            get { return (RepositoryConfigElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);
                base.BaseAdd(index, value);
            }
        }
        /// <summary>
        /// Gets a repository configuration element by its name.
        /// </summary>
        /// <param name="name">Name of the element.</param>
        /// <returns>The repository configuration element.</returns>
        public new RepositoryConfigElement this[string name]
        {
            get { return (RepositoryConfigElement)base.BaseGet(name); }
        }

        /// <summary>
        /// Gets the collection type.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        /// <summary>
        /// Provides the method that creates the new instance of the element.
        /// </summary>
        /// <returns>The created new instance.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new RepositoryConfigElement();
        }

        /// <summary>
        /// Gets the key of the element.
        /// </summary>
        /// <param name="element">The element from which the key is obtained.</param>
        /// <returns>The key.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as RepositoryConfigElement).Name;
        }

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return "repository";
            }
        }
    }
}
