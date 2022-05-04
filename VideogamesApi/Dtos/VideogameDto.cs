using System.Collections.Generic;

namespace VideogamesApi.Dtos
{
    public class VideogameDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mode { get; set; }
        public long EngineId { get; set; }
        public EngineDto EngineDto { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<DevelopmentStudio> DevelopmentStudios { get; set; }
    }

}
