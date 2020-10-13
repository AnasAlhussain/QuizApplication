using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
   public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizzes();
        Task<Quiz> GetById(int quizId);
        Task<Quiz> AddQuiz(Quiz quiz);
        Task<Quiz> UpdateQuiz(Quiz quiz);
        Task<Quiz> DeleteQuiz(int quizid);
    }
}
