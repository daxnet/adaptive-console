using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunnyChen.Common.Patterns;
using SunnyChen.Common.Patterns.ExtendableMDI;
using AcfEditor.Domain;
using SunnyChen.Common.Patterns.ExtendableMDI.Attributes;
using SunnyChen.Common.Windows.Forms;

namespace acfeditor
{
    public partial class frmMain : MainFormBase
    {
        #region Private Definitions
        /// <summary>
        /// 
        /// </summary>
        private enum ActionTag
        {
            New = 0,
            Open,
            Save,
            SaveAll
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            UpdateElements();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoAction(object sender, System.EventArgs e)
        {
            frmEditor editor;
            using (new LengthyOperation(this))
            {
                if (sender is ToolStripItem)
                {
                    ToolStripItem ctrl = (ToolStripItem)sender;
                    if (ctrl.Tag != null)
                    {
                        ActionTag tag = (ActionTag)Convert.ToInt32(ctrl.Tag);
                        switch (tag)
                        {
                            // Creates a new project
                            case ActionTag.New:
                                try
                                {
                                    string projectName = StringInputBox.GetInputString(
                                        "Please input the name of the project. The first character " +
                                        "must be either a letter or an underscore, other characters " +
                                        "can be a letter, a digit or an underscore. For example, " +
                                        "MyProject, myProject, _myProject, MyProject0, etc.",
                                        "Create New Project",
                                        EditorProject.NAME_PATTERN);
                                    if (projectName.Trim().Equals(string.Empty))
                                        return;

                                    editor = new frmEditor(this, EditorProject.Create(projectName));
                                    editor.Show();
                                }
                                catch (Exception ex)
                                {
                                    ExceptionMessageBox.ShowDialog(ex);
                                }
                                break;
                            // Opens an existing project
                            case ActionTag.Open:
                                try
                                {
                                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        string fileName = openFileDialog.FileName;
                                        editor = new frmEditor(this, EditorProject.Load(fileName));
                                        editor.Show();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ExceptionMessageBox.ShowDialog(ex);
                                }
                                break;
                            // Saves the current project
                            case ActionTag.Save:
                                this.InvokeAction<frmMain, SaveActionAttribute>();
                                break;
                            case ActionTag.SaveAll:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        #endregion

        public override void UpdateElements()
        {
            if ((this.MdiChildren.Length > 0) && (ActiveMdiChild is frmIntermediate))
            {
                frmIntermediate child = ActiveMdiChild as frmIntermediate;
                mnuSave.Enabled = tbtnSave.Enabled = child.CanSave;
            }
            else
            {
                mnuSave.Enabled = tbtnSave.Enabled = false;
            }
        }

        
    }
}
