using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Models;
using Quiz.Models.DTO;
using Quiz.Models.Repositories;

namespace Quiz.Web.Controllers
{
    public class QuestionOverviewController : Controller
    {
        private readonly IQuestionRepo questionRepo;
        private readonly IQuizRepo quizRepo;

        public QuestionOverviewController(IQuestionRepo questionRepo, IQuizRepo quizRepo)
        {
            this.questionRepo = questionRepo;
            this.quizRepo = quizRepo;
        }

        // GET: QuestionOverview
        public async Task<ActionResult> Index()
        {
            var questions = await questionRepo.GetAllQuestionsAsync();
            return View(questions);
        }

        // GET: QuestionOverview/Details/5
        public async Task<ActionResult> Details(Guid questionId)
        {
            var question = await questionRepo.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            Question_DTO model = new Question_DTO()
            {
                QuestionId = questionId.ToString()
            };
            QuestionMapper.Question_to_DTO(model,  ref question);
            return View(model);
        }

        // GET: QuestionOverview/Create
        public async Task<ActionResult> Create()
        {
            List<QuizClass> quizzes = new List<QuizClass>();
            quizzes.Insert(0, new QuizClass { Name = "Chose a quiz for this question" });
            quizzes.AddRange(await quizRepo.GetAllQuizzesAsync());

            var quizlist = new SelectList(quizzes, "QuizId", "Name");
            ViewData["Quizzes"] = quizlist;
            return View();
        }

        // POST: QuestionOverview/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, Question_DTO model)
        {
            try
            {
                if (!ModelState.IsValid) //validatie error
                {
                    return BadRequest(); //moet nog properder gemaakt worden.
                }
                Question newquestion = new Question()
                {
                    Description = model.Description,
                    PossibleOptions = new List<Option>()
                };
                Option rightanswer = new Option()
                {
                    CorrectAnswer = true,
                    OptionDescription = model.RightAnswer
                };
                newquestion.PossibleOptions.Add(rightanswer);
                if (model.WrongAnswer1 != null)
                {
                    Option option = new Option()
                    {
                        CorrectAnswer = false,
                        OptionDescription = model.WrongAnswer1
                    };
                    newquestion.PossibleOptions.Add(option);
                }
                if (model.WrongAnswer2 != null)
                {
                    Option option = new Option()
                    {
                        CorrectAnswer = false,
                        OptionDescription = model.WrongAnswer2
                    };
                    newquestion.PossibleOptions.Add(option);
                }
                if (model.WrongAnswer3 != null)
                {
                    Option option = new Option()
                    {
                        CorrectAnswer = false,
                        OptionDescription = model.WrongAnswer3
                    };
                    newquestion.PossibleOptions.Add(option);
                }

                var created = await questionRepo.Create(newquestion);
                if (created == null)
                {
                    throw new Exception("Invalid Entry");
                }
                if (model.QuizId != null)
                {
                    var linked = await quizRepo.AddQuestionToQuizAsync(new Guid(model.QuizId), newquestion.QuestionId);
                    if (linked == null)
                    {
                        throw new Exception("Invalid Entry");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exc)
            {
                Console.WriteLine("Create is giving an error: " + exc.Message);
                ModelState.AddModelError("", "Create actie is mislukt voor");
                return View();
            }
        }

        // GET: QuestionOverview/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionOverview/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionOverview/Delete/5
        public async Task<ActionResult> Delete(Guid questionId)
        {
            if (questionId == Guid.Empty)
            {
                return BadRequest();
            }
            Question question = await questionRepo.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            Question_DTO model = new Question_DTO()
            {
                QuestionId = questionId.ToString()
            };
            QuestionMapper.Question_to_DTO(model, ref question);
            return View(model);
        }

        // POST: QuestionOverview/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(IFormCollection collection, Question_DTO question)
        {
            try
            {
                if (question.QuestionId == "")
                {
                    return BadRequest();
                }
                await questionRepo.Delete(new Guid(question.QuestionId));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", "Delete failed " + exc);
                return View();
            }
        }
    }
}