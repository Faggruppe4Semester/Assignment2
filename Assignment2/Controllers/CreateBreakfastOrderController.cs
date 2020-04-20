using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Assignment2.Controllers
{
    public class CreateBreakfastOrderController : Controller
    {
        public CreateBreakfastOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Context"] = _context;
            return View();
        }

        public void CreateOrder(BreakfastOrder model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    List<BreakfastOrder> BO = _context.BreakfastOrders.Where(BO =>
                        BO.Date == model.Date && BO.RoomNumber == model.RoomNumber).ToList();
                    if (BO.Count == 0)
                    {
                        _context.BreakfastOrders.Add(model);
                        _context.SaveChanges();
                        transaction.Commit();
                        Response.Redirect("../Home/ReceptionView");
                        return;
                    }

                    if (BO.Count != 0)
                    {
                        BO[0].AmountAdults += model.AmountAdults;
                        BO[0].AmountKids += model.AmountKids;
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
                Response.Redirect("../Home/ReceptionView");
            }
        }

        private readonly ApplicationDbContext _context;
    }
}