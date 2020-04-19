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
            await quizRepo.AddQuestionToQuizAsync(new Guid("E497D9A5-09CF-41EA-893D-06EB3B0E610F"), vraag1.QuestionId);
        }
    }
}

