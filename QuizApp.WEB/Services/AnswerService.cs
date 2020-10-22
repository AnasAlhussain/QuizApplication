using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly HttpClient httpClient;

        public AnswerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Answer> CreateNewAnswer(Answer newAnswer)
        {
            return await httpClient.PostJsonAsync<Answer>("api/answers", newAnswer);
        }

        public async Task<IEnumerable<Answer>> GetAllAnswers()
        {
            return await httpClient.GetJsonAsync<Answer[]>("api/answers");
        }
    }
}
