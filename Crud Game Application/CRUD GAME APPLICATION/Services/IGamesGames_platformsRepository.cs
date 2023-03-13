using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public interface IGamesGames_platformsRepository
    {
        void AddGames(Game game);
        Task<bool> GameExistsAsync(int id_game);
        void DeleteGames(Game game);
        Task<Game> GetGamersAsync(int id_game);
        Task<IEnumerable<Game>> GetGamesAsync();
        void UpdateGames(Game game);
        void AddGamePlatform(int id_game, GamesPlatform gamePlatform);
        void DeleteGamePlatforms(GamesPlatform gamePlatform);
        Task<GamesPlatform> GetGamePlatformsAsync(int id_game, int id_platform);
        Task<IEnumerable<GamesPlatform>> GetGamePlatformAsync(int id_game);
        Task<bool> SaveAsync();
    }
}
