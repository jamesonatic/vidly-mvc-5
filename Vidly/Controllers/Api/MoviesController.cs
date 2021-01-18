using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public MovieDto GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var movieDto = new MovieDto
            {
                Name = movie.Name,
                DateAdded = movie.DateAdded,
                ReleaseDate = movie.ReleaseDate,
                GenreId = movie.GenreId,
                NumberInStock = movie.NumberInStock
            };
            return movieDto;
        }

        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieDb.Name = movieDto.Name;

            _context.SaveChanges();
            
        }
    }
}
