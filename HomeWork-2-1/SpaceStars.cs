using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class SpaceStars:BaseObject
    {
        public SpaceStars(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }
        public override void Update()
        {
            if (pos.X < Game.Width/2)
            {
                pos.X -= 1;
                if (pos.Y < Game.Height/2) dir.Y -= 1;
                if (pos.Y > Game.Height / 2) dir.Y += 1;
            }
            else
            {
                pos.X += 1;
                if (pos.Y < Game.Height / 2) dir.Y -= 1;
                if (pos.Y > Game.Height / 2) dir.Y += 1;
            }

            Random rand = new Random();

            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) pos.X = rand.Next(Game.Width);
            if (pos.X > Game.Width) pos.X = rand.Next(Game.Width);
            if (pos.Y < 0) pos.Y = rand.Next(Game.Height);
            if (pos.Y > Game.Height) pos.Y = rand.Next(Game.Height);
        }
    }
}
