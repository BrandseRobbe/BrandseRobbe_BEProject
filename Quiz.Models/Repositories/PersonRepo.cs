using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<User> userMgr;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly QuizDbContext context;

        public UserRepo(UserManager<User> userMgr, RoleManager<IdentityRole> roleManager, QuizDbContext context)
        {
            this.userMgr = userMgr;
            this.roleManager = roleManager;
            this.context = context;
        }

        public async Task<User> Add(User User)
        {
            IdentityResult result = await userMgr.CreateAsync(User);
            return null;
        }

        public Task AddEducationsToUser(string id, string[] selectedEducationsString)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            var result = userMgr.Users.Include(u => u.UserRoles).Where(p => p.UserRoles.Any(r => r.RoleId == role.Id));
            return result;
        }

        public async Task<User> GetForIdAsync(string id)
        {
            return await userMgr.FindByIdAsync(id);
        }

        public async Task<User> GetForNameAsync(string name)
        {
            return await userMgr.FindByNameAsync(name);
        }

        public bool UserExists(string id)
        {
            return context.Users.Any(e => e.Id == id);

        }

        public Task RemoveEducations(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User User)
        {
            throw new NotImplementedException();
        }
    }
}
