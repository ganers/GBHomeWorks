using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    /// <summary>
    /// Базовый абстрактный класс объектов
    /// </summary>
    abstract class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Координаты объекта</param>
        /// <param name="dir">Смещение объекта</param>
        /// <param name="size">Размер объекта</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        public abstract void Draw();

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
