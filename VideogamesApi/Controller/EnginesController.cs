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


namespace EnginesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        private readonly IEnginesService _enginesService;

        public EnginesController(IEnginesService enginesService)
        {
            _enginesService = enginesService;
        }

        // GET: api/Engines
        [HttpGet]
        public async Task<IActionResult> GetEngines()
        {
            return (await _enginesService.GetAll()).ContentOrError();
        }

        // GET: api/Engines?Name
        [HttpGet("[Action]")]
        [ActionName("search")]
        public async Task<IActionResult> SearchEngines([FromQuery] string name)
        {
            return (await _enginesService.Search(name)).ContentOrError();
        }

        //GET: api/Engines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEngine(long id)
        {
            return (await _enginesService.Get(id)).ContentOrError();
        }

        //// PUT: api/Engines/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngine([FromRoute] long id, UpdateEngineDto updateEngineDto)
        {

            return (await _enginesService.Update(id, updateEngineDto)).ContentOrError();

        }

        //// POST: api/Engines
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateEngine(CreateEngineDto newEngineDto)
        {
            return (await _enginesService.Create(newEngineDto)).ContentOrError();
        }

        //// DELETE: api/Engines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideogame(long id)
        {
            return (await _enginesService.Delete(id)).ContentOrError();
        }

        //private bool EngineExists(long id)
        //{
        //    return _context.Engines.Any(e => e.Id == id);
        //}
    }
}
