using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Waiter")]
        public IActionResult RestaurantView()
        {
            var viewModel = new RestaurantViewModel();
            return View(viewModel);
        }
        [Authorize(Roles = "Kitchen")]
        public IActionResult KitchenView()
        {
            var viewModel = new KitchenViewModel();
            return View(viewModel);
        }

        [Authorize(Roles = "Reception,Administrator")]
        public IActionResult ReceptionView()
        {
            var viewModel = new ReceptionViewModel(_context);
            return View(viewModel);
        }

        [Authorize(Roles = "Reception")]
        public IActionResult CreateBreakfastOrder()
        {
            var obj = new BreakfastOrder();
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
