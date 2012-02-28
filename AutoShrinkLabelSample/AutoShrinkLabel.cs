using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoShrinkLabelSample
{
    public partial class AutoShrinkLabel : Label
    {
        public AutoShrinkLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            Font realFont = this.Font;

            SizeF size = g.MeasureString(this.Text, realFont);
            while (size.Width >= this.Width || size.Height >= this.Height)
            {
                if (realFont.Size <= 1.0f)
                    break;

                realFont = new Font(realFont.FontFamily, realFont.Size - 1.0f);
                size = g.MeasureString(this.Text, realFont);
            }

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(g, this.Text, realFont, new Rectangle(0, 0, (int)size.Width, (int)size.Height), this.ForeColor, flags);
        }
    }
}
