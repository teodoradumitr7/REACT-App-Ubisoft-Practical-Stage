using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_GAME_APPLICATION.Entities
{
    public partial class Developer
    {
        public Developer()
        {
            GamesDevelopers = new HashSet<GamesDeveloper>();
        }

        public int IdDeveloper { get; set; }
        public string DeveloperName { get; set; }

        public virtual ICollection<GamesDeveloper> GamesDevelopers { get; set; }
    }
}
