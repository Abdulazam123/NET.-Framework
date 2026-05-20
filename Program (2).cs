using System;
using System.Linq;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Insuree insuree)
        {
            decimal quote = 50m;

            int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--;

            if (age <= 18) quote += 100m;
            else if (age <= 25) quote += 50m;
            else quote += 25m;

            if (insuree.CarYear < 2000) quote += 25m;
            if (insuree.CarYear > 2015) quote += 25m;

            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25m;
                if (insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25m;
            }

            quote += insuree.SpeedingTickets * 10m;

            if (insuree.DUI) quote *= 1.25m;
            if (insuree.CoverageType) quote *= 1.50m;

            insuree.Quote = quote;

            db.Insurees.Add(insuree);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Admin()
        {
            return View(db.Insurees.ToList());
        }
    }
}