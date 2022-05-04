using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideogamesApi;
using VideogamesApi.Dtos;
using VideogamesApi.Extensions;
using VideogamesApi.Services;

namespace DevelopmentStudio.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentStudiosController : ControllerBase
    {
        private readonly IDevelopmentStudiosService _DevelopmentStudiosService;

        public DevelopmentStudiosController(IDevelopmentStudiosService DevelopmentStudiosService)
        {
            _DevelopmentStudiosService = DevelopmentStudiosService;
        }

        // GET: api/DevelopmentStudios
        [HttpGet]
        public async Task<IActionResult> GetDevelopmentStudios()
        {
            return (await _DevelopmentStudiosService.GetAll()).ContentOrError();
        }

        //GET: api/DevelopmentStudios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevelopmentStudio(long id)
        {
            return (await _DevelopmentStudiosService.Get(id)).ContentOrError();
        }

        //// PUT: api/DevelopmentStudios/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevelopmnetStudio([FromRoute] long id, UpdateDevelopmentStudioDto updateDevelopmentStudioDto)
        {

            return (await _DevelopmentStudiosService.Update(id, updateDevelopmentStudioDto)).ContentOrError();

        }

        //// POST: api/DevelopmentStudios
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDevelopmentStudio(CreateDevelopmentStudioDto newDevelopmentStudioDto)
        {
            return (await _DevelopmentStudiosService.Create(newDevelopmentStudioDto)).ContentOrError();
        }

        //// DELETE: api/DevelopmentStudios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideogame(long id)
        {
            return (await _DevelopmentStudiosService.Delete(id)).ContentOrError();
        }

        //private bool EngineExists(long id)
        //{
        //    return _context.DevelopmentStudios.Any(e => e.Id == id);
        //}
    }
}
