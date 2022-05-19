using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VideogamesApi.Dtos;
using VideogamesApi.Mapper;
using VideogamesApi.Models;

namespace VideogamesApi.Services
{

    public interface IGenresService
    {
        Task<IOperationResult> GetAll();
        Task<IOperationResult> Get(long id);
        Task<IOperationResult> Update(long id, UpdateGenreDto updateGenresDto);
        Task<IOperationResult> Create(CreateGenreDto newGenreDto);
        Task<IOperationResult> Delete(long id);
        Task<IOperationResult> Search(string name);
    }

    public class GenresService : IGenresService
    {
        private readonly GamesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IModelFactory _modelFactory;

        public GenresService(GamesDbContext context, IMapper mapper, IModelFactory modelFactory)
        {
            _context = context;
            _mapper = mapper;
            _modelFactory = modelFactory;
        }

        public async Task<IOperationResult> GetAll()
        {
            try
            {
                // TODO: LOG THE CALL WITH A LOGGER
                var Genres = await _context.Genres.AsQueryable()
                    .ToListAsync(CancellationToken.None);

                var GenreDtos = _mapper.Map<List<GenreDto>>(Genres);


                return OperationResult.Success(GenreDtos);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Get(long id)
        {
            try
            {
                // TODO: LOG THE CALL WITH A LOGGER
                var GenreDto = await _context.Genres
                    .Where(v => v.Id == id)
                    .Select(v => _mapper.Map<GenreDto>(v))
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (GenreDto == null) return OperationResult.NotFound();

                return OperationResult.Success(GenreDto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IOperationResult> Update(long id, UpdateGenreDto updateGenreDto)
        {

            try
            {
                var dbGenres = await _context.Genres
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync();

                if (dbGenres == null) return OperationResult.NotFound();
                _modelFactory.UpdateGenreFactory(dbGenres, updateGenreDto);
                _context.Genres.Update(dbGenres);
                _context.SaveChanges();

                return OperationResult.Success();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Create(CreateGenreDto newGenre)
        {
            try
            {
                var Genre = _modelFactory.CreateGenreFactory(newGenre);
                _context.Genres.Add(Genre);
                _context.SaveChanges();


                return OperationResult.Success();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Delete(long id)
        {
            try
            {

                var Genre = await _context.Genres
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (Genre == null) return OperationResult.NotFound();

                _context.Genres.Remove(Genre);
                _context.SaveChanges();


                return OperationResult.Success();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Search(string name)
        {
            try
            {
                var searchGenres = await _context.Genres
                    .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                    .ToListAsync(CancellationToken.None);

                return OperationResult.Success(searchGenres);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
