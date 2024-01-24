using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Layer
{
    public class EmployeeModel
    {
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }

        public string Gender { get; set; }

        public string Departement { get; set; }

        public int Salary { get; set; }

        public string Image { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }
}
