using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcfEditor.Domain;
using System.Windows.Forms;
using AdaptiveConsole;

namespace acfeditor.Handlers
{
    internal sealed class OptionAttributeTypeChangedHandler : PropertyChangedHandlerBase
    {
        public override Type TargetType
        {
            get { return typeof(AdaptiveConsole.OptionAttribute); }
        }

        public override System.Reflection.PropertyInfo Property
        {
            get { return typeof(OptionAttribute).GetProperty("Type"); }
        }

        protected override void DoHandle(TreeNode treeNode, object target, object oldValue, object newValue, ref string sourceCode)
        {
            OptionSetting optionSetting = null;
            
            if (target != null)
                optionSetting = (OptionSetting)target;
            
            if (optionSetting == null)
                return;
            
            OptionType optionType = (OptionType)newValue;

            switch (optionType)
            {
                case OptionType.SingleValue:
                    optionSetting.PropertyType = ContractOptionTypes.String;
                    break;
                case OptionType.Switch:
                    optionSetting.PropertyType = ContractOptionTypes.Boolean;
                    break;
                case OptionType.ValueList:
                    optionSetting.PropertyType = ContractOptionTypes.Array;
                    break;
                default :
                    break;
            }
        }
    }
}
