using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> _customers;

        public CustomersController()
        {
            _customers = new List<Customer>
            {
                new Customer {Id=1,Name="Magic Mike"},
                new Customer {Id=2,Name="Spectacular Steve"}
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_customers);
        }


        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var idx = _customers.FindIndex(x => x.Id == id);

            return View(_customers[idx]);
        }


    }
}