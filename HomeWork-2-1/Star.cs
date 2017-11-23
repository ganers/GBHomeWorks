using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class Star:BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Метод задает вид и форму объекта
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }
        /// <summary>
        /// Метод обновляет позицию объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y - dir.Y;
            if (pos.X < 0) pos.X = Game.Width;
            if (pos.X > Game.Width) pos.X = 0;
            if (pos.Y < 0) pos.Y = Game.Height;
            if (pos.Y > Game.Height) pos.Y = 0;
        }
    }
}
