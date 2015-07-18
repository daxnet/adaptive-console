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

using System.Collections.Generic;
using AdaptiveConsole.DesignModel;

namespace AcfEditor.Domain
{
    /// <summary>
    /// Represents a collection of the option contract settings.
    /// </summary>
    public class ApplicationContractSettings : AttributeEventProvider, ICollection<ContractSetting>
    {
        #region Private Fields
        /// <summary>
        /// The list which holds a list of contract settings.
        /// </summary>
        private IList<ContractSetting> contractSettings = new List<ContractSetting>();
        #endregion

        #region ICollection<ContractSetting> Members
        /// <summary>
        /// Adds a specific item to the collection.
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void Add(ContractSetting item)
        {
            contractSettings.Add(item);
            this.NotifyPropertyChanged();
        }

        /// <summary>
        /// Clears all the entries in the collection.
        /// </summary>
        public void Clear()
        {
            contractSettings.Clear();
            this.NotifyPropertyChanged();
        }
        /// <summary>
        /// Determines whether the collection contains a specific item.
        /// </summary>
        /// <param name="item">The item to be checked.</param>
        /// <returns>True if the collection contains the item, otherwise false.</returns>
        public bool Contains(ContractSetting item)
        {
            return contractSettings.Contains(item);
        }
        /// <summary>
        /// Copies elements from specific index within the array.
        /// </summary>
        /// <param name="array">The array to which the elements are copied.</param>
        /// <param name="arrayIndex">The index from which the elements are copied.</param>
        public void CopyTo(ContractSetting[] array, int arrayIndex)
        {
            contractSettings.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Gets the count of items in the collection.
        /// </summary>
        public int Count
        {
            get { return contractSettings.Count; }
        }
        /// <summary>
        /// Checks if it is readonly.
        /// </summary>
        public bool IsReadOnly
        {
            get { return contractSettings.IsReadOnly; }
        }
        /// <summary>
        /// Removes the specific item from the collection.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        /// <returns>True if successfully removed. Otherwise false.</returns>
        public bool Remove(ContractSetting item)
        {
            bool success = contractSettings.Remove(item);
            this.NotifyPropertyChanged();
            return success;
        }

        #endregion

        #region IEnumerable<ContractSetting> Members
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<ContractSetting> GetEnumerator()
        {
            return contractSettings.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return contractSettings.GetEnumerator();
        }

        #endregion
    }
}
