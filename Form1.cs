namespace Assembler
{
    public partial class Form1 : Form
    {
        private bool isPickingPoint = false;
        private Control selectedObject;
        private string currentView = "InitialView";
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

    }
}
