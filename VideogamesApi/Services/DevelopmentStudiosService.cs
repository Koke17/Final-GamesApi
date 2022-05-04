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

    public interface IDevelopmentStudiosService
    {
        Task<IOperationResult> GetAll();
        Task<IOperationResult> Get(long id);
        Task<IOperationResult> Update(long id, UpdateDevelopmentStudioDto updateDevelopmentStudiosDto);
        Task<IOperationResult> Create(CreateDevelopmentStudioDto newDevelopmentStudioDto);
        Task<IOperationResult> Delete(long id);
    }

    public class DevelopmentStudiosService : IDevelopmentStudiosService
    {
        private readonly GamesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IModelFactory _modelFactory;

        public DevelopmentStudiosService(GamesDbContext context, IMapper mapper, IModelFactory modelFactory)
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
                var DevelopmentStudios = await _context.DevelopmentStudios.AsQueryable()
                    .ToListAsync(CancellationToken.None);

                var DevelopmentStudioDtos = _mapper.Map<List<DevelopmentStudioDto>>(DevelopmentStudios);


                return OperationResult.Success(DevelopmentStudioDtos);
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
                var DevelopmentStudioDto = await _context.DevelopmentStudios
                    .Where(v => v.Id == id)
                    .Select(v => _mapper.Map<DevelopmentStudioDto>(v))
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (DevelopmentStudioDto == null) return OperationResult.NotFound();

                return OperationResult.Success(DevelopmentStudioDto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IOperationResult> Update(long id, UpdateDevelopmentStudioDto updateDevelopmentStudioDto)
        {

            try
            {
                var dbDevelopmentStudios = await _context.DevelopmentStudios
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync();

                if (dbDevelopmentStudios == null) return OperationResult.NotFound();
                _modelFactory.UpdateDevelopmentStudioFactory(dbDevelopmentStudios, updateDevelopmentStudioDto);
                _context.DevelopmentStudios.Update(dbDevelopmentStudios);
                _context.SaveChanges();


                return OperationResult.Success();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IOperationResult> Create(CreateDevelopmentStudioDto newDevelopmentStudio)
        {
            try
            {
                var DevelopmentStudio = _modelFactory.CreateDevelopmentStudioFactory(newDevelopmentStudio);
                _context.DevelopmentStudios.Add(DevelopmentStudio);
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

                var DevelopmentStudio = await _context.DevelopmentStudios
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync(CancellationToken.None);

                if (DevelopmentStudio == null) return OperationResult.NotFound();

                _context.DevelopmentStudios.Remove(DevelopmentStudio);
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
