using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcfEditor.Domain;

namespace acfeditor.Handlers
{
    internal sealed class OptionNameChangedHandler : PropertyChangedHandlerBase
    {
        public override Type TargetType
        {
            get { return typeof(OptionSetting); }
        }

        public override System.Reflection.PropertyInfo Property
        {
            get { return typeof(OptionSetting).GetProperty("PropertyName"); }
        }

        protected override void DoHandle(
            System.Windows.Forms.TreeNode treeNode,
            object target,
            object oldValue, 
            object newValue, 
            ref string sourceCode)
        {
            treeNode.Text = newValue.ToString();
            sourceCode = string.Empty;
        }
    }
}
