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
using System.Collections.ObjectModel;

namespace HomeWork_2_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Factory.DepartmentInComboBox(CBDepartment, Factory.dataBase.department);
            Factory.EmployeeInListView(LVEmployee, Factory.dataBase.employee, CBDepartment.SelectedIndex+1);

            
            
            
        }

        private void CBDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Factory.EmployeeInListView(LVEmployee, Factory.dataBase.employee, CBDepartment.SelectedIndex+1);
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (Factory.AddNewDepartment(Factory.dataBase.department, TBAddDepartment.Text))
            {
                Factory.DepartmentInComboBox(CBDepartment, Factory.dataBase.department);
                CBDepartment.SelectedIndex = Factory.dataBase.department.Max(d => d.Department_id) - 1;
            }
            else
            {
                MessageBox.Show("Или вы не ввели название департамента\nили такой департамент уже существует.");
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddNewUser formAddNewUser = new AddNewUser();
            formAddNewUser.DepartmentId = 3 /*dataBase.department.Find(d => d == CBDepartment.SelectedItem).Department_id*/;
            formAddNewUser.employees = Factory.dataBase.employee;
            formAddNewUser.ShowDialog();

        }
    }
}
