using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{
    public interface IGamesUsersRepository
    {
        void AddUser(User user);
        Task<bool> UserExistsAsync(int id_user);
       Task<bool> GameExistsAsync(int id_game);
        void DeleteGame(Game games);
        Task<Game> GetGameAsync(int id_game);
        Task<IEnumerable<Game>> GetGameAsync();
        void UpdateGame(Game games);
        void AddUser(int id_game, User user);
        void DeleteUser(User users);
        Task<User> GetUsersAsync(int id_user, int id_game);
        Task<IEnumerable<User>> GetUsersAsync(int id_user);
        Task<bool> SaveAsync();
        void AddGame(Game game);
        Task<IEnumerable<User>> GetUsersAsync();

    }
}
