using Microsoft.EntityFrameworkCore;
using Quiz.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        private readonly QuizDbContext context;
        private readonly IQuestionRepo questionRepo;

        public QuizRepo(QuizDbContext context, IQuestionRepo questionRepo)
        {
            this.context = context;
            this.questionRepo = questionRepo;
        }

        public async Task<IEnumerable<QuizClass>> GetAllQuizzesAsync()
        {
            return await context.Quizzes.OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<QuizClass> GetQuizByIdAsync(Guid id)
        {
            try
            {
                return await context.Quizzes.SingleOrDefaultAsync<QuizClass>(e => e.QuizId == id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task<QuizClass> GetQuizByNameAsync(string quizName)
        {
            try
            {
                return await context.Quizzes.SingleOrDefaultAsync<QuizClass>(e => e.Name == quizName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Question>> GetQuizQuestionsAsync(Guid quizId)
        {
            try
            {
                List<Question> questions = new List<Question>();
                var result = await context.QuizQuestions.Include(t => t.Question)
                    .ThenInclude(q=>q.PossibleOptions)
                    .Where(e => e.QuizId == quizId)
                    .ToListAsync();
                if (result == null)
                {
                    Console.WriteLine("nog geen vragen in de quiz");
                    return null;
                }
                foreach (var item in result)
                {
                    questions.Add(item.Question);
                }
                return questions;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<QuizQuestions> AddQuestionToQuizAsync(Guid quizId, Guid questionId)
        {
            try
            {
                QuizQuestions quizQuestion = new QuizQuestions()
                {
                    QuestionId = questionId,
                    QuizId = quizId
                };

                var controle = await context.QuizQuestions.SingleOrDefaultAsync<QuizQuestions>(e => e.QuizId == quizId && e.QuestionId == questionId);
                if (controle != null)
                {
                    Console.WriteLine("already in quiz");
                    return null;
                }
                var result = await context.QuizQuestions.AddAsync(quizQuestion);
                await context.SaveChangesAsync();
                return quizQuestion;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        
        public async Task<QuizClass> Create(QuizClass quiz)
        {
            try
            {
                var result = context.Quizzes.AddAsync(quiz);
                await context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
       
        public async Task Delete(Guid quizId)
        {
            try
            {
                QuizClass quiz = await GetQuizByIdAsync(quizId);
                if (quiz== null)
                {
                    return;
                }
                //vragen uit de tussentabel verwijderen verwijderen
                var tussentabel = await context.QuizQuestions.Where(e => e.QuizId == quizId).ToListAsync();
                foreach(var tab in tussentabel)
                {
                    //questions uit quiz deleten (en tussentabel)
                    await questionRepo.Delete(tab.QuestionId);
                    //om enkel uit tussentabel halen
                    //context.QuizQuestions.Remove(tab);
                }
                context.Quizzes.Remove(quiz);
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }
      
        public async Task<QuizClass> Update(QuizClass quiz)
        {
            try
            {
                context.Quizzes.Update(quiz);
                await context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }

        public async Task<Guid?> GetQuizIdFromQuestionId(Guid id)
        {
            try
            {
                QuizQuestions quizQuestion = context.QuizQuestions.Where(e => e.QuestionId == id).FirstOrDefault();
                return quizQuestion.QuizId;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }


        //Helpers of extra's --------------------------
        public async Task<bool> QuizExists(Guid id)
        {
            return await context.Quizzes.AnyAsync(e => e.QuizId == id);
        }
    }
}
