using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
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
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = new List<MovieDto>();

            foreach (Movie movie in _context.Movies.ToList())
            {
                var movieDto = new MovieDto();
                Mapper.Map(movie, movieDto);
                movies.Add(movieDto);
            }

            return movies;
        }

        public MovieDto GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var movieDto = new MovieDto();
            Mapper.Map(movie, movieDto);

            return movieDto;
        }

        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieApi)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieNew = new Movie();
            Mapper.Map(movieApi, movieNew);

            _context.Movies.Add(movieNew);
            _context.SaveChanges();

            return movieApi;
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto,movieDb);

            _context.SaveChanges();
            
        }
    }
}
