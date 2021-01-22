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
    public class RentalController : ApiController
    {
        // GET api/<controller>
        public RentalDto GetRental()
        {
            var movies = new List<Movie>();
            movies.Add(new Movie { Id = 5, Name = "testmovie", GenreId = 2 });
            movies.Add(new Movie { Id = 6, Name = "testmovie", GenreId = 3 });
            var rental = new RentalDto
            {
                CustomerId = 5,
                Movies = movies
            };

            return rental;
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateRent(RentalDto rental)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            return Ok();
        }



    }
}