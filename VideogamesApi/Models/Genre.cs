using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class Genre
    {

        public Genre()
        {
            GenreVideogame = new HashSet<GenreVideogame>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GenreVideogame> GenreVideogame { get; set; }
    }
}
