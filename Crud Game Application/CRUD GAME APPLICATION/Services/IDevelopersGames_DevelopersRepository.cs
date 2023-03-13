using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Services
{ 
    public interface IDevelopersGames_DevelopersRepository
    {
        void AddGameDevelopers(Developer developers);
        Task<bool> DeveloperExistsAsync(int id_developer);
        void DeleteDeveloper(Developer developer);
        Task<Developer> GetDevelopersAsync(int id_developers);
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        void UpdateDevelopers(Developer developers);
        void AddGameDevelopers(int id_game, GamesDeveloper gameDevelopers);
        void DeleteGameDevelopers(GamesDeveloper gameDevelopers);
        Task<GamesDeveloper> GetDevelopersGamesAsync(int id_developers, int id_game);
        Task<IEnumerable<GamesDeveloper>> GetDevelopersGamesAsync(int id_developers);
        Task<bool> SaveAsync();


    }
}
