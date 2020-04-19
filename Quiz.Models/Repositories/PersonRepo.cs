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
    public class PersonRepo : IPersonRepo
    {
        private readonly UserManager<Person> userMgr;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly QuizDbContext context;

        public PersonRepo(UserManager<Person> userMgr, RoleManager<IdentityRole> roleManager, QuizDbContext context)
        {
            this.userMgr = userMgr;
            this.roleManager = roleManager;
            this.context = context;
        }

        public async Task<Person> Add(Person person)
        {
            IdentityResult result = await userMgr.CreateAsync(person);
            return null;
        }

        public Task AddEducationsToPerson(string id, string[] selectedEducationsString)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllAsync(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            var result = userMgr.Users.Include(u => u.Roles).Where(p => p.Roles.Any(r => r.RoleId == role.Id));
            return result;
        }

        public async Task<Person> GetForIdAsync(string id)
        {
            return await userMgr.FindByIdAsync(id);
        }

        public async Task<Person> GetForNameAsync(string name)
        {
            return await userMgr.FindByNameAsync(name);
        }

        public bool PersonExists(string id)
        {
            return context.Persons.Any(e => e.Id == id);

        }

        public Task RemoveEducations(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
