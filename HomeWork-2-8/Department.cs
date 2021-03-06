﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_8
{
    public class Department
    {
        public int Department_id { get; set; }
        public string NameDepartment { get; set; }
        public string Address { get; set; }

        public Department()
        {
        }

        public List<Employee> EmployeesOfTheDepartment(int departmentId, List<Employee> employees)
        {
            List<Employee> employeesOfTheDepartment = employees.FindAll(e => e.Id_department == departmentId);
            return employeesOfTheDepartment;
        }
    }
}
