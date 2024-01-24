using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models_Layer.Models
{
    public class EmpLoginModel
    {
        [Required]
        public int Emp_Id { get; set; }
        [Required]
        public string Emp_Name { get; set; }
    }
}
