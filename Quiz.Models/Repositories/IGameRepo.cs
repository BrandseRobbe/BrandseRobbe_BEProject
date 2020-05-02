using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Models.Repositories
{
    public interface IGameRepo
    {
        Task<GameQuestion> AddQuestionToGameAsync(Guid gameId, Guid questionId, Guid correctQuestionId);
        Task ClearGameHistory(Guid gameid);
        Task ClearUserGameHistory(string userId);
        Task<Game> Create(Game game);
        Task Delete(Guid gameId);
        Task<IEnumerable<Game>> GetAllFinishedGamesAsync();
        Task<Game> GetGameByIdAsync(Guid id);
        Task<IEnumerable<IEnumerable<Question>>> GetGameResults(Guid GameId);
        Task RemoveUsersActiveGames(string userId);
        Task<Game> Update(Game game);
    }
}