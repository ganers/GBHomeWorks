using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_2_6
{
    public class DataBase:IDisposable
    {
        string nameDB;
        public List<Employee> employee = new List<Employee>();
        public List<Department> department = new List<Department>();

        string[] stringsTable, splitString;
        Employee tmpEmploye;
        Department tmpDepartment;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nameDB">Путь к папке с файлами таблиц БД</param>
        public DataBase(string nameDB)
        {
            this.nameDB = nameDB;
            ReadEmploye();
            ReadDepartment();
            Dispose();
        }
        /// <summary>
        /// Метод читает таблицу employee и собирает ее в коллекцию
        /// </summary>
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
                    Birthday = splitString[4],
                    Salary = Convert.ToInt32(splitString[5])
                };

                this.employee.Add(tmpEmploye);
            }
            tmpEmploye = null;
        }
        /// <summary>
        /// Метод читает таблицу department и собирает ее в коллекцию
        /// </summary>
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
        /// <summary>
        /// Метод обнуляет временные переменные
        /// </summary>
        public void Dispose()
        {
            stringsTable = null;
            splitString = null;
        }
    }
}
