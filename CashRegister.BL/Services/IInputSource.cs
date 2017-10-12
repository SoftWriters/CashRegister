using System;
using System.Collections.Generic;
using CashRegister.BL.Objects;
namespace CashRegister.BL.Services
{
	public interface IInputSource
	{
		IEnumerable<Transaction> LoadData();
	}
}
