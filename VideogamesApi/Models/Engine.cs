using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class Engine
    {

        public Engine()
        {
            Videogames = new HashSet<Videogame>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguage { get; set; }
        public long DevelopmentStudioId { get; set; }

        public virtual DevelopmentStudio DevelopmentStudio { get; set; }

        public virtual ICollection<Videogame> Videogames { get; set; }

    }
}
