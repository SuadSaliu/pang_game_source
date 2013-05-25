using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pang_
{
    public partial class DevelopedBy : Form
    {
        Graphics g;

        public DevelopedBy()
        {
            InitializeComponent();
            this.CenterToScreen();
            g = this.CreateGraphics();
            Invalidate();            
        }

        private void DevelopedBy_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.FromArgb(128, 255, 128));
            g.DrawString("Developed By", new Font("Arial", 16.0F, FontStyle.Italic), new SolidBrush(Color.BlueViolet), new Point(85, 70));
            g.DrawString("=> SBJS <=", new Font("Arial", 36.0F, FontStyle.Bold), new SolidBrush(Color.IndianRed), new Point(15, 110));
           
        }
    }
}
