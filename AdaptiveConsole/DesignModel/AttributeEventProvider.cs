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
    /// Represents the event model of the changing of the properties.
    /// </summary>
    public abstract class AttributeEventProvider : Attribute
    {
        #region Events
        /// <summary>
        /// Occurs when any property of the editor project is changed.
        /// </summary>
        public event EventHandler<PropertyChangedEventArgs> PropertyChanged
        {
            add
            {
                lock (syncRoot)
                {
                    propertyChanged += value;
                }
            }
            remove
            {
                lock (syncRoot)
                {
                    propertyChanged -= value;
                }
            }
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// The delegate which represents the changing of the property.
        /// </summary>
        private EventHandler<PropertyChangedEventArgs> propertyChanged;
        /// <summary>
        /// The synchronization reference.
        /// </summary>
        private readonly object syncRoot = new object();
        #endregion

        #region Protected Methods
        /// <summary>
        /// The wrapper of the event process.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The parameter.</param>
        protected virtual void DoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler<PropertyChangedEventArgs> temp = propertyChanged;
            if (temp != null)
                temp(sender, e);
        }
        /// <summary>
        /// Notifies the changing of the property.
        /// </summary>
        /// <param name="propertyName">Name of the property to be changed.</param>
        /// <param name="oldValue">Old value of the property.</param>
        /// <param name="newValue">New value of the property.</param>
        protected virtual void NotifyPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);
            if (propertyInfo != null)
            {
                DoPropertyChanged(this, new PropertyChangedEventArgs(propertyInfo, oldValue, newValue));
            }
        }
        /// <summary>
        /// Notifies the changing of the property without any property value changes.
        /// </summary>
        /// <remarks>This method can be used for notifying the change of the property
        /// which doesn't carry any property value. For example, the add or remove of
        /// the item in a collection.</remarks>
        protected virtual void NotifyPropertyChanged()
        {
            DoPropertyChanged(this, null);
        }
        #endregion
    }
}
