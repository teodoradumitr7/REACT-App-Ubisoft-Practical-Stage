using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public interface IPlatformsGames_PlatformsRepository
    {
        void AddPlatforms(Platform platforms);
        Task<bool> PlatformExistsAsync(int id_platform);
        void DeletePlatforms(Platform platforms);
        Task<Platform> GetPlatformsAsync(int id_platform);
        Task<IEnumerable<Platform>> GetPlatformsAsync();
        void UpdatePlatforms(Platform platforms);
        void AddGamePlatform(int id_game, GamesPlatform gamePlatform);
        void DeleteGamePlatforms(GamesPlatform gamePlatform);
        Task<GamesPlatform> GetPlatformGamesAsync(int id_platform, int id_game);
        Task<IEnumerable<GamesPlatform>> GetPlatformGamesAsync(int id_platform);
        Task<bool> SaveAsync();
        
    }
}
