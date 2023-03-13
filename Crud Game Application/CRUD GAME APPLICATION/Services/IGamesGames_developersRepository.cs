using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public interface IGamesGames_developersRepository
    {
        void AddGames(Game game);
        Task<bool> GameExistsAsync(int id_game);
        void DeleteGames(Game game);
        Task<Game> GetGamersAsync(int id_game);
        Task<IEnumerable<Game>> GetGamesAsync();
        void UpdateGames(Game game);
        void AddGameDevelopers(int id_game, GamesDeveloper gameDeveloper);
        void DeleteGameDevelopers(GamesDeveloper gameDeveloper);
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        Task<GamesDeveloper> GetGameDevelopersAsync(int id_game, int id_developer);
        Task<IEnumerable<GamesDeveloper>> GetGameDeveloperAsync(int id_game);
        Task<bool> SaveAsync();
    }
}