using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Assembler
{
    public class ControlDto
    {
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool AutoSize { get; set; }
        public int BackColorArgb { get; set; }
        public int ForeColorArgb { get; set; }
    }
}
