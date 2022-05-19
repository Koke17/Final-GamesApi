using VideogamesApi.Dtos;

namespace VideogamesApi.Mapper
{
    public interface IModelFactory
    {
        public void UpdateVideogameFactory(Videogame dbVideogame, UpdateVideogameDto updateVideogameDto);
        public Videogame CreateVideogameFactory(CreateVideogameDto newVideogame);

        public void UpdateEngineFactory(Engine dbEngine, UpdateEngineDto updateEngineDto);
        public Engine CreateEngineFactory(CreateEngineDto newEngine);

        public void UpdateDevelopmentStudioFactory(DevelopmentStudio dbDebelopmentStudio, UpdateDevelopmentStudioDto updateDevelopmentStudio);
        public DevelopmentStudio CreateDevelopmentStudioFactory(CreateDevelopmentStudioDto newDevelopmentStudio);
        public void UpdateGenreFactory(Genre dbGenres, UpdateGenreDto updateGenreDto);

        public Genre CreateGenreFactory(CreateGenreDto newGenre);
    }
    public class ModelFactory : IModelFactory
    {
        public ModelFactory()
        {

        }

        public Videogame CreateVideogameFactory(CreateVideogameDto newVideogame)
        {
            return new Videogame
            {
                EngineId = newVideogame.EngineId,
                Mode = newVideogame.Mode,
                Name = newVideogame.Name
            };
        }

        public void UpdateVideogameFactory(Videogame dbVideogame, UpdateVideogameDto updateVideogameDto)
        {
            dbVideogame.Name = updateVideogameDto.Name;
            dbVideogame.Mode = updateVideogameDto.Mode;
            dbVideogame.EngineId = updateVideogameDto.EngineId;
        }

        public Engine CreateEngineFactory(CreateEngineDto  newEngine)
        {
            return new Engine
            {
                Name = newEngine.Name,
                ProgrammingLanguage = newEngine.ProgrammingLanguage,
                DevelopmentStudioId = newEngine.DevelopmentStudioId
            };
        }

        public void UpdateEngineFactory(Engine dbEngine, UpdateEngineDto updateEngineDto) 
        {
                dbEngine.Name = updateEngineDto.Name;
                dbEngine.ProgrammingLanguage = updateEngineDto.ProgrammingLanguage;
                dbEngine.DevelopmentStudioId = updateEngineDto.DevelopmentStudioId;
        } 
        
        public DevelopmentStudio CreateDevelopmentStudioFactory(CreateDevelopmentStudioDto newDevelopmentStudio)
        {
            return new DevelopmentStudio
            {
                Name = newDevelopmentStudio.Name,
                Employees = newDevelopmentStudio.Employees,
                FoundationDate = newDevelopmentStudio.FoundationDate
            };
        }

        public void UpdateDevelopmentStudioFactory(DevelopmentStudio dbDevelopmentStudio, UpdateDevelopmentStudioDto updateDevelopmentStudioDto)
        {
            dbDevelopmentStudio.Name = updateDevelopmentStudioDto.Name;
            dbDevelopmentStudio.Employees = updateDevelopmentStudioDto.Employees;
            dbDevelopmentStudio.FoundationDate = updateDevelopmentStudioDto.FoundationDate;
        }

        public void UpdateGenreFactory(Genre dbGenre, UpdateGenreDto updateGenreDto)
        {
            dbGenre.Name = updateGenreDto.Name;
        }

        public Genre CreateGenreFactory(CreateGenreDto newGenre)
        {
            return new Genre
            {
                Name = newGenre.Name
            };
        }
        
    }
}
