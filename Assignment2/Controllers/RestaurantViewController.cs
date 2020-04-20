using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Assignment2.Controllers
{
    public class RestaurantViewController : Controller
    {
        public RestaurantViewController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Context"] = _context;
            return View();
        }

        [HttpPost]
        public void CheckIn(BreakfastOrder model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    List<BreakfastOrder> BO = _context.BreakfastOrders.Where(BO => BO.Date == DateTime.Today && BO.RoomNumber == model.RoomNumber).ToList();
                    if (BO.Count == 0)
                    {
                        //Error
                        Response.Redirect("../Home/RestaurantView");
                        return;
                    }
                    if (BO[0].AmountAdults - BO[0].AdultsCheckedIn >= model.AdultsCheckedIn)
                    {
                        BO[0].AdultsCheckedIn += model.AdultsCheckedIn;
                    }

                    if (BO[0].AmountKids - BO[0].KidsCheckedIn >= model.KidsCheckedIn)
                    {
                        BO[0].KidsCheckedIn += model.KidsCheckedIn;
                    }

                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
                Response.Redirect("../Home/RestaurantView");
            }
        }

        private ApplicationDbContext _context;

    }
}