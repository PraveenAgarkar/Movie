using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.Model;
using Movie.MovieInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Movie.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMovie _movie;
        public MoviesController(ILogger<MoviesController> logger, IMovie movie)
        {
            _logger = logger;
            _movie = movie;
        }

        // GET api/movies/1
        [HttpGet("{id}")]       
        public IActionResult Get(int? Id)
        {
            var item = _movie.GetById(Id);
            if (item == null)
            {
                _logger.LogInformation("GetById api thrown expection");
                return NotFound();
            }           
            return Ok();
        }

        // GET api/movies/page/pageSize
        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetMovies(int page, int pageSize)
        {           
            var items = _movie.GetAllMovies(page, pageSize);
            return Ok(items);
        }

        // POST api/movies
        [HttpPost]       
        public IActionResult Post([FromBody] MovieEntity movieObj)
        {            
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Model data thrown expection");
                return BadRequest(ModelState);
            }
            var item = _movie.AddMovie(movieObj);            
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }
    }
}


