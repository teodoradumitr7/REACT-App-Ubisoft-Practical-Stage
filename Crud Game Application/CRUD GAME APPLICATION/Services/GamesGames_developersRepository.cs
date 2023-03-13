using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_GAME_APPLICATION.Data;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public class GamesGames_developersRepository : IGamesGames_developersRepository
    {
        private readonly GamesContext _context;
        public GamesGames_developersRepository(GamesContext gamesContext)
        {
            _context = gamesContext;
        }

        public void AddGameDevelopers(int id_game, GamesDeveloper gameDeveloper)
        {
            if (gameDeveloper == null)
            {
                throw new ArgumentNullException(nameof(gameDeveloper));
            }
            gameDeveloper.IdGame = id_game;
            _context.GamesDevelopers.Add(gameDeveloper);
        }

        public void AddGames(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Games.Add(game);
        }

        public void DeleteGameDevelopers(GamesDeveloper gameDeveloper)
        {
            if (gameDeveloper == null)
            {
                throw new ArgumentNullException(nameof(gameDeveloper));
            }

            _context.GamesDevelopers.Remove(gameDeveloper);
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

        public async Task<IEnumerable<GamesDeveloper>> GetGameDeveloperAsync(int id_game)
        {
            return await _context.GamesDevelopers
            .Where(c => c.IdGame == id_game)
            .OrderBy(c => c.IdDeveloper).ToListAsync();
        }

        public async Task<GamesDeveloper> GetGameDevelopersAsync(int id_game, int id_developer)
        {
            return await _context.GamesDevelopers
                .Where(c => c.IdGame == id_game && c.IdDeveloper== id_developer).FirstOrDefaultAsync();
        }

        public async Task<Game> GetGamersAsync(int id_game)
        {
            return await _context.Games.FirstOrDefaultAsync(a => a.IdGame== id_game);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
        public async Task<IEnumerable<Developer>> GetDevelopersAsync()
        {
            return await _context.Developers.ToListAsync<Developer>();
        }
        public void UpdateGames(Game game)
        {
            _context.Games.Update(game);
        }

    }
}
