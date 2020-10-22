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
        public Quiz Quiz { get; set; }
       
        public Employe Employee { get; set; }
        
        public Answer Answers { get; set; }
      
    
    }
}
