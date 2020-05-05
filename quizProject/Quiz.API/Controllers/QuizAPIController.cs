using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.API.Models;
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
        private readonly IGameRepo gameRepo;
        private readonly UserManager<User> userMgr;
        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ",Identity.Application";

        public QuizAPIController(IQuizRepo quizRepo, IGameRepo gameRepo, UserManager<User> userMgr)
        {
            this.quizRepo = quizRepo;
            this.gameRepo = gameRepo;
            this.userMgr = userMgr;
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
        [EnableCors("AllowOrigin")]
        [HttpGet("Quiz/{id}")]
        public async Task<IActionResult> GetQuiz(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            return Ok(await quizRepo.GetQuizByIdAsync(id ?? Guid.Empty)); //Ok()) = OkObjectResult()
        }
        
        [EnableCors("AllowOrigin")]
        [HttpGet("Quiz/{id}/Questions")]
        public async Task<IActionResult> GetQuizQuestions(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            return Ok(await quizRepo.GetQuizQuestionsAsync(id ?? Guid.Empty));
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("Quiz")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<IActionResult> PostQuiz([FromBody] QuizClass quiz)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }
                QuizClass confirmedModel = await quizRepo.Create(quiz);
                if (confirmedModel == null) return BadRequest("Something went wrong");
                return Ok(confirmedModel);
            }
            catch (Exception exc)
            {
                return BadRequest("Couldn't create the quiz");
            }
        }

        [EnableCors("AllowOrigin")]
        [HttpPut("Quiz/{id}")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<ActionResult<QuizClass>> PutQuiz([FromBody] QuizClass quiz, Guid? id)
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

        [EnableCors("AllowOrigin")]
        [HttpDelete("Quiz/{id}")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<IActionResult> DeletQuiz(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("This enpoind requires a valid QuizId");
            }
            await quizRepo.Delete(id ?? Guid.Empty);
            return new StatusCodeResult(200);
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("Quiz/statistics/{date}")]
        //[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<IActionResult> Stats(DateTime? date)
        {
            if (date == null)
            {
                return BadRequest("Give a correct date format");
            }
            var games = await gameRepo.GetGamesByDate(date);

            List<Scoreboard_DTO> gamedata = new List<Scoreboard_DTO>();
            foreach (Game game in games)
            {
                QuizClass quiz = await quizRepo.GetQuizByIdAsync(game.QuizId);
                if (quiz != null)
                {
                    User user = await userMgr.FindByIdAsync(game.UserId);
                    var questions = await quizRepo.GetQuizQuestionsAsync(game.QuizId);
                    Scoreboard_DTO vm = new Scoreboard_DTO()
                    {
                        GameId = game.GameId,
                        QuizName = quiz.Name,
                        UserEmail = user.Email,
                        UserName = user.Name,
                        correctanswers = game.CorrectAnswers,
                        maxquestions = questions.Count(),
                        completetime = game.TimeFinished.Value.Subtract(game.TimeStarted)
                    };
                    gamedata.Add(vm);
                }
            }
            Stats_DTO stats = new Stats_DTO();
            Stats_Mapper.ConvertTo_DTO(gamedata, ref stats);
            return Ok(stats);
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("Quiz/statistics/test")]
        //[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Creator")]
        public async Task<IActionResult> Stats()
        {
            DateTime? date = new DateTime(2020, 5, 5);
            if (date == null)
            {
                return BadRequest("Give a correct date format");
            }
            var games = await gameRepo.GetGamesByDate(date);

            List<Scoreboard_DTO> gamedata = new List<Scoreboard_DTO>();
            foreach (Game game in games)
            {
                QuizClass quiz = await quizRepo.GetQuizByIdAsync(game.QuizId);
                if (quiz != null)
                {
                    User user = await userMgr.FindByIdAsync(game.UserId);
                    var questions = await quizRepo.GetQuizQuestionsAsync(game.QuizId);
                    Scoreboard_DTO vm = new Scoreboard_DTO()
                    {
                        GameId = game.GameId,
                        QuizName = quiz.Name,
                        UserEmail = user.Email,
                        UserName = user.Name,
                        correctanswers = game.CorrectAnswers,
                        maxquestions = questions.Count(),
                        completetime = game.TimeFinished.Value.Subtract(game.TimeStarted)
                    };
                    gamedata.Add(vm);
                }
            }
            Stats_DTO stats = new Stats_DTO();
            Stats_Mapper.ConvertTo_DTO(gamedata, ref stats);
            return Ok(stats);
        }

    }
}
