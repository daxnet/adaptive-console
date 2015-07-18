using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunnyChen.Common.Patterns.ExtendableMDI;

namespace acfeditor
{
    public partial class frmIntermediate : MDIChildBase<frmMain>
    {
        #region Constructors
        public frmIntermediate()
        {
            InitializeComponent();
        }

        public frmIntermediate(MainFormBase _parent)
            : base((frmMain)_parent)
        {
            InitializeComponent();
        }
        #endregion
    }
}
