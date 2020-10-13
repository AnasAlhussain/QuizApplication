using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizzes();
        Task<Quiz> AddQuiz(Quiz quiz);
        Task<Quiz> UpdateQuiz(Quiz quiz);
        Task<Quiz> CheckQuizType(Quiz oldQuiz, Quiz newQuiz);
        void DeleteQuiz(int quizid);
    }
}
