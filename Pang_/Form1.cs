using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;
using System.Reflection;

namespace Pang_
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        Graphics gr;
        Graphics g, m;
        Ball ball;
        List<Ball> balls;
        Bitmap buffer;
        Image imgPlayer, background;
        int lives, numArrows = 0;
        public int points;
        bool isfinished = true, drawedBall = false, fl = false, getThat, novLevel = true, nn = true, nn2=true, pause = false, drawTheSecondArrow = false, isfinished2 = true;
        bool drawedBall2 = false, start = true;
        int ballNo, levelNo;
        String playerName;
        Bonus bonus;

        int x = -30, y = -20, y1 = -20, x2 = -30, y2 = -20, z = -20;
        Hero hero;
        public Form1(String player)
        {
            InitializeComponent();
            playerName = player;
            initializeVariables();
        }

        public void initializeVariables()
        {
            #region inicijalizacija na promenlivi
            Random r = new Random();
            int interval = r.Next(15000, 20000);
            timer5.Interval = interval;
            timer5.Start();
            getThat = true;
            ballNo = 0;
            bonus = new Bonus();
            levelNo = 1;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.CenterToScreen();
            rect = new Rectangle(20, 15, this.Size.Width - 45, 510);
            string url = "ima.png";
            if (playerName.Length == 0)
                playerName = "Unknown";
            imgPlayer = Image.FromFile(url, true);
            hero = new Hero((rect.X + rect.Width) / 2 - imgPlayer.Size.Width / 2, rect.Height - imgPlayer.Size.Height, imgPlayer);
            buffer = new Bitmap(rect.Width, rect.Height + 20);
            gr = this.CreateGraphics();
            if (playerName.Length > 6)
                lbl2.Location = new Point(lbl2.Location.X - 65, lbl2.Location.Y);

            if (playerName.Length > 9)
                lbl2.Location = new Point(lbl2.Location.X - 20, lbl2.Location.Y);
            if (playerName.Length > 13)
                playerName = playerName.Substring(0, 13);
            lbl2.Text = playerName;
            points = 0;
            bonus.bonus_what();
            lives = 3;
            newLevel(true);
            #endregion
        }
        public void allowArrow()
        {
            isfinished = true;
            y1 = -100; y = -100;
            x = -100;
            numArrows--;
            drawedBall = false;
        }

        public void allowArrow2()
        {
            isfinished2 = true;
            z = -100; y2 = -100;
            x2 = -100;
            numArrows--;
            drawedBall2 = false;
        }
        public void newBackgroundImage()
        {
            Random num = new Random();
            String url = "backg" + num.Next(0, 5) + ".jpg";
            background = Image.FromFile(url);
        }

        public void newLevel(Boolean newLev)
        {
            #region kreiranje na novo nivo ili prodolzuvanje na staroto nivo po zagubeniot zivot
            start = true;
            m = pcbLives.CreateGraphics();
            if (newLev)
            {
                newBackgroundImage();
                newLevelBallNumber();
                Level lev = new Level(levelNo);
                this.Visible = false;
                lev.ShowDialog();
                this.Visible = true;
                gr.DrawImageUnscaled(background, 0, 0);
            }
            else
            {
                Thread.Sleep(3000); nn = false; nn2 = false;
                m.Clear(panel1.BackColor);
            }

            allowArrow(); allowArrow2();
            nn = false; drawTheSecondArrow = false; nn2 = false;
            balls = new List<Ball>();
            Rectangle bounds = new Rectangle(rect.X - 23, rect.Y, (int)rect.Width + 3, rect.Height);
            int minus = 1;
            for (int i = 0; i < ballNo; i++)
            {
                int xCoordinate;
                if (minus > 0)
                    xCoordinate = i * 100 + 50;
                else xCoordinate = rect.Width - (i * 100) - 50;
                int yCoordinate = (rect.Y + rect.Height + 20) / 4 + ((i + 1) * minus * (100)) % (rect.Y + rect.Height) / 4;
                minus = -minus;
                ball = new Ball(xCoordinate, yCoordinate, 50, 18, (float)(Math.PI * 2 / 5), this.Size, 4);
                ball.velocityX *= minus;
                ball.Bounds = bounds;
                balls.Add(ball);
            }
            hero.X = (rect.X + rect.Width) / 2 - imgPlayer.Size.Width / 2;
            timer1.Start(); timer3.Start(); novLevel = true;
            #endregion
        }
        public void newLevelBallNumber()
        {
            ballNo = (int)(ballNo * 1.2) + 1;
        }

        #region tajmeri

        private void timer1_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(buffer);
            g.Clear(Color.White);
            OnPaint(g, true, 0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (y < 25)
            {
                allowArrow();
                timer2.Stop();
            }
            else
                OnPaint(g, false, 1);

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (balls.Count == 0 && novLevel)
            {
                levelNo++;
                novLevel = false;
                timer3.Stop();
                newLevel(true);
            }
            nn = true; nn2 = true;
            foreach (Ball topka in balls)
            {

                double distance = Math.Sqrt((topka.X - (hero.X + 10)) * (topka.X - (hero.X + 10)) + (topka.Y - hero.Y - 18) * (topka.Y - 18 - hero.Y));
                double distance2 = Math.Sqrt((topka.X - (hero.X + 6 + hero.img.Width / 2)) * (topka.X - (hero.X + 6 + hero.img.Width / 2)) + (topka.Y - 8 - hero.Y) * (topka.Y - 8 - hero.Y));
                double distance3 = Math.Sqrt((topka.X - (hero.X + 56)) * (topka.X - (hero.X + 56)) + (topka.Y - hero.Y - 23) * (topka.Y - 23 - hero.Y));
                double distance4 = Math.Sqrt((topka.X - (hero.X + 56)) * (topka.X - (hero.X + 56)) + (topka.Y - hero.Y - 68) * (topka.Y - 68 - hero.Y));

                if (distance <= topka.Radius || distance2 <= topka.Radius || distance3 <= topka.Radius || distance4 <= topka.Radius)
                {
                    lives--; timer1.Stop(); timer2.Stop(); timer3.Stop(); timer4.Stop();
                    nn = false; nn2 = false; drawTheSecondArrow = false;
                    if (lives <= 0)
                    {
                        pisinadatoteka();
                        gr.DrawString("Game Over " + playerName, new Font("Arial", 30.0F, FontStyle.Bold), new SolidBrush(Color.Blue), new Point(300, 250));
                        timer3.Stop();
                        HighScore1 high = new HighScore1();
                        high.ShowDialog();
                        Thread.Sleep(2000);

                    }
                    else
                    {
                        Updatethe();
                    }
                }

            }

        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (y2 < 25)
            {
                allowArrow2();
                timer4.Stop();
            }
            else
                OnPaint(g, false, 2);
        }
        private void timer5_Tick_1(object sender, EventArgs e)
        {
            bonus = new Bonus();
            bonus.bonus_what();
            fl = true;
            Random r = new Random();
            int interval = r.Next(15000, 20000);
            timer5.Interval = interval;
            getThat = false;
        }
       

        private void timer6_Tick(object sender, EventArgs e)
        {
            getThat = true; timer6.Stop();
        }
        #endregion

        #region OnPaint metodot
        protected void OnPaint(Graphics g, bool flag, int n)
        {
            if (flag)
            {
                hitTheBall();
                foreach (Ball topka in balls)
                {
                    topka.Move();
                    topka.Draw(new SolidBrush(Color.Red), g);
                }

                List<Ball> topki = new List<Ball>(balls);
                foreach (Ball topka in balls)
                {
                    topki.Remove(topka);
                    topka.seOdbivaat(topki);
                }

                if (fl)
                {
                    bonus.draw(g);
                    bonus.move();
                    if (bonus.y + bonus.img.Height > rect.Y + rect.Height - 10)
                    {
                        fl = false;
                        timer6.Start();
                    }
                }
                else
                {
                    if (!getThat)
                    {
                        if ((hero.X <= bonus.x + 57 && hero.X >= bonus.x) || (hero.X + 70 >= bonus.x && hero.X <= bonus.x + 57))
                        {
                            points += 200; getThat = true;

                            if (bonus.randomN == 4)
                            {
                                explodeBalls();
                            }
                            else if (bonus.randomN == 3)
                            {
                                drawTheSecondArrow = true;
                            }

                        }
                        else
                        {
                            bonus.draw(g);
                        }
                    }
                }

                g.DrawLine(new Pen(Color.Blue, 4), new Point(x, y1), new Point(x, y));
                g.DrawLine(new Pen(Color.Blue, 4), new Point(x, y), new Point(x - 10, y + 10));
                g.DrawLine(new Pen(Color.Blue, 4), new Point(x, y), new Point(x + 10, y + 10));


                g.DrawLine(new Pen(Color.Blue, 4), new Point(x2, z), new Point(x2, y2));
                g.DrawLine(new Pen(Color.Blue, 4), new Point(x2, y2), new Point(x2 - 10, y2 + 10));
                g.DrawLine(new Pen(Color.Blue, 4), new Point(x2, y2), new Point(x2 + 10, y2 + 10));
                hero.drawtheImg(g);
            }

            else
            {
                if (n == 1)
                {
                    g.DrawLine(new Pen(Color.White, 4), new Point(x, y), new Point(x - 10, y + 10));
                    g.DrawLine(new Pen(Color.White, 4), new Point(x, y), new Point(x + 10, y + 10));
                    g.DrawLine(new Pen(Color.Blue, 4), new Point(x, y1), new Point(x, y - 25));
                    y = y - 25;
                    g.DrawLine(new Pen(Color.Blue, 4), new Point(x, y), new Point(x - 10, y + 10));
                    g.DrawLine(new Pen(Color.Blue, 4), new Point(x, y), new Point(x + 10, y + 10));
                }
                else if (n == 2)
                {
                    g.DrawLine(new Pen(Color.White, 4), new Point(x2, y2), new Point(x2 - 10, y2 + 10));
                    g.DrawLine(new Pen(Color.White, 4), new Point(x2, y2), new Point(x2 + 10, y2 + 10));
                    g.DrawLine(new Pen(Color.Blue, 4), new Point(x2, z), new Point(x2, y2 - 25));
                    y2 = y2 - 25;
                    g.DrawLine(new Pen(Color.Blue, 4), new Point(x2, y2), new Point(x2 - 10, y2 + 10));
                    g.DrawLine(new Pen(Color.Blue, 4), new Point(x2, y2), new Point(x2 + 10, y2 + 10));
                }
                hero.drawtheImg(g);
            }
            if (start)
            {
                gr.DrawImageUnscaled(background, 0, 0); start = false;

            }

            lblPoeni.Text = points.ToString();

            m.DrawString(lives.ToString() + " x ", new Font("Arial", 26.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(0, 15));
            Rectangle r = new Rectangle(rect.X - 20, rect.Y - 15, rect.Width - 1, rect.Height + 18);

            g.DrawRectangle(new Pen(Color.Blue), r);
            gr.DrawImageUnscaled(buffer, rect.X, rect.Y);
        }
        #endregion

        #region Delenje na topkata
        private void splitTheBall(Ball b, int idx, bool hitted, bool hitted2)
        {
            Ball b1 = new Ball(b.X, b.Y, b.Radius / 2, 18, (float)(Math.PI * 2 / 5), this.Size, 0);
            Ball b2 = new Ball(b.X, b.Y, b.Radius / 2, 18, (float)(Math.PI * 2 / 5), this.Size, 0);
            points += 200;
            b1.Bounds = b.Bounds;
            b2.Bounds = b1.Bounds;
            b2.velocityX = -b2.velocityX;

            b1.velocityY = -b1.velocityY + 1F;
            b2.velocityY = -b2.velocityY + 1F;

            balls.RemoveAt(idx);

            if (b1.Radius > 10)
            {
                balls.Add(b1); balls.Add(b2);
            }
            if (hitted)
            {
                drawedBall = true;
                y = -100; x = -110;
            }
            if (hitted2)
            {
                drawedBall2 = true;
                y2 = -100; x2 = -100;
            }
        }

        public void explodeBalls()
        {
            int counter = 0;
            while (true)
            {
                bool exAll = true;
                int i = 0; counter = balls.Count;
                while (i < counter)
                {
                    if (balls[i].Radius > 15)
                    {
                        splitTheBall(balls[i], i, false, false);
                        counter--;
                        exAll = false;
                    }
                    i++;
                }
                if (exAll)
                    break;
            }
        }

        private void hitTheBall()
        {
            int i = 0;
            foreach (Ball b in balls)
            {
                if (x >= b.X - b.Radius && x <= b.X + b.Radius && y <= b.Y + b.Radius && !drawedBall)
                {
                    splitTheBall(b, i, true, false);
                    break;
                }

                i++;
            } i = 0;
            foreach (Ball b in balls)
            {
                if (x2 >= b.X - b.Radius && x2 <= b.X + b.Radius && y2 <= b.Y + b.Radius && !drawedBall2)
                {
                    splitTheBall(b, i, false, true);
                    break;
                }
                i++;
            }
        }
        #endregion

        public void Updatethe()
        {
            timer3.Stop();
            newLevel(false);
        }

        #region pisuvanje rezultatot vo datoteka
        public void pisinadatoteka()
        {
            Stream str = File.OpenRead("Scores.bin");
            BinaryFormatter bf = new BinaryFormatter();

            List<Player> aal = (List<Player>)bf.Deserialize(str);

            Player p = new Player(playerName, points);
            aal.Add(p);
            str.Close();
            str = File.Create("Scores.bin");

            bf = new BinaryFormatter();
            bf.Context = new StreamingContext(StreamingContextStates.CrossAppDomain);
            bf.Serialize(str, aal);
            str.Close();
        }
        #endregion

        #region nastani pri pritiskanje na tastatura
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        { }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed(e, false);
            if (e.KeyData == Keys.P)
            {
                pause = !pause;
                if (pause)
                {
                    timer1.Stop();
                    nn = false; nn2 = false;
                    timer2.Stop();
                    timer3.Stop(); timer4.Stop();
                }
                else
                {
                    timer2.Start(); timer4.Start();
                    nn = true; nn2 = true;
                    timer1.Start(); Thread.Sleep(2); timer3.Start();
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyPressed(e, true);
        }
        public void keyPressed(KeyEventArgs e, bool space)
        {
            if (e.KeyData == Keys.Left)
            {
                if (hero.X > rect.X - 20) hero.moveLeft();

            }
            if (e.KeyData == Keys.Right)
            {
                if (hero.X + hero.img.Width < rect.X + rect.Width - 25)
                    hero.moveRight();
            }
            if (e.KeyData == Keys.Alt)
            {

            }
            if (space)
            {
                if (e.KeyData == Keys.Space)
                {
                    if (isfinished && nn)
                    {
                        x = (int)hero.X + hero.img.Width / 2;
                        y = rect.Height;
                        y1 = y; y = y - hero.img.Height;
                        timer2.Start();
                        isfinished = false;
                        numArrows++;

                    }
                    else if (drawTheSecondArrow && numArrows < 2 && isfinished2 && !isfinished && nn2)
                    {
                        x2 = (int)hero.X + hero.img.Width / 2;
                        y2 = rect.Height;
                        z = y2; y2 = y2 - hero.img.Height;
                        timer4.Start();
                        isfinished2 = false;
                        numArrows++;
                    }

                }
            }

        }
        #endregion

        private void pcbLives_Paint(object sender, PaintEventArgs e)
        {
            m.DrawString(lives.ToString(), new Font("Arial", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), new Point(15, 15));
        }                      
    }
}