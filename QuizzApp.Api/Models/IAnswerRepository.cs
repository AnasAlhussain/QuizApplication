using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAnswers();
        Task<Answer> GetAnswerBy(int answerId);
        Task<Answer> AddAnswer(Answer answer);
        Task<Answer> CheckAnswer(Answer oldAnnswer, Answer newAnswer);
        void DeleteAnswer(int answerId);
    }
}
