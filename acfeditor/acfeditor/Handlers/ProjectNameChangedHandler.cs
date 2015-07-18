using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcfEditor.Domain;
using SunnyChen.Common.Patterns.ExtendableMDI;
using System.Windows.Forms;

namespace acfeditor.Handlers
{
    internal sealed class ProjectNameChangedHandler : PropertyChangedHandlerBase
    {
        public override Type TargetType
        {
            get { return typeof(EditorProject); }
        }

        public override System.Reflection.PropertyInfo Property
        {
            get { return typeof(EditorProject).GetProperty("Name"); }
        }

        protected override void DoHandle(System.Windows.Forms.TreeNode treeNode, object target, object oldValue, object newValue, ref string sourceCode)
        {
            treeNode.Text = newValue.ToString();
            frmEditor formEditor = null;
            Control parent = treeNode.TreeView.Parent;
            while (parent != null)
            {
                if (parent is frmEditor)
                    break;
                parent = parent.Parent;
            }
            if (parent != null)
            {
                formEditor = (frmEditor)parent;
                formEditor.Text = newValue.ToString();
            }
            sourceCode = string.Empty;
        }
    }
}
