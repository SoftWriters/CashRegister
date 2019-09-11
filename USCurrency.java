package com.example.cashregister.us;

import com.example.cashregister.AbstractCurrency;
import com.example.cashregister.Denomination;

/**
 * US implementation for Currency
 * 
 * @author tivdemo
 *
 */
public class USCurrency extends AbstractCurrency {
	//
	// US Denominations [Limit to $20 for this test]
	//
	public static final String TWENTY_DOLLARS_SINGULAR_DESCRIPTION = "Twenty Dollar Bill";
	public static final String TEN_DOLLARS_SINGULAR_DESCRIPTION = "Ten Dollar Bill";
	public static final String FIVE_DOLLARS_SINGULAR_DESCRIPTION = "Five Dollar Bill";
	public static final String ONE_DOLLARS_SINGULAR_DESCRIPTION = "Dollar Bill";
	
	public static final String QUARTERS_SINGULAR_DESCRIPTION = "Quarter";
	public static final String DIMES_SINGULAR_DESCRIPTION = "Dime";
	public static final String NICKLES_SINGULAR_DESCRIPTION = "Nickle";
	public static final String PENNIES_SINGULAR_DESCRIPTION = "Penny";
	
	public static final String TWENTY_DOLLARS_PLURAL_DESCRIPTION = "Twenty Dollar Bills";
	public static final String TEN_DOLLARS_PLURAL_DESCRIPTION = "Ten Dollar Bills";
	public static final String FIVE_DOLLARS_PLURAL_DESCRIPTION = "Five Dollar Bills";
	public static final String ONE_DOLLARS_PLURAL_DESCRIPTION = "Dollar Bills";
	
	public static final String QUARTERS_PLURAL_DESCRIPTION = "Quarters";
	public static final String DIMES_PLURAL_DESCRIPTION = "Dimes";
	public static final String NICKLES_PLURAL_DESCRIPTION = "Nickles";
	public static final String PENNIES_PLURAL_DESCRIPTION = "Pennies";
	
	public static final String NO_CHANGE_DESCRIPTION = "No change due";
	public static final String PAID_LT_OWED_DESCRIPTION = "Error: The amount paid is less than the amount due";
		
	public static final int TWENTY_DOLLAR_VALUE = 2000;
	public static final int TEN_DOLLAR_VALUE = 1000;
	public static final int FIVE_DOLLAR_VALUE = 500;
	public static final int ONE_DOLLAR_VALUE = 100;
		
	public static final int QUARTER_VALUE = 25;
    public static final int DIME_VALUE = 10;
    public static final int NICKEL_VALUE = 5;
    public static final int PENNY_VALUE = 1;    
        
    /**
     * 
     * Get the list of denominations for the currency.
     * 
     * @return Denomination[] The list of denominations.
	 */
	public Denomination[] getDenominations()
	{		
		Denomination[] denominations = new Denomination[8];
		denominations[0] = new Denomination(TWENTY_DOLLARS_SINGULAR_DESCRIPTION, TWENTY_DOLLARS_PLURAL_DESCRIPTION, TWENTY_DOLLAR_VALUE);
		denominations[1] = new Denomination(TEN_DOLLARS_SINGULAR_DESCRIPTION, TEN_DOLLARS_PLURAL_DESCRIPTION, TEN_DOLLAR_VALUE);
		denominations[2] = new Denomination(FIVE_DOLLARS_SINGULAR_DESCRIPTION, FIVE_DOLLARS_PLURAL_DESCRIPTION, FIVE_DOLLAR_VALUE);
		denominations[3] = new Denomination(ONE_DOLLARS_SINGULAR_DESCRIPTION, ONE_DOLLARS_PLURAL_DESCRIPTION, ONE_DOLLAR_VALUE);
		denominations[4] = new Denomination(QUARTERS_SINGULAR_DESCRIPTION, QUARTERS_PLURAL_DESCRIPTION, QUARTER_VALUE);
		denominations[5] = new Denomination(DIMES_SINGULAR_DESCRIPTION, DIMES_PLURAL_DESCRIPTION, DIME_VALUE);
		denominations[6] = new Denomination(NICKLES_SINGULAR_DESCRIPTION, NICKLES_PLURAL_DESCRIPTION, NICKEL_VALUE);
		denominations[7] = new Denomination(PENNIES_SINGULAR_DESCRIPTION, PENNIES_PLURAL_DESCRIPTION, PENNY_VALUE);
		
		return denominations;
	}
	
	public String getNoChangeDescription() {
		return NO_CHANGE_DESCRIPTION;
	}
	
	public String getAmountPaidLessThanAmountOwed() {
		return PAID_LT_OWED_DESCRIPTION;
	}
}
