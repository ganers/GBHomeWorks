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
        static Image asteroidImg;
        Random rnd = new Random();
        public int Power { get; set; }
        public int ScoreForDestruction { get; set; }
        public Point Speed { get; set; }

        public Asteroid(Point pos, Point dir, Size size):base(pos, dir, size)
        {
            Power = 1;
            ScoreForDestruction = size.Width + size.Height;
            Speed = dir;
            asteroidImg = Image.FromFile("pictures/asteroid1.png");
        }
        /// <summary>
        /// Метод задает вид и форму объекта
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(asteroidImg, pos.X, pos.Y, size.Width, size.Height);
        }
        /// <summary>
        /// Метод обновляет позицию объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < (-size.Width))
            {
                pos.X = Game.Width + (size.Width + rnd.Next(Game.Width));
                pos.Y = rnd.Next(Game.Height);
            }
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y),
            new Size(size.Width, size.Height))
            { Power = Power };
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
