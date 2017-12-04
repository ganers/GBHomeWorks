using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_5
{
    class Employee
    {
        public Employee(string name, string dep)
        {
            Name = name;
            Dep = dep;
        }
        public string Name { get; set; }
        public string Dep { get; set; }
    }
}
