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

            var customer = _context.Customers.Single(
                c => c.Id == rental.CustomerId);

            var movies = _context.Movies.Where(
                m => rental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest();

                movie.NumberAvailable--;
                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Today
                };
                _context.Rental.Add(newRental);
            }


            _context.SaveChanges();

            return Ok();
        }



    }
}