using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class Videogame
    {

        public Videogame () 
        {
            GenreVideogame = new HashSet<GenreVideogame>();
            DevelopmentStudioVideogame = new HashSet<DevelopmentStudioVideogame>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mode { get; set; }
        public long EngineId { get; set; }

        public virtual Engine Engine { get; set; }

        public ICollection<GenreVideogame> GenreVideogame { get; set; }
        public ICollection<DevelopmentStudioVideogame> DevelopmentStudioVideogame { get; set; }

        public string ImgPath { get; set; }
    }
}
