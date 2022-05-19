using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class GenreVideogame
    {

        public long VideogameId { get; set; }
        public long GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Videogame Videogame { get; set; }

        
    }
}
