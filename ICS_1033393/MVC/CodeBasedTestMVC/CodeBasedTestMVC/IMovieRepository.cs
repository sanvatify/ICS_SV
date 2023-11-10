using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBasedTestMVC
{
    public interface IMovieRepository:IDisposable
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieByID(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        IEnumerable<Movie> GetMoviesReleaseInYear(int year);
    }
}