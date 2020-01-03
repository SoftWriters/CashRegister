using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegister
{
    public class Currency
    {
        public static Currency Hundred { get; } = new Currency("hundred", "hundreds", 10000);
        public static Currency Fifty { get; } = new Currency("fifty", "fifties", 5000);
        public static Currency Twenty { get; } = new Currency("twenty", "twenties", 2000);
        public static Currency Ten { get; } = new Currency("ten", "tens", 1000);
        public static Currency Five { get; } = new Currency("five", "fives", 500);
        public static Currency Dollar { get; } = new Currency("dollar", "dollars", 100);
        public static Currency Quarter { get; } = new Currency("quarter", "quarters", 25);
        public static Currency Dime { get; } = new Currency("dime", "dimes", 10);
        public static Currency Nickel { get; } = new Currency("nickel", "nickels", 5);
        public static Currency Penny { get; } = new Currency("penny", "pennies", 1);

        public static IEnumerable<Currency> List()
        {
            return new[] { Hundred, Fifty, Twenty, Ten, Five, Dollar, Quarter, Dime, Nickel, Penny };
        }

        private Currency(string name, string plural, int value)
        {
            Name = name;
            Plural = plural;
            Value = value;
        }

        public string Name { get; private set; }
        public string Plural { get; private set; }
        public int Value { get; private set; }
    }
}
