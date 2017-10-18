using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_1;

namespace HomeWork_2
{
    class Program
    {
        //Метод возвращает меньшее из 3-х чисел
        static double Min3Num( double a, double b, double c)
        {
            double result = 0;
            result = (a < b && a < c) ? a : b < c ? b : c;
            return result;
        }

        //Метод считает количество цифр числа (если число введено строкой)
        static int CountNumber(string number)
        {
            int result = 0;

            if (Int32.TryParse(number, out int num))
            {
                while (num != 0)
                {
                    result++;
                    num /= 10;
                }
            }
            else
            {
                Console.WriteLine("Введенное значение не является числом.");
            }

            return result;
        }

        //Метод считает количество цифр числа
        static long CountNumber(long number)
        {
            long result = 0;
            while (number != 0)
            {
                result++;
                number /= 10;
            }
            return result;
        }

        //Метод принимает числа с клавиатуры пока не будет введен 0, затем считает сумму всех нечетных положительных чисел
        static long Hw2Task2()
        {
            long result = 0;
            string numInput = null;

            do
            {
                Console.WriteLine("Введите число");
                numInput = Console.ReadLine();
                if (numInput == "0")
                {
                    break;
                }

                if (Int32.TryParse(numInput, out int num))
                {
                    result = (num % 2 == 1 && num > 0) ? result + num : result;
                }
                else
                {
                    Console.WriteLine("Введенное значение не является числом.");
                }
            } while (true);

            return result;
        }

        //Метод проверки логина/пароля. Возвращает true или false в зависимости от результата проверки
        static bool auth(string login, string passwd)
        {
            bool result = false;
            if (login == "root" && passwd == "GeekBrains")
            {
                result = true;
            }
            return result;
        }

        //Задача 4
        static void Hw2Task4()
        {
            int count = 0;
            do
            {
                Console.Write("Имя пользователя: ");
                string login = Console.ReadLine();
                Console.Write("Пароль: ");
                string passwd = Console.ReadLine();
                if (auth(login, passwd))
                {
                    Console.WriteLine($"Добро пожаловать {login}!");
                    break;
                }
                else
                {
                    count++;
                    Console.WriteLine($"Логин или пароль не верны.\nОсталось попыток {3 - count}");
                }
            } while (count < 3);
        }

        //Метод проверят является ли число хорошим
        static bool GoodNum(long num)
        {
            long numTmp = num;
            long sum = 0;
            while (numTmp != 0)
            {
                sum = sum + (numTmp % 10);
                numTmp /= 10;
            }
            long sign = sum != 0 ? num % sum : 1;
            if (sign == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        //Задача 6. Найти кол-во хороших чисел
        static long Hw2Task6(long maxNum)
        {
            DateTime start = DateTime.Now;
            long result = 0;

            for (int i = 0; i <= maxNum; i++)
            {
                if (GoodNum(i))
                {
                    result++;
                }
            }

            DateTime finish = DateTime.Now;
            Console.WriteLine("Время работы программы: " + (finish - start));

            return result;
        }

        //Метод вывод числа от a до b (a < b) с помощью рекурсии
        static int Hw2Task7(int a, int b)
        {
            int sum = a;

            if (a < b)
            {
                Console.WriteLine(a);
                sum += Hw2Task7(a+1, b);
            }
            else
            {
                sum = 0;
            }
            return sum;
        }

        static void Hw2Task7(int a, int b, ref int sum)
        {
            if (a != b && a < b)
            {
                sum = sum + a;
                Console.WriteLine(a);
                Hw2Task7(a + 1, b, ref sum);
            }
        }

        static void Main(string[] args)
        {
            GanersClass ganersObj = new GanersClass();

            //Задание 1
            //ganersObj.printMsg(Min3Num(5, 8, 34));

            //Задание 2
            //ganersObj.printMsg("Введите число");
            //ganersObj.printMsg(CountNumber(Console.ReadLine()));

            //Задание 3
            //ganersObj.printMsg("Результат: " + Hw2Task2());

            //Задание 4
            //Hw2Task4();

            //Задание 6
            //Console.WriteLine(Hw2Task6(1000000000));

            //Задание 7
            int sum = Hw2Task7(1, 10);
            Console.WriteLine(sum);

            //int sum = 0;
            //Hw2Task7(1, 10, ref sum);
            //Console.WriteLine(sum);
        }
    }
}
