using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CashRegister.Models;
using Microsoft.AspNetCore.Http;
using CashRegister.Services.Interfaces;
using System.IO;

namespace CashRegister.Controllers
{
    [Route("/api/v1/CashRegister")]
    public class CashRegisterController : Controller
    {
        private readonly ILogger<CashRegisterController> logger;
        private readonly List<string> acceptedFileTypes = new List<string>()
        {
            ".txt",
            ".csv"
        };
        private ICsvFileParser csvParser;

        public CashRegisterController(ILogger<CashRegisterController> logger,
            ICsvFileParser csvParser
        )
        {
            this.logger = logger;
            this.csvParser = csvParser;
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (!acceptedFileTypes.Contains(file.ContentType.ToLower()))
            {
                return BadRequest("Please submit a file with a .txt or .csv extension");
            }

            var reader = file.OpenReadStream();


            return View();
        }

    }
}
