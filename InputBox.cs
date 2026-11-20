using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assembler
{
    public partial class InputBox : Form
    {
        public string UserInput => textBox1.Text;
        public InputBox(string prompt, string title)
        {
            InitializeComponent();
            Text = title;
            lblPrompt.Text = prompt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a value.");
                return; // Stops the dialog from closing
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
