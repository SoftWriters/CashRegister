using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CashRegisterMVC.Helpers;

namespace CashRegisterMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            try
            {

                // Helper class containing logic
                var MonetaryHelper = new MonetaryHelper();

                return View(MonetaryHelper);
            }
            catch (Exception ex)
            { 
                return View("Error", new HandleErrorInfo(ex,"Home","Index"));
            }
        }

        

    }
}