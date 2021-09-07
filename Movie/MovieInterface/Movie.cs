using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.MovieInterface
{
    public class Movie : IMovie
    {
        public static List<MovieEntity> Movies { get; set; }
       
        public Movie()
        {
            Movies = new List<MovieEntity>
{
new MovieEntity { Id = 1, Title = "Toy Story 1", Director = "John Lasseter" },
new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" },
new MovieEntity { Id = 3, Title = "Arrival", Director = "Denis Villeneuve" },
new MovieEntity { Id = 4, Title = "Interstellar", Director = "Christopher Nolan" },
new MovieEntity { Id = 5, Title = "The Martian", Director = "Ridley Scott" }, new MovieEntity { Id = 6, Title = "Avatar", Director = "James Cameron" },
new MovieEntity { Id = 7, Title = "Prometheus", Director = "Ridley Scott" },
new MovieEntity { Id = 8, Title = "Sunshine", Director = "Danny Boyle" }, new MovieEntity { Id = 9, Title = "Serenity", Director = "Joss Whedon" },
new MovieEntity { Id = 10, Title = "WALL-E", Director = "Andrew Stanton" },
};
        }
        public MovieEntity AddMovie(MovieEntity movieObj)
        {
            if(movieObj == null)
            {
                throw new ArgumentNullException("movie");
            }
            Movies.Add(movieObj);
            return movieObj;
        }

        public IEnumerable<MovieEntity> GetAllMovies(int page,int pagesize)
        {
            var objMovie = Movies.Skip((page-1) * pagesize).Take(pagesize);
            return objMovie;
        }

        public MovieEntity GetById(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("movie");
            }
            var objMovie = Movies.FirstOrDefault(f => f.Id == Id);
            return objMovie;
        }
       
    }
}
