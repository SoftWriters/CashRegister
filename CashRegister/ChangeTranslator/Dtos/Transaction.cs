using System;

namespace ChangeTranslator.Dtos
{
    public class Transaction
    {
        public decimal Cost { get; }
        public decimal Paid { get; }
        public bool RandomChange => (Cost * 100) % 3 == 0;

        public Transaction(string cost, string paid)
        {
            if (decimal.TryParse(cost, out decimal temp))
                Cost = temp;
            else throw new InvalidCastException($"{cost} cannot be cast as a decimal.");

            if (decimal.TryParse(paid, out temp))
                Paid = temp;
            else throw new InvalidCastException($"{paid} cannot be cast as a decimal.");
        }
    }
}
