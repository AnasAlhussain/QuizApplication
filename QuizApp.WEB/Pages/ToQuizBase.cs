using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using QuizApp.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Pages
{
    public class ToQuizBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IQuizService QuizService { get; set; }
        public Quiz quiz { get; set; } = new Quiz();
        public Answer answer { get; set; }
        [Inject]
        public IAnswerService AnswerService { get; set; }

        public Employe employee { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IRecordService RecordService { get; set; }
        public Record record { get; set; } = new Record();
        public string Description { get; set; } = string.Empty;

        public DateTime DateValue { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);

        protected override async Task OnInitializedAsync()
        {
           quiz = await QuizService.GetQizeById(int.Parse(Id));

            answer = new Answer
            {
                Description="",

            };
        }
    }
}
