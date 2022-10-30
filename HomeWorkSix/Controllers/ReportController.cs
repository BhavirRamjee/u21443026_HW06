using HomeWorkSix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWorkSix.Controllers
{
    public class ReportController : Controller
    {
        private BikeStoresEntities  bikeStoresEntities = new BikeStoresEntities();

       
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RetrieveBarGraphResults()
        {
            var result = (from a in bikeStoresEntities.orders
                          group a by new { month = a.order_date.Month } into g
                          select new
                          {
                              MonthlyOrders = g.Count(),
                              Month = g.Key.month
                          }).ToList();

            return Json(new { Results = result });
        }
    }
}