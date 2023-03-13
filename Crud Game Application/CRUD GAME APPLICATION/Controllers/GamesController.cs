using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Entities;
using CRUD_GAME_APPLICATION.Models;
using CRUD_GAME_APPLICATION.Services;

namespace CRUD_GAME_APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesUsersRepository _gamesUsersRepository;


        public GamesController(IGamesUsersRepository gamesUsersRepository)
        {
            _gamesUsersRepository = gamesUsersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var gamesFromRepo = await _gamesUsersRepository.GetGameAsync();

            List<GameDto> gamesDto = new List<GameDto>();

            foreach (var game in gamesFromRepo)
            {
                gamesDto.Add(new GameDto()
                {
                    id_game = game.IdGame,
                    game_name = game.GameName,
                    edition=game.Edition,
                    storage=game.Storage,
                    launch_date=game.LaunchDate,
                    multiplayer=game.Multiplayer,
                    genre=game.Genre
                    });
            }

            return Ok(gamesDto);
        }

        
        [HttpGet("{id_game}", Name = "GetGame")]
        public async Task<IActionResult> GetGame(int id_game)
        {
            var gameFromRepo = await _gamesUsersRepository.GetGameAsync(id_game);

            if (gameFromRepo == null)
                return NotFound();

            var game = new GameDto()
            {

                id_game = gameFromRepo.IdGame,
                game_name = gameFromRepo.GameName,
                edition = gameFromRepo.Edition,
                storage = gameFromRepo.Storage,
                launch_date = gameFromRepo.LaunchDate,
                multiplayer = gameFromRepo.Multiplayer,
                genre = gameFromRepo.Genre,
                developersNames = gameFromRepo.GamesDevelopers.Select(x=> x.IdDeveloperNavigation.DeveloperName).ToList(),
                platformNames = gameFromRepo.GamesPlatforms.Select(x =>x.IdPlatformNavigation.PlatformName).ToList()
            };

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult> AddGame(Game game)
        {
            _gamesUsersRepository.AddGame(game);
            await _gamesUsersRepository.SaveAsync();

            var gameResponse = new GameDto()
            {
                id_game = game.IdGame,
                game_name = game.GameName,
                edition = game.Edition,
                storage = game.Storage,
                launch_date = game.LaunchDate,
                multiplayer = game.Multiplayer,
                genre = game.Genre
            };

            return CreatedAtRoute("GetGame",
                new { id_game = gameResponse.id_game },
                gameResponse);
        }

        [HttpPut("{id_game}")]
        public async Task<ActionResult> UpdateGame(int id_game, Game game)
        {
            if (!await _gamesUsersRepository.GameExistsAsync(id_game))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "Game doesn't exists"
                };
                return NotFound(errResponse);
            }
            game.IdGame = id_game;
            _gamesUsersRepository.UpdateGame(game);
            await _gamesUsersRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id_game}")]
        public async Task<ActionResult> Delete(int id_game)
        {
            var gameFromRepo = await _gamesUsersRepository.GetGameAsync(id_game);

            if (gameFromRepo == null)
                return NotFound();

            _gamesUsersRepository.DeleteGame(gameFromRepo);
            await _gamesUsersRepository.SaveAsync();

            return NoContent();
        }


    }

}
