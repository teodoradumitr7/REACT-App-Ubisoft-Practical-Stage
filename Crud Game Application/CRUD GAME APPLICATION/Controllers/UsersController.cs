using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Services;
using CRUD_GAME_APPLICATION.Models;
using CRUD_GAME_APPLICATION.Entities;

namespace CRUD_GAME_APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGamesUsersRepository _gamesUsersRepository;

        public UsersController(IGamesUsersRepository gamesUsersRepository)
        {
            _gamesUsersRepository = gamesUsersRepository;
        }


        [HttpGet("{id_user}")]
        public async Task<IActionResult> GetUsersByGame(int id_user)
        {
           if (!await _gamesUsersRepository.UserExistsAsync(id_user))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "User doesn't exists"
                };
                return NotFound(errResponse);
            }

            var usersFromRepo = await _gamesUsersRepository.GetUsersAsync(id_user);

            return Ok(usersFromRepo);
        }

       [HttpGet("{id_user}/game/{id_game}")]
          public async Task<IActionResult> GetUsersByGame(int id_game, int id_user)
        {
            if (!await _gamesUsersRepository.UserExistsAsync(id_game))
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = "User doesn't exists"
                };
                return NotFound(errResponse);
            }

            var usersFromRepo = await _gamesUsersRepository.GetUsersAsync(id_user, id_game);

            if (usersFromRepo == null)
            {
                ErrResponse errResponse = new ErrResponse()
                {
                    HttpCode = 404,
                    Error = $"Id user {id_user} doesn't exists for Game id {id_game}"
                };
                return NotFound(errResponse);
            }

            return Ok(usersFromRepo);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            _gamesUsersRepository.AddUser(user);
            await _gamesUsersRepository.SaveAsync();

            var userResponse = new UserDto()
            {
                id_user= user.IdUser,
                username = user.Username,
                id_game = user.IdGame
             
            };

            return CreatedAtRoute("GetUser",
                new { id_user = userResponse.id_user },
                userResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersFromRepo = await _gamesUsersRepository.GetUsersAsync();

            List<UserDto> usersDto = new List<UserDto>();

            foreach (var user in usersFromRepo)
            {
                usersDto.Add(new UserDto()
                {
           
                    id_user = user.IdUser,
                    username = user.Username,
                    id_game = user.IdGame,
                    game_name=user.IdGameNavigation.GameName

                });
            }
            return Ok(usersDto);
        }



    }

    public class ErrResponse
    {
        public int HttpCode { get; set; }
        public string Error { get; set; }
    }
}

