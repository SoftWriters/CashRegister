namespace CashRegister.Core
{
    namespace Denominations
    {
        public class Penny : Coin
        {
            public Penny() : base(1, "penny", "pennies")
            {
            }
        }

        public class Nickel : Coin
        {
            public Nickel() : base(5, "nickel", "nickels")
            {
            }
        }

        public class Dime : Coin
        {
            public Dime() : base(10, "dime", "dimes")
            {
            }
        }

        public class Quarter : Coin
        {
            public Quarter() : base(25, "quarter", "quarters")
            {
            }
        }

        public class Dollar : Coin
        {
            public Dollar() : base(100, "dollar", "dollars")
            {
            }
        }
    }
}
