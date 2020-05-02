using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            List<QuizClass> valids = new List<QuizClass>();
            foreach (QuizClass quiz in quizzes)
            {
                var questions = await quizRepo.GetQuizQuestionsAsync(quiz.QuizId);
                if (questions.Count() != 0)
                {
                    valids.Add(quiz);
                }
            }
            return View(valids.AsEnumerable());
        }


        public async Task<ActionResult> Scoreboard()
        {
            var scores = await gameRepo.GetAllFinishedGamesAsync();
            List<Scoreboard_VM> scoreboard = new List<Scoreboard_VM>();
            foreach (Game score in scores)
            {
                QuizClass quiz = await quizRepo.GetQuizByIdAsync(score.QuizId);
                if (quiz != null)
                {
                    User user = await userMgr.FindByIdAsync(score.UserId);
                    var questions = await quizRepo.GetQuizQuestionsAsync(score.QuizId);
                    Scoreboard_VM vm = new Scoreboard_VM()
                    {
                        GameId = score.GameId,
                        QuizName = quiz.Name,
                        UserEmail = user.Email,
                        UserName = user.Name,
                        correctanswers = score.CorrectAnswers,
                        maxquestions = questions.Count(),
                        completetime = score.TimeFinished.Value.Subtract(score.TimeStarted)
                    };
                    scoreboard.Add(vm);
                }
            }
            return View(scoreboard.OrderByDescending(e => e.correctanswers / e.maxquestions).ThenBy(e => e.completetime).ToList());
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteScore(Guid? id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            await gameRepo.Delete(id ?? Guid.Empty);
            return RedirectToAction("Scoreboard");
        }


        public Game_VM convertGame(Guid gameid, Question question, int questionNr)
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
                QuestionId = question.QuestionId,
                Options = options,
                ImageData = question.ImageData,
                questionNr = questionNr
            };
            return gamevm;
        }

        public async Task<ActionResult> StartGame(Guid? id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //alle history van gespeelde games verwijderen
            await gameRepo.ClearUserGameHistory(userId);
            //alle oude foutief afgesloten quizzen verwijderen
            await gameRepo.RemoveUsersActiveGames(userId);
            //quiz starten
            var q = await quizRepo.GetQuizQuestionsAsync(id ?? Guid.Empty);
            List<Question> questions = q.Cast<Question>().ToList();
            if (questions.Count() == 0)
            {
                return Redirect("/Error/404");
            }
            Game game = new Game()
            {
                QuizId = id ?? Guid.Empty,
                UserId = userId,
            };
            if (await gameRepo.Create(game) == null)
            {
                return Redirect("/Error/0");
            }
            Game_VM vm = convertGame(game.GameId, questions[0], 0);

            ViewBag.questionNr = vm.questionNr;
            ViewBag.questionId = vm.QuestionId;
            return View("Play", vm);
        }

        [HttpPost]
        public async Task<ActionResult> Play(Game_VM vm, IFormCollection collection)
        {
            Guid vraagId = new Guid(collection["vraagId"].ToString());
            int vraagNr = Int32.Parse(collection["vraagNr"].ToString());
            Game currentgame = await gameRepo.GetGameByIdAsync(vm.GameId);
            Question currentquestion = await questionRepo.GetQuestionByIdAsync(vraagId);

            // controleren of het antwoord juist was
            bool correct = true;
            //controleren of ze wel iets hebben aangeduid
            bool filled = false;
            foreach (var input in vm.Options)
            {
                if (input.Value == true) filled = true;
            }
            if (!filled)
            {
                vm = convertGame(currentgame.GameId, currentquestion, vm.questionNr);
                ViewBag.questionNr = vraagNr;
                ViewBag.questionId = vraagId;
                ModelState.AddModelError("", "Je moet een optie kiezen");
                return View(vm);
            }
            List<Option> histoptions = new List<Option>();
            foreach (Option option in currentquestion.PossibleOptions)
            {
                //var guessedval = vm.Options[option.OptionDescription];
                //var correctval = option.CorrectAnswer;
                if (vm.Options[option.OptionDescription] != option.CorrectAnswer)
                {
                    correct = false;
                }
                //ondertussen options opslaan voor bij te houden voor de uitslag
                Option histoption = new Option()
                {
                    OptionDescription = option.OptionDescription,
                    CorrectAnswer = vm.Options[option.OptionDescription]
                };
                histoptions.Add(histoption);
            }
            if (correct)
            {
                currentgame.CorrectAnswers += 1;
                if (await gameRepo.Update(currentgame) == null)
                {
                    return Redirect("/Error/0");
                }
            }

            //question opslaan voor later als bij uitslag weer te geven
            Question histquestion = new Question()
            {
                PossibleOptions = histoptions
            };
            if (await questionRepo.Create(histquestion) != null)
            {
                if (await gameRepo.AddQuestionToGameAsync(vm.GameId, histquestion.QuestionId, currentquestion.QuestionId) == null)
                {
                    return Redirect("/Error/0");
                }
            }

            //getting next question
            var allquestions = await quizRepo.GetQuizQuestionsAsync(currentgame.QuizId);
            bool save = false;
            Question nextQuestion = new Question();
            foreach (Question question in allquestions)
            {
                if (question.Description == currentquestion.Description)
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
                QuizClass currentQuiz = await quizRepo.GetQuizByIdAsync(currentgame.QuizId);
                DateTime finishedtime = DateTime.Now;
                TimeSpan completetime = finishedtime.Subtract(currentgame.TimeStarted);
                //vm voor uitslag pagina opvullen
                var gameresults = await gameRepo.GetGameResults(vm.GameId);
                Finished_VM finished_vm = new Finished_VM()
                {
                    QuizName = currentQuiz.Name,
                    QuizDescription = currentQuiz.Description,
                    userscore = currentgame.CorrectAnswers,
                    maxscore = allquestions.Count(),
                    completetime = finishedtime.Subtract(currentgame.TimeStarted),
                    gameresults = gameresults
                };
                currentgame.TimeFinished = finishedtime;
                if (await gameRepo.Update(currentgame) == null)
                {
                    return Redirect("/Error/0");
                }
                return View("Finished", finished_vm);
            }
            vm = convertGame(currentgame.GameId, nextQuestion, vm.questionNr + 1);

            ViewBag.questionNr = vm.questionNr;
            ViewBag.questionId = nextQuestion.QuestionId;
            return View("Play", vm);
        }
    }
}