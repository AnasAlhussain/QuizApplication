using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public class QuizService : IQuizService
    {
        private readonly HttpClient httpClient;

        public QuizService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Quiz>> GeTAllQuizzes()
        {
            return await httpClient.GetJsonAsync<Quiz[]>("api/quizzes");
        }
    }
}
