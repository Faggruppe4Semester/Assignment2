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
            Date = DateTime.Today;
            RoomNumber = 0;
            AmountAdults = 0;
            AmountKids = 0;
            AdultsCheckedIn = 0;
            KidsCheckedIn = 0;
        }

        public BreakfastOrder(int roomNumber, int amountAdults, int amountKids, DateTime date)
        { 
            Date = date;
            RoomNumber = roomNumber;
            AmountAdults = amountAdults;
            AmountKids = amountKids;
            AdultsCheckedIn = 0;
            KidsCheckedIn = 0;
        }


        public DateTime Date { get; set; }

        public int RoomNumber { get; set; }
        public int AmountAdults { get; set; }
        public int AmountKids { get; set; }
        public int AdultsCheckedIn { get; set; }
        public int KidsCheckedIn { get; set; }


    }
}
