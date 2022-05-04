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


namespace GenresApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _GenresService;

        public GenresController(IGenresService GenresService)
        {
            _GenresService = GenresService;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            return (await _GenresService.GetAll()).ContentOrError();
        }

        //GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(long id)
        {
            return (await _GenresService.Get(id)).ContentOrError();
        }

        //// PUT: api/Genres/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre([FromRoute] long id, UpdateGenreDto updateGenreDto)
        {

            return (await _GenresService.Update(id, updateGenreDto)).ContentOrError();

        }

        //// POST: api/Genres
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostGenre(CreateGenreDto newGenreDto)
        {
            return (await _GenresService.Create(newGenreDto)).ContentOrError();
        }

        //// DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(long id)
        {
            return (await _GenresService.Delete(id)).ContentOrError();
        }

        //private bool GenreExists(long id)
        //{
        //    return _context.Genres.Any(e => e.Id == id);
        //}
    }
}
