using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pang_
{
    class Ball
    {
        public Ball(float x, float y, float radius, float velocity, float angle, Size s, int novi)
        {
            X = x;
            Y = y;
            Radius = radius;
            Velocity = velocity;
            Angle = angle;
            velocityX = (float)Math.Cos(Angle) * Velocity; 
            velocityY = (float)Math.Sin(Angle) * Velocity;
            oldY = velocityY;
            Size = s;
            nov = novi;
        }
        public float X { get; set; }
        public float Y { get; set; }
        public int nov;
        public float Radius { get; set; }
        public float Velocity { get; set; }
        public float Angle { get; set; }
        public Rectangle Bounds;
        public float velocityX;
        public float velocityY, oldY;
        int sign = 1;
        private Size Size;
       
        public void Move()
        {
            #region pomestuvanje na topkata i gravitet
            float nextX = X + velocityX;
            float nextY = Y + velocityY;
            if (nextX - Radius <= Bounds.Left || (nextX + Radius >= Bounds.Right))
            {
                velocityX = -velocityX;
            }
            if (velocityY > 0) sign = 1;
            else sign = -1;

            int bound;
            if (Radius > 40) bound = 250;
            else if (Radius > 20) bound = 380;
            else bound = 480;

            if (nextY + Radius >= Bounds.Bottom)
                velocityY = -(float)Math.Sin(Angle) * Velocity;
            else if (Y <= bound)
            {
                velocityY += 2.14F;
                
            }
            else
            {
                velocityY = sign*oldY;
            }
            X += velocityX;
            Y += velocityY;

            #endregion
        }

        public void seOdbivaat(List<Ball> topki)
        {
            foreach (Ball ball in topki)
            {
                collision(ball);                
            }
        }
     

        public void collision(Ball ball2)
        {
            if (nov > 3)
            {
                float bRad = ball2.Radius;
                if (bRad < 15) bRad = 16;
                float Rad = Radius;
                if (Rad < 15) Rad = 16;

                #region Proverka na kolizija
                // ball hits ball2 from the right, and we don't know the direction of ball2 nor ball
                if ((((this.X + Radius) > (ball2.X - ball2.Radius) && (this.X + Radius) < (ball2.X + ball2.Radius)) && (((this.Y - Radius) >= (ball2.Y - Radius) && (this.Y - Radius) <= (ball2.Y + ball2.Radius)) || ((this.Y - Radius) <= (ball2.Y - ball2.Radius) && (this.Y + Radius) >= (ball2.Y - ball2.Radius)))))
                {
                   
                    if (Math.Abs(this.velocityX) < 0.5 && Math.Abs(velocityX) >= 0)
                        velocityX = ball2.velocityX;
                    else if (velocityX > 0)
                        velocityX *= (-1F);
                    else
                        velocityX *= 1F;

                    if (Math.Abs(ball2.velocityX) < 0.5 && Math.Abs(ball2.velocityX) >= 0)
                        ball2.velocityX = velocityX;
                    else if (ball2.velocityX > 0)
                        ball2.velocityX *= 1F;
                    else
                        ball2.velocityX *= -1F;
                }

                // ball hits ball2 from the left, and we don't know the direction of ball2 nor ball
                else  if ((((this.X - Radius) > (ball2.X - ball2.Radius) && (this.X - Radius) < (ball2.X + ball2.Radius)) && (((this.Y - Radius) >= (ball2.Y - ball2.Radius) && (this.Y - Radius) <= (ball2.Y + ball2.Radius)) || ((this.Y - Radius) <= (ball2.Y - ball2.Radius) && (this.Y + Radius) >= (ball2.Y - ball2.Radius)))))
                {                  
                    if (Math.Abs(velocityX) < 0.5 && Math.Abs(velocityX) >= 0)
                        velocityX = ball2.velocityX;
                    else if (velocityX < 0)
                        velocityX *= -1F;
                    else
                        velocityX *= 1F;

                    if (Math.Abs(ball2.velocityX) < 0.5 && Math.Abs(ball2.velocityX) >= 0)
                        ball2.velocityX = velocityX;
                    else if (ball2.velocityX < 0)
                        ball2.velocityX *= 1F;
                    else
                        ball2.velocityX *= -1F;
                }

                // ball2 hits ball from up, and we don't know the direction of ball2 nor ball
                else if (((this.Y - Rad) <= (ball2.Y + bRad) && (this.Y - Rad) >= (ball2.Y - bRad)) && (((this.X + Rad) >= (ball2.X + bRad) && (this.X - Rad) <= (ball2.X + bRad)) || ((this.X + Rad) <= (ball2.X + bRad) && (this.X + Rad) >= (ball2.X - bRad))))
                {
                   
                  if (Math.Abs(velocityY) < 0.5 && Math.Abs(velocityY) >= 0)
                     velocityY = ball2.velocityY;
                  else 
                    if (velocityY < 0)
                        velocityY *= -1F;
                    else
                        velocityY *= 1F;

                    if (Math.Abs(ball2.velocityY) < 0.5 && Math.Abs(ball2.velocityY) >= 0)
                      ball2.velocityY = velocityY;
                   else
                    if (ball2.velocityY < 0)
                        ball2.velocityY *= 1F;
                    else
                        ball2.velocityY *= -1F;
                }

                // ball2 hits ball from down, and we don't know the direction of ball2 nor ball
                else if (((ball2.Y - bRad) <= (this.Y + Rad) && (ball2.Y - bRad) >= (this.Y - Rad)) && (((ball2.X + bRad) >= (this.X + Rad) && (ball2.X - bRad) <= (this.X + Rad)) || ((ball2.X + bRad) <= (this.X + Rad) && (ball2.X + bRad) >= (this.X - Rad))))
                {

                    if (Math.Abs(ball2.velocityY) < 0.5 && Math.Abs(ball2.velocityY) >= 0)
                         ball2.velocityY=velocityY;
                    else
                        if (ball2.velocityY < 0)
                            ball2.velocityY *= -1F;
                        else
                            ball2.velocityY *= 1F;

                    if (Math.Abs(velocityY) < 0.5 && Math.Abs(velocityY) >= 0)
                        velocityY = ball2.velocityY;
                    else
                        if (velocityY < 0)
                            velocityY *= 1F;
                        else
                            velocityY *= -1F;
                }
                #endregion ball and ball2
            }
            else nov++;
        }


        public void Draw(Brush brush, Graphics g)
        {
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }

    }
}
