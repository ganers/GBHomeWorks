using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_7
{
    class Udvoitel
    {
        int current;
        int finish;

        public Udvoitel(int finish)
        {
            this.finish = finish;
            current = 1;
        }

        //Метод увеличивает число на 1
        public void CurrentAddOne()
        {
            current++;
        }

        //Метод увеличивает число в 2 раза
        public void CurrentMultiplyBy2()
        {
            current *= 2;
        }

        //Метод сбрасывает число до 1
        public void CurrentReset()
        {
            current = 1;
        }

        //Сво-во возвращает current
        public int Current
        {
            get { return current; }
        }

        //Сво-во возвращает finish
        public int Finish
        {
            get { return finish; }
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            #region Задача 1

            //Random rand = new Random();
            //int finish = rand.Next(1, 1000);

            //Udvoitel UObj = new Udvoitel(finish);

            //for (int step = 0; UObj.Current <= finish; step++)
            //{
            //    Console.Clear();

            //    if (UObj.Current == finish)
            //    {
            //        Console.WriteLine($"Вы победили за {step} шагов.\nКонечное число: {finish}\nВаше текущее число: {UObj.Current}");
            //        break;
            //    }

            //    Console.WriteLine($"Конечное число: {finish}\nВаше текущее число: {UObj.Current}\nКоличество шагов: {step}");
            //    Console.WriteLine("\nЕсли хотите добавить 1, введите 1\nЕсли хотите умножить на 2, введите 2\nЕсли хотите сбросить текущее значение, введите 0\n");

            //    switch (Console.ReadLine())
            //    {
            //        case "1":
            //            UObj.CurrentAddOne();
            //            break;
            //        case "2":
            //            UObj.CurrentMultiplyBy2();
            //            break;
            //        case "0":
            //            UObj.CurrentReset();
            //            break;
            //        default:
            //            Console.WriteLine("Введенной комманды не существует.\nПо пробуйте снова.");
            //            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            //            Console.ReadKey();

            //            step--;
            //            break;
            //    }
            //}

            //if (UObj.Current > finish)
            //{
            //    Console.WriteLine($"Перебор!!!\nКонечное число: {finish}\nВаше текущее число: {UObj.Current}.\n");
            //    Console.WriteLine("Нажмите любую клавишу для продолжения.");
            //    Console.ReadKey();
            //}

            #endregion
        }
    }
}
