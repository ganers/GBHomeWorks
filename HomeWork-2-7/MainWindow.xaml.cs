using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace HomeWork_2_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=N56GANERS\SQLEXPRESS;Initial Catalog=lesson7;Integrated Security=True;Pooling=False";

        public MainWindow()
        {
            InitializeComponent();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                string sql = "SELECT * FROM Employee";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable table = new DataTable();

                sqlDataAdapter.Fill(table);

                DataGridView.DataContext = table;

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
