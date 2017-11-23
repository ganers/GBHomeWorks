using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    /// <summary>
    /// Интерфейс обработки столкновений
    /// </summary>
    interface IColission
    {
        bool Collision(IColission obj);
        Rectangle Rect { get; }
    }
}
