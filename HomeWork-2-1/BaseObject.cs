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
    abstract class BaseObject:IColission
    {
        public delegate void Message();

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
        /// <summary>
        /// Прямоугольная область которую занимает объект
        /// </summary>
        public Rectangle Rect
        {
            get { return new Rectangle(pos, size); }
        }
        /// <summary>
        /// Метод возвращает true если объект пересекается с obj и fslse если не пересекается
        /// </summary>
        /// <param name="obj">Объект для проверки</param>
        /// <returns></returns>
        public bool Collision(IColission obj)
        {
            if (obj.Rect.IntersectsWith(this.Rect)) return true; else return false;
        }
        /// <summary>
        /// Метод задает вид и форму объекта
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Метод обновляет позицию объекта на форме
        /// </summary>
        public abstract void Update();
    }
}
