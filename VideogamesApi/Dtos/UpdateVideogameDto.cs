using System.Collections.Generic;

namespace VideogamesApi.Dtos
{
    public class UpdateVideogameDto
    {
        public string Name { get; set; }
        public string Mode { get; set; }
        public long EngineId { get; set; }
        public IList<long> DevelopmentStudioIds { get; set; }
        public IList<long> GenreIds { get; set; }
        public string ImgPath { get; set; }


    }
}
