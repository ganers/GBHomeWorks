using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_4
{
    class BelieveNotBelieve
    {
        //Проверка существования элемента в массиве
        //Почему компилятор жалуется если при объявлении flag сразу не присвоено значение? Ведь в цикле всеравно оно будет присвоено!!!
        static bool ArraySearch(int[] arr, int search)
        {
            bool flag = false;

            foreach (var item in arr)
            {
                if (item == search)
                {
                    flag = true;
                    break;
                }
            }
            
            return flag;
        }

        //Возвращает массив с вопросами и варантами ответов
        static string[][] GetQuestions(int numQuestions)
        {
            string filePath = "questions.txt";
            string[] fileQuestions = File.ReadAllLines(filePath);
            string[][] questions = new string[numQuestions][];

            int[] num = new int[numQuestions];
            int tmp;
            int counter = 0;
            Random rand = new Random();

            while (counter < numQuestions)
            {
                tmp = rand.Next(1, fileQuestions.Length+1);
                if (!BelieveNotBelieve.ArraySearch(num, tmp))
                {
                    num[counter] = tmp;
                    counter++;
                }
            }

            for (int i = 0; i < num.Length; i++)
            {
                questions[i] = new string[2];
                questions[i] = fileQuestions[num[i]-1].Split(';');
            }

            return questions;
        }

        public void Start(int numQuestions)
        {
            string[][] questions = GetQuestions(numQuestions);
            int score = 0;
            string answer;

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine("Веришь ли ты что (\"да\" или \"нет\")\n");
                Console.WriteLine(questions[i][0]);
                answer = Console.ReadLine();
                answer = answer.Trim();
                questions[i][1] = questions[i][1].Trim();
                answer = answer.ToLower();
                questions[i][1] = questions[i][1].ToLower();

                //Console.WriteLine($"Вопрос - {questions[i][0]}, ответ на него {questions[i][1]}, вы ввели {answer}");

                if (answer == questions[i][1])
                {
                    score += 1;
                    Console.WriteLine("Это правда!");
                }
                else
                {
                    Console.WriteLine($"Это не правда!");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения.");
                Console.ReadLine();
            }

            Console.WriteLine($"Вы набрали {score} очков.");
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            //АНДРЕЙ АЛЕКСЕЕВ
            //Написать игру “Верю.Не верю”. В файле хранятся некоторые данные и правда это или нет.
            #region 6-я задача
            //BelieveNotBelieve BNBObj = new BelieveNotBelieve();
            //BNBObj.Start(3);
            #endregion

            //Существует алгоритмическая игра “Удвоитель”.
            //В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”,
            //достичь этого числа за минимальное число шагов. Робот умеет выполнять несколько команд: увеличить число на 1,
            //умножить число на 2 и сбросить число до 1. Начальное значение удвоителя равно 1.
            #region 5-я задача
            Random rand = new Random();
            int finish = rand.Next(1, 1000);

            Udvoitel UObj = new Udvoitel(finish);

            for (int step = 0; UObj.Current <= finish; step++)
            {
                Console.Clear();

                if (UObj.Current == finish)
                {
                    Console.WriteLine($"Вы победили за {step} шагов.\nКонечное число: {finish}\nВаше текущее число: {UObj.Current}");
                    break;
                }

                Console.WriteLine($"Конечное число: {finish}\nВаше текущее число: {UObj.Current}\nКоличество шагов: {step}");
                Console.WriteLine("\nЕсли хотите добавить 1, введите 1\nЕсли хотите умножить на 2, введите 2\nЕсли хотите сбросить текущее значение, введите 0\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        UObj.CurrentAddOne();
                        break;
                    case "2":
                        UObj.CurrentMultiplyBy2();
                        break;
                    case "0":
                        UObj.CurrentReset();
                        break;
                    default:
                        Console.WriteLine("Введенной комманды не существует.\nПо пробуйте снова.");
                        Console.WriteLine("Нажмите любую клавишу для продолжения.");
                        Console.ReadKey();

                        step--;
                        break;
                }
            }

            if (UObj.Current > finish)
            {
                Console.WriteLine($"Перебор!!!\nКонечное число: {finish}\nВаше текущее число: {UObj.Current}.\n");
                Console.WriteLine("Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
            }
            #endregion
        }
    }
}
