using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public interface IUserRepo
    {
        Task<User> Add(User User);
        Task AddEducationsToUser(string id, string[] selectedEducationsString);
        Task Delete(string id);
        Task<IEnumerable<User>> GetAllAsync(string roleName);
        Task<User> GetForIdAsync(string id);
        Task<User> GetForNameAsync(string name);
        bool UserExists(string id);
        Task RemoveEducations(string id);
        Task<User> Update(User User);
    }
}