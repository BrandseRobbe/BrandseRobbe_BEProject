using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using Quiz.Models.Repositories;
using Quiz.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.Data
{
    public static class QuizDbContextExtensions
    {
        public async static Task SeedQuiz(IQuizRepo quizRepo, IQuestionRepo questionRepo)
        {
            string[] quizNames = { "Animals", "trivia", "geography" };
            List<QuizClass>  quizzes = new List<QuizClass>();
            foreach (var quizName in quizNames)
            {
                var quiz = await quizRepo.GetQuizByNameAsync(quizName);
                if (quiz == null)
                {
                    QuizClass newQuiz = new QuizClass()
                    {
                        Name = quizName
                    };
                    await quizRepo.Create(newQuiz);
                }
                quizzes.Add(quiz);
            }

            Question vraag1 = new Question()
            {
                Description = "hoeveel weegt pikachu"
            };
            Option option1 = new Option()
            {
                OptionDescription = "5 kg",
                CorrectAnswer = true
            };
            Option option2 = new Option()
            {
                OptionDescription = "8 kg",
                CorrectAnswer = false
            };

            List<Option> opties = new List<Option>();
            opties.Add(option1);
            opties.Add(option2);
            vraag1.PossibleOptions = opties;

            var question = await questionRepo.GetQuestionByDescriptionAsync(vraag1.Description);
            if (question == null)
            {
                await questionRepo.Create(vraag1);
            }
            await quizRepo.AddQuestionToQuizAsync(quizzes[0].QuizId, vraag1.QuestionId);
        }

        public async static Task SeedRoles(RoleManager<Role> RoleMgr)
        {
            IdentityResult roleResult; string[] roleNames = { "Admin", "Player", "Creator"};
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleMgr.RoleExistsAsync(roleName);
                if (!roleExist) 
                {
                    Role role = new Role(roleName);
                    roleResult = await RoleMgr.CreateAsync(role); 
                }
            }
        }
        public async static Task SeedUsers(UserManager<User> userMgr)
        {
            //Admin aanmaken 
            if (await userMgr.FindByNameAsync("admin@mail.com") == null)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    Email = "admin@mail.com",
                    UserName = "admin@mail.com"
                };
                var userResult = await userMgr.CreateAsync(user, "Admin#1");
                var roleResult1 = await userMgr.AddToRoleAsync(user, "Admin");
                var roleResult2 = await userMgr.AddToRoleAsync(user, "Creator");
                var roleResult3 = await userMgr.AddToRoleAsync(user, "Player");
                // var claimResult = await userMgr.AddClaimAsync(user, new Claim("DocentWeb", "True"));                
                if (!userResult.Succeeded || !roleResult1.Succeeded || !roleResult2.Succeeded || !roleResult3.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
            //2. meerdere users  aanmaken --------------------------------------------         
            //2a. persons met rol "Student" aanmaken       
            //var nmbrStudents = 9;
            //for (var i = 1; i <= nmbrStudents; i++)
            //{
            //    if (userMgr.FindByNameAsync("Student" + i).Result == null)
            //    {
            //        Person student = new Person
            //        {
            //            Id = Guid.NewGuid().ToString(),
            //            UserName = "Student" + i,
            //            Name = "nameStudent" + i,
            //            Email = "emailSt" + i + "@howest.be",
            //            Gender = (Person.GenderType)new Random().Next(0, 2), //GenderType.Male           
            //        };
            //        var userResult = await userMgr.CreateAsync(student, "studentP@sw00rd" + i);
            //        var roleResult = await userMgr.AddToRoleAsync(student, "Student");
            //        if (!userResult.Succeeded || !roleResult.Succeeded)
            //        {
            //            throw new InvalidOperationException("Failed to build " + student.UserName);
            //        }
            //    }
            //}
        }

    }
}

