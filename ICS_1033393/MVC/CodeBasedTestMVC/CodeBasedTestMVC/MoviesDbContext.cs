using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeBasedTestMVC
{
    public class MoviesDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}