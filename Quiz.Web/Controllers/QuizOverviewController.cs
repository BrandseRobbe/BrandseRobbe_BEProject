using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models.Repositories;

namespace Quiz.Web.Controllers
{
    public class QuizOverviewController : Controller
    {
        private readonly IQuizRepo quizRepo;

        public QuizOverviewController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        // GET: QuizOverview
        public async Task<ActionResult> Index()
        {
            var result = await quizRepo.GetAllQuizzesAsync();
            return View(result);
        }

        // GET: QuizOverview/Details/5
        public async Task<ActionResult> Questions(string id)
        {
            Guid quizid = new Guid(id);
            var result = await quizRepo.GetQuizQuestionsAsync(quizid);
            return View(result);
        }

        // GET: QuizOverview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizOverview/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizOverview/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuizOverview/Edit/5
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

        // GET: QuizOverview/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuizOverview/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}