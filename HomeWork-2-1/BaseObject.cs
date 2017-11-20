using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    abstract class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        public virtual void Draw()
        {
            Image starImg = Image.FromFile("star.gif");

            Point ulC = new Point(pos.X, pos.Y);
            Point urC = new Point(pos.X + 32, pos.Y + 24);
            Point llC = new Point(pos.X, pos.Y + 24);
            Point[] dest = { ulC, urC, llC };

            Game.buffer.Graphics.DrawImage(starImg, dest);

            //Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }
        public virtual void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > Game.Height) dir.Y = -dir.Y;
        }
    }
}
