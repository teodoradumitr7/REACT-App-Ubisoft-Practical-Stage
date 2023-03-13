using CRUD_GAME_APPLICATION.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_GAME_APPLICATION.Models
{
    public class GameDto
    {
        public int id_game { get; set; }
        public string game_name { get; set; }
        public string edition { get; set; }
        public float? storage { get; set; } 
        public DateTime launch_date { get; set; }
        public bool? multiplayer { get; set; }
        public string genre { get; set; }

        public IList<string> developersNames { get; set; }
        public IList<string> platformNames{ get; set; }

        
    }
}
