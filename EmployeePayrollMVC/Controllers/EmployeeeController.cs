using Bussines_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models_Layer;
using Models_Layer.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeeController : Controller
    {
        private readonly IEmployee_BL employee_BL;

        public EmployeeeController(IEmployee_BL employee_BL)
        {
            this.employee_BL = employee_BL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
       // [Route("Register")]
        public IActionResult AddEmployee()
        {
            return View();

        }

        [HttpPost]
        //[Route("Register")]
        public IActionResult AddEmployee([Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                employee_BL.AddEmployee(employeeModel);
                 return RedirectToAction("GetEmployeeList");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();

            employeeList = employee_BL.GetEmployeeList().ToList();
            return View(employeeList);

        }


        [HttpGet]
        public IActionResult DeleteEmployeeById(int Emp_Id)
        {
            if (Emp_Id == null)
            {
                return NotFound();
            }
            EmployeeModel emp = employee_BL.GetEmployeeById(Emp_Id);

            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);

        }

        [HttpPost, ActionName("DeleteEmployeeById")]
        public IActionResult DeleteEmployee(int Emp_Id)
        {
            employee_BL.DeleteEmployeeById(Emp_Id);
            return RedirectToAction("GetEmployeeList");
        }

        [HttpGet]
        public IActionResult UpdatedEmployeeDetails(int Emp_Id)
        {
            if (Emp_Id == null)
            {
                return NotFound();
            }
            EmployeeModel emp = employee_BL.GetEmployeeById(Emp_Id);

            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }



        [HttpPost]
        public IActionResult UpdatedEmployeeDetails([Bind] EmployeeModel employeeModel, int Emp_Id)
        {
            if (Emp_Id != employeeModel.Emp_Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employee_BL.UpdatedEmployeeDetails(employeeModel);
                return RedirectToAction("GetEmployeeList");
            }

            return View(employeeModel);
        }


        [HttpGet]
        public IActionResult GetEmployeeById(int Emp_Id)
        {
            if (Emp_Id == null)
            {
                return NotFound();
            }

            EmployeeModel employee = employee_BL.GetEmployeeById(Emp_Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult GetEmployeeById(int Emp_Id, [Bind] EmployeeModel employeeModel)
        {
            if (Emp_Id != employeeModel.Emp_Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employee_BL.GetEmployeeById(Emp_Id);
                return RedirectToAction("GetEmployeeList");
            }

            return View(employeeModel);


        }

        [HttpGet]
        public IActionResult EmpLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmpLogin([Bind] EmpLoginModel empLoginModel)
        { 
            var result = employee_BL.EmpLogin(empLoginModel);
            if(result != null)
            //if (empLoginModel.Emp_Id != null)
            {
                employee_BL.EmpLogin(empLoginModel);
                return RedirectToAction("GetEmployeeList");
            }
            return View(empLoginModel);

        }
        
        [HttpGet]

        public IActionResult GetEmployeeByName(string Emp_Name)
        {
            if (Emp_Name == null)
            {
                return NotFound();
            }

            EmployeeModel employee = employee_BL.GetEmployeeByName(Emp_Name);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult GetEmployeeByName(string Emp_Name, [Bind] EmployeeModel employeeModel)
        {
            if (Emp_Name != employeeModel.Emp_Name)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employee_BL.GetEmployeeByName(Emp_Name);
                return RedirectToAction("GetEmployeeList");
            }

            return View(employeeModel);


        }

        //check the empid , if it exist then edit data else add a new data

        [HttpGet]

        public IActionResult AlterEmp_Id(int Emp_Id)
        {
            if (Emp_Id == null)
            {
                return NotFound();
            }
            EmployeeModel emp = employee_BL.GetEmployeeById(Emp_Id);

            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }


        [HttpPost]
        public IActionResult AlterEmp_Id([Bind] EmployeeModel employeeModel, int Emp_Id)
        {
            if (Emp_Id != employeeModel.Emp_Id)
            {
                employee_BL.AlterEmpId(employeeModel);
            }
            if (ModelState.IsValid)
            {
                employee_BL.AlterEmpId(employeeModel);
                return RedirectToAction("GetEmployeeList");
            }

            return View(employeeModel);
        }





    }
}


