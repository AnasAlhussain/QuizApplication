using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApp.Models
{
    public class QuizzAnswer
    {
        [Key]
        public int Id { get; set; }
        public Answer Answer { get; set; }
        public Quiz Quizz { get; set; }
    }
}
