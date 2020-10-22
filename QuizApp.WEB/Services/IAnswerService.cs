using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public interface IAnswerService 
    {
        Task<IEnumerable<Answer>> GetAllAnswers();
        Task<Answer> CreateNewAnswer(Answer newAnswer);
    }
}
