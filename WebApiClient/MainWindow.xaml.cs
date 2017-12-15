using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace WebApiClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:53860/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var res = client.GetStringAsync(@"http://localhost:53860/api/employee").Result;

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var listEmployee = JsonConvert.DeserializeObject<List<Employee>>(client.GetStringAsync(@"http://localhost:53860/api/employee").Result, settings);
            var listDepartment = JsonConvert.DeserializeObject<List<Department>>(client.GetStringAsync(@"http://localhost:53860/api/department").Result, settings);


            LV_Employees.ItemsSource = listEmployee;
            CB_Departments.ItemsSource = listDepartment;
        }

        private void CB_Departments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id_dep = CB_Departments.SelectedIndex + 1;
            LV_Employees.ItemsSource = JsonConvert.DeserializeObject<List<Employee>>(client.GetStringAsync($@"http://localhost:53860/api/employee/{id_dep}").Result);
        }
    }
}
