using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_GAME_APPLICATION.Entities
{
    public partial class Game
    {
        public Game()
        {
            GamesDevelopers = new HashSet<GamesDeveloper>();
            GamesPlatforms = new HashSet<GamesPlatform>();
            Users = new HashSet<User>();
        }

        public int IdGame { get; set; }
        public string GameName { get; set; }
        public string Edition { get; set; }
        public float? Storage { get; set; }
        public DateTime LaunchDate { get; set; }
        public bool? Multiplayer { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<GamesDeveloper> GamesDevelopers { get; set; }
        public virtual ICollection<GamesPlatform> GamesPlatforms { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
