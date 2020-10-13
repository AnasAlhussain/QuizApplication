using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public class QuizRepository : IQuizRepository
    {
        private readonly AppDbContext appDbContext;

        public QuizRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Quiz> AddQuiz(Quiz quiz)
        {
          var newQuiz = await appDbContext.AddAsync(quiz);
            await appDbContext.SaveChangesAsync();
            return newQuiz.Entity;
        }

        public Task<Quiz> CheckQuizType(Quiz oldQuiz, Quiz newQuiz)
        {
            throw new NotImplementedException();
        }

        public async void DeleteQuiz(int quizid)
        {
            var result = await appDbContext.Quizzes.FirstOrDefaultAsync(qu => qu.QizId == quizid);
            if (result != null)
            {
                appDbContext.Quizzes.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Quiz>> GetQuizzes()
        {
            return await appDbContext.Quizzes.ToListAsync();
        }

        public Task<Quiz> UpdateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }
    }
}
