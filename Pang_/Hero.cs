using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pang_
{
    class Hero
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Image img { get; set; }
        public float VelocityX { get; set; }

        public Hero(float x,float y,Image i)
        {
            X = x;
            Y = y;
            img = i;
            VelocityX=(float)Math.Cos((float)(Math.PI * 2 / 5)) * 10;
        }

        public void drawtheImg(Graphics g)
        {
            g.DrawImageUnscaled(img, (int) X, (int) Y);

        }
        public void moveRight()
        {
            X +=10;
        }
        public void moveLeft()
        {
            X -= 10;
        }
    }
}
