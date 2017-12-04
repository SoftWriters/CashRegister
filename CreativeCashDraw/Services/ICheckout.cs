using CreativeCashDraw.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeCashDraw.Services
{
    public interface ICheckout
    {
        List<CheckoutModel> Calculate(List<CheckoutModel> inputs);
    }
}
