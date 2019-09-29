package resources.javafiles;
import java.util.*;
import java.text.*;
import java.math.*;
/**
 * CashRegister computes the change due back to a customer given a price and a tendered amount.
 * This implementation of CashRegister utilizes unit of currency "US cents" 
 * (100 US cents = 1 US dollar). Values therefore must be converted to US cents prior to use of
 * this implementation of the class CashRegister. Change is exported as denominations of:
 * US dollars, quarters, dimes, nickels, and pennies.<br>
 * Version 1.0 (this) intentionally has no modifier for "package-protected" access privileges. 
 * <p>
 * This implementation of class CashRegister has two primary functions to compute change:
 * <ol>
 * <li>If the amount due (price) in the transaction is a multiple of $0.03 (3 cents), 
 * CashRegister will return the change due in random denominations of change using java.util.Random
 * <li>Otherwise, CashRegister will return the minimum amount of physical change.
 * </ol> <br>
 * By design, this method operates recursively rather than iteratively to favor faster runtime 
 * because (in a real world scenario):<br><br>
 * <ul>
 * <li>A cashier is much more likely to make next-dollar change or break the next highest bill 
 * than ask a cashier for thousands of dollars in change in one dollar bills or coins. 
 * <li>A typical cash drawer has a limited capacity for several reasons:
 * <ul> 
 * <li> To minimize losses from theft, cash drawers purposefully only contain a limited amount 
 * of change based on the industry, daily sales, time of day, etc.
 * <li>Even more practically speaking, change of more than $1000 or so would be more of a banking 
 * transaction beyond the scope of this implementation focusing on Point of Sale (POS) 
 * transactions.
 * </ul></ul><br>
 * To overcome StackOverflowError produced in these unlikely cases, if the change due is more 
 * than $5000, the customer is given 5000 one dollar bills in a single recursive instance for the 
 * optimal change-making function and 3500 one-dollar bills for the random change-making function. 
 * Likewise, while CashRegister can take parameters of any positive int primitive, change that can 
 * be calculated is limited to $1million. For ease of locating offending lines in the input file,
 * the change limit of $1million was implemented in CashRegisterIO rather than CashRegister. 
 * Greater change due amounts are skipped when writing to output and an error is printed to screen.
 * 
 * @author 	Zach Grimaldi, zpg6@pitt.edu, zachgrimaldi.com
 * @version 1.0
 * @since 	2019-09-29
 * @see 	java.util.Random
 */
class CashRegister {
	
	private final int DOLLAR = 100;
	private final int QUARTER = 25;
	private final int DIME = 10;
	private final int NICKEL = 5;
	private final int PENNY = 1;
	private Random generator = new Random();
	
	/**
	 * CashRegister is initialized in an empty constructor (no parameters required).
	 * Once instantiated, CashRegister has one public method "getChange" for use in this
	 * specific implementation given its two primary functions. 
	 */
	CashRegister() {}
	
	/**
	 * Change is a non-static inner class of CashRegister. 
	 * As a security mechanism, this inner class is made private
	 * to abstract away the methodology of the change computation.
	 */
	private class Change {
		
		int price, tendered, changeDue;						// inputs
		int dollars, quarters, dimes, nickels, pennies;		// outputs
		
		/**
		 * Change is initialized in its only constructor with a transaction's total due 
		 * and amount tendered. The constructor also calculates and stores changeDue.
		 * @param price This is the total of the transaction due by the customer in US cents
		 * @param tendered This is the total amount given to the cashier by the customer in US 
		 * cents
		 */
		private Change(int price, int tendered) {
			
			this.price = price;			
			this.tendered = tendered;
			this.changeDue = tendered - price;
		} // end Change constructor
	} // end private inner-class Change 

	/**
	 * This method and the CashRegister constructor have no-modifier access for intended
	 * "package-protected" access privileges. <br>
	 * getChange takes two parameters (price and tendered) and returns a String of the change due 
	 * in denominations according to:
	 * <ol>
	 * <li>If the amount due (price) in the transaction is a multiple of $0.03 (3 cents), 
	 * CashRegister will return a String of the change due in RANDOM denominations of physical 
	 * change.
	 * <li>Otherwise, CashRegister will return a String of the minimum amount of physical change.
	 * </ol><br>
	 * In preventing StackOverflowError, getChange will skip transactions with change greater than 
	 * $1million and return an empty String "" to symbolize a skip.
	 * 
	 * @param price This is the total of the transaction due by the customer 
	 * @param tendered This is the total amount given to the cashier by the customer in US 
	 * cents
	 * @return String This returns a String of the denominations of change to be given back to the 
	 * customer. An empty string will be returned if change over $1million is attempted.
	 */	
	String getChange(int price, int tendered) {
		
		if (tendered-price > 100000000) {		// this is a fail-safe control statement
			return "";							// that should previously have been handled per 
		}										// method description, but prevent an Exception 
		boolean isRandom = (price%3==0);
		Change c = new Change(price,tendered);
		if (isRandom) {
			c = getRandomChange(c);
		}
		else {
			c = getOptimalChange(c);
		}
		return printChange(c);
	} // end public String getChange(int price, int tendered)
	
