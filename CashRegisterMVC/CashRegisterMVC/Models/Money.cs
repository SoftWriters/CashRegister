using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace CashRegisterMVC.Models
{
    public class Money
    {

        public string InputData { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Change { get; set; }
        public string PairKey { get; set; }
        public string ChangeGiven { get; set; }

        [RegularExpression(@"/^\d*\.?\d*\,\d*\.?\d*$/]", ErrorMessage="Input string must be in format decimal,decimal")]
        public string Path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/monetaryValues.dat");
     
        public Dictionary<string, decimal> CashDictionary = new Dictionary<string, decimal>();
        public Dictionary<string, decimal> RandomCashDictionary = new Dictionary<string, decimal>();
    }
}