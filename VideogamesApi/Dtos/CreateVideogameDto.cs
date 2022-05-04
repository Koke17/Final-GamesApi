using System.Collections.Generic;

namespace VideogamesApi.Dtos
{
    public class CreateVideogameDto
    {
        public string VideogameName { get; set; }
        public string Mode { get; set; }
        public long EngineId { get; set; }
        public IList<long> GenreIds { get; set; }
        public IList<long> DeveloperIds { get; set; }
    }
}
