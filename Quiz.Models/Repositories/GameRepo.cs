using Microsoft.EntityFrameworkCore;
using Quiz.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public class GameRepo : IGameRepo
    {
        private readonly QuizDbContext context;
        private readonly IQuestionRepo questionRepo;

        public GameRepo(QuizDbContext context, IQuestionRepo questionRepo)
        {
            this.context = context;
            this.questionRepo = questionRepo;
        }

        public async Task<Game> GetGameByIdAsync(Guid id)
        {
            try
            {
                return await context.Games.SingleOrDefaultAsync<Game>(e => e.GameId == id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Game>> GetAllFinishedGamesAsync()
        {
            try
            {
                //.ThenBy(e=>e.TimeFinished-e.TimeStarted)
                return await context.Games.OrderBy(e => e.CorrectAnswers).Where(e => e.TimeFinished != null).ToListAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task RemoveUsersActiveGames(string userId)
        {
            try
            {
                var activegames = await context.Games.Where(e => e.UserId == userId && e.TimeFinished == null).ToListAsync();
                foreach (var game in activegames)
                {
                    context.Games.Remove(game);
                }
                context.SaveChanges();
            }
            catch (Exception exc)
            {
                return;
            }
        }
        public async Task<Game> Create(Game game)
        {
            try
            {
                var result = context.Games.AddAsync(game);
                await context.SaveChangesAsync();
                return game;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task<Game> Update(Game game)
        {
            try
            {
                context.Games.Update(game);
                await context.SaveChangesAsync();
                return game;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }
        public async Task Delete(Guid gameId)
        {
            try
            {
                Game game = await GetGameByIdAsync(gameId);
                context.Games.Remove(game);
                await context.SaveChangesAsync();
                await ClearGameHistory(gameId);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }
        public async Task ClearUserGameHistory(string userId)
        {
            var games = await context.Games.Where(e => e.UserId == userId).ToListAsync();
            foreach(Game game in games)
            {
                ClearGameHistory(game.GameId);
            }
        }
        public async Task ClearGameHistory(Guid gameid)
        {
            var tussentabel = await context.GameQuestions.Where(e => e.GameId == gameid).ToListAsync();
            foreach (var tab in tussentabel)
            {
                //questions uit quiz deleten (en tussentabel)
                await questionRepo.Delete(tab.QuestionId);
                //om enkel uit tussentabel halen
                //context.QuizQuestions.Remove(tab);
            }
        }


        public async Task<GameQuestion> AddQuestionToGameAsync(Guid gameId, Guid questionId, Guid correctQuestionId)
        {
            try
            {
                GameQuestion gameQuestion = new GameQuestion()
                {
                    QuestionId = questionId,
                    GameId = gameId,
                    CorrectQuestionId = correctQuestionId
                };

                var controle = await context.GameQuestions.SingleOrDefaultAsync<GameQuestion>(e => e.GameId == gameId && e.QuestionId == questionId);
                if (controle != null)
                {
                    Console.WriteLine("already in quiz");
                    return null;
                }
                var result = await context.GameQuestions.AddAsync(gameQuestion);
                await context.SaveChangesAsync();
                return gameQuestion;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        public async Task<IEnumerable<IEnumerable<Question>>> GetGameResults(Guid GameId)
        {
            var gameQuestions = await context.GameQuestions.Where(e => e.GameId == GameId).ToListAsync();
            List<IEnumerable<Question>> result = new List<IEnumerable<Question>>();
            foreach (GameQuestion gameQuestion in gameQuestions)
            {
                Question question = context.Questions.Include(e => e.PossibleOptions).Where(e => e.QuestionId == gameQuestion.CorrectQuestionId).FirstOrDefault();
                Question userinput = context.Questions.Include(e => e.PossibleOptions).Where(e => e.QuestionId == gameQuestion.QuestionId).FirstOrDefault();
                List<Question> questions = new List<Question>();
                questions.Add(question);
                questions.Add(userinput);
                IEnumerable<Question> enumerable = questions;
                result.Add(enumerable);
            }
            IEnumerable<IEnumerable<Question>> en = result;
            return en;
        }

        public async Task<IEnumerable<Game>> GetGamesByDate(DateTime? date)
        {
            try
            {
                return await context.Games.Where(e => e.TimeFinished != null && e.TimeFinished.Value.Date == date.Value.Date).ToListAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

    }
}
