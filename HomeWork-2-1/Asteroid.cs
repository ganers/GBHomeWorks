using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class Asteroid:BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size):base(pos,dir,size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.White, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            Random rnd = new Random();
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) pos.X = Game.Width + (size.Width + rnd.Next(Game.Width));
        }
    }
}
