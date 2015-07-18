using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acfeditor.Helper
{
    internal enum TreeNodeType
    {
        ApplicationRoot,
        ApplicationProviderRoot,
        ApplicationContractsRoot,
        ApplicationContract,
        ApplicationContractOption,
        ApplicationReferencedAssemblies,
        ApplicationReferencedAssembly,
        ApplicationNull
    }

    internal class TreeNodeValue
    {
        public TreeNodeType Type { get; set; }
        public object Value { get; set; }

        public TreeNodeValue()
        {
            this.Type = TreeNodeType.ApplicationNull;
            this.Value = null;
        }

        public TreeNodeValue(TreeNodeType type)
        {
            this.Type = type;
            this.Value = null;
        }

        public TreeNodeValue(TreeNodeType type, object value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
