using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CreativeCashDraw.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using CreativeCashDraw.Models.Home;
using CreativeCashDraw.Services;

namespace CreativeCashDraw.Controllers
{
    /// <summary>
    /// This is main controller for this demo project.
    /// </summary>
    public class HomeController : Controller
    {
        private ICheckout _checkoutService;

        public HomeController(ICheckout checkoutService)
        {
            this._checkoutService = checkoutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var model = new FileOutputModel();
            if (file == null || file.Length == 0 || file.ContentType.ToLower() != "text/plain")
            {
                model.InvalidFile = true;
                return View("Index", model);
            }
          
            var fileExt = Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\output.txt");

            model.Name = Path.GetFileName(file.FileName);
            model.Path = file.FileName;
            model.Url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/uploads/output.txt";

            //read file
            var fileStream = await file.GetFileStream();
            fileStream.Position = 0;
            List<CheckoutModel> checkoutModel = new List<CheckoutModel>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    var checkout = new CheckoutModel();
                    checkout.OwnedAmount = decimal.Parse(line.Split(",")[0].Trim());
                    checkout.PaidAmount = decimal.Parse(line.Split(",")[1].Trim());
                    checkoutModel.Add(checkout);

                }
            }
            model.CheckoutModel = checkoutModel;
            var calculatedModel = _checkoutService.Calculate(checkoutModel);
            //write to the output file
            using (StreamWriter writetext = new StreamWriter(path, false))
            {
                foreach(var line in calculatedModel)
                {
                    writetext.WriteLine(line.ChangeString);
                }
                
            }

            return View("Index", model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "My demo application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "My demo contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
