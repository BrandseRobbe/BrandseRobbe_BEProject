using Microsoft.EntityFrameworkCore;
using Quiz.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quiz.Models.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly QuizDbContext context;

        public QuestionRepo(QuizDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            try
            {
                return await context.Questions.ToListAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public async Task<Question> GetQuestionByIdAsync(Guid questionId)
        {
            try
            {
                return await context.Questions
                    .Include(e => e.PossibleOptions)
                    .Where(p => p.QuestionId == questionId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task<Question> GetQuestionByDescriptionAsync(string desciption)
        {
            try
            {
                //return await context.Questions.SingleOrDefaultAsync<Question>(e => e.Description == desciption);
                return await context.Questions
                    .Include(e => e.PossibleOptions)
                    .Where(p => p.Description == desciption)
                    .FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task<Question> Create(Question question)
        {
            try
            {
                var result = context.Questions.AddAsync(question);
                await context.SaveChangesAsync();
                return question;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task Delete(Guid questionId)
        {
            try
            {
                Question question = await GetQuestionByIdAsync(questionId);
                if (questionId == null)
                {
                    return;
                }
                var result = context.Questions.Remove(question);
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }
        public async Task<Question> Update(Question question)
        {
            try
            {
                context.Questions.Update(question);
                await context.SaveChangesAsync();
                return question;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }

    }
}
