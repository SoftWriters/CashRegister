using System;
using System.Collections.Generic;
using CashRegister.BL.Objects;
namespace CashRegister.BL.Services
{
	public interface IOutputSource
	{
		bool SaveData(IList<Denomination> dataList);
	}
}
