using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using QuizApp.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Pages
{
    public class QuizListBase : ComponentBase
    {
        [Inject]
        public IQuizService QuizService { get; set; }

        [Inject]
        public IAnswerService AnswerService { get; set; }

        public Answer answer { get; set; } = new Answer();
        public Moods ThreeFaces { get; set; } = new Moods();

        public DateTime dateTime { get; set; } = new DateTime { };
        public DateTime DateValue { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
        public IEnumerable<Quiz> Quizzes { get; set; }

        

        protected override async Task OnInitializedAsync()
        {
           Quizzes =  (await QuizService.GeTAllQuizzes()).ToList();

            // GetQuizzes();
            // return base.OnInitializedAsync();
            answer = new Answer
            {
                 AnswerId=1,
                 AnswerDate=DateTime.Now,
                 Mood=new Moods(),
                 QuizId=1 ,
            };
        }

        protected async Task HandleValidSubmit()
        {
            Answer result = null;
            result = await AnswerService.CreateNewAnswer(answer);
            
            
            
        }
        protected void  HandelButtons()
        {
            Moods newmood = 0;
            if (newmood == Moods.Green)
            {
                newmood = Moods.Green;
            }

            
        }

        public void Decre()
        {
            var yesterday = DateValue.AddDays(-1);
            
           
        }

       
        /*
        private void GetQuizzes()
        {
            Quiz q1 = new Quiz
            {
                 QizId = 1, 
                Title= "How are you ?",
                AnswerId = 1,
                QuizType = QuizTypes.RedYellowGreen_WhithText,
            };
            Quiz q2 = new Quiz
            {
                QizId = 2,
                Title = "Are you ready for today ?",
                AnswerId =2,
                QuizType = QuizTypes.Yes_No,
                Description = "About"
            };
            Quiz q3 = new Quiz
            {
                QizId = 3,
                Title = "What you will do ?",
                AnswerId = 3,
                QuizType = QuizTypes.Text,
                Description = "About"
            };
            Quiz q4 = new Quiz
            {
                QizId = 4,
                Title = "What you will do ?",
                AnswerId = 4,
                QuizType = QuizTypes.Alternativ,
                Description = "Some thing"
            };
            Quiz q5 = new Quiz
            {
                QizId = 5,
                Title = "Which day is you bearthday?",
                AnswerId = 5,
                QuizType = QuizTypes.Date,
                Description = "Some thing"
                
            };
            Quiz q6 = new Quiz
            {
                QizId = 6,
                Title = "How are you ?",
                AnswerId = 6,
                QuizType = QuizTypes.RedYellowGreen_WhithoutText,
                Description = "Some thing"

            };
            Quizzes = new List<Quiz> { q1, q2,q3,q4,q5,q6 };
        }
        */
    }
}
