using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;
using CRUD_GAME_APPLICATION.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_GAME_APPLICATION.Services
{

        public class GamesUsersRepository : IGamesUsersRepository
        {
            private readonly GamesContext _context;
            public GamesUsersRepository(GamesContext gamesContext)
            {
                _context = gamesContext;
            }
            public void AddUser(User user)
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                _context.Users.Add(user);
            }
        public void AddGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            _context.Games.Add(game);
        }

        public void AddUser(int id_game, User user)
            {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

            public void DeleteGame(Game games)
            {
                if (games == null)
                {
                    throw new ArgumentNullException(nameof(games));
                }
                _context.Games.Remove(games);
            }

            public void DeleteUser(User users)
            {
                _context.Users.Remove(users);
            }

            public async Task<bool> UserExistsAsync(int id_user)
            {
                return await _context.Users.AnyAsync(a => a.IdUser == id_user);
            }
        public async Task<bool> GameExistsAsync(int id_game)
        {
            return await _context.Games.AnyAsync(a => a.IdGame == id_game);
        }

        public async Task<Game> GetGameAsync(int id_game)
            {
                return await _context.Games
                            .Include(x => x.GamesDevelopers).ThenInclude(x => x.IdDeveloperNavigation)
                            .Include(y=> y.GamesPlatforms).ThenInclude(x =>x.IdPlatformNavigation)
                            .FirstOrDefaultAsync(a => a.IdGame == id_game);
            }

            public async Task<IEnumerable<Game>> GetGameAsync()
            {
                return await _context.Games.ToListAsync<Game>();
            }

            public async Task<User> GetUsersAsync(int id_user, int id_game)
            {
                return await _context.Users
                    .Where(c => c.IdUser == id_user && c.IdGame == id_game).FirstOrDefaultAsync();

            }

            public async Task<IEnumerable<User>> GetUsersAsync(int id_user)
            {
                return await _context.Users
                  .Where(c => c.IdUser == id_user)
                  .OrderBy(c => c.Username).ToListAsync();
            }

            public async Task<bool> SaveAsync()
            {
                return await _context.SaveChangesAsync() >= 0;
            }

            public void UpdateGame(Game games)
            {
                _context.Games.Update(games);
            }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Include(u=>u.IdGameNavigation).ToListAsync();
        }
        public async Task<IEnumerable<Platform>> GetPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync<Platform>();
        }
    }
    }
