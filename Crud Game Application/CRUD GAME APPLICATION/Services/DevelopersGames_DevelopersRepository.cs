using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_GAME_APPLICATION.Data;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public class DevelopersGames_DevelopersRepository : IDevelopersGames_DevelopersRepository
    {
        private readonly GamesContext _context;
        public DevelopersGames_DevelopersRepository(GamesContext developersContext)
        {
            _context = developersContext;
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

        public void AddGameDevelopers(Developer developers)
        {
            if (developers == null)
            {
                throw new ArgumentNullException(nameof(developers));
            }

            _context.Developers.Add(developers);
        }

        public void DeleteGameDevelopers(GamesDeveloper gameDeveloper)
        {
            if (gameDeveloper == null)
            {
                throw new ArgumentNullException(nameof(gameDeveloper));
            }

            _context.GamesDevelopers.Remove(gameDeveloper);
        }

        public void DeleteDeveloper(Developer developers)
        {
            if (developers == null)
            {
                throw new ArgumentNullException(nameof(developers));
            }

            _context.Developers.Remove(developers);
        }

        public async Task<bool> DeveloperExistsAsync(int id_developer)
        {
            return await _context.Developers.AnyAsync(a => a.IdDeveloper == id_developer);
        }


        public async Task<IEnumerable<GamesDeveloper>> GetDevelopersGamesAsync(int id_developer)
        {
            return await _context.GamesDevelopers
            .Where(c => c.IdDeveloper == id_developer)
            .OrderBy(c => c.IdDeveloper).ToListAsync();
        }

        public async Task<GamesDeveloper> GetDevelopersGamesAsync(int id_developer, int id_game)
        {
            return await _context.GamesDevelopers
                .Where(c => c.IdDeveloper == id_developer && c.IdGame == id_game).FirstOrDefaultAsync();
        }

        public async Task<Developer> GetDevelopersAsync(int id_developer)
        {
            return await _context.Developers.FirstOrDefaultAsync(a => a.IdDeveloper == id_developer);
        }

        public async Task<IEnumerable<Developer>> GetDevelopersAsync()
        {
            return await _context.Developers.ToListAsync<Developer>();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateDevelopers(Developer developers)
        {
            _context.Developers.Update(developers);
        }
    }
}
