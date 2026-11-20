namespace Assembler
{
    partial class InputBox
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
            lblPrompt = new Label();
            textBox1 = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(29, 45);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(68, 30);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(626, 35);
            textBox1.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(524, 177);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(131, 40);
            btnOk.TabIndex = 2;
            btnOk.Text = "&Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(387, 177);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // InputBox
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(693, 253);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(textBox1);
            Controls.Add(lblPrompt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputBox";
            ShowInTaskbar = false;
            Text = "InputBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrompt;
        private TextBox textBox1;
        private Button btnOk;
        private Button btnCancel;
    }
}