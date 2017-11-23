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
        Random rand = new Random();
        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size):base(pos, dir, size)
        {
            Power = 1;
        }
        /// <summary>
        /// Метод задает вид и форму объекта
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.Gray, pos.X, pos.Y, size.Width, size.Height);
        }
        /// <summary>
        /// Метод обновляет позицию объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < (-size.Width)) pos.X = Game.Width + (size.Width + rand.Next(Game.Width));
        }
        /// <summary>
        /// Метод обновляет позицию объекта после столкновения
        /// </summary>
        public void UpdateAfterCollision()
        {
            pos.X = rand.Next(Game.Width, Game.Width + Game.Width);
            pos.Y = rand.Next(Game.Height);
        }
    }
}
