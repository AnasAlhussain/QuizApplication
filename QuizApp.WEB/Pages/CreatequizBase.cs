using AutoMapper;
using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using QuizApp.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Pages
{
    public class CreatequizBase : ComponentBase
    {
        [Inject]
        public IQuizService QuizService { get; set; }

        public IEnumerable<Quiz> Quizzes { get; set; }

        public Quiz quiz { get; set; } = new Quiz();
        /*
        [Inject]
        public IMapper Mapper  { get; set; }
        */

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
           

            Quizzes = (await QuizService.GeTAllQuizzes()).ToList();
            //quiz = (await QuizService.CreateNewQuiz(quiz));

            quiz = new Quiz
            {
                QizId=1,
                Title = "",
                Description = "",
                QuizType = new QuizTypes()
            };
        }
        /*
        protected async void SaveNewQuiz()
        {
           await QuizService.CreateNewQuiz(quiz);
            quiz = new Quiz();
        }
        */
        
        protected async Task HandleValidSubmit()
        {
            Quiz result = null;
            result = await QuizService.CreateNewQuiz(quiz);
            if (result != null)
            {
                NavigationManager.NavigateTo("/createquiz");
            }
            /*
            quiz = (await QuizService.CreateNewQuiz(quiz));
            */
        }
        

    }
}
