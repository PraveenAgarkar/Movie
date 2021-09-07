using Movie.Model;
using Movie.MovieInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace web_api_tests
{
    public class MovieServiceFake : IMovie
    {
        private readonly List<MovieEntity> _movie;

        public MovieServiceFake()
        {
            _movie = new List<MovieEntity>()
            {
                new MovieEntity { Id = 1, Title = "Toy Story 1", Director = "John Lasseter" },
                new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" },
                new MovieEntity { Id = 3, Title = "Arrival", Director = "Denis Villeneuve" }
            };
        }

        public IEnumerable<MovieEntity> GetAllMovies(int page, int pagesize)
        {
            return _movie;
        }

        public MovieEntity AddMovie(MovieEntity newItem)
        {           
            _movie.Add(newItem);
            return newItem;
        }

        public MovieEntity GetById(int? id)
        {
            return _movie.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _movie.First(a => a.Id == id);
            _movie.Remove(existing);
        }
        
    }
}
