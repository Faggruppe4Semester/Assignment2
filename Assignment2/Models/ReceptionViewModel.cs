using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Models
{
    public class ReceptionViewModel
    {
        public ReceptionViewModel(ApplicationDbContext context)
        {
            _context = context;
            context.Add(new BreakfastOrder(22, 2, 2, DateTime.Today));
            context.SaveChanges();
            BreakfastOrders = context.BreakfastOrders.Where(d => d.Date == DateTime.Today).ToList();

        }

        public List<BreakfastOrder> BreakfastOrders { get; set; }

        private readonly ApplicationDbContext _context;

    }
}
