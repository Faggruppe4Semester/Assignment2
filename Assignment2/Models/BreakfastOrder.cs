using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public class BreakfastOrder
    {
        public BreakfastOrder()
        {
            RoomNumber = 0;
            AmountAdults = 0;
            AmountKids = 0;
        }

        public BreakfastOrder(int roomNumber, int amountAdults, int amountKids, DateTime date)
        {
            State = OrderState.NotCheckedIn;
            Date = date;
            RoomNumber = roomNumber;
            AmountAdults = amountAdults;
            AmountKids = amountKids;
        }

        public enum OrderState
        {
            NotCheckedIn, CheckedIn
        }

        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        
        public int RoomNumber { get; set; }
        public int AmountAdults { get; set; }
        public int AmountKids { get; set; }

    }
}
