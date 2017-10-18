using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//АЛЕКСЕЕВ АНДРЕЙ. Домашнее задание №1.

namespace HomeWork_1
{
    class Program
    {
        static void headerHomeWork(string header)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(header);
            Console.ResetColor();
        }
        static void again()
        {
            Console.WriteLine("\n\n\nЕсли хотите выбрать другое ДЗ, напишите \"да\"");
            string answer = Console.ReadLine();
            if (answer == "да")
            {
                homeWorkInit();
            }
        }
        static void homeWorkInit()
        {
            Console.Clear();

            //*Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
            GanersClass ganersObj = new GanersClass();

            string helloMsg = "АЛЕКСЕЕВ АНДРЕЙ.\nДомашняя работа №1. \nДоступные задания и варианты:\n 1 задание, а, б, в.\n 2 задание без вариантов.\n 3 задание, а, б.\n 4 задание, а, б.\n 5 задание, а, б, в.\n 6 задание прийдется смотерть в коде.";
            ganersObj.printMsg(helloMsg, Console.WindowWidth / 2, 1);

            Console.WriteLine("\nВведите номер задания");
            string hwnum = Console.ReadLine();
            string variant = null;
            if (hwnum == "2" || hwnum == "6")
            {
                homeWork(hwnum, variant);
            } else if (hwnum == "1" || hwnum == "3" || hwnum == "4" || hwnum == "5")
            {
                Console.WriteLine("Введите вариант задания");
                variant = Console.ReadLine();
                homeWork(hwnum, variant);
            }
            else
            {
                Console.WriteLine("Такого задания нет.");
                again();
            }
        }
        static void xToY(double x1, double y1, double x2, double y2)
        {
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("{0:f2}", r);
        }
        static void homeWork(string hwnum, string variant)
        {
            GanersClass ganersObj = new GanersClass();

            if (hwnum == "1" && (variant == "а" || variant == "б" || variant == "в"))
            {
                //1.Написать программу “Анкета”. Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес).В результате вся информация выводится в одну строчку.
                //а) используя склеивание;
                //б) используя форматированный вывод;
                //в) *используя вывод со знаком $.

                string header = "\nНаписать программу “Анкета”. \nПоследовательно задаются вопросы (имя, фамилия, возраст, рост, вес). \nВ результате вся информация выводится в одну строчку.";
                headerHomeWork(header);
                ganersObj.printMsg("Введите ваше имя:");
                var firstname = Console.ReadLine();
                Console.WriteLine("Введите вашу фамилию:");
                var lastname = Console.ReadLine();
                Console.WriteLine("Введите ваш возраст:");
                var years = Console.ReadLine();
                Console.WriteLine("Введите ваш рост:");
                var growth = Console.ReadLine();
                Console.WriteLine("Введите ваш вес:");
                var weight = Console.ReadLine();
                if (variant == "а")
                {
                    header = "Вывод информации в одну строчку, используя склеивание.";
                    headerHomeWork(header);
                    Console.WriteLine("Имя: " + firstname + ". Фамилия: " + lastname + ". Возраст: " + years + ". Рост: " + growth + ". Вес: " + weight);
                    again();
                }
                else if (variant == "б")
                {
                    header = "Вывод информации в одну строчку, используя форматирование.";
                    headerHomeWork(header);
                    Console.WriteLine("Имя: {0}. Фамилия: {1}. Возраст: {2}. Рост: {3}. Вес: {4}.", firstname, lastname, years, growth, weight);
                    again();
                }
                else if (variant == "в")
                {
                    header = "Вывод информации в одну строчку, используя $.";
                    headerHomeWork(header);
                    decimal price = 123456789;
                    Console.WriteLine("Имя: {0}. Фамилия: {1}. Возраст: {2}. Рост: {3}. Вес: {4}. Ценник: {5:C1}.", firstname, lastname, years, growth, weight, price.ToString("C3", new CultureInfo("en-US")));
                    Console.WriteLine("Или если имелось ввиду форматировани с $\"{var}\"");
                    Console.WriteLine($"Имя: {firstname}. Фамилия: {lastname}. Возраст: {years}. Рост: {growth}. Вес: {weight}.");
                    again();
                }
            }
            else if (hwnum == "2")
            {
                //Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I = m / (h * h); где m-масса тела в килограммах, h - рост в метрах

                string header = "\nВвести вес и рост человека. \nРассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h*h); \nгде m-масса тела в килограммах, h - рост в метрах.";
                headerHomeWork(header);
                Console.WriteLine("Введите рост (см): ");
                float growth = Single.Parse(Console.ReadLine()) / 100;
                Console.WriteLine("Введите вес (кг): ");
                float weight = Single.Parse(Console.ReadLine());
                Console.WriteLine("Ваш индекс массы тела равен {0:0.0}.", weight / (growth * growth));
                again();
            }
            else if (hwnum == "3" && (variant == "а" || variant == "б")) {

                //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат используя спецификатор формата .2f(с двумя знаками после запятой);
                //б) *Выполните предыдущее задание оформив вычисления расстояния между точками в виде метода;

                string header = "\nНаписать программу, которая подсчитывает расстояние между точками \nс координатами x1, y1 и x2,y2 по формуле \nr=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).";
                headerHomeWork(header);
                Console.WriteLine("Введите по очереди координаты первой точки:");
                double x1 = Double.Parse(Console.ReadLine());
                double x2 = Double.Parse(Console.ReadLine());
                Console.WriteLine("Введите по очереди координаты второй точки:");
                double y1 = Double.Parse(Console.ReadLine());
                double y2 = Double.Parse(Console.ReadLine());
                if (variant == "а")
                {
                    header = "Вывести результат используя спецификатор формата .2f (с двумя знаками после запятой)";
                    headerHomeWork(header);
                    double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                    Console.WriteLine("{0:f2}", r);
                    again();
                }
                else if (variant == "б")
                {
                    header = "Выполнить задание оформив вычисления расстояния между точками в виде метода.\nИмя метода xToY().";
                    headerHomeWork(header);
                    xToY(x1, y1, x2, y2);
                    again();
                }
            }
            else if (hwnum == "4" && (variant == "а" || variant == "б"))
            {

                //Написать программу обмена значениями двух переменных
                //а) с использованием третьей переменной;
                //б) *без использования третьей переменной.

                string header = "\nНаписать программу обмена значениями двух переменных.";
                headerHomeWork(header);
                Console.WriteLine("Введите значение переменной a:");
                var a = Console.ReadLine();
                Console.WriteLine("Введите значение переменной b:");
                var b = Console.ReadLine();
                if (variant == "а")
                {
                    header = "С использованием третьей переменной.";
                    headerHomeWork(header);
                    Console.WriteLine("a = {0}, b = {1}", a, b);
                    string c = a;
                    a = b;
                    b = c;
                    Console.WriteLine("a = {0}, b = {1}", a, b);
                    again();
                }
                else if (variant == "б")
                {
                    header = "Без использования третьей переменной. Строки. Колхозный метод :-))).";
                    headerHomeWork(header);
                    Console.WriteLine("a = {0}, b = {1}", a, b);
                    int aCount = a.Length;
                    int bCount = b.Length;
                    a = a + b;
                    b = a.Substring(0, a.Length - bCount);
                    a = a.Substring(bCount);
                    Console.WriteLine("a = {0}, b = {1}", a, b);

                    header = "Без использования третьей переменной. Числа.";
                    headerHomeWork(header);

                    if (Int32.TryParse(a, out var a2) && Int32.TryParse(b, out var b2))
                    {
                        Console.WriteLine($"а = {a2}. b = {b2}");
                        a2 = a2 ^ b2;
                        b2 = a2 ^ b2;
                        a2 = a2 ^ b2;
                        Console.WriteLine($"а = {a2}. b = {b2}");
                    }
                    else
                    {
                        Console.WriteLine("Введенные значения не могут быть преобразованы в число.");
                    }

                    //headerHomeWork(header);
                    again();
                }
            }
            else if (hwnum == "5" && (variant == "а" || variant == "б" || variant == "в"))
            {

                //Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                //б) Сделать задание, только вывод организуйте в центре экрана
                //в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)

                string header = "\nНаписать программу, которая выводит на экран ваше имя, фамилию и город проживания.";
                headerHomeWork(header);
                Console.WriteLine("Введите ваше имя:");
                var firstname = Console.ReadLine();
                Console.WriteLine("Введите вашу фамилию:");
                var lastname = Console.ReadLine();
                Console.WriteLine("Введите город в котором вы живете:");
                var city = Console.ReadLine();
                if (variant == "а")
                {
                    header = "Вывод информации в одну строчку, используя склеивание.";
                    headerHomeWork(header);
                    string msg = "Имя: " + firstname + " Фамилия: " + lastname + " Город: " + city;
                    Console.Clear();
                    ganersObj.printMsg(msg);
                    again();
                }
                else if (variant == "б")
                {
                    header = "Вывод информации в центре экрана.";
                    headerHomeWork(header);
                    int x = Console.WindowWidth;
                    int y = Console.WindowHeight;
                    Console.SetCursorPosition(x / 2, y / 2);
                    string msg = $"Имя: {firstname}. Фамилия: {lastname}. Город: {city}.";
                    Console.Clear();
                    ganersObj.printMsg(msg);
                    again();
                }
                else if (variant == "в")
                {
                    header = "Вывод информации используя свой метод Print().";
                    headerHomeWork(header);
                    Console.WriteLine("Введите по очереди координаты X и Y.");
                    int x = Int32.Parse(Console.ReadLine());
                    int y = Int32.Parse(Console.ReadLine());
                    string msg = $"Имя: {firstname}. Фамилия: {lastname}. Город: {city}.";
                    Console.Clear();
                    ganersObj.printMsg(msg, x, y);
                    again();
                }
            }
            else
            {
                Console.WriteLine("\nТакого варианта задания не существует.");
                again();
            }
        }
        static void Main(string[] args)
        {
         

            homeWorkInit();
        }
    }
}
