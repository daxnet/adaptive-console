using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Common.Patterns;
using SunnyChen.Common.Patterns.ExtendableMDI;
using SunnyChen.Common.Patterns.ExtendableMDI.Attributes;
using AcfEditor.Domain;
using acfeditor.Helper;
using acfeditor.Handlers;

namespace acfeditor
{
    public partial class frmEditor : frmIntermediate
    {
        #region Private Constants
        private const string KEY_PROJECT = @"PROJECT";
        private const string KEY_APPLICATION_PROVIDER = @"APPLICATION_PROVIDER";
        private const string KEY_APPLICATION_CONTRACTS = @"APPLICATION_CONTRACTS";
        private const string KEY_CONTRACT = @"CONTRACT";
        private const string KEY_OPTION = @"OPTION";
        private const string KEY_REFERENCED_ASSEMBLIES = @"REFERENCED_ASSEMBLIES";
        private const string KEY_REFERENCED_ASSEMBLY = @"REFERENCED_ASSEMBLY";
        #endregion

        #region Private Fields
        private EditorProject project = null;
        #endregion

        #region Constructors
        public frmEditor()
        {
            InitializeComponent();
        }

        public frmEditor(MainFormBase parent, EditorProject project)
            : base((MainFormBase)parent)
        {
            InitializeComponent();
            this.project = project;
            this.project.PropertyChanged += 
                new EventHandler<AdaptiveConsole.DesignModel.PropertyChangedEventArgs>(project_PropertyChanged);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TreeNodeValue GetSelectedNodeValue()
        {
            TreeNode selectedNode = projTree.SelectedNode;
            if (selectedNode != null && selectedNode.Tag != null)
            {
                return (TreeNodeValue)selectedNode.Tag;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void AddContract(TreeNode parent)
        {
            // Get the name of the contract from user input.
            string contractName = StringInputBox.GetInputString(
                "Please input the name of the contract. The first character " +
                "must be either a letter or an underscore, other characters " +
                "can be a letter, a digit or an underscore. For example, " +
                "DisplayContract, displayContract, _displayContract, " +
                "DisplayContract0, etc.",
                "Add Contract",
                EditorProject.NAME_PATTERN);
            
            // Checks the value of the name.
            if (contractName.Trim().Equals(string.Empty))
                return;

            // Checks if the contract already exists.
            bool hasContract =
                this.project.ApplicationContractSettings.Count(
                (cs) =>
                {
                    if (this.project.CaseSensitive)
                        return cs.Name.Equals(contractName);
                    else
                        return cs.Name.ToUpper().Equals(contractName.ToUpper());
                }) != 0;

            if (hasContract)
            {
                MessageBox.Show(string.Format("The contract with the name '{0}' already exists.", contractName),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Create the new instance for the contract setting.
            ContractSetting setting = new ContractSetting(this.project, contractName);
            this.project.ApplicationContractSettings.Add(setting);

            // Create the tree node on the UI.
            TreeNode node = new TreeNode(contractName);
            node.SelectedImageKey =
                node.StateImageKey =
                node.ImageKey = KEY_CONTRACT;
            node.Tag = new TreeNodeValue(TreeNodeType.ApplicationContract, setting);
            parent.Nodes.Add(node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void AddContractOption(TreeNode parent)
        {
            TreeNodeValue tag = (TreeNodeValue)parent.Tag;
            if (tag == null)
                return;
            if (tag.Type != TreeNodeType.ApplicationContract)
                return;
            if (tag.Value == null)
                return;
            
            ContractSetting contractSetting = (ContractSetting)tag.Value;

            string optionName = StringInputBox.GetInputString(
                "Please input the name of the option. The first character " +
                "must be either a letter or an underscore, other characters " +
                "can be a letter, a digit or an underscore. For example, " +
                "NoLogo, noLogo, _NoLogo, NoLogo0, etc.",
                "Add Contract Option",
                EditorProject.NAME_PATTERN);
            
            if (optionName.Trim().Equals(string.Empty))
                return;

            bool hasOption =
                contractSetting.ContractOptionSettings.Count(
                (os) =>
                {
                    if (this.project.CaseSensitive)
                        return os.PropertyName.Equals(optionName);
                    else
                        return os.PropertyName.ToUpper().Equals(optionName);
                }) != 0;

            if (hasOption)
            {
                MessageBox.Show(string.Format("The option with the name '{0}' already exists.", optionName),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            OptionSetting optionSetting = new OptionSetting(this.project, optionName);
            contractSetting.ContractOptionSettings.Add(optionSetting);

            TreeNode node = new TreeNode(optionName);
            node.SelectedImageKey =
                node.StateImageKey =
                node.ImageKey = KEY_OPTION;
            node.Tag = new TreeNodeValue(TreeNodeType.ApplicationContractOption, optionSetting);
            parent.Nodes.Add(node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void DeleteContract(TreeNode selected)
        {
            DialogResult dialogResult =
                MessageBox.Show("You are going to delete the selected contract, do you wish to continue?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                TreeNodeValue selectedTag = this.GetSelectedNodeValue();
                TreeNode parent = selected.Parent;
                if (selectedTag != null && parent != null)
                {
                    this.project.ApplicationContractSettings.Remove((ContractSetting)selectedTag.Value);
                    parent.Nodes.Remove(selected);
                }
            }
        }

        private void DeleteContractOption(TreeNode selected)
        {

        }

        private void project_PropertyChanged(object sender, AdaptiveConsole.DesignModel.PropertyChangedEventArgs e)
        {
            this.CanSave = this.project.Modified;
            if (sender != null && e != null)
            {
                PropertyChangedHandlerBase @base = PropertyChangedHandlerBase.GetHandler(
                    sender.GetType(),
                    e.Property);
                if (@base != null)
                {
                    string sourceCode = string.Empty;
                    object tag = projTree.SelectedNode.Tag;
                    TreeNodeValue treeNodeValue = (TreeNodeValue)tag;
                    object target = treeNodeValue.Value;
                    @base.Handle(projTree.SelectedNode, target, e.OldValue, e.NewValue, ref sourceCode);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddObject(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this.parent__))
            {
                TreeNodeValue tag = this.GetSelectedNodeValue();
                TreeNode parent = projTree.SelectedNode;
                if (tag != null)
                {
                    switch (tag.Type)
                    {
                        case TreeNodeType.ApplicationContractsRoot:
                            this.AddContract(parent);
                            break;
                        case TreeNodeType.ApplicationContract:
                            this.AddContractOption(parent);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteObject(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this.parent__))
            {
                TreeNodeValue tag = this.GetSelectedNodeValue();
                TreeNode selected = projTree.SelectedNode;
                if (tag != null)
                {
                    switch (tag.Type)
                    {
                        case TreeNodeType.ApplicationContract:
                            this.DeleteContract(selected);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateProjectTree()
        {
            TreeNode projectNode = new TreeNode(project.Name);
            projectNode.ImageKey = KEY_PROJECT;
            projectNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationRoot, project);

            TreeNode applicationProviderNode = new TreeNode("Application Provider");
            applicationProviderNode.SelectedImageKey =
                applicationProviderNode.StateImageKey =
                applicationProviderNode.ImageKey = KEY_APPLICATION_PROVIDER;
            applicationProviderNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationProviderRoot, project.ApplicationProviderSettings);
            projectNode.Nodes.Add(applicationProviderNode);

            TreeNode applicationContractsNode = new TreeNode("Application Contracts");
            applicationContractsNode.SelectedImageKey =
                applicationContractsNode.StateImageKey = 
                applicationContractsNode.ImageKey = KEY_APPLICATION_CONTRACTS;
            applicationContractsNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationContractsRoot);
            foreach (ContractSetting contractSetting in project.ApplicationContractSettings)
            {
                TreeNode contractSettingNode = new TreeNode(contractSetting.Name);
                contractSettingNode.SelectedImageKey =
                    contractSettingNode.StateImageKey =
                    contractSettingNode.ImageKey = KEY_CONTRACT;
                contractSettingNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationContract, contractSetting);
                foreach (OptionSetting optionSetting in contractSetting.ContractOptionSettings)
                {
                    TreeNode optionSettingNode = new TreeNode(optionSetting.PropertyName);
                    optionSettingNode.SelectedImageKey =
                        optionSettingNode.StateImageKey =
                        optionSettingNode.ImageKey = KEY_OPTION;
                    optionSettingNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationContractOption, optionSetting);
                    contractSettingNode.Nodes.Add(optionSettingNode);
                }
                applicationContractsNode.Nodes.Add(contractSettingNode);
            }
            projectNode.Nodes.Add(applicationContractsNode);

            TreeNode referencedAssembliesNode = new TreeNode("Referenced Assemblies");
            referencedAssembliesNode.SelectedImageKey =
                referencedAssembliesNode.StateImageKey =
                referencedAssembliesNode.ImageKey = KEY_REFERENCED_ASSEMBLIES;
            referencedAssembliesNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationReferencedAssemblies);
            foreach (var referencedAssembly in project.ReferencedAssembliesSettings)
            {
                TreeNode referencedAssemblyNode = new TreeNode(referencedAssembly);
                referencedAssemblyNode.SelectedImageKey =
                    referencedAssemblyNode.StateImageKey =
                    referencedAssemblyNode.ImageKey = KEY_REFERENCED_ASSEMBLY;
                referencedAssemblyNode.Tag = new TreeNodeValue(TreeNodeType.ApplicationReferencedAssembly);
                referencedAssembliesNode.Nodes.Add(referencedAssemblyNode);
            }
            projectNode.Nodes.Add(referencedAssembliesNode);

            projTree.Nodes.Clear();
            projTree.Nodes.Add(projectNode);
        }
        /// <summary>
        /// 
        /// </summary>
        [SaveAction]
        private void SaveProject()
        {
            string fileName = this.project.FileName;
            if (fileName.Equals(string.Empty))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                }
                else
                    return;
            }
            EditorProject.Save(fileName, this.project);
            this.project.Modified = false;
            this.CanSave = false;
        }
        #endregion

        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.Text = project.Name;
            this.CreateProjectTree();
        }

        private void projTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                if (selectedNode.Tag != null)
                {
                    TreeNodeValue value = (TreeNodeValue)selectedNode.Tag;
                    propertyGrid.SelectedObject = value.Value;
                }
            }
        }

        private void projTree_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedNode = projTree.GetNodeAt(e.X, e.Y);
            if (selectedNode != null)
            {
                projTree.SelectedNode = selectedNode;
                if (e.Button == MouseButtons.Right && selectedNode.Tag != null)
                {
                    TreeNodeValue value = (TreeNodeValue)selectedNode.Tag;
                    if (value != null)
                    {
                        switch (value.Type)
                        {
                            case TreeNodeType.ApplicationContractsRoot:
                                contractRootContextMenu.Show(projTree, e.X, e.Y);
                                break;
                            case TreeNodeType.ApplicationContract:
                                contractContextMenu.Show(projTree, e.X, e.Y);
                                break;
                            case TreeNodeType.ApplicationReferencedAssemblies:
                                assembliesContextMenu.Show(projTree, e.X, e.Y);
                                break;
                            case TreeNodeType.ApplicationReferencedAssembly:
                                assemblyContextMenu.Show(projTree, e.X, e.Y);
                                break;
                            case TreeNodeType.ApplicationContractOption:
                                optionContextMenu.Show(projTree, e.X, e.Y);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
