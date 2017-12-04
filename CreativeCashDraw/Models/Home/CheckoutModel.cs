using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeCashDraw.Models.Home
{
    /// <summary>
    /// This class is to store checkout info including both input and output info.
    /// </summary>
    public class CheckoutModel
    {
        public decimal OwnedAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string ChangeString { get; set; }
    }
}
