using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_7
{
    class Udvoitel
    {
        int current;    //текущее число
        int finish;     //загаданое число
        int step;       //кол-во пройденых шагов
        int[] stepMemory = new int[0];  //все шаги по порядку

        //public Udvoitel(int finish)
        //{
        //    this.finish = finish;
        //    current = 1;
        //}

        public void InitGame(int finish)
        {
            this.finish = finish;
            this.current = 1;
            this.step = 0;
            this.stepMemory = new int[0];
        }

        //Метод увеличивает число на 1
        public void CurrentAddOne()
        {
            current++;
            step++;
            Array.Resize(ref stepMemory, stepMemory.Length + 1);
            stepMemory[step - 1] = current;
        }

        //Метод увеличивает число в 2 раза
        public void CurrentMultiplyBy2()
        {
            current *= 2;
            step++;
            Array.Resize(ref stepMemory, stepMemory.Length + 1);
            stepMemory[step - 1] = current;
        }

        //Метод сбрасывает число до 1
        public void CurrentReset()
        {
            current = 1;
            step++;
            Array.Resize(ref stepMemory, stepMemory.Length + 1);
            stepMemory[step - 1] = current;
        }

        public void BackStep()
        {
            if (step > 1)
            {
                step--;
                current = stepMemory[step - 1];
            }
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

        public int Step
        {
            get { return step; }
        }

        public bool isWin()
        {
            if (this.current == this.finish)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isStop()
        {
            if (this.current > this.finish)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            #region Задача 1

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            #endregion
        }
    }
}
