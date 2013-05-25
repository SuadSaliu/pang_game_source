using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace Pang_
{
    public partial class startTheGame : Form
    {
        Graphics g;
        Boolean trepenje = true;
        String playerN;
        public startTheGame()
        {
            InitializeComponent();
            this.CenterToScreen();
            
            try
            {
                if (!File.Exists("Scores.bin"))
                {
                    List<Player> al = new List<Player>();

                    Player roger = new Player("Roger", 813);
                    Player rafael = new Player("Rafael", 346);
                    Player unk = new Player("Unknown", 0);
                    Player unk1 = new Player("Unknown1", 0);

                    al.Add(roger); al.Add(rafael); al.Add(unk); al.Add(unk1);

                    Stream str = File.Create("Scores.bin");

                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Context = new
                    StreamingContext(StreamingContextStates.CrossAppDomain);
                    bf.Serialize(str, al);

                    str.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Invalidate();
        }

        private void startTheGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawString("Start New Game", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(228, 132));
            g.DrawString("Start New Game", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(228, 132));

            g.DrawString("Highscore", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(253, 182));
            g.DrawString("Highscore", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(253, 182));

            g.DrawString("Developed By", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(228, 232));
            g.DrawString("Developed By", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(228, 232));
        }

        private void startTheGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X >= 228 && e.X <= 394 && e.Y >= 132 && e.Y <= 149)
            {
                PlayerName player = new PlayerName();
                
                if (player.ShowDialog() == DialogResult.OK)
                {
                    playerN = player.Player;
                    this.Visible = false;
                    Form1 f1 = new Form1(playerN);
                    
                    f1.Visible = false;
                     f1.ShowDialog();
                    f1.Close();
                    this.Visible = true;
                }

            }
            else if (e.X >= 258 && e.X <= 357 && e.Y >= 185 && e.Y <= 200)
            {
                HighScore1 high = new HighScore1();
                high.ShowDialog();

            }
            else if (e.X >= 233 && e.X <= 370 && e.Y >= 236 && e.Y <= 252)
            {
                DevelopedBy db = new DevelopedBy();
                db.ShowDialog();
            }
        }

        private void startTheGame_MouseHover(object sender, EventArgs e)
        {

        }

        private void startTheGame_MouseEnter(object sender, EventArgs e)
        {

        }

        private void startTheGame_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void startTheGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= 228 && e.X <= 394 && e.Y >= 132 && e.Y <= 149)
            {
                if (trepenje)
                {
                    Point[] points ={   new Point (218,130),
                                        new Point (225,160),
                                        new Point (397,160),
                                        new Point (404,130),
                                    };
                    Graphics m = this.CreateGraphics();
                    m.FillPolygon(new SolidBrush(Color.Silver), points);
                    m.DrawString("Start New Game", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(228, 132));
                    m.DrawString("Start New Game", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(228, 132));
                    trepenje = false;
                }
            }
            else if (e.X >= 258 && e.X <= 357 && e.Y >= 185 && e.Y <= 200)
            {
                if (trepenje)
                {
                    Point[] points1 ={ new Point (248,180),
new Point (255,211),
new Point (360,211),
new Point (367,180),
};
                    Graphics m = this.CreateGraphics();
                    m.FillPolygon(new SolidBrush(Color.Silver), points1);

                    m.DrawString("Highscore", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(253, 182));
                    m.DrawString("Highscore", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(253, 182));
                    trepenje = false;
                }
            }
            else if (e.X >= 233 && e.X <= 370 && e.Y >= 236 && e.Y <= 252)
            {
                if (trepenje)
                {
                    Point[] points2 ={ new Point (223,231),
new Point (228,259),
new Point (373,259),
new Point (380,231),
};
                    Graphics m = this.CreateGraphics();
                    m.FillPolygon(new SolidBrush(Color.Silver), points2);

                    m.DrawString("Developed By", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(228, 232));
                    m.DrawString("Developed By", new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(228, 232));
                    trepenje = false;
                }
            }
            else
            {
                Invalidate();
                trepenje = true;
            }

        }

        public void startTheGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                startTheGame_MouseClick(this,new MouseEventArgs(MouseButtons.Left,1,230,135,0));
        }
    }
}