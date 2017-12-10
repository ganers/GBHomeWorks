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
using System.Windows.Shapes;

namespace HomeWork_2_6
{
    /// <summary>
    /// Логика взаимодействия для AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Window
    {
        public int DepartmentId { get; set; }
        public List<Employee> employees;

        public AddNewUser()
        {
            InitializeComponent();
        }

        Employee NewEmploye()
        {
            Employee e = new Employee
            {
                FirstName = TBAddNewEmployeeFirstName.Text,
                LastName = TBAddNewEmployeeLastName.Text,
                //Birthday = DPAddNewEmployeeBirthday.Text,
                //Salary = Convert.ToDouble(TBAddNewEmployeeSalary.Text)
            };

            return e;
        }

        private void btnAddNewEmployeeCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddNewEmployeeOk_Click(object sender, RoutedEventArgs e)
        {
            if (TBAddNewEmployeeFirstName.Text != "" && TBAddNewEmployeeLastName.Text != "")
            {
                Employee newEmploye = NewEmploye();

                Factory.AddNewEmployee(employees, newEmploye);

                this.Close();
            }
            else
            {
                MessageBox.Show("Что то пошло не так");
            }
        }
    }
}
