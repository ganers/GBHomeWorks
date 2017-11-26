using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class Asteroid:BaseObject,ICloneable,IComparable<Asteroid>
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

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y),
            new Size(size.Width, size.Height))
            { Power = Power };
            // Не забываем скопировать новому астероиду Power нашего астероида
            return asteroid;
        }

        int IComparable<Asteroid>.CompareTo(Asteroid obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }
    }
}
