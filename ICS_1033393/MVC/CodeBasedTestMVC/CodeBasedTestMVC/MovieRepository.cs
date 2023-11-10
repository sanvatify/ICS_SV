using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBasedTestMVC
{
    public class MovieRepository:IMovieRepository
    {
        private MoviesDbContext db = new MoviesDbContext();
        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies.ToList();
        }
        public Movie GetMovieByID(int id)
        {
            return db.Movies.Find(id);
        }
        public AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
        public void UpdateMovie(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }
        public IEnumerable<Movie> GetMoviesReleaseInYear (int year)
        {
            return db.Movies.Where(m => m.DateOfRelease.Year == year).ToList();
        }
        public void Displose()
        {
            db.Dispose();
        }
    }
}