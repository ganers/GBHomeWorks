using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HomeWork_6
{
    class Program
    {
        static void Save(string fileName, int n)
        {
            Random rnd = new Random();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 1; i < n; i++)
            {
                bw.Write(rnd.Next(0, 100000)); // int -занимает 4 байта
            }
            fs.Close();
            bw.Close();
        }
        static void Load(string fileName)
        {
            DateTime d = DateTime.Now;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int[] a = new int[fs.Length / 4];
            for (int i = 0; i < fs.Length / 4; i++) // int занимает 4 байта
            {
                a[i] = br.ReadInt32();
            }
            br.Close();
            fs.Close();
            int max = 0;
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    if (Math.Abs(i - j) >= 8 && a[i] * a[j] > max) max = a[i] * a[j];
            Console.WriteLine(max);
            Console.WriteLine(DateTime.Now - d);
        }


        static void ReadNumber(string fileName)
        {
            Regex numberFormat = new Regex(@"(\d{2}-\d{2}-\d{2})|(\d{3}-\d{3})|(\d{3}-\d{2}-\d{2})");
            string s = File.ReadAllText(fileName);
            foreach (var item in numberFormat.Matches(s))
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            #region 6-я задача
            ////6. ***В заданной папке найти во всех html файлах теги<img src=...> и вывести названия картинок.Использовать регулярные выражения.

            //// Получаем список файлов в папке. AllDirectories - сканировать также и подпапки
            //string[] fs = Directory.GetFiles("html", "*.*", SearchOption.AllDirectories);
            //// Просматриваем каждый файл в массиве
            //foreach (var filename in fs)
            //{
            //    // Создаем регулярное выражения дя поиска img и alt
            //    Regex regexImg = new Regex(@"(<img).+(src=)[^>]+(>){1}");

            //    Regex regexAlt = new Regex("(alt=\"){1}[^\"]{1,}(\"){1}");

            //    // Считываем файл
            //    string s = File.ReadAllText(filename);

            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(filename);
            //    Console.ResetColor();

            //    // Выводим найденные названия картинок
            //    foreach (var c in regexImg.Matches(s).Cast<Match>().Select(m => m.Value).ToArray())
            //    {
            //        string result = regexAlt.Match(c).Value;

            //        if (result != "")
            //        {
            //            Console.WriteLine(result.Substring(5, result.Length - 6));
            //        }
            //    }
            //}
            #endregion

            #region 5-я задача
            //НЕ ПРИДУМАЛ КАК РЕШИТЬ ЗАДАЧУ!!!

            //Save("data.bin", 100000);
            //Console.WriteLine("Файл создан.");
            //Load("data.bin");
            #endregion

            #region 4-я задача
            //4. **В файле могут встречаться номера телефонов, записанные в формате xx-xx-xx,
            //xxx-xxx или xxx-xx-xx.Вывести все номера телефонов, которые содержатся в файле.

            //ReadNumber("number.txt");

            #endregion

            //Console.ReadKey();
        }
    }
}
