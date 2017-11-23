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
        public delegate int MyDelegate(int x, int y);

        public void MyMethod(Random random, MyDelegate myDelegate)
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!!!");
        }
    }
}