	/**
	 * getOptimalChange takes an instance of Change as a parameter. This instance of Change does 
	 * not yet have any of its output variables (dollars, quarters, dimes, nickels, pennies) 
	 * incremented. This method then returns the same instance of Change with denominations of the 
	 * minimum amount of physical change now filled in. 	 
	 *  
	 * @param c instance of inner-class Change that needs to be evaluated for optimal change
	 * @return c the same instance of inner-class Change that has been evaluated for optimal change
	 */
	private Change getOptimalChange(Change c) {
		
		if (c.changeDue <=0) {
			return c;
		}
		else if (c.changeDue >=(5000*DOLLAR)) {		
			c.dollars += 5000;						
			c.changeDue -= (5000*DOLLAR);
		}
		else if (c.changeDue >=DOLLAR) {
			c.dollars++;
			c.changeDue -= DOLLAR;
		}
		else if (c.changeDue >=QUARTER) {
			c.quarters++;
			c.changeDue -= QUARTER;
		}
		else if (c.changeDue >=DIME) {
			c.dimes++;
			c.changeDue -= DIME;
		}
		else if (c.changeDue >=NICKEL) {
			c.nickels++;
			c.changeDue -= NICKEL;
		}
		else if (c.changeDue >=PENNY) {
			c.pennies++;
			c.changeDue -= PENNY;
		}
		return getOptimalChange(c);	
	} // end private Change getOptimalChange(Change c)
	
	/**
	 * getRandomChange takes an instance of Change as a parameter. This instance of Change does 
	 * not yet have any of its output variables (dollars, quarters, dimes, nickels, pennies) 
	 * incremented. This method then returns the same instance of Change with random denominations 
	 * of change. Some, but not all, randomness is sacrificed for faster runtime for values of 
	 * change due greater than $5000.
	 *  
	 * @param c instance of inner-class Change that needs to be evaluated for optimal change
	 * @return c the same instance of inner-class Change that has been evaluated for optimal change
	 */
	private Change getRandomChange(Change c) {

		int randomValue = generator.nextInt(4);	// generates random value [0,4] <--inclusive
		if (c.changeDue <=0) {
			return c;
		}
		else if (c.changeDue >=(5000*DOLLAR)) {		
			c.dollars += 3500;						
			c.changeDue -= (3500*DOLLAR);			
		}											
		switch (randomValue) {						
			case 0:									
				if (c.changeDue >= DOLLAR) {		
					c.dollars++;					
					c.changeDue -= DOLLAR;			
				}									
			case 1:									
				if (c.changeDue >= QUARTER) {
					c.quarters++;
					c.changeDue -= QUARTER;
				}
			case 2:
				if (c.changeDue >= DIME) {
					c.dimes++;
					c.changeDue -= DIME;
				}
			case 3:
				if (c.changeDue >= NICKEL) {
					c.nickels++;
					c.changeDue -= NICKEL;
				}
			case 4:
				if (c.changeDue >= PENNY) {
					c.pennies++;
					c.changeDue -= PENNY;
				}
		}	
		return getRandomChange(c);		
	} // end private Change getRandomChange(Change c)
	
	/**
	 * printChange takes an instance of Change as a parameter. This instance of Change already 
	 * has its output variables (dollars, quarters, dimes, nickels, pennies) filled in.
	 * This method returns a String of these denominations and prevents extraneous commas, ensures 
	 * correct singular or plural nouns for denominations, and only includes non-zero values. 
	 * Some, but not all, randomness is sacrificed for faster runtime for values of 
	 * change due greater than $5000.
	 *  
	 * @param c instance of inner-class Change that has denominations to be formatted as a String
	 * @return String This is the formatted String specific to this implementation of CashRegister
	 */
	private String printChange(Change c) {
		
		StringBuilder result = new StringBuilder();
		if (c.dollars>1) {
			result.append(c.dollars);
			result.append(" dollars");
		}
		else if (c.dollars==1) {
			result.append(c.dollars);
			result.append(" dollar");
		}	
		if (c.quarters>1) {
			if (c.dollars>=1) {
				result.append(",");
			}
			result.append(c.quarters);
			result.append(" quarters");
		}
		else if (c.quarters==1) {
			if (c.dollars>=1) {
				result.append(",");
			}
			result.append(c.quarters);
			result.append(" quarter");
		}	
		if (c.dimes>1) {
			if (c.dollars>=1 || c.quarters>=1) {
				result.append(",");
			}
			result.append(c.dimes);
			result.append(" dimes");
		}
		else if (c.dimes==1) {
			if (c.dollars>=1 || c.quarters>=1) {
				result.append(",");
			}
			result.append(c.dimes);
			result.append(" dime");
		}	
		if (c.nickels>1) {
			if (c.dollars>=1 || c.quarters>=1 || c.dimes>=1) {
				result.append(",");
			}
			result.append(c.nickels);
			result.append(" nickels");
		}
		else if (c.nickels==1) {
			if (c.dollars>=1 || c.quarters>=1 || c.dimes>=1) {
				result.append(",");
			}
			result.append(c.nickels);
			result.append(" nickel");
		}		
		if (c.pennies>1) {
			if (c.dollars>=1 || c.quarters>=1 || c.dimes>=1 || c.nickels>=1) {
				result.append(",");
			}
			result.append(c.pennies);
			result.append(" pennies");
		}
		else if (c.pennies==1) {
			if (c.dollars>=1 || c.quarters>=1 || c.dimes>=1 || c.nickels>=1) {
				result.append(",");
			}
			result.append(c.pennies);
			result.append(" penny");
		}
		return result.toString();
	} // end String printChange(Change c);
} // EOF class CashRegister