using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_1;
using System.Numerics;

//АЛЕКСЕЕВ АНДРЕЙ - Домашняя работа № 3.

namespace HomeWork_3
{
    class Program
    {
        //Метод принимает числа с клавиатуры пока не будет введен 0, затем считает сумму всех нечетных положительных чисел
        static void InputNum()
        {
            long sum = 0;
            string numInput = null;
            string numbers = "Введенные числа:";
            string sumNumbers = "Положительные, нечентые числа:";

            do
            {
                Console.Clear();
                Console.WriteLine("Введите число");
                numInput = Console.ReadLine();
                numbers = numInput != "0" ? numbers + " " + numInput : numbers;


                if (Int32.TryParse(numInput, out int num))
                {
                    sum = (num % 2 == 1 && num > 0) ? sum + num : sum;
                    sumNumbers = (num % 2 == 1 && num > 0) ? sumNumbers + " " + numInput : sumNumbers;
                }
                else
                {
                    Console.WriteLine("Введенное значение не является числом.");
                }
            } while (numInput != "0" || numInput != "-0");

            Console.Clear();
            Console.Write($"{numbers}.\n{sumNumbers}\nСумма нечетных положительных чисел: {sum}.\n");
            Console.ReadLine();
        }

        //Метод принимает числа с клавиатуры пока не будет введен 0, затем считает сумму всех нечетных положительных чисел с использованием обработки ИСКЛЮЧЕНИЙ
        static void InputNumTry()
        {
            long sum = 0;
            string numInput = null;
            string numbers = "Введенные числа:";
            string sumNumbers = "Положительные, нечентые числа:";
            bool flag = true;   //Флаг для определения правильности ввода чисел

            do
            {
                Console.Clear();
                Console.WriteLine("Введите число");
                numInput = Console.ReadLine();
                numbers = numInput != "0" ? numbers + " " + numInput : numbers;

                try
                {
                    int num = Int32.Parse(numInput);
                    sum = (num % 2 == 1 && num > 0) ? sum + num : sum;
                    sumNumbers = (num % 2 == 1 && num > 0) ? sumNumbers + " " + numInput : sumNumbers;
                }
                catch
                {
                    flag = false;
                    break;
                }

            } while (numInput != "0" || numInput != "-0");

            if(flag)
            {
                Console.Clear();
                Console.Write($"{numbers}.\n{sumNumbers}\nСумма нечетных положительных чисел: {sum}.\n");
                Console.ReadLine();
            } else
            {
                Console.WriteLine("Введенное значение не является числом.");
            }
            
        }

        //Класс дробей - рациональных чисел
        class Fraction
        {
            int numerator, denominator;

            public Fraction()
            {
                numerator = 0;
                denominator = 0;
            }

