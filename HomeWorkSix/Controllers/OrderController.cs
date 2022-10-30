using HomeWorkSix.Models;
using PagedList;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace HomeWorkSix.Controllers
{
    public class OrderController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();

       
        public ViewResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IQueryable<order> orders = db.orders;

            if (!String.IsNullOrEmpty(searchString))
            {

                DateTime orderDate = DateTime.ParseExact(searchString, "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
                orders = orders.Where(s => s.order_date.Equals(orderDate));
            }

            orders = orders.OrderBy(x => x.order_id);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }
    }
}