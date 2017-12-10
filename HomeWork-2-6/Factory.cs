using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_6
{
    public class Factory
    {
        public static List<Employee> Employees
        {
            get
            {
                return Employees;
            }
            set
            {
                Employees = value;
            }
        }
        public static List<Department> Departments
        {
            get
            {
                return Departments;
            }
            set
            {
                Departments = value;
            }
        }
        public static DataBase dataBase = new DataBase("db");


        /// <summary>
        /// Метод заполняет ComboBox из коллекции
        /// </summary>
        /// <param name="CBName">Имя ComboBox который будет заполнен</param>
        /// <param name="departments">Коллекция</param>
        public static void DepartmentInComboBox(ComboBox CBName, List<Department> departments)
        {
            CBName.Items.Clear();
            foreach (var item in departments)
            {
                CBName.Items.Add(item.NameDepartment);
            }
        }
        /// <summary>
        /// Метод заполняет ListView из коллекции
        /// </summary>
        /// <param name="LVName">Имя ListView который будет заполнен</param>
        /// <param name="employees">Коллекция</param>
        /// <param name="departmentId">ID департамента (если -1 (по умолчанию) то все работники, иначе по ID департамента)</param>
        public static void EmployeeInListView(ListView LVName, List<Employee> employees, int departmentId = -1)
        {
            if (departmentId == -1)
            {
                LVName.ItemsSource = employees;
            }
            else
            {
                List<Employee> tmp = new List<Employee>();
                tmp = employees.FindAll(e => e.Id_department == departmentId);
                LVName.ItemsSource = tmp;
            }
        }
        /// <summary>
        /// Метод добавляет новый департамент в коллекцию
        /// </summary>
        /// <param name="departments">Коллекция</param>
        /// <param name="nameNewDepartment">Имя департамента</param>
        /// <returns></returns>
        public static bool AddNewDepartment(List<Department> departments, string nameNewDepartment)
        {
            if (nameNewDepartment == "" || departments.FindIndex(d => d.NameDepartment == nameNewDepartment) != -1)
            {
                return false;
            }
            else
            {
                int maxId = departments.Max(d => d.Department_id) + 1;
                departments.Add(new Department() { Department_id = maxId, NameDepartment = nameNewDepartment });
                return true;
            }
        }
        /// <summary>
        /// Метод добавляет нового работника в коллекцию
        /// </summary>
        /// <param name="employees">Коллекция</param>
        /// <param name="employee">Работник</param>
        /// <returns></returns>
        public static bool AddNewEmployee(List<Employee> employees, Employee employee)
        {
            int maxId = employees.Max(e => e.User_id) + 1;
            return true;
        }
    }
}
