package com.example.cashregister;

import java.util.Random;

/**
 * The class representing a single denomination of a currency.
 * 
 * @author tivdemo
 *
 */
public class Denomination {
	private final String pluralDescription;
	private final String singularDescription;
	private final int denomination;
		
	private Random rand = new Random();
	
	/**
	 * Constructor
	 * 
	 * @param singularDescription String - The singular description for the given amount
	 * @param pluralDescription String  - The plural description for the given amount
	 * @param denomination int - The amount [denomination]
	 */
	public Denomination(String singularDescription, String pluralDescription, int denomination)
	{
		this.singularDescription = singularDescription;
		this.pluralDescription = pluralDescription;
		this.denomination = denomination;
	}	
	
	/**
	 * Gets the descriptive string for the given units [singular or plural]
	 * 
	 * @param units int - The number of units. 
	 * @return String - The descriptive string.
	 */
	private String getDescription(int units) {
		if (units == 1)
			return singularDescription;
		else
			return pluralDescription;
	}
	
	/**
	 * Process the change amount and generate a descriptive string in the associated currency
	 * for up to the given amount.  Calculates the maximum number of units in the denomination
	 * for the amount.  If the random flag is set then the number of units is calculated as a random 
	 * integer from zero to the maximum number of units in the denomination for the amount. If 
	 * the last flag is set, this indicates that this denomination is the last [smallest] denomination 
	 * for the currency.  The last flag overrides the random flag and calculates the number of units 
	 * for the remaining amount.
	 * 
	 * @param change int - The amount to process.
	 * @param sb StringBuilder - The container of the descriptive string.
	 * @param random boolean - The random flag.
	 * @param last boolean - The last flag.
	 * 
	 * @return int - The remaining amount after processing this denomination.
	 */
	public int process(int change, StringBuilder sb, boolean random, boolean last)
	{		
		if (change > this.denomination)
		{
			int units = change / denomination;
			
			if (random && !last) 
				units = rand.nextInt(units);

			if (units > 0) {
				if (sb.length() > 0)
					sb.append(", ");
				
				sb.append(units);
				sb.append(" ");
				sb.append(getDescription(units));				
				
				change -= (denomination * units);
			}
		}
		
		return change;	
	}
}
