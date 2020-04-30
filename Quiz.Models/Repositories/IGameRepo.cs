using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public interface IGameRepo
    {
        Task<Game> Create(Game game);
        Task<IEnumerable<Game>> GetAllFinishedGamesAsync();
        Task<Game> GetGameByIdAsync(Guid id);
        Task RemoveUsersActiveGames(string userId);
        Task<Game> Update(Game game);
    }
}