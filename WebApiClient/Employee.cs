using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiClient
{
    public class Employee
    {
        public int User_id { get; set; }
        public int Id_department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }

        public Employee()
        {

        }
    }
}
