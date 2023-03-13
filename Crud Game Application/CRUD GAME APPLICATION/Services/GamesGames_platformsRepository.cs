using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_GAME_APPLICATION.Data;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public class GamesGames_platformsRepository: IGamesGames_platformsRepository
    {
        private readonly GamesContext _context;
        public GamesGames_platformsRepository(GamesContext gamesContext)
        {
            _context = gamesContext;
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

        public void AddGames(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Games.Add(game);
        }

        public void DeleteGamePlatforms(GamesPlatform gamePlatform)
        {
            if (gamePlatform == null)
            {
                throw new ArgumentNullException(nameof(gamePlatform));
            }

            _context.GamesPlatforms.Remove(gamePlatform);
        }

        public void DeleteGames(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Games.Remove(game);
        }

        public async Task<bool> GameExistsAsync(int id_game)
        {
            return await _context.Games.AnyAsync(a => a.IdGame == id_game);
        }

        public async Task<IEnumerable<GamesPlatform>> GetGamePlatformAsync(int id_game)
        {
            return await _context.GamesPlatforms
            .Where(c => c.IdGame == id_game)
            .OrderBy(c => c.IdPlatform).ToListAsync();
        }

        public async Task<GamesPlatform> GetGamePlatformsAsync(int id_game, int id_platform)
        {
            return await _context.GamesPlatforms
                .Where(c => c.IdGame== id_game && c.IdPlatform == id_platform).FirstOrDefaultAsync();
        }

        public async Task<Game> GetGamersAsync(int id_game)
        {
            return await _context.Games.FirstOrDefaultAsync(a => a.IdGame == id_game);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync<Game>();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateGames(Game game)
        {
            _context.Games.Update(game);
        }

    }
}
