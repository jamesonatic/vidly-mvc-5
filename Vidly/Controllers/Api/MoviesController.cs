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
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieApi)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieNew = Mapper.Map<MovieDto, Movie>(movieApi);
            _context.Movies.Add(movieNew);
            _context.SaveChanges();

            movieApi.Id = movieNew.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieApi.Id), movieApi);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieDb == null)
                return NotFound();

            _context.Movies.Remove(movieDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
