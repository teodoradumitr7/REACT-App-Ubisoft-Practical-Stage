using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_GAME_APPLICATION.Models
{
    public class UserDto
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public int id_game { get; set; }
        public string game_name { get; set; }
    }
}