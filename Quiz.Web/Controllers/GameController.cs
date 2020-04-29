using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.Models.Repositories;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    [Authorize(Roles = "Admin, Creator, Player")]
    public class GameController : Controller
    {
        private readonly IQuizRepo quizRepo;
        private readonly IGameRepo gameRepo;
        private readonly IQuestionRepo questionRepo;
        private readonly UserManager<User> userMgr;

        public GameController(IQuizRepo quizRepo, IGameRepo gameRepo, IQuestionRepo questionRepo, UserManager<User> userMgr)
        {
            this.quizRepo = quizRepo;
            this.gameRepo = gameRepo;
            this.questionRepo = questionRepo;
            this.userMgr = userMgr;
        }

        public async Task<ActionResult> Index()
        {
            var quizzes = await quizRepo.GetAllQuizzesAsync();
            return View(quizzes);
        }

        public async Task<ActionResult> Scoreboard()
        {
            var scores = await gameRepo.GetAllFinishedGamesAsync();
            List<Scoreboard_VM> scoreboard = new List<Scoreboard_VM>();
            foreach(Game score in scores)
            {
                QuizClass quiz = await quizRepo.GetQuizByIdAsync(new Guid(score.QuizId));
                User user = await userMgr.FindByIdAsync(score.UserId);
                var questions = await quizRepo.GetQuizQuestionsAsync(new Guid(score.QuizId));
                Scoreboard_VM vm = new Scoreboard_VM()
                {
                    QuizName = quiz.Name,
                    UserName = user.Name,
                    correctanswers = score.CorrectAnswers,
                    maxquestions = questions.Count(),
                    completetime = score.TimeFinished.Value.Subtract(score.TimeStarted)
                };
                scoreboard.Add(vm);
            }
            return View(scoreboard);
        }

        public Game_VM convertGame(string gameid, Question question)
        {
            Dictionary<string, bool> options = new Dictionary<string, bool>();
            foreach (Option option in question.PossibleOptions)
            {
                options.Add(option.OptionDescription, false);
            }
            Game_VM gamevm = new Game_VM()
            {
                GameId = gameid,
                QuestionDescription = question.Description,
                QuestionId = question.QuestionId.ToString(),
                Options = options,
                ImageData = question.ImageData
            };
            return gamevm;
        }

        public async Task<ActionResult> StartGame(string id)
        {
            Guid quizId = new Guid(id);
            var q = await quizRepo.GetQuizQuestionsAsync(quizId);
            List<Question> questions = q.Cast<Question>().ToList();
            if (questions.Count() == 0)
            {
                return BadRequest("Cant find the quiz");
            }
            Game game = new Game() { QuizId = id, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            if (await gameRepo.Create(game) == null)
            {
                return BadRequest("Can't create the quiz");
            }
            Game_VM gamevm = convertGame(game.GameId, questions[0]);

            //return await this.Play(gamevm);
            return View("Play", gamevm);
        }

        [HttpPost]
        public async Task<ActionResult> Play(Game_VM vm, IFormCollection collection)
        {
            Game currentgame = await gameRepo.GetGameByIdAsync(vm.GameId);
            Guid questionId = new Guid(vm.QuestionId);
            Question currentquestion = await questionRepo.GetQuestionByIdAsync(questionId);
            // controleren of het antwoord juist was
            bool correct = true;
            foreach (Option option in currentquestion.PossibleOptions)
            {
                var guessedval = vm.Options[option.OptionDescription];
                var correctval = option.CorrectAnswer;
                if (vm.Options[option.OptionDescription] != option.CorrectAnswer)
                {
                    correct = false;
                    break;
                }
            }
            if (correct)
            {
                currentgame.CorrectAnswers += 1;
                if (await gameRepo.Update(currentgame) == null)
                {
                    return BadRequest("Can't update");
                }
            }
            //getting next question
            var allquestions = await quizRepo.GetQuizQuestionsAsync(new Guid(currentgame.QuizId));
            bool save = false;
            Question nextQuestion = new Question();
            foreach (Question question in allquestions)
            {
                if (question == currentquestion)
                {
                    save = true;
                }
                else if (save)
                {
                    nextQuestion = question;
                    save = false;
                    break;
                }
            }
            //als save nog aanstaat betekend dat de we aan de laatste vraag zitten.
            if (save)
            {
                //finish the quiz
                QuizClass currentQuiz = await quizRepo.GetQuizByIdAsync(new Guid(currentgame.QuizId));
                DateTime finishedtime = DateTime.Now;
                TimeSpan completetime = finishedtime.Subtract(currentgame.TimeStarted);
                Finished_VM finished_vm = new Finished_VM()
                {
                    QuizDescription = currentQuiz.Description,
                    userscore = currentgame.CorrectAnswers,
                    maxscore = allquestions.Count(),
                    completetime = finishedtime.Subtract(currentgame.TimeStarted)
                };
                currentgame.TimeFinished = finishedtime;
                if (await gameRepo.Update(currentgame) == null)
                {
                    return BadRequest("Can't update");
                }
                return View("Finished", finished_vm);
            }
            Game_VM next_vm = convertGame(currentgame.GameId, nextQuestion);
            return View("Play", next_vm);
        }
    }
}