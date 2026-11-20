namespace Assembler
{
    public partial class Form1 : Form
    {
        private bool isPickingPoint = false;
        private Control selectedObject;
        private string currentView = "InitialView";
        private Dictionary<string, List<ControlDto>> views = new Dictionary<string, List<ControlDto>>();
        public Form1()
        {
            InitializeComponent();

            // Assign the custom flat renderer
            var modernRenderer = new ToolStripProfessionalRenderer(new ModernColorTable());
            menuStrip1.Renderer = modernRenderer;
            toolStrip1.Renderer = modernRenderer;
            ctxTVView.Renderer = modernRenderer;
            ctxTVRootView.Renderer = modernRenderer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pl
        }

        private bool isUpdatingSelection = false; // Prevents infinite loops
        private int controlCounter = 1; // Ensures unique names

        private void selectControlForProps(object sender)
        {
            if (isUpdatingSelection || !(sender is Control ctrl)) return;

            isUpdatingSelection = true;
            try
            {
                selectedObject = ctrl;
                propertyGrid1.SelectedObject = ctrl;

                // Directly select the linked TreeNode stored in Tag
                if (ctrl.Tag is TreeNode linkedNode)
                {
                    treeView1.SelectedNode = linkedNode;
                }
            }
            finally
            {
                isUpdatingSelection = false;
                tsRemoveSelectedControl.Enabled = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isUpdatingSelection || e.Node == null) return;

            tsRemoveView.Enabled = false;
            tsRemoveSelectedControl.Enabled = false;

            if (e.Node.Tag is Control ctrl && !ctrl.IsDisposed)
            {
                ctrl.Focus();
                selectControlForProps(ctrl);
            }
            else if (e.Node.ImageIndex is 0 or 1)
            {
                tsRemoveView.Enabled = true;

                if (currentView != e.Node.Text)
                {
                    SwitchView(e.Node.Text);
                }
            }
        }



        private void AddToTreeview(Control control)
        {
            TreeNode ctrlNode = new TreeNode(control.Text)
            {
                Name = control.Name,
                Tag = control // Link TreeNode -> Control
            };

            control.Tag = ctrlNode; // Link Control -> TreeNode

            if (control is Button)
            {
                ctrlNode.SelectedImageIndex = 3;
                ctrlNode.ImageIndex = 4;
            }
            else if (control is Label)
            {
                ctrlNode.SelectedImageIndex = 6;
                ctrlNode.ImageIndex = 5;
            }
            else if (control is TextBox)
            {
                ctrlNode.SelectedImageIndex = 8;
                ctrlNode.ImageIndex = 7;
            }

            var viewNode = treeView1.Nodes.Find(currentView, true).FirstOrDefault();
            viewNode?.Nodes.Add(ctrlNode);
            viewNode?.Expand(); // Automatically expand so new items are visible
        }

        private void splitContainer2_Panel1_Click(object sender, EventArgs e)
        {
            if (!isPickingPoint || selectedObject == null) return;
            selectedObject.Location = DesignerSplit.Panel1.PointToClient(Cursor.Position);
        }

        private void toolStripButton4_Click(object sender, EventArgs e) => isPickingPoint = !isPickingPoint;

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button newButton = new Button()
            {
                Text = "&Button",
                Name = "newBttn",
                Location = new Point(20, 20),
                Size = new Size(131, 40),
                ContextMenuStrip = ctxDesignerControl
            };
            newButton.Click += (sender, e) => selectControlForProps(sender);
            AddToTreeview(newButton);
            DesignerSplit.Panel1.Controls.Add(newButton);
        }

        private void tsRemoveSelectedControl_Click(object sender, EventArgs e) => RemoveSelectedObject();

        private void RemoveSelectedObject()
        {
            if (selectedObject == null) return;

            selectedObject.Parent.Controls.Remove(selectedObject);
            treeView1.Nodes.Find(selectedObject.Name, true).FirstOrDefault()?.Remove();
            selectedObject.Dispose();
        }

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Label newLabel = new Label()
            {
                Text = "Label",
                Name = "newLbl",
                Location = new Point(20, 20),
                ContextMenuStrip = ctxDesignerControl
            };

            newLabel.Click += (sender, e) => selectControlForProps(sender);
            AddToTreeview(newLabel);
            DesignerSplit.Panel1.Controls.Add(newLabel);
        }

        private void textboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox()
            {
                Text = "TextBox",
                Name = "newTxtBox",
                Location = new Point(20, 20),
                ContextMenuStrip = ctxDesignerControl
            };

            newTextBox.Click += (sender, e) => selectControlForProps(sender);
            AddToTreeview(newTextBox);
            DesignerSplit.Panel1.Controls.Add(newTextBox);
        }
        private List<ControlDto> CaptureCurrentView()
        {
            var list = new List<ControlDto>();
            foreach (Control ctrl in DesignerSplit.Panel1.Controls)
            {
                list.Add(new ControlDto
                {
                    TypeName = ctrl.GetType().FullName,
                    Name = ctrl.Name,
                    Text = ctrl.Text,
                    X = ctrl.Location.X,
                    Y = ctrl.Location.Y,
                    Width = ctrl.Width,
                    Height = ctrl.Height,
                    AutoSize = ctrl.AutoSize,
                    BackColorArgb = ctrl.BackColor.ToArgb(),
                    ForeColorArgb = ctrl.ForeColor.ToArgb()
                });
            }
            return list;
        }
        public void SwitchView(string targetViewName, bool attachDesignerEvents = true)
        {
            // Save what is currently on the canvas before switching away
            if (!string.IsNullOrEmpty(currentView))
            {
                views[currentView] = CaptureCurrentView();
            }

            currentView = targetViewName;

            // Clear and dispose current canvas controls
            DesignerSplit.Panel1.SuspendLayout();
            for (int i = DesignerSplit.Panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control oldCtrl = DesignerSplit.Panel1.Controls[i];
                DesignerSplit.Panel1.Controls.RemoveAt(i);
                oldCtrl.Dispose();
            }
            selectedObject = null;
            propertyGrid1.SelectedObject = null;

            // If the target view already exists, reconstruct its controls
            if (views.TryGetValue(targetViewName, out var dtoList))
            {
                foreach (var dto in dtoList)
                {
                    Type ctrlType = typeof(Control).Assembly.GetType(dto.TypeName);
                    if (ctrlType != null && Activator.CreateInstance(ctrlType) is Control ctrl)
                    {
                        ctrl.Name = dto.Name;
                        ctrl.Text = dto.Text;
                        ctrl.AutoSize = dto.AutoSize;
                        ctrl.Location = new Point(dto.X, dto.Y);
                        ctrl.Size = new Size(dto.Width, dto.Height);
                        ctrl.BackColor = Color.FromArgb(dto.BackColorArgb);
                        ctrl.ForeColor = Color.FromArgb(dto.ForeColorArgb);

                        // Only attach designer click selection if in Design Mode
                        if (attachDesignerEvents)
                        {
                            ctrl.Click += (s, e) => selectControlForProps(s);
                        }

                        // Find the matching TreeNode under the target view and re-link both Tags
                        var viewNode = treeView1.Nodes.Find(targetViewName, true).FirstOrDefault();
                        var ctrlNode = viewNode?.Nodes.Find(dto.Name, false).FirstOrDefault();
                        if (ctrlNode != null)
                        {
                            ctrl.Tag = ctrlNode;
                            ctrlNode.Tag = ctrl;
                        }


                        DesignerSplit.Panel1.Controls.Add(ctrl);
                    }
                }
            }

            DesignerSplit.Panel1.ResumeLayout();
        }

        private void PreviewCurrentView()
        {
            var useUserDefinedColours = Abstractor.YesNo("Do you want to use user-defined colours for the preview?", "Preview");
            // Capture current controls into DTOs
            List<ControlDto> currentControls = CaptureCurrentView();

            // Create a clean popup Form to host the preview
            Form previewForm = new Form
            {
                Text = $"{currentView} - Preview",
                Size = DesignerSplit.Panel1.Size,
                StartPosition = FormStartPosition.CenterParent
            };

            // Instantiate the controls WITHOUT attaching selectControlForProps
            foreach (var dto in currentControls)
            {
                Type ctrlType = typeof(Control).Assembly.GetType(dto.TypeName);
                if (ctrlType != null && Activator.CreateInstance(ctrlType) is Control ctrl)
                {
                    ctrl.Name = dto.Name;
                    ctrl.Text = dto.Text;
                    ctrl.AutoSize = dto.AutoSize;
                    ctrl.Location = new Point(dto.X, dto.Y);
                    ctrl.Size = new Size(dto.Width, dto.Height);
                    if (useUserDefinedColours)
                    {
                        ctrl.BackColor = Color.FromArgb(dto.BackColorArgb);
                        ctrl.ForeColor = Color.FromArgb(dto.ForeColorArgb);
                    }
                    previewForm.Controls.Add(ctrl);
                }
            }

            previewForm.ShowDialog(this);
            previewForm.Dispose();
        }

        private void tsPreviewCurrView_Click(object sender, EventArgs e) => PreviewCurrentView();

        private void AddView(string name)
        {
            views.Add(name, []);

            TreeNode newNode = new TreeNode(name)
            {
                Name = name, // Required so Nodes.Find(currentView, true) finds this view!
                ImageIndex = 0,
                SelectedImageIndex = 1,
                ContextMenuStrip = ctxTVView
            };

            treeView1.Nodes[0].Nodes.Add(newNode);
            treeView1.Nodes[0].Expand();
            treeView1.SelectedNode = newNode; // Highlights the new view in the TreeView
        }

        private void RemoveView(string name)
        {
            views.Remove(name);
            var nodeToRemove = treeView1.Nodes[0].Nodes.Find(name, true).FirstOrDefault();
            if (nodeToRemove != null)
            {
                treeView1.Nodes[0].Nodes.Remove(nodeToRemove);
            }
            SwitchView(treeView1.Nodes[0].Nodes[0]?.Text ?? string.Empty);
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var inp = new InputBox("Enter the name of the new view:", "Add View");
            if (inp.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(inp.UserInput))
            {
                string newViewName = inp.UserInput.Trim();
                if (!views.ContainsKey(newViewName))
                {
                    AddView(newViewName);
                    SwitchView(newViewName);
                }
                else
                {
                    MessageBox.Show($"A view named '{newViewName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsRemoveView_Click(object sender, EventArgs e) => RemoveView(currentView);

        private void removeToolStripMenuItem_Click(object sender, EventArgs e) => RemoveView(treeView1.SelectedNode?.Text ?? string.Empty);

        private void addViewToolStripMenuItem_Click(object sender, EventArgs e) => toolStripButton5_Click(sender, e);

        private void RenameView(string name)
        {
            var node = treeView1.Nodes[0].Nodes.Find(name, true).FirstOrDefault();
            if (node != null)
            {
                var inp = new InputBox("Enter the new name for the view:", "Rename View");
                if (inp.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(inp.UserInput))
                {
                    string newViewName = inp.UserInput.Trim();
                    if (!views.ContainsKey(newViewName))
                    {
                        views.Add(newViewName, views[name]);
                        views.Remove(name);
                        node.Text = newViewName;
                        node.Name = newViewName;
                    }
                    else
                    {
                        MessageBox.Show($"A view named '{newViewName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e) => RenameView(treeView1.SelectedNode?.Text ?? string.Empty);

        private void addViewToolStripMenuItem1_Click(object sender, EventArgs e) => toolStripButton5_Click(sender, e);

        private void removeThisVoewToolStripMenuItem_Click(object sender, EventArgs e) => RemoveView(currentView);

        private void renameThisViewToolStripMenuItem_Click(object sender, EventArgs e) => RenameView(currentView);

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e) => RemoveSelectedObject();
    }
}
