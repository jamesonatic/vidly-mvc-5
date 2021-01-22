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
        public ApplicationDbContext _context { get; set; }

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET api/<controller>
        public RentalDto GetRental()
        {
            var movies = new List<int>();
            movies.Add(1);
            movies.Add(2);
            var rental = new RentalDto
            {
                CustomerId = 5,
                MovieIds = movies
            };

            return rental;
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateRent(RentalDto rental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            foreach (var rentalMovieId in rental.MovieIds)
            {
                var rentalDb = new Rental
                {
                    Customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId),
                    Movie = _context.Movies.SingleOrDefault(m => m.Id == rentalMovieId),
                    DateRented = DateTime.Today
                };
                _context.Rental.Add(rentalDb);
            }


            _context.SaveChanges();

            return Ok();
        }



    }
}