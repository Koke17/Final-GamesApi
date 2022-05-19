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
    public interface IVideogamesService
    {
        Task<IOperationResult> GetAll();
        Task<IOperationResult> Get(long id);
        Task<IOperationResult> Update(long id, UpdateVideogameDto updateVideogameDto);
        Task<IOperationResult> Create(CreateVideogameDto newVideogame);
        Task<IOperationResult> Delete(long id);
        Task<IOperationResult> Search(string name);

    }

    public class VideogamesService : IVideogamesService
    {
        private readonly GamesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IModelFactory _modelFactory;

        public VideogamesService(GamesDbContext context, IMapper mapper, IModelFactory modelFactory)
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
                var videogames = await _context.Videogames.AsQueryable()
                    .Include(r => r.Engine)
                    .ToListAsync(CancellationToken.None);
                var videogameDtos = _mapper.Map<List<VideogameDto>>(videogames);
                foreach (var videogameDto in videogameDtos)
                {
                    await ApplyAdditionalData(videogameDto);
                }
                return OperationResult.Success(videogameDtos);
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
                var videogameDto = await _context.Videogames
                    .Where(v => v.Id == id)
                    .Include(v => v.Engine)
                    .Include(v => v.DevelopmentStudioVideogame)
                    .Include(v => v.GenreVideogame)
                    .Select(v => _mapper.Map<VideogameDto>(v))
                    .FirstOrDefaultAsync(CancellationToken.None);
                if (videogameDto == null) return OperationResult.NotFound();
                //await ApplyAdditionalData(videogameDto);
                return OperationResult.Success(videogameDto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Update(long id, UpdateVideogameDto updateVideogameDto) {

            try
            {
                var dbVideogame = await _context.Videogames
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync();

                if (dbVideogame == null) return OperationResult.NotFound();
                _modelFactory.UpdateVideogameFactory(dbVideogame, updateVideogameDto);
                _context.Videogames.Update(dbVideogame);
                await UpdateVideogameData(id, updateVideogameDto);
                _context.SaveChanges();
                return OperationResult.Success();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateVideogameData(long id, UpdateVideogameDto updateVideogameDto)
        {
            var dbGenreVideogames = await _context.GenreVideogames.Where(gv => gv.VideogameId == id).ToListAsync(CancellationToken.None);
            dbGenreVideogames.ForEach(gv => _context.GenreVideogames.Remove(gv));
            foreach (var genreId in updateVideogameDto.GenreIds)
            {
                _context.GenreVideogames.Add(new GenreVideogame
                {
                    GenreId = genreId,
                    VideogameId = id
                });
            }
            _context.SaveChanges();

            var dbDevelopmentStudioVideogames = await _context.DevelopmentStudioVideogames.Where(gv => gv.VideogameId == id).ToListAsync(CancellationToken.None);
            dbDevelopmentStudioVideogames.ForEach(dv => _context.DevelopmentStudioVideogames.Remove(dv));
            foreach (var developerId in updateVideogameDto.DevelopmentStudioIds)
            {
                _context.DevelopmentStudioVideogames.Add(new DevelopmentStudioVideogame
                {
                    DevelopmentStudioId = developerId,
                    VideogameId = id
                });
            }
            _context.SaveChanges();
        }

        public async Task<IOperationResult> Create(CreateVideogameDto newVideogame)
        {
            try{
                var videogame = _modelFactory.CreateVideogameFactory(newVideogame);
                _context.Videogames.Add(videogame);
                _context.SaveChanges();
                if (newVideogame.DeveloperIds != null)
                {
                    foreach (var developerId in newVideogame.DeveloperIds)
                    {
                        _context.DevelopmentStudioVideogames.Add(new DevelopmentStudioVideogame
                        {
                            DevelopmentStudioId = developerId,
                            VideogameId = videogame.Id
                        });
                    }
                }
                if (newVideogame.GenreIds != null)
                {
                    foreach (var genreId in newVideogame.GenreIds)
                    {
                        _context.GenreVideogames.Add(new GenreVideogame
                        {
                            GenreId = genreId,
                            VideogameId = videogame.Id
                        });
                    }
                }


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

                var videogame = await _context.Videogames
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (videogame == null) return OperationResult.NotFound();

                 _context.Videogames.Remove(videogame);
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
                var searchVideogames = await _context.Videogames
                    .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                    .ToListAsync(CancellationToken.None);

                return OperationResult.Success(searchVideogames);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private async Task ApplyAdditionalData(VideogameDto videogameDto)
        {
            //videogamedto.developmentstudios = await _context.developmentstudios
            //    .where(d => _context.developmentstudiovideogames
            //        .where(dv => dv.videogameid == videogamedto.id)
            //        .select(dv => dv.developmentstudioid)
            //        .tolist()
            //        .contains(d.id))
            //    .tolistasync(cancellationtoken.none);
            //videogamedto.genres = await _context.genres
            //    .where(g => _context.genrevideogames
            //        .where(gv => gv.videogameid == videogamedto.id)
            //        .select(gv => gv.genreid)
            //        .tolist()
            //        .contains(g.id))
            //    .tolistasync(cancellationtoken.none);
        }

       
    }
}
