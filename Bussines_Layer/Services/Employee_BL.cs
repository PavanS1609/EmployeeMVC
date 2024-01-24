using Bussines_Layer.Interfaces;
using Models_Layer;
using Models_Layer.Models;
using Repo_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines_Layer.Services
{
    public class Employee_BL : IEmployee_BL
    {
        private IEmployee_RL employee_RL;

        public Employee_BL(IEmployee_RL employee_RL)
        {
            this.employee_RL = employee_RL;

        }
        public string AddEmployee(EmployeeModel employeeModel)
        {
            return employee_RL.AddEmployee(employeeModel);
        }

        public string DeleteEmployeeById(int Emp_Id)
        {
            return employee_RL.DeleteEmployeeById(Emp_Id);
        }
        public List<EmployeeModel> GetEmployeeList()
        {
            return employee_RL.GetEmployeeList();
        }
        public void UpdatedEmployeeDetails(EmployeeModel employeeModel)
        {
            employee_RL.UpdatedEmployeeDetails(employeeModel);
        }

        public EmployeeModel GetEmployeeById( int Emp_Id)
        {
            return employee_RL.GetEmployeeById( Emp_Id);
        }

        public EmployeeModel EmpLogin(EmpLoginModel empLoginModel)
        {
            return employee_RL.EmpLogin( empLoginModel);
        }

        public EmployeeModel GetEmployeeByName(string Emp_Name)
        {
            return employee_RL.GetEmployeeByName( Emp_Name);
        }

        public void AlterEmpId(EmployeeModel employeeModel)
        {
             employee_RL.AlterEmpId(employeeModel);
        }
    }
}
