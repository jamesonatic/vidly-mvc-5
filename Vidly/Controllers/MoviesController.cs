using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre);

            return View(movies);    
        }

        public ViewResult Details(int id)
        {

            var movie = _context.Movies.Find(id);

            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres;
            var movieForm = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm",movieForm);
        }

        public ActionResult jhgjhgjhgj()
        {
            var movie = new Movie();

            return View(movie);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            var movieForm = viewModel.Movie;

            if (movieForm.Id == 0)
            {
                movieForm.DateAdded = DateTime.Today;
                _context.Movies.Add(movieForm);
            }
            else
            {
                var movieDb = _context.Movies.SingleOrDefault(m => m.Id == movieForm.Id);

                movieDb.Name = movieForm.Name;
                movieDb.DateRelease = movieForm.DateRelease;
                movieDb.GenreId = movieForm.GenreId;
                movieDb.Stock = movieForm.Stock;
            }

            _context.SaveChanges();


            var movies = _context.Movies.Include(m => m.Genre);

            return View("Index",movies);
        }

        public ActionResult Edit(int id)
        {
            var movieDb = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==id);
            var genresDb = _context.Genres;
            var movieForm = new MovieFormViewModel
            {
                Movie = movieDb,
                Genres = genresDb
            };

            return View("MovieForm",movieForm);
        }
    }
}