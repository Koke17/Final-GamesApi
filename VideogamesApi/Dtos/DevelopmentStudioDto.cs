using System;

namespace VideogamesApi.Dtos
{
    public class DevelopmentStudioDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public int Employees { get; set; }
        public DateTime Foundation_Date { get; set; }
        public string ImgPath { get; set; }


    }
}
