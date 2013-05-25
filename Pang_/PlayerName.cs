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
    public partial class PlayerName : Form
    {
        Graphics g;
        public String Player;
        public PlayerName()
        {
            InitializeComponent();
            this.CenterToScreen();
            g = this.CreateGraphics();
            txtName.KeyDown += new KeyEventHandler(txtName_KeyDown);

        }


        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                Player = txtName.Text;
                this.Close();
            }
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
        }


        private void PlayerName_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, 192, 192)), 0, 0, Width, Height);
            g.DrawString("Enter your name", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(50, 50));
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Player = txtName.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void PlayerName_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void PlayerName_KeyUp(object sender, KeyEventArgs e)
        {            
        }

        private void PlayerName_KeyPress(object sender, KeyPressEventArgs e)
        {           
        }

    }
}
