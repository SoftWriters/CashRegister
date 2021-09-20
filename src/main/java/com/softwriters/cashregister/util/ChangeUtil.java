package com.softwriters.cashregister.util;

import java.math.BigDecimal;

import com.softwriters.cashregister.model.ChangeModel;

public class ChangeUtil {

	public static ChangeModel[] change= {new ChangeModel("100.00","one-hundred dollar bill", "one-hundred dollar bills"), 
			new ChangeModel("50.00","fifty dollar bill", "fifty dollar bills"),
			new ChangeModel("20.00","twenty dollar bill", "twenty dollar bills"), 
			new ChangeModel("10.00","ten dollar bill", "ten dollar bills"), 
			new ChangeModel("5.00","five dollar bill", "five dollar bills"),
			new ChangeModel("1.00","dollar", "dollars"), new ChangeModel("0.25","quarter", "quarters"), new ChangeModel("0.10","dime", "dimes"),
			new ChangeModel("0.05","nickel", "nickels"), new ChangeModel("0.01","penny", "pennies")};
	
	public static BigDecimal zero = new BigDecimal("0.00");
}
