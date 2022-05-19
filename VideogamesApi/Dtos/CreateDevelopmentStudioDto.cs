using System;


namespace VideogamesApi.Dtos
{
    public class CreateDevelopmentStudioDto
    {

        public string Name { get; set; }
        public int Employees { get; set; }
        public DateTime FoundationDate { get; set; }

    }
}
