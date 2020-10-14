using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuizApp.Models
{
   public class Quiz
    {
        [Key]
        public int QizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public QuizTypes QuizType { get; set; }

        public int AnswerId { get; set; }


    }
}
