namespace acfeditor
{
    partial class frmEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditor));
            this.VerticalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftHorizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.projTree = new System.Windows.Forms.TreeView();
            this.projectImageList = new System.Windows.Forms.ImageList(this.components);
            this.lblProjectTreeTitle = new System.Windows.Forms.Label();
            this.editorImageList = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.lblPropertiesTitle = new System.Windows.Forms.Label();
            this.rightHorizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lblSourceCodeEditorTitle = new System.Windows.Forms.Label();
            this.tcStatus = new System.Windows.Forms.TabControl();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.tpErrorList = new System.Windows.Forms.TabPage();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.contractRootContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddContract = new System.Windows.Forms.ToolStripMenuItem();
            this.contractContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteContract = new System.Windows.Forms.ToolStripMenuItem();
            this.assembliesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddReference = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteReference = new System.Windows.Forms.ToolStripMenuItem();
            this.optionContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteOption = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.VerticalSplitContainer.Panel1.SuspendLayout();
            this.VerticalSplitContainer.Panel2.SuspendLayout();
            this.VerticalSplitContainer.SuspendLayout();
            this.leftHorizontalSplitContainer.Panel1.SuspendLayout();
            this.leftHorizontalSplitContainer.Panel2.SuspendLayout();
            this.leftHorizontalSplitContainer.SuspendLayout();
            this.rightHorizontalSplitContainer.Panel1.SuspendLayout();
            this.rightHorizontalSplitContainer.Panel2.SuspendLayout();
            this.rightHorizontalSplitContainer.SuspendLayout();
            this.tcStatus.SuspendLayout();
            this.tpOutput.SuspendLayout();
            this.contractRootContextMenu.SuspendLayout();
            this.contractContextMenu.SuspendLayout();
            this.assembliesContextMenu.SuspendLayout();
            this.assemblyContextMenu.SuspendLayout();
            this.optionContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalSplitContainer
            // 
            this.VerticalSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.VerticalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.VerticalSplitContainer.Name = "VerticalSplitContainer";
            // 
            // VerticalSplitContainer.Panel1
            // 
            this.VerticalSplitContainer.Panel1.Controls.Add(this.leftHorizontalSplitContainer);
            // 
            // VerticalSplitContainer.Panel2
            // 
            this.VerticalSplitContainer.Panel2.Controls.Add(this.rightHorizontalSplitContainer);
            this.VerticalSplitContainer.Size = new System.Drawing.Size(660, 461);
            this.VerticalSplitContainer.SplitterDistance = 226;
            this.VerticalSplitContainer.SplitterWidth = 3;
            this.VerticalSplitContainer.TabIndex = 0;
            // 
            // leftHorizontalSplitContainer
            // 
            this.leftHorizontalSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftHorizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftHorizontalSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.leftHorizontalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.leftHorizontalSplitContainer.Name = "leftHorizontalSplitContainer";
            this.leftHorizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftHorizontalSplitContainer.Panel1
            // 
            this.leftHorizontalSplitContainer.Panel1.Controls.Add(this.projTree);
            this.leftHorizontalSplitContainer.Panel1.Controls.Add(this.lblProjectTreeTitle);
            // 
            // leftHorizontalSplitContainer.Panel2
            // 
            this.leftHorizontalSplitContainer.Panel2.Controls.Add(this.propertyGrid);
            this.leftHorizontalSplitContainer.Panel2.Controls.Add(this.lblPropertiesTitle);
            this.leftHorizontalSplitContainer.Size = new System.Drawing.Size(226, 461);
            this.leftHorizontalSplitContainer.SplitterDistance = 198;
            this.leftHorizontalSplitContainer.SplitterWidth = 3;
            this.leftHorizontalSplitContainer.TabIndex = 0;
            // 
            // projTree
            // 
            this.projTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projTree.HideSelection = false;
            this.projTree.ImageIndex = 0;
            this.projTree.ImageList = this.projectImageList;
            this.projTree.Location = new System.Drawing.Point(0, 16);
            this.projTree.Name = "projTree";
            this.projTree.SelectedImageIndex = 0;
            this.projTree.Size = new System.Drawing.Size(222, 178);
            this.projTree.TabIndex = 1;
            this.projTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projTree_MouseClick);
            this.projTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.projTree_AfterSelect);
            // 
            // projectImageList
            // 
            this.projectImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("projectImageList.ImageStream")));
            this.projectImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.projectImageList.Images.SetKeyName(0, "PROJECT");
            this.projectImageList.Images.SetKeyName(1, "APPLICATION_PROVIDER");
            this.projectImageList.Images.SetKeyName(2, "APPLICATION_CONTRACTS");
            this.projectImageList.Images.SetKeyName(3, "CONTRACT");
            this.projectImageList.Images.SetKeyName(4, "OPTION");
            this.projectImageList.Images.SetKeyName(5, "REFERENCED_ASSEMBLIES");
            this.projectImageList.Images.SetKeyName(6, "REFERENCED_ASSEMBLY");
            // 
            // lblProjectTreeTitle
            // 
            this.lblProjectTreeTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblProjectTreeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProjectTreeTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectTreeTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProjectTreeTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProjectTreeTitle.ImageIndex = 0;
            this.lblProjectTreeTitle.ImageList = this.editorImageList;
            this.lblProjectTreeTitle.Location = new System.Drawing.Point(0, 0);
            this.lblProjectTreeTitle.Name = "lblProjectTreeTitle";
            this.lblProjectTreeTitle.Size = new System.Drawing.Size(222, 16);
            this.lblProjectTreeTitle.TabIndex = 0;
            this.lblProjectTreeTitle.Text = "Project Tree";
            this.lblProjectTreeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editorImageList
            // 
            this.editorImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("editorImageList.ImageStream")));
            this.editorImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.editorImageList.Images.SetKeyName(0, "Control_TreeView.bmp");
            this.editorImageList.Images.SetKeyName(1, "Properties.bmp");
            this.editorImageList.Images.SetKeyName(2, "EditCode.bmp");
            this.editorImageList.Images.SetKeyName(3, "Status.bmp");
            this.editorImageList.Images.SetKeyName(4, "Output.bmp");
            this.editorImageList.Images.SetKeyName(5, "ErrorList.bmp");
            this.editorImageList.Images.SetKeyName(6, "Delete.bmp");
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 16);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(222, 240);
            this.propertyGrid.TabIndex = 1;
            // 
            // lblPropertiesTitle
            // 
            this.lblPropertiesTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPropertiesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPropertiesTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertiesTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPropertiesTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPropertiesTitle.ImageIndex = 1;
            this.lblPropertiesTitle.ImageList = this.editorImageList;
            this.lblPropertiesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPropertiesTitle.Name = "lblPropertiesTitle";
            this.lblPropertiesTitle.Size = new System.Drawing.Size(222, 16);
            this.lblPropertiesTitle.TabIndex = 0;
            this.lblPropertiesTitle.Text = "Properties";
            this.lblPropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightHorizontalSplitContainer
            // 
            this.rightHorizontalSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightHorizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightHorizontalSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.rightHorizontalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.rightHorizontalSplitContainer.Name = "rightHorizontalSplitContainer";
            this.rightHorizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightHorizontalSplitContainer.Panel1
            // 
            this.rightHorizontalSplitContainer.Panel1.Controls.Add(this.lblSourceCodeEditorTitle);
            // 
            // rightHorizontalSplitContainer.Panel2
            // 
            this.rightHorizontalSplitContainer.Panel2.Controls.Add(this.tcStatus);
            this.rightHorizontalSplitContainer.Panel2.Controls.Add(this.lblStatusTitle);
            this.rightHorizontalSplitContainer.Size = new System.Drawing.Size(431, 461);
            this.rightHorizontalSplitContainer.SplitterDistance = 341;
            this.rightHorizontalSplitContainer.SplitterWidth = 3;
            this.rightHorizontalSplitContainer.TabIndex = 0;
            // 
            // lblSourceCodeEditorTitle
            // 
            this.lblSourceCodeEditorTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSourceCodeEditorTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSourceCodeEditorTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceCodeEditorTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSourceCodeEditorTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSourceCodeEditorTitle.ImageIndex = 2;
            this.lblSourceCodeEditorTitle.ImageList = this.editorImageList;
            this.lblSourceCodeEditorTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSourceCodeEditorTitle.Name = "lblSourceCodeEditorTitle";
            this.lblSourceCodeEditorTitle.Size = new System.Drawing.Size(427, 16);
            this.lblSourceCodeEditorTitle.TabIndex = 1;
            this.lblSourceCodeEditorTitle.Text = "Source Code";
            this.lblSourceCodeEditorTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcStatus
            // 
            this.tcStatus.Controls.Add(this.tpOutput);
            this.tcStatus.Controls.Add(this.tpErrorList);
            this.tcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcStatus.ImageList = this.editorImageList;
            this.tcStatus.Location = new System.Drawing.Point(0, 16);
            this.tcStatus.Multiline = true;
            this.tcStatus.Name = "tcStatus";
            this.tcStatus.SelectedIndex = 0;
            this.tcStatus.Size = new System.Drawing.Size(427, 97);
            this.tcStatus.TabIndex = 3;
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.lstOutput);
            this.tpOutput.ImageIndex = 4;
            this.tpOutput.Location = new System.Drawing.Point(4, 23);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutput.Size = new System.Drawing.Size(419, 70);
            this.tpOutput.TabIndex = 0;
            this.tpOutput.Text = "Output";
            this.tpOutput.UseVisualStyleBackColor = true;
            // 
            // lstOutput
            // 
            this.lstOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.HorizontalScrollbar = true;
            this.lstOutput.Location = new System.Drawing.Point(3, 3);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.ScrollAlwaysVisible = true;
            this.lstOutput.Size = new System.Drawing.Size(413, 56);
            this.lstOutput.TabIndex = 0;
            // 
            // tpErrorList
            // 
            this.tpErrorList.ImageIndex = 5;
            this.tpErrorList.Location = new System.Drawing.Point(4, 23);
            this.tpErrorList.Name = "tpErrorList";
            this.tpErrorList.Padding = new System.Windows.Forms.Padding(3);
            this.tpErrorList.Size = new System.Drawing.Size(415, 70);
            this.tpErrorList.TabIndex = 1;
            this.tpErrorList.Text = "Error List";
            this.tpErrorList.UseVisualStyleBackColor = true;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatusTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatusTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStatusTitle.ImageIndex = 3;
            this.lblStatusTitle.ImageList = this.editorImageList;
            this.lblStatusTitle.Location = new System.Drawing.Point(0, 0);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(427, 16);
            this.lblStatusTitle.TabIndex = 2;
            this.lblStatusTitle.Text = "Status";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractRootContextMenu
            // 
            this.contractRootContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddContract});
            this.contractRootContextMenu.Name = "contractRootContextMenu";
            this.contractRootContextMenu.Size = new System.Drawing.Size(163, 26);
            // 
            // mnuAddContract
            // 
            this.mnuAddContract.Name = "mnuAddContract";
            this.mnuAddContract.Size = new System.Drawing.Size(162, 22);
            this.mnuAddContract.Text = "Add Contract...";
            this.mnuAddContract.Click += new System.EventHandler(this.AddObject);
            // 
            // contractContextMenu
            // 
            this.contractContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOptionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mnuDeleteContract});
            this.contractContextMenu.Name = "contractContextMenu";
            this.contractContextMenu.Size = new System.Drawing.Size(152, 54);
            // 
            // addOptionToolStripMenuItem
            // 
            this.addOptionToolStripMenuItem.Name = "addOptionToolStripMenuItem";
            this.addOptionToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addOptionToolStripMenuItem.Text = "Add Option...";
            this.addOptionToolStripMenuItem.Click += new System.EventHandler(this.AddObject);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuDeleteContract
            // 
            this.mnuDeleteContract.Image = global::acfeditor.Properties.Resources.IMG_DELETE;
            this.mnuDeleteContract.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuDeleteContract.Name = "mnuDeleteContract";
            this.mnuDeleteContract.Size = new System.Drawing.Size(151, 22);
            this.mnuDeleteContract.Text = "Delete...";
            this.mnuDeleteContract.Click += new System.EventHandler(this.DeleteObject);
            // 
            // assembliesContextMenu
            // 
            this.assembliesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddReference});
            this.assembliesContextMenu.Name = "assembliesContextMenu";
            this.assembliesContextMenu.Size = new System.Drawing.Size(169, 26);
            // 
            // mnuAddReference
            // 
            this.mnuAddReference.Name = "mnuAddReference";
            this.mnuAddReference.Size = new System.Drawing.Size(168, 22);
            this.mnuAddReference.Text = "Add Assembly...";
            // 
            // assemblyContextMenu
            // 
            this.assemblyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteReference});
            this.assemblyContextMenu.Name = "assemblyContextMenu";
            this.assemblyContextMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // mnuDeleteReference
            // 
            this.mnuDeleteReference.Image = global::acfeditor.Properties.Resources.IMG_DELETE;
            this.mnuDeleteReference.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuDeleteReference.Name = "mnuDeleteReference";
            this.mnuDeleteReference.Size = new System.Drawing.Size(124, 22);
            this.mnuDeleteReference.Text = "Delete...";
            // 
            // optionContextMenu
            // 
            this.optionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteOption});
            this.optionContextMenu.Name = "optionContextMenu";
            this.optionContextMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // mnuDeleteOption
            // 
            this.mnuDeleteOption.Image = global::acfeditor.Properties.Resources.IMG_DELETE;
            this.mnuDeleteOption.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuDeleteOption.Name = "mnuDeleteOption";
            this.mnuDeleteOption.Size = new System.Drawing.Size(124, 22);
            this.mnuDeleteOption.Text = "Delete...";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "acf";
            this.saveFileDialog.Filter = "ACF Project (*.acf)|*.acf";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Save Project As";
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 461);
            this.Controls.Add(this.VerticalSplitContainer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditor";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.VerticalSplitContainer.Panel1.ResumeLayout(false);
            this.VerticalSplitContainer.Panel2.ResumeLayout(false);
            this.VerticalSplitContainer.ResumeLayout(false);
            this.leftHorizontalSplitContainer.Panel1.ResumeLayout(false);
            this.leftHorizontalSplitContainer.Panel2.ResumeLayout(false);
            this.leftHorizontalSplitContainer.ResumeLayout(false);
            this.rightHorizontalSplitContainer.Panel1.ResumeLayout(false);
            this.rightHorizontalSplitContainer.Panel2.ResumeLayout(false);
            this.rightHorizontalSplitContainer.ResumeLayout(false);
            this.tcStatus.ResumeLayout(false);
            this.tpOutput.ResumeLayout(false);
            this.contractRootContextMenu.ResumeLayout(false);
            this.contractContextMenu.ResumeLayout(false);
            this.assembliesContextMenu.ResumeLayout(false);
            this.assemblyContextMenu.ResumeLayout(false);
            this.optionContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer VerticalSplitContainer;
        private System.Windows.Forms.SplitContainer leftHorizontalSplitContainer;
        private System.Windows.Forms.Label lblProjectTreeTitle;
        private System.Windows.Forms.TreeView projTree;
        private System.Windows.Forms.ImageList editorImageList;
        private System.Windows.Forms.Label lblPropertiesTitle;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ImageList projectImageList;
        private System.Windows.Forms.SplitContainer rightHorizontalSplitContainer;
        private System.Windows.Forms.Label lblSourceCodeEditorTitle;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.TabControl tcStatus;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.TabPage tpErrorList;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.ContextMenuStrip contractRootContextMenu;
        private System.Windows.Forms.ContextMenuStrip contractContextMenu;
        private System.Windows.Forms.ContextMenuStrip assembliesContextMenu;
        private System.Windows.Forms.ContextMenuStrip assemblyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddContract;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteContract;
        private System.Windows.Forms.ToolStripMenuItem mnuAddReference;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteReference;
        private System.Windows.Forms.ContextMenuStrip optionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteOption;
        private System.Windows.Forms.ToolStripMenuItem addOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}