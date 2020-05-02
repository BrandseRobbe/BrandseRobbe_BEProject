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
        public async Task<IActionResult> GetQuiz(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            return Ok(await quizRepo.GetQuizByIdAsync(id ?? Guid.Empty)); //Ok()) = OkObjectResult()
        }
        [HttpGet("Quiz/{id}/Questions")]
        public async Task<IActionResult> GetQuizQuestions(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            return Ok(await quizRepo.GetQuizQuestionsAsync(id ?? Guid.Empty));
        }

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
                if (confirmedModel == null) return BadRequest("Something went wrong");
            }
            catch (Exception exc)
            {
                return BadRequest("Couldn't create the quiz");
            }
            return CreatedAtAction("Get", new { id = confirmedModel.QuizId }, confirmedModel);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<ActionResult<QuizClass>> PutQuiz([FromForm] QuizClass quiz, Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            quiz.QuizId = id ?? Guid.Empty;
            var confirmedModel = new QuizClass(); //te returnen 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await quizRepo.QuizExists(id ?? Guid.Empty))
                {
                    return BadRequest($"{id} bestaat niet");
                }
                confirmedModel = await quizRepo.Update(quiz);
            }
            catch (DbUpdateException)
            {
                if (await quizRepo.QuizExists(id ?? Guid.Empty))
                {
                    return Conflict();
                }
                else
                {
                    return BadRequest("Something went wrong, try again later");
                }
            }
            return Ok(confirmedModel);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task DeletQuiz(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            await quizRepo.Delete(id ?? Guid.Empty);
            return;
        }
    }
}
