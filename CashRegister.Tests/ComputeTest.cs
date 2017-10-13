using System;
using Xunit;
using CashRegister.BL.Services;
using CashRegister.BL.Objects;
namespace CashRegister.Tests
{
	public class ComputeTest
	{
		[Fact]
		public void TestMinComputeLessThanZero()
		{
			var service = new MinChangeGenerator();
			Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => service.ComputeChange(-1));
		}

		[Fact]
		public void TestMinComputePassOne()
		{
			var service = new MinChangeGenerator();
			var result = service.ComputeChange(103);
			Assert.Equal(result.TotalCoins, 4);
		}

	}
}
