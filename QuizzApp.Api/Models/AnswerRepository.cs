using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext appDbContext;

        public AnswerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Answer> AddAnswer(Answer answer)
        {
            var newAnswer = await appDbContext.Answers.AddAsync(answer);
            await appDbContext.SaveChangesAsync();
            return newAnswer.Entity;

        }

       
        public async Task<Answer> DeleteAnswer(int answerId)
        {
            var result = await appDbContext.Answers.FirstOrDefaultAsync(a => a.AnswerId == answerId);
            if (result != null)
            {
                appDbContext.Answers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Answer> GetAnswerBy(int answerId)
        {
            return await appDbContext.Answers.FirstOrDefaultAsync(a => a.AnswerId == answerId);
        }

        public async Task<IEnumerable<Answer>> GetAnswers()
        {
            return await appDbContext.Answers.ToListAsync();
        }
    }
}
