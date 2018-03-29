/* ----------------------------------------------------------------------------
 * AdaptiveConsole - A flexable console application framework.
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
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
using System.Reflection;

namespace AdaptiveConsole.DesignModel
{
    /// <summary>
    /// Represents event handler arguments that identify the changing
    /// of a property.
    /// </summary>
    public class PropertyChangedEventArgs : EventArgs
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the information on the property which
        /// was just changed.
        /// </summary>
        public PropertyInfo Property { get; set; }
        /// <summary>
        /// Gets or sets the value of the property which was before
        /// the changing.
        /// </summary>
        public object OldValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the property which was after
        /// the changing.
        /// </summary>
        public object NewValue { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public PropertyChangedEventArgs()
        {
            this.Property = null;
            this.OldValue = null;
            this.NewValue = null;
        }

        /// <summary>
        /// Initializes the object with the given property information.
        /// </summary>
        /// <param name="property">The property information which is used to
        /// initialize the object.</param>
        public PropertyChangedEventArgs(PropertyInfo property)
        {
            this.Property = property;
            this.OldValue = null;
            this.NewValue = null;
        }

        /// <summary>
        /// Initializes the object with the given property information, the old and new
        /// values of the property.
        /// </summary>
        /// <param name="property">The property information which is used to
        /// initialize the object.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        public PropertyChangedEventArgs(PropertyInfo property, object oldValue, object newValue)
        {
            this.Property = property;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
        #endregion
    }
}
