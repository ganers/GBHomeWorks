using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork_2_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Department> departments = new List<Department>();
        List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Метод загружает информацию из БД в память
        /// </summary>
        void LoadInfo()
        {
            string[] db = DataBase.ReadDb("db.txt");
            string[] tmpItemDb;

            foreach (var item in db)
            {
                tmpItemDb = item.Split(';');
                this.departments.Add(new Department(tmpItemDb[0]));
                for (int i = 1; i < tmpItemDb.Length; i++)
                {
                    if (tmpItemDb[i] != String.Empty)
                    {
                        this.employees.Add(new Employee(tmpItemDb[i], tmpItemDb[0]));
                    }
                }
            }
        }

        /// <summary>
        /// Метод отображает сотрудников выбранного департамента
        /// </summary>
        /// <param name="dep"></param>
        void ViewSelectDepartment(string dep)
        {
            LVEmployees.Items.Clear();
            foreach (var item in employees)
            {
                if (item.Dep == dep)
                {
                    LVEmployees.Items.Add(item.Name);
                }
            }
        }

        /// <summary>
        /// Метод собирает данные из памяти для записи в БД
        /// </summary>
        /// <returns>Массив для записи в БД</returns>
        string[] PreSaveDb()
        {
            string[] db = new string[departments.Count];
            for (int i = 0; i < departments.Count; i++)
            {
                db[i] += departments[i].NameDepartment + ";";
                foreach (var item in employees)
                {
                    if (item.Dep == departments[i].NameDepartment)
                    {
                        db[i] += item.Name + ";";
                    }
                }
            }
            return db;
        }

        /// <summary>
        /// Метод выводит все департаменты в ComboBox
        /// </summary>
        void ViewAllDepartments()
        {
            CBDepartments.Items.Clear();
            foreach (var item in this.departments)
            {
                CBDepartments.Items.Add(item.NameDepartment);
            }
        }

        /// <summary>
        /// Метод выводит всех сотрудников в ListView (метод не используется)
        /// </summary>
        void ViewAllEmployees()
        {
            LVEmployees.Items.Clear();
            foreach (var item in this.employees)
            {
                LVEmployees.Items.Add(item.Name);
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            LoadInfo();

            ViewAllDepartments();
            CBDepartments.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Обработчик события добавления нового департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            departments.Add(new Department(TBAddDepartment.Text));
            ViewAllDepartments();
        }
        /// <summary>
        /// Обработчик события сохранения БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataBase.WriteDb("db.txt", PreSaveDb());
        }
        /// <summary>
        /// Обработчик события добавления нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            employees.Add(new Employee(TBAddEmployee.Text, CBDepartments.Text));
            ViewSelectDepartment(CBDepartments.SelectedItem.ToString());
            TBAddEmployee.Clear();
        }
        /// <summary>
        /// Обработчик события изменения выделенного элемента в ComboBox департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LVEmployees.Items.Clear();
            ViewSelectDepartment(CBDepartments.SelectedItem.ToString());
        }
        /// <summary>
        /// Обработчик события удаление сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelEmployee_Click(object sender, RoutedEventArgs e)
        {
            //LVEmployees.Items.Clear();
            //employees.RemoveAt(employees.FindIndex(item => item.Name == LVEmployees.SelectedItem.ToString()));
            //ViewSelectDepartment(CBDepartments.SelectedItem.ToString());
        }
    }
}
