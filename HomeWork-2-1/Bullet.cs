using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class Bullet:BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X + 5;
        }
    }
}
