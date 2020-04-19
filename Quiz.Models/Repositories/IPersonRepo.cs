using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public interface IPersonRepo
    {
        Task<Person> Add(Person person);
        Task AddEducationsToPerson(string id, string[] selectedEducationsString);
        Task Delete(string id);
        Task<IEnumerable<Person>> GetAllAsync(string roleName);
        Task<Person> GetForIdAsync(string id);
        Task<Person> GetForNameAsync(string name);
        bool PersonExists(string id);
        Task RemoveEducations(string id);
        Task<Person> Update(Person person);
    }
}