using System;
using Xunit;
using CashRegister.BL.Services;
using CashRegister.BL.Objects;
using CashRegister.BL;
using CashRegister.BL.Reducers;

namespace CashRegister.Tests
{
	public class ComputeTest
	{
		[Fact]
		public void TestMinComputeLessThanZero()
		{
			var service = new ChangeGenerator();
			Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => service.ComputeChange(-1, (list) => 
                {
					var reducer = new MinReducer();
                    return reducer.Reduce(list);
                }));
		}

		[Fact]
		public void TestMinComputePassOne()
		{
			var service = new ChangeGenerator();
			var result = service.ComputeChange(103, (list) => 
                {
					var reducer = new MinReducer();
                    return reducer.Reduce(list);
                });
			Assert.Equal(result.TotalCoins, 4);
		}

		[Fact]
		public void TestGetReducerRandom() 
		{
			var mock = new MockFile();
			var register = new Register(mock, mock);
			var reducer = register.GetReducer(3);
			Assert.IsType<RandomReducer>(reducer);
		}
		[Fact]
		public void TestGetReducerMin() 
		{
			var mock = new MockFile();
			var register = new Register(mock, mock);
			var reducer = register.GetReducer(1);
			Assert.IsType<MinReducer>(reducer);
			
		}

	}
}
