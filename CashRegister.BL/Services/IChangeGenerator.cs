using System;
using System.Collections.Generic;
using CashRegister.BL.Objects;
namespace CashRegister.BL.Services
{
	public interface IChangeGenerator
	{
		Denomination ComputeChange(int totalCents, Func<IList<Denomination>, Denomination> reducer);
	}
}