            public Fraction(int numerator, int denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            //Метод для доступа к переменной числитель
            public int Numerator
            {
                get { return numerator; }
                set { if (value >= 0) numerator = value; }
            }
            //Метод для доступа к переменной знаменатель
            public int Denominator
            {
                get { return denominator; }
                set { if (value >= 0) denominator = value; }
            }
            //Метод приведения к общему знаменателю
            public static void GeneralDenominator(ref Fraction fract1, ref Fraction fract2)
            {
                int maxDen;
                int minDen;
                int genDen = 0;

                if (fract1.denominator > fract2.denominator)
                {
                    maxDen = fract1.denominator;
                    minDen = fract2.denominator;
                }
                else
                {
                    maxDen = fract2.denominator;
                    minDen = fract1.denominator;
                }

                genDen = maxDen;

                while (true)
                {
                    if (genDen % minDen == 0 )
                    {
                        break;
                    }
                    else
                    {
                        genDen += maxDen;
                    }
                }

                fract1.numerator = (genDen / fract1.denominator) == 1 ? fract1.numerator : fract1.numerator * (genDen / fract1.denominator);
                fract2.numerator = (genDen / fract2.denominator) == 1 ? fract2.numerator : fract2.numerator * (genDen / fract2.denominator);
                fract1.denominator = genDen;
                fract2.denominator = genDen;
            }
            //Метод сокращения дробей
            public static void Reduction(ref Fraction fract)
            {
                int redK = 0;
                int min = fract.numerator < fract.denominator ? fract.numerator : fract.denominator;

                while (min != 0)
                {
                    if (fract.numerator % min == 0 && fract.denominator % min == 0)
                    {
                        redK = min;
                        min = 0;
                    }
                    else
                    {
                        min--;
                    }
                }

                if (redK > 0)
                {
                    fract.numerator /= redK;
                    fract.denominator /= redK;
                }
            }
            
            //Метод сложения дробей
            public static Fraction Plus(Fraction fract1, Fraction fract2)
            {
                if (fract1.denominator != fract2.denominator)
                {
                    GeneralDenominator(ref fract1, ref fract2);
                }

                int genDen = fract1.denominator;

                Fraction fract3 = new Fraction();
                fract3.numerator = fract1.numerator + fract2.numerator;
                fract3.denominator = genDen;

                Reduction(ref fract3);

                return fract3;
            }

            //Метод вычитания дробей
            public static Fraction Minus(Fraction fract1, Fraction fract2)
            {
                if (fract1.denominator != fract2.denominator)
                {
                    GeneralDenominator(ref fract1, ref fract2);
                }

                int genDen = fract1.denominator;

                Fraction fract3 = new Fraction();
                fract3.numerator = fract1.numerator - fract2.numerator;
                fract3.denominator = genDen;

                Reduction(ref fract3);

                return fract3;
            }

            //Метод умножения дробей
            public static Fraction Multiplication(Fraction fract1, Fraction fract2)
            {
                Fraction fract3 = new Fraction();
                fract3.numerator = fract1.numerator * fract2.numerator;
                fract3.denominator = fract1.denominator * fract2.denominator;

                Reduction(ref fract3);

                return fract3;
            }

            //Метод умножения дробей
            public static Fraction Division(Fraction fract1, Fraction fract2)
            {
                Fraction fract3 = new Fraction();
                fract3.numerator = fract1.numerator * fract2.denominator;
                fract3.denominator = fract1.denominator * fract2.numerator;

                Reduction(ref fract3);

                return fract3;
            }

            //Метод вывода дроби на экран
            public static void Print(Fraction fract)
            {
                if (fract.numerator > fract.denominator)
                {
                    int whooleNum = fract.numerator / fract.denominator;
                    for (int i = 0; i < whooleNum; i++)
                    {
                        fract.numerator -= fract.denominator;
                    }
                    Console.Write($" {fract.Numerator}\n{whooleNum}--\n {fract.Denominator}\n");
                }
                else
                {
                    Console.Write($" {fract.Numerator}\n--\n {fract.Denominator}\n");
                }
            }

        }

        static void Main(string[] args)
        {
            //Вторая задача
            //InputNumTry();

            Fraction f1 = new Fraction(5, 6);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = Fraction.Plus(f1, f2);
            Fraction f4 = Fraction.Minus(f1, f2);
            Fraction f5 = Fraction.Multiplication(f1, f2);
            Fraction f6 = Fraction.Division(f1, f2);

            Console.WriteLine("Первая дробь (упрощеная):");
            Fraction.Print(f1);
            Console.WriteLine("Вторая дробь (упрощеная):");
            Fraction.Print(f2);

            Console.WriteLine("Результат сложения дробей:");
            Fraction.Print(f3);

            Console.WriteLine("Результат вычитания дробей:");
            Fraction.Print(f4);

            Console.WriteLine("Результат умножения дробей:");
            Fraction.Print(f5);

            Console.WriteLine("Результат деления дробей:");
            Fraction.Print(f6);

        }
    }
}
