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

namespace HomeWork_2_8_Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Employee> tmp = client.GetEmployees(-1);
            EmployeeInListView(LV_Employees, client.GetEmployees(3));
        }

        ServiceReferenceASMX.WebService1SoapClient client = new ServiceReferenceASMX.WebService1SoapClient();

        /// <summary>
        /// Метод заполняет ListView из коллекции
        /// </summary>
        /// <param name="LVName">Имя ListView который будет заполнен</param>
        /// <param name="employees">Коллекция</param>
        /// <param name="departmentId">ID департамента (если -1 (по умолчанию) то все работники, иначе по ID департамента)</param>
        public static void EmployeeInListView(ListView LVName, List<Employee> employees)
        {
            LVName.ItemsSource = employees;
        }
    }
}
