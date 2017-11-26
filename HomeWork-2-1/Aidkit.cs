using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class Aidkit : BaseObject
    {
        Random rnd = new Random();

        public Aidkit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillRectangle(new SolidBrush(Color.White), pos.X, pos.Y,size.Width, size.Height);
            Game.buffer.Graphics.DrawLine(Pens.Red, pos.X, pos.Y + (size.Height/2), pos.X + size.Width, pos.Y + (size.Height / 2));
            Game.buffer.Graphics.DrawLine(Pens.Red, pos.X + (size.Width / 2), pos.Y, pos.X + (size.Width / 2), pos.Y + size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < (-size.Width)) pos.X = Game.Width + (size.Width + rnd.Next(Game.Width));
        }
    }
}
