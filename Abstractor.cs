using System;
using System.Collections.Generic;
using System.Text;

namespace Assembler
{
    internal class Abstractor
    {
        public static bool YesNo(string prompt, string title)
        {
            var res = MessageBox.Show(prompt, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res == DialogResult.Yes;
        }
    }
}
