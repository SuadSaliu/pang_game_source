using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Pang_
{
    public partial class Level : Form
    {
        String url;
        int level;
        Graphics g;
        int i;
        Color col;
        public Level(int a)
        {
            InitializeComponent();
            
            Random num=new Random();
            this.CenterToScreen();
            i = 0;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            int ran = num.Next(0,5);            
            
            url = "level" + ran+ ".jpg";

            pbImage1.BackgroundImageLayout = ImageLayout.Stretch;
            pbImage1.BackgroundImage = Image.FromFile(url);
            g=pbImage1.CreateGraphics();

            if (ran == 2) col = Color.Black;
            else if (ran == 0) col = Color.Azure;
            else if (ran == 3) col = Color.Aquamarine;
            else if (ran == 4) col = Color.DarkGreen;
            else col = Color.Chocolate;

            level = a; 
            pbImage1.Invalidate();
             timer1.Start();
        }
        public void exit() { this.Close(); }
        private void pbImage1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawString("Level " + level, new Font("Courier", 25.0F, FontStyle.Bold), new SolidBrush(col), new Point(100, 75));
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            if (i > 1)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else i++;
        }
    }
}
