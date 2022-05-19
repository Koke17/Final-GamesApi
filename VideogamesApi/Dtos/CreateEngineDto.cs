using System.Collections.Generic;

namespace VideogamesApi.Dtos
{
    public class CreateEngineDto
    {
        public string Name { get; set; }
        public string ProgrammingLanguage { get; set; }
        public long DevelopmentStudioId { get; set; }

    }
}
