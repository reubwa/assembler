using System.Drawing;
using System.Windows.Forms;

namespace Assembler
{
    public class ModernColorTable : ProfessionalColorTable
    {
        // Remove the gradient from the main menubar background
        public override Color MenuStripGradientBegin => Color.FromArgb(245, 245, 245); // Light neutral
        public override Color MenuStripGradientEnd => Color.FromArgb(245, 245, 245);

        // Remove gradients from toolbars
        public override Color ToolStripGradientBegin => Color.FromArgb(245, 245, 245);
        public override Color ToolStripGradientMiddle => Color.FromArgb(245, 245, 245);
        public override Color ToolStripGradientEnd => Color.FromArgb(245, 245, 245);

        // Style the dropdown menu background
        public override Color ToolStripDropDownBackground => Color.FromArgb(250, 250, 250);
        public override Color ImageMarginGradientBegin => Color.FromArgb(250, 250, 250);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(250, 250, 250);
        public override Color ImageMarginGradientEnd => Color.FromArgb(250, 250, 250);

        // Style the hover/selected item states
        public override Color MenuItemSelected => Color.FromArgb(225, 225, 225);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(225, 225, 225);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(225, 225, 225);

        // Style the pressed item states
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(215, 215, 215);
        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(215, 215, 215);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(215, 215, 215);

        // Style the borders
        public override Color MenuBorder => Color.FromArgb(200, 200, 200);
        public override Color ToolStripBorder => Color.FromArgb(210, 210, 210);
    }
}