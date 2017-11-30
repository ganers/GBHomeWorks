using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * АНДРЕЙ АЛЕКСЕЕВ
 * 
 * 
 * 
 */
namespace HomeWork_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = new List<int>();

            listInt.Add(123);
            listInt.Add(234);
            listInt.Add(345);
            listInt.Add(678);
            listInt.Add(890);
            listInt.Add(123);
            listInt.Add(345);

            for (int i = 0; i < listInt.Count; i++)
            {
                int current = listInt[i];
                int counter = 1;

                for (int j = 0; j < listInt.Count; j++)
                {
                    if (listInt[i] == listInt[j] && j != i)
                    {
                        listInt.RemoveAt(j);
                        counter++;
                    }
                }
                Console.WriteLine($"{current}: Встречается {counter} раз.");
            }
            Console.WriteLine();

            //listInt.Add(123);
            //listInt.Add(234);
            //listInt.Add(345);
            //listInt.Add(678);
            //listInt.Add(890);
            //listInt.Add(123);
            //listInt.Add(345);

            //List<int> newList = listInt.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            //List<int> newList = listInt.FindAll(i => i == 123);

            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}

            Dictionary<string, int> dict = new Dictionary<string, int>()
              {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
              };
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}
