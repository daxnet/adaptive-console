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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace acfeditor.Handlers
{
    /// <summary>
    /// The base class of the classes which are responsible for handling
    /// the change of the property on a specific object in the project.
    /// </summary>
    internal abstract class PropertyChangedHandlerBase
    {
        #region Private Static Fields
        /// <summary>
        /// The list of the PropertyChangedHandlerBase instance.
        /// </summary>
        private static volatile HashSet<PropertyChangedHandlerBase> handlers;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the type of the object on which the property was changed.
        /// </summary>
        public abstract Type TargetType { get; }
        /// <summary>
        /// Gets the detailed information of the property which was changed.
        /// </summary>
        public abstract PropertyInfo Property { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Handles the change of the property.
        /// </summary>
        /// <param name="treeNode">
        /// The UI TreeNode on which the object was attached.</param>
        /// <param name="oldValue">The value before the property was changed.</param>
        /// <param name="newValue">The value after the property 
        /// has been changed.</param>
        /// <param name="sourceCode">The source code generated because 
        /// of the changing of the property.</param>
        public void Handle(TreeNode treeNode,
            object target,
            object oldValue,
            object newValue,
            ref string sourceCode)
        {
            //if (target != null &&
            //    this.TargetType != target.GetType())
            //    throw new InvalidOperationException("The type of the target doesn't match the specified type.");
            
            if (this.Property != null)
            {
                if (this.Property.DeclaringType != this.TargetType)
                    throw new InvalidOperationException("The declaring type of the property doesn't match the target type.");

                if (oldValue != null &&
                    this.Property.PropertyType != oldValue.GetType())
                    throw new InvalidOperationException("The type of oldValue doesn't match the property type.");

                if (newValue != null &&
                    this.Property.PropertyType != newValue.GetType())
                    throw new InvalidOperationException("The type of newValue doesn't match the property type.");
                
                //if (this.Property.PropertyType != oldValue.GetType() ||
                //    this.Property.PropertyType != newValue.GetType())
                //    throw new InvalidOperationException("The type of either oldValue or newValue doesn't match the property type.");
            }
            this.DoHandle(treeNode, target, oldValue, newValue, ref sourceCode);
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return this.TargetType.GetHashCode() ^
                this.Property.GetHashCode();
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Handles the change of the property.
        /// </summary>
        /// <param name="treeNode">
        /// The UI TreeNode on which the object was attached.</param>
        /// <param name="target">The target on which the property was changed.</param>
        /// <param name="oldValue">The value before the property was changed.</param>
        /// <param name="newValue">The value after the property 
        /// has been changed.</param>
        /// <param name="sourceCode">The source code generated because 
        /// of the changing of the property.</param>
        protected abstract void DoHandle(TreeNode treeNode,
            object target,
            object oldValue,
            object newValue,
            ref string sourceCode);
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Get the handler according to the target type and
        /// the detailed property information.
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns></returns>
        public static PropertyChangedHandlerBase GetHandler(
            Type targetType, 
            PropertyInfo propertyInfo)
        {
            if (handlers == null)
                handlers = new HashSet<PropertyChangedHandlerBase>();

            if (handlers.Count == 0)
            {
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (type != typeof(PropertyChangedHandlerBase) &&
                        type.IsSubclassOf(typeof(PropertyChangedHandlerBase)) &&
                        !type.IsAbstract)
                    {
                        PropertyChangedHandlerBase @base =
                            (PropertyChangedHandlerBase)
                            Activator.CreateInstance(type);
                        handlers.Add(@base);
                    }
                }
            }
            var query = from handler in handlers
                        where handler.Property.Equals(propertyInfo) &&
                        handler.TargetType.Equals(targetType)
                        select handler;
            if (query.Count() == 0)
                return null;
            return query.First();
        }
        #endregion
    }
}
