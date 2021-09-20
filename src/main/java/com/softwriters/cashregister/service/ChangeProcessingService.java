package com.softwriters.cashregister.service;

import java.math.BigDecimal;
import java.util.HashSet;

public class ChangeProcessingService {

	private final BigDecimal[] changeValues = {new BigDecimal("1.00"),new BigDecimal("0.25"),
			new BigDecimal("0.10"), new BigDecimal("0.05"), new BigDecimal("0.01")};
	
	private final String[] changeStringSingle = {"dollar", "quarter","dime", "nickel","penny"};
	private final String[] changeStringPlural = {"dollars", "quarters","dimes", "nickels","pennies"};
	
	private final BigDecimal zero = new BigDecimal("0.00");
	
	public ChangeProcessingService() {
		
	}
	
	public String calculateChange(BigDecimal totalDue, BigDecimal amountGiven) {
		
		String change = "";
		//Determine change needed
		BigDecimal changeNeeded = amountGiven.subtract(totalDue);
		
		for(int i=0;i<changeValues.length;i++) {
			
			int numberOfChange = 0;
			
			//iterate from highest change value to lowest and subtract till less than zero or zero		
			while((changeNeeded.subtract(changeValues[i]).compareTo(zero)==1)||
					(changeNeeded.subtract(changeValues[i]).compareTo(zero)==0)) {
				
				//track number of change denominations and subtract from total change required
				numberOfChange++;
				changeNeeded = changeNeeded.subtract(changeValues[i]);
			}
			//create strings for change based on number of change denominations
			if(numberOfChange == 1) {
				change += numberOfChange + " " + changeStringSingle[i] + ",";
			}
			else if (numberOfChange>1) {
				change += numberOfChange + " " + changeStringPlural[i] + ",";
			}
			
		}
		
		return change;
	}
	
	public String calculateRandomChange(BigDecimal totalDue, BigDecimal amountGiven) {
		
		String change = "";
		
		//Determine change needed
		BigDecimal changeNeeded = amountGiven.subtract(totalDue);
		
		//Create a hash set to keep track of used change value indexes
		HashSet<Integer> indexSet = new HashSet<>();
		
		//While all denominations haven't been used and change needed isn't zero
		while(indexSet.size()!=changeValues.length && changeNeeded.compareTo(zero)!= 0) {
			
			//generate random index
			int randomIndex = generateRandomIndex();
			
			//check to see if random index already used; if so re-calculate till find one
			while(indexSet.contains(randomIndex)) {
				randomIndex = generateRandomIndex();
			}
			
			int numberOfChange = 0;
			
			//subtract change till at zero or less than zero
			while((changeNeeded.subtract(changeValues[randomIndex]).compareTo(zero)==1)||
					(changeNeeded.subtract(changeValues[randomIndex]).compareTo(zero)==0)) {
				
				numberOfChange++;
				changeNeeded = changeNeeded.subtract(changeValues[randomIndex]);
			}
			
			//create change strings
			if(numberOfChange == 1) {
				change += numberOfChange + " " + changeStringSingle[randomIndex] + ",";
			}
			else if (numberOfChange>1) {
				change += numberOfChange + " " + changeStringPlural[randomIndex] + ",";
			}	
			
			//Add index to set
			indexSet.add(randomIndex);
		}

		
		return change;
	}
	
	private int generateRandomIndex() {
		int random = (int)(Math.random() * changeValues.length);
		return random;
	}
}
