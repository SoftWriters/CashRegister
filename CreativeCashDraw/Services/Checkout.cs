using CreativeCashDraw.Models.Home;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeCashDraw.Services
{
    public class Checkout : ICheckout
    {
        public List<CheckoutModel> Calculate(List<CheckoutModel> inputs)
        {
            var coinTypes = new[] {
                    new { name = "quarter", value = 0.25m },
                    new { name = "dime", value = 0.10m },
                    new { name = "nickel", value = 0.05m },
                    new { name = "penny", value = 0.01m }
                };

            foreach (var input in inputs)
            {
                decimal totalChange = input.PaidAmount - input.OwnedAmount;

                string strInput = input.OwnedAmount.ToString().Replace(".", string.Empty);
                
                if (int.Parse(strInput) % 3 == 0)
                {
                    //special logic
                    int dollarChange = (int)totalChange;
                    decimal coinChange = totalChange;
                    var sb = new StringBuilder();
                    if (dollarChange != 0)
                    {
                        int randomDollars = GetRandomNumber(0, dollarChange);
                        if (randomDollars != 0)
                        {
                            sb.Append($"{randomDollars} dollars,");
                            coinChange = totalChange - randomDollars;
                        }
                        
                    }
                  
                    foreach (var coin in coinTypes)
                    {
                        int count = (int)(coinChange / coin.value);
                        if (coin.name != "penny")
                        {//we need to get random count except "penny" to make the "math" add up.
                            if (count != 0)
                            {
                                int randomCoinCount = GetRandomNumber(0, count);
                                if (randomCoinCount != 0)
                                {
                                    coinChange -= randomCoinCount * coin.value;
                                    sb.Append($"{randomCoinCount} {coin.name},");
                                }

                            }
                        }
                        else
                        {
                            if (count != 0)
                            {
                                sb.Append($"{count} {coin.name},");
                            }
                        }
                    }
                    input.ChangeString = sb.ToString().TrimEnd(new char[] { ',' });
                }
                else//regular logic
                {
                    int dollarChange = (int)totalChange;
                    decimal coinChange = totalChange - dollarChange;
                    var sb = new StringBuilder();
                    if (dollarChange != 0)
                    {
                        sb.Append($"{dollarChange} dollars,");
                    }

                    foreach (var coin in coinTypes)
                    {
                        int count = (int)(coinChange / coin.value);
                        if (count != 0)
                        {
                            coinChange -= count * coin.value;
                            sb.Append($"{count} {coin.name},");
                        }
                    }
                    input.ChangeString = sb.ToString().TrimEnd(new char[] { ',' });
                }

            }

            return inputs;
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
