using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Services;
using CRUD_GAME_APPLICATION.Entities;
using CRUD_GAME_APPLICATION.Models;

namespace CRUD_GAME_APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformsGames_PlatformsRepository _gamesPlatformsRepository;

        public PlatformsController(IPlatformsGames_PlatformsRepository gamesPlatformsRepository)
        {
            _gamesPlatformsRepository = gamesPlatformsRepository;
        }

        [HttpGet("{id_platform}")]
        public async Task<IActionResult> GetPlatformsByGame(int id_platform)
        {
            if (!await _gamesPlatformsRepository.PlatformExistsAsync(id_platform))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "Platform doesn't exists"
                };
                return NotFound(errResponse);
            }

            var platformsFromRepo = await _gamesPlatformsRepository.GetPlatformsAsync(id_platform);

            return Ok(platformsFromRepo);
        }

        [HttpGet("{id_game}/platform/{id_platform}")]
        public async Task<IActionResult> GetPlatformsByGame(int id_game, int id_platform)
        {
            if (!await _gamesPlatformsRepository.PlatformExistsAsync(id_platform))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "Game doesn't exists"
                };
                return NotFound(errResponse);
            }

            var platformsFromRepo = await _gamesPlatformsRepository.GetPlatformGamesAsync(id_platform, id_game);

            if (platformsFromRepo == null)
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = $"Id platform {id_platform} doesn't exists for Game id {id_game}"
                };
                return NotFound(errResponse);
            }

            return Ok(platformsFromRepo);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            var platformsFromRepo = await _gamesPlatformsRepository.GetPlatformsAsync();
            //in loc de foreach
            var platformsFromDto = platformsFromRepo.Select(x => new PlatformDto { IdPlatform = x.IdPlatform, PlatformName = x.PlatformName });
            return Ok(platformsFromDto);
        }
    }
}

