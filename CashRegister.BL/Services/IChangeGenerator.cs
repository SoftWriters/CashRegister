using System;
using CashRegister.BL.Objects;
namespace CashRegister.BL.Services
{
	public interface IChangeGenerator
	{
		Denomination ComputeChange(int totalCents);
	}
}
