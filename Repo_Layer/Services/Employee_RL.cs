using Microsoft.Extensions.Configuration;
using Models_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Repo_Layer.Interfaces;
using Models_Layer.Models;

namespace Repo_Layer.Services
{
    public class Employee_RL : IEmployee_RL
    {
        private readonly IConfiguration configuration;

        public Employee_RL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddEmployee(EmployeeModel employeeModel)
        {
            if (employeeModel != null)
            {
                // using (SqlConnection con = new SqlConnection(this."ConnectionString:EmployeePayroll"))
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("EmployeePayroll")))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_Name", employeeModel.Emp_Name);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Departement", employeeModel.Departement);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@Image", employeeModel.Image);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                return "User Detail Added Succefully";
            }
            else
            {
                return "User Details not Added";
            }
        }


        public List<EmployeeModel> GetEmployeeList()
        {
            List<EmployeeModel> employeelist = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEMployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
                    employee.Emp_Name = rdr["Emp_Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Departement = rdr["Departement"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                    employee.Image = rdr["Image"].ToString();
                    employeelist.Add(employee); 
                }
                con.Close();
            }
            return employeelist;
        }

        public string DeleteEmployeeById(int Emp_Id)
        {
            if (Emp_Id != 0)
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployeeById", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                return "Employee Details found & deleted";
            }
            else
            {
                return "Employee Details Not found and couldn't delete ";
            }
        }

        public void UpdatedEmployeeDetails(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Id", employeeModel.Emp_Id);
                cmd.Parameters.AddWithValue("@Emp_Name", employeeModel.Emp_Name);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Departement", employeeModel.Departement);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@Image", employeeModel.Image);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
        }


        public EmployeeModel GetEmployeeById(int Emp_Id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            using (SqlConnection conn = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    
                    employeeModel.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
                    employeeModel.Emp_Name = rdr["Emp_Name"].ToString();
                    employeeModel.Gender = rdr["Gender"].ToString();
                    employeeModel.Departement = rdr["Departement"].ToString();
                    employeeModel.Salary = Convert.ToInt32(rdr["Salary"]);
                    employeeModel.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employeeModel.Notes = rdr["Notes"].ToString();
                    employeeModel.Image = rdr["Image"].ToString();

                }

                conn.Close();
            }
                return employeeModel;
            

        }


        //fetch userdetails using EmpName

        public EmployeeModel GetEmployeeByName(string Emp_Name)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            using (SqlConnection conn = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Name", Emp_Name);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    employeeModel.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
                    employeeModel.Emp_Name = rdr["Emp_Name"].ToString();
                    employeeModel.Gender = rdr["Gender"].ToString();
                    employeeModel.Departement = rdr["Departement"].ToString();
                    employeeModel.Salary = Convert.ToInt32(rdr["Salary"]);
                    employeeModel.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employeeModel.Notes = rdr["Notes"].ToString();
                    employeeModel.Image = rdr["Image"].ToString();

                }

                conn.Close();
            }
            return employeeModel;


        }


        //check the empid , if it exist then edit data else add a new data

        public void AlterEmpId(EmployeeModel employeeModel)
        {
            if (employeeModel.Emp_Id == null || employeeModel.Emp_Id != null)
            {
                //  EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection conn = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
                {
                    SqlCommand cmd = new SqlCommand("spAlterEmployeeById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_Id", employeeModel.Emp_Id);
                    cmd.Parameters.AddWithValue("@Emp_Name", employeeModel.Emp_Name);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Departement", employeeModel.Departement);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@Image", employeeModel.Image);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            //else
            //{
            //    AddEmployee(employeeModel);

            //}
        }



        public EmployeeModel EmpLogin(EmpLoginModel empLoginModel)
        {
            if (empLoginModel != null)
            {

                EmployeeModel employeeModel = new EmployeeModel();

                using (SqlConnection conn = new SqlConnection(configuration["ConnectionStrings:EmployeePayroll"]))
                {
                    SqlCommand cmd = new SqlCommand("uspEmpLogin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_Id", employeeModel.Emp_Id);
                    cmd.Parameters.AddWithValue("@Emp_Name", employeeModel.Emp_Name);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        employeeModel.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
                        employeeModel.Emp_Name = rdr["Emp_Name"].ToString();
                        employeeModel.Gender = rdr["Gender"].ToString();
                        employeeModel.Departement = rdr["Departement"].ToString();
                        employeeModel.Salary = Convert.ToInt32(rdr["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employeeModel.Notes = rdr["Notes"].ToString();
                        employeeModel.Image = rdr["Image"].ToString();


                    }
                    conn.Close();


                }
                return employeeModel;
            }
            else
            {
                return null;
            }
                 
        }
    }


    
}
