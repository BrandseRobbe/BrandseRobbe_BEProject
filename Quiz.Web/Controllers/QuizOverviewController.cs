using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.Models.Repositories;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    [Authorize(Roles = "Creator")]
    public class QuizOverviewController : Controller
    {
        private readonly IQuizRepo quizRepo;
        private readonly IQuestionRepo questionRepo;

        public QuizOverviewController(IQuizRepo quizRepo, IQuestionRepo questionRepo)
        {
            this.quizRepo = quizRepo;
            this.questionRepo = questionRepo;
        }

        public async Task<ActionResult> Index()
        {
            var result = await quizRepo.GetAllQuizzesAsync();
            return View(result);
        }

        public async Task<ActionResult> Questions(Guid? id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            //controleren of de quiz we lbestaat
            QuizClass quiz = await quizRepo.GetQuizByIdAsync(id ?? Guid.Empty);
            if (quiz == null)
            {
                return Redirect("/Error/0");
            }
            var result = await quizRepo.GetQuizQuestionsAsync(id ?? Guid.Empty);
            ViewBag.quizId = id;
            return View(result);
        }
        // quiz operations
        public ActionResult CreateQuiz()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuiz(IFormCollection collection, QuizClass quiz)
        {
            try
            {
                if (!ModelState.IsValid) //validatie error
                {
                    return View();
                }
                if (await quizRepo.GetQuizByNameAsync(quiz.Name) != null)
                {
                    ModelState.AddModelError("", "This name is already in use");
                    return View();
                }
                var created = await quizRepo.Create(quiz);
                if (created == null)
                {
                    return Redirect("/Error/0");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exc)
            {
                Console.WriteLine("Create is giving an error: " + exc.Message);
                ModelState.AddModelError("", "Create actie is failed try again");
                return View();
            }
        }

        public async Task<ActionResult> EditQuiz(Guid? id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            QuizClass quiz = await quizRepo.GetQuizByIdAsync(id ?? Guid.Empty);
            if (quiz == null)
            {
                return Redirect("/Error/0");
            }
            return View(quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditQuiz(Guid? id, IFormCollection collection, QuizClass quiz)
        {
            try
            {
                if (id == null)
                {
                    return Redirect("/Error/400");
                }
                if (!ModelState.IsValid)
                {
                    return View();
                }
                quiz.QuizId = id ?? Guid.Empty;
                QuizClass checkdouble = await quizRepo.GetQuizByNameAsync(quiz.Name);
                if (checkdouble != null && checkdouble.QuizId != id)
                {
                    ModelState.AddModelError("", "This name is already in use");
                    return View();
                }
                //eerst controleren of er een aanpassing gebeurt is
                QuizClass original = await quizRepo.GetQuizByIdAsync(quiz.QuizId);
                if (original.Name == quiz.Name && original.Description == quiz.Description && original.Difficulty == quiz.Difficulty)
                {
                    return RedirectToAction(nameof(Index));
                }
                if (await quizRepo.Update(quiz) == null)
                {
                    throw new Exception("Couldn't create the quiz");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exc)
            {
                Console.WriteLine("Create is giving an error: " + exc.Message);
                ModelState.AddModelError("", "Create actie is failed try again");
                return View();
            }
        }

        public async Task<ActionResult> DeleteQuiz(Guid? id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            QuizClass result = await quizRepo.GetQuizByIdAsync(id ?? Guid.Empty);
            if (result == null)
            {
                return Redirect("/Error/0");
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteQuiz(Guid? id, IFormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return Redirect("/Error/400");
                }
                await quizRepo.Delete(id ?? Guid.Empty);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", "Delete failed " + exc);
                return View();
            }
        }


        //question operations
        public async Task<ActionResult> QuestionDetails(Guid? questionId, Guid? quizId)
        {
            if (questionId == null || quizId == null)
            {
                return Redirect("/Error/400");
            }
            ViewBag.quizId = quizId ?? Guid.Empty;
            Question question = await questionRepo.GetQuestionByIdAsync(questionId ?? Guid.Empty);
            if (question == null)
            {
                return Redirect("/Error/404");
            }
            return View(question);
        }

        public ActionResult CreateQuestion(Guid id)
        {
            ViewBag.quizId = id;
            Question_VM vm = new Question_VM() { QuizId = id };
            vm.OptionDescriptions.Add("");
            vm.OptionAnswers.Add(false);
            vm.OptionDescriptions.Add("");
            vm.OptionAnswers.Add(false);
            //vm.OptionCount = 2;

            return View(vm);
        }
        [HttpPost]
        public ActionResult AddOption(IFormCollection collection, Question_VM model)
        {
            ViewBag.quizId = model.QuizId;
            //int aantalOpties = Int32.Parse(collection["aantalOpties"].ToString());
            //model.OptionCount = model.OptionDescriptions.Count() + 1;
            model.OptionAnswers.Add(false);
            model.OptionDescriptions.Add("");
            return View("CreateQuestion", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuestion(IFormCollection collection, Question_VM model)
        {
            try
            {
                if (!ModelState.IsValid) //validatie error
                {
                    return View(model);
                }
                ViewBag.quizId = model.QuizId;
                if (await quizRepo.GetQuizByIdAsync(model.QuizId) == null)
                {
                    return Redirect("/Error/404");
                }
                if (await questionRepo.GetQuestionByDescriptionAsync(model.Description) != null)
                {
                    ModelState.AddModelError("", "This description is already being used by another question");
                    return View(model);
                }

                List<Option> options = new List<Option>();
                int corrects = 0;
                for (int i = 0; i < model.OptionDescriptions.Count(); i++)
                {
                    if (!string.IsNullOrWhiteSpace(model.OptionDescriptions[i]))
                    {
                        Option option = new Option()
                        {
                            OptionDescription = model.OptionDescriptions[i],
                            CorrectAnswer = model.OptionAnswers[i]
                        };
                        options.Add(option);
                        if (model.OptionAnswers[i]) corrects += 1;
                    }
                }
                if (options.Count() < 2)
                {
                    ModelState.AddModelError("", "Add at least 2 Options");
                    return View(model);
                }
                if (corrects == 0)
                {
                    ModelState.AddModelError("", "Add at least 1 right answer");
                    return View(model);
                }

                Question question = new Question()
                {
                    Description = model.Description,
                    PossibleOptions = options
                };
                if (model.ImageString != null)
                {
                    byte[] b;
                    using (BinaryReader br = new BinaryReader(model.ImageString.OpenReadStream()))
                    {
                        b = br.ReadBytes((int)model.ImageString.OpenReadStream().Length);
                        question.ImageData = b;
                    }
                }
                if (await questionRepo.Create(question) == null)
                {
                    throw new Exception("Couldn't create the question");
                }
                if (await quizRepo.AddQuestionToQuizAsync(model.QuizId, question.QuestionId) == null)
                {
                    throw new Exception("Couldn't add the question to the quiz");
                }
                return RedirectToAction("Questions", new { id = model.QuizId });
            }
            catch (Exception exc)
            {
                Console.WriteLine("Create is giving an error: " + exc.Message);
                ModelState.AddModelError("", "Create actie is failed try again");
                return View();
            }
        }

        public async Task<ActionResult> DeleteQuestion(Guid? questionId, Guid? quizId)
        {
            if (questionId == null || quizId == null)
            {
                return Redirect("/Error/400");
            }
            ViewBag.quizId = quizId ?? Guid.Empty;
            Question question = await questionRepo.GetQuestionByIdAsync(questionId ?? Guid.Empty);
            if (question == null)
            {
                return Redirect("/Error/404");
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteQuestion(Question question, IFormCollection collection)
        {
            try
            {
                //quizid ophalen voor redirect
                Guid? quizId = await quizRepo.GetQuizIdFromQuestionId(question.QuestionId);
                if (quizId == null)
                {
                    return RedirectToAction("Index");
                }
                if (question.QuestionId == null)
                {
                    return Redirect("/Error/404");
                }
                await questionRepo.Delete(question.QuestionId);
                return RedirectToAction("Questions", new { id = quizId });
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", "Delete failed");
                return View();
            }
        }
    }
}