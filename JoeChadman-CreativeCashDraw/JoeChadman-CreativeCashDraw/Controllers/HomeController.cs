using JoeChadman_CreativeCashDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper.Configuration;
using System.IO;
using CsvHelper;

namespace JoeChadman_CreativeCashDraw.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Cash Register";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            List<Register> register = new List<Register>();

            //get data from csv
            try {
                if (file.ContentLength > 0)
                {
                    IEnumerable<Register> records;
                    using (var reader = new CsvReader(new StreamReader(file.FileName)))
                    { 
                        //no header record.  This property is trure by default.
                        reader.Configuration.HasHeaderRecord = false;

                        //use a mapping file to pull the data into the class correctly by index
                        reader.Configuration.RegisterClassMap<RegisterClassMapping>();

                        //Fill Class from comma delimited file
                        records = reader.GetRecords<Register>();

                        //need to have the records in a list so converting from the ienumberable csvhelper needed
                        register = records.ToList();
                    }                    
                }
            }
            catch (Exception ex) {
                ViewBag.Error = "Upload Failed: " + ex.Message;
            }
            
            return View(register);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Joe Chadman";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Joe Chadman";

            return View();
        }
    }
}
