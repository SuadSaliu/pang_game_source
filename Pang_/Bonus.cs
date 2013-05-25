using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pang_
{
    class Bonus
    {
        public int x { get; set; }
        public int y { get; set; }
        public Image img;
        public bool drawtwo = false;
        Random r = new Random();
        public bool flag = false;
        public int randomN { get; set; }

        public Bonus()
        {
            x = r.Next(100, 500);
            y = 0;
        }

        public void move()
        {
            y += 20;
        }

        public void bonus_what()
        {
            do
            {
                randomN = r.Next(0, 5);

            } while (randomN < 1 && randomN > 4);

            if (randomN == 1)
            {
                img = Image.FromFile("bannana.jpg", true);
            }
            else if (randomN == 2)
            {
                img = Image.FromFile("orange.jpg", true);
            }
            else if (randomN == 3)
            {
                img = Image.FromFile("towarows.jpg", true);
            }
            else 
            {
                img = Image.FromFile("bomb.jpg", true);
                randomN = 4;
            }
        }

        public void draw(Graphics g)
        {
            g.DrawImage(img, new Point(this.x, this.y));
        }
    }
}