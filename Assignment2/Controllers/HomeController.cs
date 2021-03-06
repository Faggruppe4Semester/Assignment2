﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Assignment2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;

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
        [Authorize(Roles = "Waiter,Administrator")]
        public IActionResult RestaurantView()
        {
            ViewData["Context"] = _context;
            var viewModel = new RestaurantViewModel(_context);
            return View(viewModel);
        }
        [Authorize(Roles = "Kitchen,Administrator")]
        public IActionResult KitchenView()
        {
            try
            {
                string requestString = Request.QueryString.Value;
                var date = (requestString == "" ? DateTime.Today : DateTime.Parse(HttpUtility.ParseQueryString(requestString).Get("date")));
                var viewModel = new KitchenViewModel(_context,date);
                return View(viewModel);
            }
            catch (Exception e)
            {
                var viewModel = new KitchenViewModel(_context, DateTime.Today);
                return View(viewModel);
            }
            ;
        }

        [Authorize(Roles = "Reception,Administrator")]
        public IActionResult ReceptionView()
        {
            ViewData["Context"] = _context;
            var viewModel = new ReceptionViewModel(_context);
            return View(viewModel);
        }

        [Authorize(Roles = "Reception,Administrator")]
        public IActionResult CreateBreakfastOrder()
        {
            ViewData["Context"] = _context;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
