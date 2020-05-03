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
        public async static Task SeedQuizold(IQuizRepo quizRepo, IQuestionRepo questionRepo)
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
                        Name = quizName,
                        Difficulty = 2,
                        Description = "A quiz about " + quizName
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
        public async static Task SeedQuiz(IQuizRepo quizRepo, IQuestionRepo questionRepo)
        {
            //quiz over Trivia aanmaken
            string quizName = "Trivia";
            if (await quizRepo.GetQuizByNameAsync(quizName) == null)
            {
                QuizClass newQuiz = new QuizClass()
                {
                    Name = quizName,
                    Difficulty = 5,
                    Description = "A quiz about all sorts of things"
                };
                await quizRepo.Create(newQuiz);

                List<Option> opties = new List<Option>();
                Question vraag = new Question()
                {
                    Description = "Which of the following items was owned by the fewest U.S. homes in 1990?"
                };
                if (await questionRepo.GetQuestionByDescriptionAsync(vraag.Description) == null)
                {
                    Option option1 = new Option()
                    {
                        OptionDescription = "home computer",
                        CorrectAnswer = false
                    };
                    Option option2 = new Option()
                    {
                        OptionDescription = "compact disk player",
                        CorrectAnswer = true
                    };
                    Option option3 = new Option()
                    {
                        OptionDescription = "dishwasher",
                        CorrectAnswer = false
                    };
                    opties.Add(option1);
                    opties.Add(option2);
                    opties.Add(option3);
                    vraag.PossibleOptions = opties;
                    await questionRepo.Create(vraag);
                    await quizRepo.AddQuestionToQuizAsync(newQuiz.QuizId, vraag.QuestionId);
                }

                vraag = new Question()
                {
                    Description = "How tall is the tallest man on earth?"
                };
                if (await questionRepo.GetQuestionByDescriptionAsync(vraag.Description) == null)
                {
                    Option option1 = new Option()
                    {
                        OptionDescription = "2.72 m",
                        CorrectAnswer = true
                    };
                    Option option2 = new Option()
                    {
                        OptionDescription = "2.64 m",
                        CorrectAnswer = false
                    };
                    Option option3 = new Option()
                    {
                        OptionDescription = "3.05 m",
                        CorrectAnswer = false
                    };
                    opties = new List<Option>();
                    opties.Add(option1);
                    opties.Add(option2);
                    opties.Add(option3);
                    vraag.PossibleOptions = opties;
                    await questionRepo.Create(vraag);
                    await quizRepo.AddQuestionToQuizAsync(newQuiz.QuizId, vraag.QuestionId);
                }
                vraag = new Question()
                {
                    Description = "Which racer holds the record for the most Grand Prix wins?"
                };
                if (await questionRepo.GetQuestionByDescriptionAsync(vraag.Description) == null)
                {
                    Option option1 = new Option()
                    {
                        OptionDescription = "Michael Schumacher",
                        CorrectAnswer = true
                    };
                    Option option2 = new Option()
                    {
                        OptionDescription = "Mario Andretti",
                        CorrectAnswer = false
                    };
                    Option option3 = new Option()
                    {
                        OptionDescription = "Lewis Hamilton",
                        CorrectAnswer = false
                    };
                    opties = new List<Option>();
                    opties.Add(option1);
                    opties.Add(option2);
                    opties.Add(option3);
                    vraag.PossibleOptions = opties;
                    await questionRepo.Create(vraag);
                    await quizRepo.AddQuestionToQuizAsync(newQuiz.QuizId, vraag.QuestionId);
                }
            }
            return;
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
            //Admins aanmaken 
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
                var roleResult3 = await userMgr.AddToRoleAsync(user, "Player");
                // var claimResult = await userMgr.AddClaimAsync(user, new Claim("DocentWeb", "True"));                
                if (!userResult.Succeeded || !roleResult1.Succeeded || !roleResult3.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
            if (await userMgr.FindByNameAsync("Docent@MCT") == null)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Docent",
                    Email = "Docent@MCT",
                    UserName = "Docent@MCT"
                };
                var userResult = await userMgr.CreateAsync(user, "Docent@1");
                var roleResult1 = await userMgr.AddToRoleAsync(user, "Admin");
                var roleResult2 = await userMgr.AddToRoleAsync(user, "Creator");
                var roleResult3 = await userMgr.AddToRoleAsync(user, "Player");
                // var claimResult = await userMgr.AddClaimAsync(user, new Claim("DocentWeb", "True"));                
                if (!userResult.Succeeded || !roleResult1.Succeeded || !roleResult2.Succeeded || !roleResult3.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
        }
    }
}

