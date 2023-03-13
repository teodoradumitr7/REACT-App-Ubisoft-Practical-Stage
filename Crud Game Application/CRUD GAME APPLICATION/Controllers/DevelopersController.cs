using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Services;
using CRUD_GAME_APPLICATION.Models;

namespace CRUD_GAME_APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopersGames_DevelopersRepository _developersGames_DevelopersRepository;

        public DevelopersController(IDevelopersGames_DevelopersRepository developersGames_DevelopersRepository)
        {
            _developersGames_DevelopersRepository = developersGames_DevelopersRepository;
        }

        [HttpGet("{id_developer}")]
        public async Task<IActionResult> GetDevelopersByGame(int id_developer)
        {
            if (!await _developersGames_DevelopersRepository.DeveloperExistsAsync(id_developer))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "Developer doesn't exists"
                };
                return NotFound(errResponse);
            }

            var developersFromRepo = await _developersGames_DevelopersRepository.GetDevelopersAsync(id_developer);

            return Ok(developersFromRepo);
        }

        [HttpGet("{id_game}/developer/{id_developer}")]
        public async Task<IActionResult> GetDevelopersByGame(int id_game, int id_developer)
        {
            if (!await _developersGames_DevelopersRepository.DeveloperExistsAsync(id_game))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "Developer doesn't exists"
                };
                return NotFound(errResponse);
            }

            var developersFromRepo = await _developersGames_DevelopersRepository.GetDevelopersGamesAsync(id_developer, id_game);

            if (developersFromRepo == null)
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = $"Id developer {id_developer} doesn't exists for Game id {id_game}"
                };
                return NotFound(errResponse);
            }

            return Ok(developersFromRepo);
        }
        [HttpGet]
        public async Task<IActionResult> GetDevelopers()
        {
            var developersFromRepo = await _developersGames_DevelopersRepository.GetDevelopersAsync();
            //in loc de foreach
            var developersFromDto = developersFromRepo.Select(x => new DevelopersDto { IdDeveloper = x.IdDeveloper, DeveloperName = x.DeveloperName });
            return Ok(developersFromRepo);
        }
    }
}
