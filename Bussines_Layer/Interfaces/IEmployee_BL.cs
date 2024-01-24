using Models_Layer;
using Models_Layer.Models;
using System.Collections.Generic;

namespace Bussines_Layer.Interfaces
{
    public interface IEmployee_BL
    {
        public string AddEmployee(EmployeeModel employeeModel);
        public string DeleteEmployeeById(int Emp_Id);
        public List<EmployeeModel> GetEmployeeList();
        public void UpdatedEmployeeDetails(EmployeeModel employeeModel);
        public EmployeeModel GetEmployeeById( int Emp_Id);
        public EmployeeModel EmpLogin(EmpLoginModel empLoginModel);

        public EmployeeModel GetEmployeeByName(string Emp_Name);
        public void AlterEmpId(EmployeeModel employeeModel);
    }
}