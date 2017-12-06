using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_2_6
{
    class DataBase:IDisposable
    {
        string nameDB;
        public List<Employee> employee;
        public List<Department> department;

        string[] stringsTable, splitString;
        Employee tmpEmploye;
        Department tmpDepartment;

        public DataBase(string nameDB)
        {
            this.nameDB = nameDB;
            ReadEmploye();
            ReadDepartment();
            Dispose();
        }

        void ReadEmploye()
        {
            this.stringsTable = File.ReadAllLines($"{nameDB}/employee.table");

            for (int i = 1; i < stringsTable.Length; i++)
            {
                splitString = stringsTable[i].Split(';');

                tmpEmploye = new Employee
                {
                    User_id = Convert.ToInt32(splitString[0]),
                    Id_department = Convert.ToInt32(splitString[1]),
                    FirstName = splitString[2],
                    LastName = splitString[3],
                    Birthday = Convert.ToDateTime(splitString[4]),
                    Salary = Convert.ToInt32(splitString[5])
                };

                this.employee.Add(tmpEmploye);
            }
            tmpEmploye = null;
        }

        void ReadDepartment()
        {
            this.stringsTable = File.ReadAllLines($"{nameDB}/department.table");

            for (int i = 1; i < stringsTable.Length; i++)
            {
                splitString = stringsTable[i].Split(';');

                tmpDepartment = new Department
                {
                    Department_id = Convert.ToInt32(splitString[0]),
                    NameDepartment = splitString[1]
                };

                this.department.Add(tmpDepartment);
            }
            tmpDepartment = null;
        }

        public void Dispose()
        {
            stringsTable = null;
            splitString = null;
        }
    }
}
