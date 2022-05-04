using System.Collections.Generic;


namespace VideogamesApi.Dtos
{
    public class EngineDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguage { get; set; }
        public long DevelopmentStudioId { get; set; }

        public DevelopmentStudioDto DevelopmentStudioDto { get; set; }


    }
}
