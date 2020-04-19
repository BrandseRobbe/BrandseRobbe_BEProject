using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public interface IQuizRepo
    {
        Task<QuizQuestions> AddQuestionToQuizAsync(Guid quizId, Guid questionId);
        Task<QuizClass> Create(QuizClass quiz);
        Task Delete(Guid quizId);
        Task<IEnumerable<QuizClass>> GetAllQuizzesAsync();
        Task<QuizClass> GetQuizByIdAsync(Guid id);
        Task<QuizClass> GetQuizByNameAsync(string quizName);
        Task<IEnumerable<Question>> GetQuizQuestionsAsync(Guid quizId);
        Task<bool> QuizExists(Guid id);
        Task<QuizClass> Update(QuizClass quiz);
    }
}