using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.MovieInterface
{
    public interface IMovie
    {
        MovieEntity GetById(int? Id);

        IEnumerable<MovieEntity> GetAllMovies(int page,int pagesize);

        MovieEntity AddMovie(MovieEntity movieObj);

    }
}
