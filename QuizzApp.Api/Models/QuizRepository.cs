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

       

        public async Task<Quiz> DeleteQuiz(int quizid)
        {
            var result = await appDbContext.Quizzes.FirstOrDefaultAsync(qu => qu.QizId == quizid);
            if (result != null)
            {
                appDbContext.Quizzes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Quiz> GetById(int quizId)
        {
            return await appDbContext.Quizzes.FirstOrDefaultAsync(qu => qu.QizId == quizId);
        }

        public async Task<IEnumerable<Quiz>> GetQuizzes()
        {
            return await appDbContext.Quizzes.ToListAsync();
        }

        public async Task<Quiz> UpdateQuiz(Quiz quiz)
        {
            var result = await appDbContext.Quizzes.FirstOrDefaultAsync(qu => qu.QizId == quiz.QizId);
            if (result != null)
            {
                result.Title = quiz.Title;
                result.Description = quiz.Description;
                result.QuizType = quiz.QuizType;
               

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
