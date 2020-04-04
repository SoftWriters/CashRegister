using System;
using System.Collections.Generic;

namespace CashRegister
{
    public class Denominator
    {
        public string Name;
        public string Plural;
        public decimal Nominal;
    }
    
    public static class Main
    {

        private static List<Denominator> _coins =
            new List<Denominator>()
            {
                new Denominator {Name = "hundred", Plural = "hundreds", Nominal = 100m},
                new Denominator {Name = "fifty", Plural = "fifties", Nominal = 50m},
                new Denominator {Name = "twenty", Plural = "twenties", Nominal = 20m},
                new Denominator {Name = "ten", Plural = "tens", Nominal = 10m},
                new Denominator {Name = "five", Plural = "fives", Nominal = 5m},
                new Denominator {Name = "dollar", Plural = "dollars", Nominal = 1m},
                new Denominator {Name = "quarter", Plural = "quarters", Nominal = 0.25m},
                new Denominator {Name = "dime", Plural = "dimes", Nominal = 0.10m},
                new Denominator {Name = "nickel", Plural = "nickels", Nominal = 0.05m},
                new Denominator {Name = "penny", Plural = "pennies", Nominal = 0.01m}
            };
        
        public static string GetChange(decimal cost, decimal given)
        {
            var change = given - cost;
            
            if (cost * 100 % 3 == 0)
                return _getRandomChange(change);
            
            var changeDescriptor = new List<string>();

            foreach (var coin in _coins)
            {
                var count = (int) (change / coin.Nominal);
                change -= count * coin.Nominal;

                var coinName = $"{(count > 1 ? coin.Plural : coin.Name )}";
                
                if(count != 0)
                    changeDescriptor.Add($"{count} {coinName}");
            }

            return string.Join(", ", changeDescriptor);
        }

        private static string _getRandomChange(decimal change)
        {
            var changeDescriptor = new List<string>();

            foreach (var coin in _coins)
            {
                var count = (int) (change / coin.Nominal);
                decimal randomCount = coin.Name == "penny" ? count : new Random().Next(0, count);
                
                change -= randomCount * coin.Nominal;

                var coinName = $"{(count > 1 ? coin.Plural : coin.Name )}";
                
                if(randomCount != 0)
                    changeDescriptor.Add($"{randomCount} {coinName}");
            }

            return string.Join(", ", changeDescriptor);
        }
    }
}