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

namespace VideogamesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogamesController : ControllerBase
    {
        private readonly IVideogamesService _videogamesService;

        public VideogamesController(IVideogamesService videogamesService)
        {
            _videogamesService = videogamesService;
        }

        // GET: api/Videogames
        [HttpGet]
        public async Task<IActionResult> GetVideogames()
        {
            return (await _videogamesService.GetAll()).ContentOrError();
        }

        //GET: api/Videogames/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideogame(long id)
        {
            return (await _videogamesService.Get(id)).ContentOrError();
        }

        // GET: api/Videogames?Name
        [HttpGet("[Action]")]
        [ActionName("search")]
        public async Task<IActionResult> SearchVideogames([FromQuery] string name)
        {
            return (await _videogamesService.Search(name)).ContentOrError();
        }

        //// PUT: api/Videogames/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideogame([FromRoute] long id, UpdateVideogameDto updateVideogameDto)
        {

            return (await _videogamesService.Update(id, updateVideogameDto)).ContentOrError();

        }

        //// POST: api/Videogames
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostVideogame(CreateVideogameDto newVideogameDto)
        {
            return (await _videogamesService.Create(newVideogameDto)).ContentOrError();
        }

        //// DELETE: api/Videogames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideogame(long id)
        {
            return (await _videogamesService.Delete(id)).ContentOrError();
        }

        //private bool VideogameExists(long id)
        //{
        //    return _context.Videogames.Any(e => e.VideogameId == id);
        //}
    }
}
