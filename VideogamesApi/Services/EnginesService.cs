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

    public interface IEnginesService
    {
        Task<IOperationResult> GetAll();
        Task<IOperationResult> Get(long id);
        Task<IOperationResult> Update(long id, UpdateEngineDto updateEngineDto);
        Task<IOperationResult> Create(CreateEngineDto newEngineDto);
        Task<IOperationResult> Delete(long id);
    }

    public class EnginesService : IEnginesService
    {
        private readonly GamesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IModelFactory _modelFactory;

        public EnginesService(GamesDbContext context, IMapper mapper, IModelFactory modelFactory)
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
                var engines = await _context.Engines.AsQueryable()
                    .Include(r => r.DevelopmentStudio)
                    .ToListAsync(CancellationToken.None);
                var engineDtos = _mapper.Map<List<EngineDto>>(engines);
                

                return OperationResult.Success(engineDtos);
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
                var engineDto = await _context.Engines
                    .Where(v => v.Id == id)
                    .Include(v => v.DevelopmentStudio)
                    .Select(v => _mapper.Map<EngineDto>(v))
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (engineDto == null) return OperationResult.NotFound();
                
                return OperationResult.Success(engineDto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IOperationResult> Update(long id, UpdateEngineDto updateEngineDto)
        {

            try
            {
                var dbEngine = await _context.Engines
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync();

                if (dbEngine == null) return OperationResult.NotFound();
                _modelFactory.UpdateEngineFactory(dbEngine, updateEngineDto);
                _context.Engines.Update(dbEngine);
                _context.SaveChanges();
                
                return OperationResult.Success();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Create(CreateEngineDto newEngine)
        {
            try
            {
                var engine = _modelFactory.CreateEngineFactory(newEngine);
                _context.Engines.Add(engine);
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

                var engine = await _context.Engines
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (engine == null) return OperationResult.NotFound();

                _context.Engines.Remove(engine);
                _context.SaveChanges();


                return OperationResult.Success();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }




    }
}
