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

        public GameRepo(QuizDbContext context)
        {
            this.context = context;
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
            var activegames = context.Games.Where(e => e.UserId == userId && e.TimeFinished == null);
            foreach(var game in activegames)
            {
                context.Games.Remove(game);
            }
            context.SaveChanges();
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
    }
}
