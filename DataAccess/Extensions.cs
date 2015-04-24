using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataLayer
{
	public static class Extensions
	{
		public static string Description(this Enum e)
		{
			string value = e.ToString();
			Type type = e.GetType();
			DescriptionAttribute[] descAttribute = (DescriptionAttribute[])type.GetField(value).GetCustomAttributes(typeof(DescriptionAttribute), false);
			return descAttribute.Length > 0 ? descAttribute[0].Description : value;
		}
	}
}
