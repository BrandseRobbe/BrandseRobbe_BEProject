using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using Quiz.Models.Repositories;
using Quiz.Web.Data;

namespace Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAPIController : ControllerBase
    {
        private readonly IQuizRepo quizRepo;
        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ",Identity.Application";

        public QuizAPIController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        // GET: api/QuizAPI/Quizzes
        [EnableCors("AllowOrigin")]
        [HttpGet("Quizzes")]
        public async Task<IActionResult> GetQuizzes()
        {
            var quizzes = await quizRepo.GetAllQuizzesAsync();
            return Ok(quizzes);
        }

        // GET: api/QuizAPI/edce166a-db38-4e71-8279-be8612a13632
        [HttpGet("Quiz/{id}")]
        public async Task<IActionResult> GetQuiz(Guid id)
        {
            return Ok(await quizRepo.GetQuizByIdAsync(id)); //Ok()) = OkObjectResult()
        }

        // POST: api/QuizAPI
        [HttpPost]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<IActionResult> PostQuiz([FromForm] QuizClass quiz)
        {
            //waarschijnlijk nog aanpassen naar DTO's
            QuizClass confirmedModel = new QuizClass();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                confirmedModel = await quizRepo.Create(quiz);
                if (confirmedModel == null) return NotFound("Er ging iets mis.");
            }
            catch (Exception exc)
            {
                return BadRequest("Toevoegen mislukt");
            }
            return CreatedAtAction("Get", new { id = confirmedModel.QuizId }, confirmedModel);
        }

        //// PUT: api/QuizAPI/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<ActionResult<QuizClass>> PutQuiz([FromForm] QuizClass quiz, Guid id)
        {
            quiz.QuizId = id;
            var confirmedModel = new QuizClass(); //te returnen 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await quizRepo.QuizExists(id))
                {
                    return BadRequest($"{id} bestaat niet");
                }
                confirmedModel = await quizRepo.Update(quiz);
            }
            catch (DbUpdateException)
            {
                if (await quizRepo.QuizExists(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok(confirmedModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task DeletQuiz(Guid id)
        {
            await quizRepo.Delete(id);
            return;
        }
    }
}
