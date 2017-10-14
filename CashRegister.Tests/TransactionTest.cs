using System;
using Xunit;
using CashRegister.BL.Services;
using CashRegister.BL.Objects;
namespace CashRegister.Tests
{
	public class TransactionTest
	{
		[Fact]
		public void TestChange()
		{
            var trans = new Transaction(5.45m, 6.00m);
            Assert.Equal(trans.AmountChangeCents, 55);
		}

	}
}
