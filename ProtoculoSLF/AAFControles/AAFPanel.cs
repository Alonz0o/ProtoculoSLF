using DevExpress.Drawing.Internal.Fonts.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoculoSLF
{
    public partial class AAFPanel : Panel
    {
        public AAFPanel()
        {
            InitializeComponent();
            Resize += new EventHandler(Panel_Resize);
            Paint += new PaintEventHandler(Panel_Paint);
            DoubleBuffered = true;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Color colorInicio = Color.FromArgb(74, 178, 255);
            Color colorFin = Color.FromArgb(227, 242, 253);
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, colorInicio, colorFin, 90F))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }
        private void Panel_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
