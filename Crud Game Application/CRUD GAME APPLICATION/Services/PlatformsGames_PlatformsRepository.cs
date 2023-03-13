using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_GAME_APPLICATION.Data;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public class PlatformsGames_PlatformsRepository: IPlatformsGames_PlatformsRepository
    {
        private readonly GamesContext _context;
        public PlatformsGames_PlatformsRepository(GamesContext platformsContext)
        {
            _context = platformsContext;
        }

        public void AddGamePlatform(int id_game, GamesPlatform gamePlatform)
        {
            if (gamePlatform == null)
            {
                throw new ArgumentNullException(nameof(gamePlatform));
            }
            gamePlatform.IdGame = id_game;
            _context.GamesPlatforms.Add(gamePlatform);
        }

        public void AddPlatforms(Platform platforms)
        {
            if (platforms == null)
            {
                throw new ArgumentNullException(nameof(platforms));
            }

            _context.Platforms.Add(platforms);
        }

        public void DeleteGamePlatforms(GamesPlatform gamePlatform)
        {
            if (gamePlatform == null)
            {
                throw new ArgumentNullException(nameof(gamePlatform));
            }

            _context.GamesPlatforms.Remove(gamePlatform);
        }

        public void DeletePlatforms(Platform platforms)
        {
            if (platforms == null)
            {
                throw new ArgumentNullException(nameof(platforms));
            }

            _context.Platforms.Remove(platforms);
        }

        public async Task<bool> PlatformExistsAsync(int id_platform)
        {
            return await _context.Platforms.AnyAsync(a => a.IdPlatform == id_platform);
        }


        public async Task<IEnumerable<GamesPlatform>> GetPlatformGamesAsync(int id_platform)
        {
            return await _context.GamesPlatforms
            .Where(c => c.IdPlatform == id_platform)
            .OrderBy(c => c.IdPlatform).ToListAsync();
        }

        public async Task<GamesPlatform> GetPlatformGamesAsync(int id_platform, int id_game)
        {
            return await _context.GamesPlatforms
                .Where(c => c.IdPlatform == id_platform && c.IdGame == id_game).FirstOrDefaultAsync();
        }

        public async Task<Platform> GetPlatformsAsync(int id_platform)
        {
            return await _context.Platforms.FirstOrDefaultAsync(a => a.IdPlatform == id_platform);
        }

        public async Task<IEnumerable<Platform>> GetPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync<Platform>();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdatePlatforms(Platform platforms)
        {
            _context.Platforms.Update(platforms);
        }

       
    }
}
