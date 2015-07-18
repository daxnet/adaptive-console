using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcfEditor.Domain;

namespace acfeditor.Handlers
{
    internal sealed class ContractNameChangedHandler : PropertyChangedHandlerBase
    {
        public override Type TargetType
        {
            get { return typeof(ContractSetting); }
        }

        public override System.Reflection.PropertyInfo Property
        {
            get { return typeof(ContractSetting).GetProperty("Name"); }
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
