using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApp.Models
{
   public class QuizEmployeeList
    {
        [Key]
        public int Id { get; set; }
        // public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        //public Employe Employe { get; set; }
        public int EmployeId { get; set; }

    }
}
