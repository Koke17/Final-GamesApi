using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class DevelopmentStudioVideogame
    {
        public long DevelopmentStudioId { get; set; }
        public long VideogameId { get; set; }

        public virtual DevelopmentStudio DevelopmentStudio { get; set; }
        public virtual Videogame Videogame { get; set; }
    }
}
