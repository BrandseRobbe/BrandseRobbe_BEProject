using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public interface IQuestionRepo
    {
        Task<Question> Create(Question question);
        Task Delete(Guid questionId);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByDescriptionAsync(string desciption);
        Task<Question> GetQuestionByIdAsync(Guid questionId);
    }
}