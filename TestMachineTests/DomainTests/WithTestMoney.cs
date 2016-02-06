using System.Collections.Generic;
using CashMachine.Domain;

namespace BasicConsoleAppTests.DomainTests
{
    public class WithTestMoney<TSubject> : With<TSubject> where TSubject : class
    {
        // For testing, limited the currency to only three currency units. This should allow proper testing 
        // without overkill of all the different currencies that are available.
        public static ICurrency Dollar = Money.Dollar;
        public static ICurrency Dime = Money.Dime;
        public static ICurrency Penny = Money.Penny;

        public static IList<ICurrency> TestMoney { get { return _testMoney; } private set { } }

        private static IList<ICurrency> _testMoney = new List<ICurrency>() { Dollar, Dime, Penny };
    }
}
