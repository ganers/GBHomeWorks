using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork_2_1
{

    class Program
    {
        public delegate void MyPrint(string str);

        public void PrinConsole(string str)
        {

        }

        public void PrintMsg(string str, MyPrint myDelegate)
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!!!");
        }
    }
}
