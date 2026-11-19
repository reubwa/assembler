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
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Ignore programmatic selection updates and nodes without a linked Control (like "InitialView")
            if (isUpdatingSelection || e.Node?.Tag == null) return;

            if (e.Node.Tag is Control ctrl)
            {
                ctrl.Focus();
                selectControlForProps(ctrl);
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
            };
            newButton.Click += (sender, e) => selectControlForProps(sender);
            AddToTreeview(newButton);
            DesignerSplit.Panel1.Controls.Add(newButton);
        }

        private void tsRemoveSelectedControl_Click(object sender, EventArgs e)
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
                Location = new Point(20, 20)
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
                Location = new Point(20, 20)
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

                        DesignerSplit.Panel1.Controls.Add(ctrl);
                    }
                }
            }

            DesignerSplit.Panel1.ResumeLayout();
        }

        private void PreviewCurrentView()
        {
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
                    //ctrl.BackColor = Color.FromArgb(dto.BackColorArgb);
                    //ctrl.ForeColor = Color.FromArgb(dto.ForeColorArgb);
                    previewForm.Controls.Add(ctrl);
                }
            }

            previewForm.ShowDialog(this);
            previewForm.Dispose();
        }

        private void tsPreviewCurrView_Click(object sender, EventArgs e) => PreviewCurrentView();
    }
}
