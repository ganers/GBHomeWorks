using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace HomeWork_2_8
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        string connectionString = @"Data Source=ganers-pc\sqlexpress;Initial Catalog=Lesson7;Integrated Security=True;Pooling=False";

        void AddEmployee(List<Employee> employees, SqlDataReader reader)
        {
            employees.Add(new Employee
            {
                User_id = reader.GetInt32(0),
                Id_department = reader.IsDBNull(1) ? -1 : reader.GetInt32(1),
                FirstName = reader.IsDBNull(2) ? null : reader.GetString(2),
                LastName = reader.IsDBNull(3) ? null : reader.GetString(3),
                Birthday = reader.IsDBNull(4) ? null : reader.GetString(4),
                Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                Phone = reader.IsDBNull(6) ? null : reader.GetString(6),
                Salary = reader.IsDBNull(7) ? 0 : reader.GetInt32(7)
            });
        }

        /// <summary>
        /// Метод возвращает коллекцию сотрудников
        /// </summary>
        /// <param name="IdDepartment">ID Департамента список сотрудников которого надо получить. 0 если нужен список всех работников.</param>
        /// <returns>Коллекция Employee</returns>
        [WebMethod]
        public List<Employee> GetEmployees(int IdDepartment)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (IdDepartment == 0)
                        {
                            AddEmployee(employees, reader);
                        }
                        else
                        {
                            if (reader.GetInt32(1) == IdDepartment) AddEmployee(employees, reader);
                        }
                    }
                }
                reader.Close();
            }
            return employees;
        }

        /// <summary>
        /// Метод возвращает коллекцию департаментов
        /// </summary>
        /// <returns>Коллекция Department</returns>
        [WebMethod]
        public List<Department> GetDepartment()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Department", connection);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            Department_id = reader.GetInt32(0),
                            NameDepartment = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Address = reader.IsDBNull(2) ? null : reader.GetString(2)
                        });
                    }
                }
                reader.Close();
            }
            return departments;
        }
    }
}
