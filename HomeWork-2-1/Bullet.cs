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
        Random rnd = new Random();

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Метод задает вид и форму объекта
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        /// <summary>
        /// Метод обновляет позицию объекта
        /// </summary>
        public override void Update()
        {
            if (pos.X < Game.Width + size.Width)
            {
                pos.X = pos.X + 5;
            }
        }
        /// <summary>
        /// Метод возвращает true если объект находится в границах поля игры или false если объект вышел за границы
        /// </summary>
        /// <returns></returns>
        public bool InField()
        {
            if (pos.X > (Game.Width + size.Width)) return false; else return true;
        }
        /// <summary>
        /// Метод меняет позицию объекта в место клика мыши
        /// </summary>
        /// <param name="x">X координата</param>
        /// <param name="y">Y Координата</param>
        public void UpdateAfterMouseClick(int x, int y)
        {
            if (x < Game.Width && y < Game.Height)
            {
                pos.X = x;
                pos.Y = y;
            }
        }
    }
}
