using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_GAME_APPLICATION.Entities
{
    public partial class Platform
    {
        public Platform()
        {
            GamesPlatforms = new HashSet<GamesPlatform>();
        }

        public int IdPlatform { get; set; }
        public string PlatformName { get; set; }

        public virtual ICollection<GamesPlatform> GamesPlatforms { get; set; }
    }
}
