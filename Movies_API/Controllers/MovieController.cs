using Microsoft.AspNetCore.Mvc;
using Movies_API.Entities;
using Movies_API.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MovieController(IMoviesRepository moviesRepository)
        {
            this._moviesRepository = moviesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _moviesRepository.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{cod_movie}")]
        public async Task<IActionResult> GetById(int cod_movie)
        {
            var data = await _moviesRepository.GetByIdAsync(cod_movie);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            var data = await _moviesRepository.AddAsync(movie);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int cod_movie)
        {
            var data = await _moviesRepository.DeleteAsync(cod_movie);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Movie movie, int codMovie)
        {
            var data = await _moviesRepository.UpdateAsync(movie,codMovie);
            return Ok(data);
        }
    }
}

