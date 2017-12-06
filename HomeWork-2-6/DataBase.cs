using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_2_6
{
    public class DataBase
    {
        string nameDB;
        List<Employee> employee;
        List<Department> department;

        public DataBase(string nameDB)
        {
            this.nameDB = nameDB;
        }



    }
}
