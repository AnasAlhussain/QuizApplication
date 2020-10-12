using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApp.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        //public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
         //public Employe Employee { get; set; }
        public int EmployeId { get; set; }
        //public Answer Answers { get; set; }
        public int AnswerId { get; set; }

    }
}
