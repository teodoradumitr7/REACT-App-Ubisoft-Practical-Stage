using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_GAME_APPLICATION.Entities
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public int IdGame { get; set; }

        public virtual Game IdGameNavigation { get; set; }
    }
}
