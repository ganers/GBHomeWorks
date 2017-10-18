using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HomeWork_5
{
    class Program
    {
        //Структура для проверки правильности ввода логин/пароля
        struct Authorization
        {
            //Метод получает и проверяет логин пользователя
            public bool GetLogin(string login)
            {
                bool error = false;

                if (login.Length >= 2 && login.Length <= 10)
                {
                    if (!Char.IsDigit(login[0]))
                    {
                        for (int i = 0; i < login.Length; i++)
                        {
                            if (!Char.IsLetterOrDigit(login, i))
                            {
                                error = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        error = true;
                    }
                }
                else
                {
                    error = true;
                }

                if (error == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //Метод получает и проверяет пароль пользователя
            public void GetPassword(string psswd)
            {

            }
        }

        //Класс для работы с строками. Для второй задачи.
        class MyString
        {
            //Метод переводит строку в массив слов
            public static string[] ParseToArray(string s)
            {
                
                if (s.Length > 0)
                {
                    string[] sArr;
                    sArr = s.Split(' ', '.', ',', '!', '?');
                    return sArr;
                }
                else
                {
                    string[] sArr = new string[1];
                    sArr[0] = String.Empty;
                    return sArr;
                }
            }

            //Метод возвращает сообщение только с теми словами которые содеражть не более чем num букв
            public static StringBuilder GetString(string s, int num)
            {
                string[] sArr;
                sArr = ParseToArray(s);
                StringBuilder result = new StringBuilder(String.Empty);

                if (sArr.Length <= 1 && sArr[0] == "")
                {
                    Console.WriteLine("Введенная строка была пустой");
                }
                else
                {
                    foreach (string item in sArr)
                    {
                        if (item.Length <= num)
                        {
                            result.Append(item + " ");
                        }
                    }
                }
                
                return result;
            }

            //Метод удаляет из предложения все слова заканчивающиеся на end
            public static StringBuilder GetString(string s, string end)
            {
                string[] sArr;
                sArr = ParseToArray(s);
                StringBuilder result = new StringBuilder(String.Empty);

                foreach (var item in sArr)
                {
                    if (!item.EndsWith(end))
                    {
                        result.Append(item + " ");
                    }
                }
                return result;
            }

            //Метод находит самое длинное слово в сообщении
            public static string GetMaxString(string s, int mod = -1)
            {
                string[] sArr;
                sArr = ParseToArray(s);
                int length = 0;
                string result = String.Empty;

                foreach (var item in sArr)
                {
                    if (length < item.Length)
                    {
                        result = item;
                        length = item.Length;
                    }
                }

                if (mod == 1)
                {
                    result = String.Empty;
                    foreach (var item in sArr)
                    {
                        if (length == item.Length)
                        {
                            result += item + " ";
                        }
                    }
                }
                return result;
            }
        }

        static bool isAnagramma(string s1, string s2)
        {
            if (s1.Length == s1.Length)
            {
                s1 = s1.Trim().ToLower();
                s2 = s2.Trim().ToLower();
                char[] s1Arr = s1.ToCharArray(0, s1.Length);
                char[] s2Arr = s2.ToCharArray(0, s2.Length);

                Array.Sort(s1Arr);
                Array.Sort(s2Arr);

                bool flag = false;

                for (int i = 0; i < s1Arr.Length; i++)
                {
                    if (s1Arr[i] == s2Arr[i])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {

            #region Первая задача
            /*
            * 1. Создать программу, которая будет проверять корректность ввода логина.
            * Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы
            * или цифры, и при этом цифра не может быть первой.
            * а) без использования регулярных выражений;
            * б) **с использованием регулярных выражений.
            */

            ////Проверка логина на соответствие правилам без использования регулярных выражений
            //void CheckLogin(Authorization verify)
            //{
            //    Console.WriteLine("Введите логин.\nЛогин должен содержать от 2 до 10 символов.\nМожет содержать только буквы и цифры, и начинаться только с буквы.");
            //    string login = Console.ReadLine();
            //    if (verify.GetLogin(login))
            //    {
            //        Console.WriteLine("Логин соответствует требованиям.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Логин не соответствует требованиям.\nПо пробуйте еще раз.");
            //        CheckLogin(verify);
            //    }
            //}

            //Authorization verify1 = new Authorization();
            //CheckLogin(verify1);
            //Console.ReadKey();

            ////Проверка логина на соответствие правилам с использованием регулярных выражений
            //void CheckLogin2()
            //{
            //    Console.WriteLine("Введите логин.\nЛогин должен содержать от 2 до 10 символов.\nМожет содержать только буквы и цифры, и начинаться только с буквы.");
            //    string login = Console.ReadLine();

            //    Regex myReg = new Regex(@"^[a-zA-Z]{1}[0-9a-zA-Z]{1,9}$");

            //    if (myReg.IsMatch(login))
            //    {
            //        Console.WriteLine("Логин соответствует требованиям.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Логин не соответствует требованиям.\nПо пробуйте еще раз.");
            //        CheckLogin2();
            //    }
            //}

            //CheckLogin2();
            #endregion

            #region Вторая задача
            /*
             * 2. Разработать методы для решения следующих задач. Дано сообщение:
             * а) Вывести только те слова сообщения, которые содержат не более чем n букв;
             * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
             * в) Найти самое длинное слово сообщения;
             * г) Найти все самые длинные слова сообщения.
             * Постараться разработать класс MyString.
             */

            //string s = "Hello, world! Добро пожаловать в программу. Первое длинноеслово, второе длинноеслов0.";

            //Console.WriteLine(MyString.GetString(s, 6));
            //Console.WriteLine(MyString.GetString(s, "о"));
            //Console.WriteLine(MyString.GetMaxString(s));
            //Console.WriteLine(MyString.GetMaxString(s, 1));

            #endregion

            #region Третья задача
            /*
             * 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
             * а) с использованием методов C#
             * б) *разработав собственный алгоритм
             * Например: badc являются перестановкой abcd
             */

            string s1 = " hello ";
            string s2 = "ehlol";

            if (isAnagramma(s1, s2))
            {
                Console.WriteLine($"Строки {s1} и {s2} равны.");
            }
            else
            {
                Console.WriteLine($"Строки {s1} и {s2} не равны.");
            }

            #endregion
        }
    }
}
