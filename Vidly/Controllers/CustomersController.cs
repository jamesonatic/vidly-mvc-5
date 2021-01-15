using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewmodel);
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // Diferred execution

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) 
        {
            return View();
        }
    }
}