namespace Assembler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TreeNode treeNode1 = new TreeNode("InitialView", 0, 1);
            TreeNode treeNode2 = new TreeNode("Views", 2, 2, new TreeNode[] { treeNode1 });
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsAddControlDD = new ToolStripDropDownButton();
            buttonToolStripMenuItem = new ToolStripMenuItem();
            labelToolStripMenuItem = new ToolStripMenuItem();
            textboxToolStripMenuItem = new ToolStripMenuItem();
            tsRemoveSelectedControl = new ToolStripButton();
            tsMoveToggle = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton5 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            ViewsDesignerSplit = new SplitContainer();
            treeView1 = new TreeView();
            imageList1 = new ImageList(components);
            DesignerSplit = new SplitContainer();
            propertyGrid1 = new PropertyGrid();
            tsPreviewCurrView = new ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewsDesignerSplit).BeginInit();
            ViewsDesignerSplit.Panel1.SuspendLayout();
            ViewsDesignerSplit.Panel2.SuspendLayout();
            ViewsDesignerSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DesignerSplit).BeginInit();
            DesignerSplit.Panel2.SuspendLayout();
            DesignerSplit.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1706, 38);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(62, 34);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(173, 40);
            newToolStripMenuItem.Text = "&New";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripSeparator1, tsAddControlDD, tsRemoveSelectedControl, tsMoveToggle, toolStripSeparator2, toolStripButton5, toolStripButton4, tsPreviewCurrView });
            toolStrip1.Location = new Point(0, 38);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(1706, 42);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(40, 36);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(40, 36);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(40, 36);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 42);
            // 
            // tsAddControlDD
            // 
            tsAddControlDD.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsAddControlDD.DropDownItems.AddRange(new ToolStripItem[] { buttonToolStripMenuItem, labelToolStripMenuItem, textboxToolStripMenuItem });
            tsAddControlDD.Image = (Image)resources.GetObject("tsAddControlDD.Image");
            tsAddControlDD.ImageTransparentColor = Color.Magenta;
            tsAddControlDD.Name = "tsAddControlDD";
            tsAddControlDD.Size = new Size(53, 36);
            tsAddControlDD.Text = "toolStripDropDownButton1";
            tsAddControlDD.ToolTipText = "Add Control";
            // 
            // buttonToolStripMenuItem
            // 
            buttonToolStripMenuItem.Image = Properties.Resources.Unselected_Button;
            buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
            buttonToolStripMenuItem.Size = new Size(202, 40);
            buttonToolStripMenuItem.Text = "&Button";
            buttonToolStripMenuItem.Click += buttonToolStripMenuItem_Click;
            // 
            // labelToolStripMenuItem
            // 
            labelToolStripMenuItem.Image = Properties.Resources.Unselected_Label;
            labelToolStripMenuItem.Name = "labelToolStripMenuItem";
            labelToolStripMenuItem.Size = new Size(202, 40);
            labelToolStripMenuItem.Text = "&Label";
            labelToolStripMenuItem.Click += labelToolStripMenuItem_Click;
            // 
            // textboxToolStripMenuItem
            // 
            textboxToolStripMenuItem.Image = Properties.Resources.Unselected_Textbox;
            textboxToolStripMenuItem.Name = "textboxToolStripMenuItem";
            textboxToolStripMenuItem.Size = new Size(202, 40);
            textboxToolStripMenuItem.Text = "&Textbox";
            textboxToolStripMenuItem.Click += textboxToolStripMenuItem_Click;
            // 
            // tsRemoveSelectedControl
            // 
            tsRemoveSelectedControl.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsRemoveSelectedControl.Image = (Image)resources.GetObject("tsRemoveSelectedControl.Image");
            tsRemoveSelectedControl.ImageTransparentColor = Color.Magenta;
            tsRemoveSelectedControl.Name = "tsRemoveSelectedControl";
            tsRemoveSelectedControl.Size = new Size(40, 36);
            tsRemoveSelectedControl.Text = "toolStripButton6";
            tsRemoveSelectedControl.ToolTipText = "Remove Selected Control";
            tsRemoveSelectedControl.Click += tsRemoveSelectedControl_Click;
            // 
            // tsMoveToggle
            // 
            tsMoveToggle.CheckOnClick = true;
            tsMoveToggle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsMoveToggle.Image = (Image)resources.GetObject("tsMoveToggle.Image");
            tsMoveToggle.ImageTransparentColor = Color.Magenta;
            tsMoveToggle.Name = "tsMoveToggle";
            tsMoveToggle.Size = new Size(40, 36);
            tsMoveToggle.Text = "Move Control Mode";
            tsMoveToggle.Click += toolStripButton4_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 42);
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(40, 36);
            toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(40, 36);
            toolStripButton4.Text = "toolStripButton4";
            // 
            // ViewsDesignerSplit
            // 
            ViewsDesignerSplit.Dock = DockStyle.Fill;
            ViewsDesignerSplit.Location = new Point(0, 80);
            ViewsDesignerSplit.Name = "ViewsDesignerSplit";
            // 
            // ViewsDesignerSplit.Panel1
            // 
            ViewsDesignerSplit.Panel1.Controls.Add(treeView1);
            // 
            // ViewsDesignerSplit.Panel2
            // 
            ViewsDesignerSplit.Panel2.Controls.Add(DesignerSplit);
            ViewsDesignerSplit.Size = new Size(1706, 981);
            ViewsDesignerSplit.SplitterDistance = 312;
            ViewsDesignerSplit.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.ImageIndex = 0;
            treeView1.ImageList = imageList1;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "InitialView";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "InitialView";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "RootViews";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Text = "Views";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode2 });
            treeView1.SelectedImageIndex = 0;
            treeView1.Size = new Size(312, 981);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Fatcow-Farm-Fresh-Application-form.32.png");
            imageList1.Images.SetKeyName(1, "Fatcow-Farm-Fresh-Application-form-edit.32.png");
            imageList1.Images.SetKeyName(2, "Fatcow-Farm-Fresh-Application-from-storage.32.png");
            imageList1.Images.SetKeyName(3, "Fatcow-Farm-Fresh-Button.32.png");
            imageList1.Images.SetKeyName(4, "Fatcow-Farm-Fresh-Button-default.32.png");
            imageList1.Images.SetKeyName(5, "Fatcow-Farm-Fresh-Text.32.png");
            imageList1.Images.SetKeyName(6, "Fatcow-Farm-Fresh-Text-edit.32.png");
            imageList1.Images.SetKeyName(7, "Fatcow-Farm-Fresh-Textfield.32.png");
            imageList1.Images.SetKeyName(8, "Fatcow-Farm-Fresh-Textfield-rename.32.png");
            // 
            // DesignerSplit
            // 
            DesignerSplit.Dock = DockStyle.Fill;
            DesignerSplit.Location = new Point(0, 0);
            DesignerSplit.Name = "DesignerSplit";
            // 
            // DesignerSplit.Panel1
            // 
            DesignerSplit.Panel1.Click += splitContainer2_Panel1_Click;
            // 
            // DesignerSplit.Panel2
            // 
            DesignerSplit.Panel2.Controls.Add(propertyGrid1);
            DesignerSplit.Size = new Size(1390, 981);
            DesignerSplit.SplitterDistance = 1049;
            DesignerSplit.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            propertyGrid1.BackColor = SystemColors.Control;
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(337, 981);
            propertyGrid1.TabIndex = 0;
            // 
            // tsPreviewCurrView
            // 
            tsPreviewCurrView.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsPreviewCurrView.Image = (Image)resources.GetObject("tsPreviewCurrView.Image");
            tsPreviewCurrView.ImageTransparentColor = Color.Magenta;
            tsPreviewCurrView.Name = "tsPreviewCurrView";
            tsPreviewCurrView.Size = new Size(40, 36);
            tsPreviewCurrView.Text = "toolStripButton6";
            tsPreviewCurrView.ToolTipText = "Preview Current View";
            tsPreviewCurrView.Click += tsPreviewCurrView_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1706, 1061);
            Controls.Add(ViewsDesignerSplit);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Assembler";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ViewsDesignerSplit.Panel1.ResumeLayout(false);
            ViewsDesignerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ViewsDesignerSplit).EndInit();
            ViewsDesignerSplit.ResumeLayout(false);
            DesignerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DesignerSplit).EndInit();
            DesignerSplit.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStrip toolStrip1;
        private SplitContainer ViewsDesignerSplit;
        private TreeView treeView1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private SplitContainer DesignerSplit;
        private PropertyGrid propertyGrid1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton tsAddControlDD;
        private ToolStripButton tsMoveToggle;
        private ToolStripMenuItem buttonToolStripMenuItem;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton4;
        private ToolStripButton tsRemoveSelectedControl;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem labelToolStripMenuItem;
        private ToolStripMenuItem textboxToolStripMenuItem;
        private ImageList imageList1;
        private ToolStripButton tsPreviewCurrView;
    }
}
