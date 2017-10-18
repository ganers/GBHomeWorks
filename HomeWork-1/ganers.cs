using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_1
{
    //*Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
    public class GanersClass
    {
        //Останавливает выполнение приложения до нажатия любой клавиши
        public void pause()
        {
            Console.ReadKey();
        }

        //Выводит сообщение в консоль в указаных координатах
        public void printMsg(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        //Выводит сообщение в консоль
        public void printMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        //Выводит сообщение в консоль
        public void printMsg(double msg)
        {
            Console.WriteLine(msg);
        }
        //Выводит сообщение в консоль
        public void printMsg(int msg)
        {
            Console.WriteLine(msg);
        }
    }
}
