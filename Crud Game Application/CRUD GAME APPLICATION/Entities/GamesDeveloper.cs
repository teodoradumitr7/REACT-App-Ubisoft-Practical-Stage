using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_GAME_APPLICATION.Entities
{
    public partial class GamesDeveloper
    {
        public int IdGame { get; set; }
        public int IdDeveloper { get; set; }
        public int WorkedHours { get; set; }

        public virtual Developer IdDeveloperNavigation { get; set; }
        public virtual Game IdGameNavigation { get; set; }
    }
}
