using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBasedTestMVC
{
    public class CodeController:Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        public ActionResult CustomersInGermany()
        {
            var germanCustomers = db.customers.Where(c => c.Countery == "Germany").ToList();
            return View(germanCustomers);
        }
        public ActionResult CustomerDetailsForOrder()
        {
            var orderDetails = db.Customers
                .Join(db.Orders, c => c.CustomerID, o => o.CustomerID, (c, o) => new { c, o })
                .Where(x => x.o.OrderID == 10248).ToList();
            return View(orderDetails);
        }
    }
}