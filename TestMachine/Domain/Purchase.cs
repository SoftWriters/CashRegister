using System;

namespace CashMachine.Domain
{
    public class Purchase
    {
        /// <summary>
        /// Creates a purchase with format "payment,Cost"
        /// </summary>
        /// <param name="purchase"></param>
        public Purchase(string purchase)
        {
            var values = purchase.Split(',');
            decimal dvalue;

            if (!decimal.TryParse(values[1], out dvalue)) throw new Exception("Invalid item Payment! Line: " + purchase);
            Payment = dvalue;

            if (!decimal.TryParse(values[0], out dvalue)) throw new Exception("Invalid item Cost! Line: " + purchase);
            ItemCost = dvalue;

            if (ItemCost < 0 || Payment < 0) throw new Exception("No negatives allowed!");

            if (ItemCost > Payment) throw new Exception("Not enough Money! Cost > Payment" + purchase);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return "P:" + Payment + ",C:" + ItemCost;
        }

        public decimal Payment { get; set; }
        public decimal ItemCost { get; set; }
    }
}
