package com.example.cashregister;

/**
 * Base class for Currency.
 * 
 * @author tivdemo
 *
 */
public abstract class AbstractCurrency {
	/**
	 * The denominations for the associated currency.
	 */
	private static Denomination[] denominations;
	
	/**
	 * Get the denominations for the associated currency - implemented by the subclass.
	 * 
	 * @return Denomination[] The list of denominations.
	 */
	public abstract Denomination[] getDenominations();
	
	/**
	 * Get the description when no change is due.
	 * 
	 * @return String - The description 
	 */
	public abstract String getNoChangeDescription();
	
	/**
	 * Get the description when the amount paid is less than the amount due.
	 * 
	 * @return String - The description 
	 */
	public abstract String getAmountPaidLessThanAmountOwed();
	
	public AbstractCurrency() {
		denominations = getDenominations();
	}
		
	/**
	 * Process the given amount and generate a descriptive string identifying
	 * the denominations in the associated currency for the given amount.  The random
	 * flag is passed through to the denomination. 
	 * 
	 * @param amount int - The amount.
	 * @param random boolean - The random flag.
	 * 
	 * @return String - The descriptive string. 
	 */
	public String process(int amount, boolean random) {
		StringBuilder sb = new StringBuilder();		
		
		for (int i = 0; i < denominations.length && amount > 0; i++) 
			amount = denominations[i].process(amount, sb, random, (i == denominations.length - 1));
		
		return sb.toString();
	}
}
