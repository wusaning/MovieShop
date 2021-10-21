using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        // method that get 30 top
        IEnumerable<Movie> GetTop30RevenueMovies();
    }
}
