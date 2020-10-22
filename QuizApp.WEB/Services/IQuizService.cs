using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<Quiz>> GeTAllQuizzes();
        Task<Quiz> CreateNewQuiz(Quiz newQuiz);
        Task<Quiz> GetQizeById(int id);


    }
}
