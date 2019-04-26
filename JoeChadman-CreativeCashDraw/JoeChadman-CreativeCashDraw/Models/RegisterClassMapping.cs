using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoeChadman_CreativeCashDraw.Models
{
    public sealed class RegisterClassMapping : CsvClassMap<Register>
    {
        public RegisterClassMapping()
        {
            Map(m => m.AmtOwed).Index(0);
            Map(m => m.AmtPaid).Index(1);
        }
    }

}