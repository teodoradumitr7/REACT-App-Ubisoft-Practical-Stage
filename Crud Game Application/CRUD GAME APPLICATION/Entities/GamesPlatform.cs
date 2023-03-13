using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_GAME_APPLICATION.Entities
{
    public partial class GamesPlatform
    {
        public int IdGame { get; set; }
        public int IdPlatform { get; set; }

        public virtual Game IdGameNavigation { get; set; }
        public virtual Platform IdPlatformNavigation { get; set; }
    }
}
