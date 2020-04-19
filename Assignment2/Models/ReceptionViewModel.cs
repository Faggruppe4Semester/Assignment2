using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public class ReceptionViewModel
    {
        public ReceptionViewModel()
        {
            BreakfastOrders = new List<BreakfastOrder>();
            BreakfastOrders.Add(new BreakfastOrder(47, 2, 0, DateTime.Today));
            BreakfastOrders.Add(new BreakfastOrder(25, 2, 2, DateTime.Today));

        }

        public List<BreakfastOrder> BreakfastOrders { get; set; }

    }
}
