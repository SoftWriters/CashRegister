using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using CashRegister.Services.Interfaces;
using System.Linq;
using System.IO;

namespace CashRegister.Controllers
{
    [Route("/api/v1/CashRegister")]
    public class CashRegisterController : Controller
    {
        private readonly ILogger<CashRegisterController> logger;
        private ICsvFileParser csvParser;
        private IChangeCalculator changeCalculator;
        private IRandomChangeCalculator randomChangeCalculator;

        private readonly List<string> acceptedFileTypes = new List<string>()
        {
            ".txt",
            ".csv"
        };

        public CashRegisterController(ILogger<CashRegisterController> logger,
            ICsvFileParser csvParser,
            IChangeCalculator changeCalculator,
            IRandomChangeCalculator randomChangeCalculator
        )
        {
            this.logger = logger;
            this.csvParser = csvParser;
            this.changeCalculator = changeCalculator;
            this.randomChangeCalculator = randomChangeCalculator;
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (!acceptedFileTypes.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                return BadRequest("Please submit a file with a .txt or .csv extension");
            }

            var stream = file.OpenReadStream();
            var results = csvParser.ParseCsvFile(stream);

            var changeString = results.Select(res =>
            {
                var changeDue = 0m;
                
                // If the cost in cents is divisible by 3, the client wants to 
                // use the random number generator to generate the change
                if (res.costDue * 100 % 3 == 0)
                {
                    changeDue = randomChangeCalculator.CalculateChange(res.paid, res.costDue);

                    return randomChangeCalculator.DetermineChange(changeDue); 
                }

                changeDue = changeCalculator.CalculateChange(res.paid, res.costDue);

                return changeCalculator.DetermineChange(changeDue);
            }).ToList();


            return Ok(changeString);
        }

    }
}
