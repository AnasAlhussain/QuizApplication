using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApp.Models
{
   public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DepName { get; set; }
       //public Employe Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
