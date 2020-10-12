using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApp.Models
{
   public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Answer")]
        public DateTime AnswerDate { get; set; }
        public int QuizId { get; set; }
       // public Employe Employee { get; set; }
        public int EmployeeId { get; set; }


    }
}
