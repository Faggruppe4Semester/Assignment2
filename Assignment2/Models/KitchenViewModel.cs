using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public class KitchenViewModel
    {
        public KitchenViewModel()
        {
            BreakfastOrders = new List<BreakfastOrder>();
            BreakfastOrders.Add(new BreakfastOrder(47, 2, 0,DateTime.Today));
            BreakfastOrders.Add(new BreakfastOrder(25, 2, 2, DateTime.Today));

        }

        public List<BreakfastOrder> BreakfastOrders { get; set; }

        public int GetCheckedInAdults(DateTime date)
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders.Where(b=> b.Date == date))
            {
                if (breakfastOrder.State == BreakfastOrder.OrderState.CheckedIn)
                    total += breakfastOrder.AmountAdults;
            }
            return total;
        }

        public int GetCheckedInKids(DateTime date)
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders.Where(b =>b.Date == date))
            {
                if (breakfastOrder.State == BreakfastOrder.OrderState.CheckedIn)
                    total += breakfastOrder.AmountKids;
            }
            return total;
        }

        public int GetExpectedAdults(DateTime date)
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders.Where(b =>b.Date == date))
            {
                total += breakfastOrder.AmountAdults;
            }
            return total;
        }

        public int GetExpectedKids(DateTime date)
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders)
            {
                total += breakfastOrder.AmountKids;
            }
            return total;
        }

        public int GetNotCheckedInAdults(DateTime date)
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders.Where(b => b.Date == date))
            {
                if (breakfastOrder.State == BreakfastOrder.OrderState.NotCheckedIn)
                    total += breakfastOrder.AmountAdults;
            }
            return total;
        }

        public int GetNotCheckedInKids(DateTime date)
        {
            int total = 0;
            foreach (var breakfastOrder in BreakfastOrders.Where(b => b.Date == date))
            {
                if (breakfastOrder.State == BreakfastOrder.OrderState.NotCheckedIn)
                    total += breakfastOrder.AmountKids;
            }
            return total;
        }
    }
}
