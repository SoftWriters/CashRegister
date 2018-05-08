using CashRegister.Businesses;
using CashRegister.Extensions;
using CashRegister.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CashRegister.Controllers
{
    public class CashRegisterController : Controller
    {        
        // Class that implements all the business logic for Cash Register operations
        private CashRegisterBusiness _business;

        // If CashRegisterBusiness connected to the database and needs to be faked / mocked, 
        // use Ninject and dependency injection to create CashRegisterBusiness
        // Otherwise, this is sufficient
        public CashRegisterController()
        {
            _business = new CashRegisterBusiness();
        }

        /// <summary>
        /// Main Cash Register page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Process the uploaded file and return the results.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ViewResult ProcessFile(HttpPostedFileBase cashRegisterFile)
        {
            // Would be a good idea to add a token or some sort of verification to prevent abuse if this method is publicly accessible
            string fileContents = cashRegisterFile.ToAsciiString();
            IEnumerable<CashRegisterRecord> results = _business.ProcessFile(fileContents);
            return View("Results", results);
        }
    }
}