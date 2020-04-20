using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Models
{
    public class RestaurantViewModel
    {
        public RestaurantViewModel(ApplicationDbContext context)
        {
            _context = context;
        }


        private readonly ApplicationDbContext _context;

    }
}
