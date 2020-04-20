using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;

namespace Assignment2.Models
{
    public class KitchenViewModel
    {
        public KitchenViewModel(ApplicationDbContext context,DateTime date)
        {
            Date = date;
            _context = context;
            BreakfastOrders = new List<BreakfastOrder>();
        }

        public List<BreakfastOrder> GetBreakfastOrders()
        {
            BreakfastOrders = _context.BreakfastOrders.Where(BO => BO.Date == Date).ToList();
            return BreakfastOrders;
        }

        public List<BreakfastOrder> BreakfastOrders { get; set; }
        private readonly ApplicationDbContext _context;
        public DateTime Date { get; set; }

        public int GetCheckedInAdults()
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.AdultsCheckedIn;
            }
            return total;
        }

        public int GetCheckedInKids()
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.KidsCheckedIn;
            }
            return total;
        }

        public int GetExpectedAdults()
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.AmountAdults;
            }
            return total;
        }

        public int GetExpectedKids()
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.AmountKids;
            }
            return total;
        }

        public int GetNotCheckedInAdults()
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.AmountAdults - breakfastOrder.AdultsCheckedIn;
            }
            return total;
        }

        public int GetNotCheckedInKids()
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.AmountKids - breakfastOrder.KidsCheckedIn;
            }

            return total;
        }
    }
}
