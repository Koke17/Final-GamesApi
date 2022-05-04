using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class Videogame
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mode { get; set; }
        public long EngineId { get; set; }

        public virtual Engine Engine { get; set; }
    }
}
