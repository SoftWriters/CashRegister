package com.softwriters.cashregister.service;

import java.math.BigDecimal;
import java.util.HashSet;

public class ChangeProcessingService {

	private final BigDecimal[] changeValues = {new BigDecimal("1.00"),new BigDecimal("0.25"),
			new BigDecimal("0.10"), new BigDecimal("0.05"), new BigDecimal("0.01")};
	
	private final String[] changeStringSingle = {"dollar", "quarter","dime", "nickel","penny"};
	private final String[] changeStringPlural = {"dollars", "quarters","dimes", "nickels","pennies"};
	
	private final BigDecimal zero = new BigDecimal("0.00");
	
	public String calculateChange(BigDecimal totalDue, BigDecimal amountGiven) {
		
		String change = "";
		
		BigDecimal changeNeeded = amountGiven.subtract(totalDue);
		
		for(int i=0;i<changeValues.length;i++) {
			
			int numberOfChange = 0;
					
			while((changeNeeded.subtract(changeValues[i]).compareTo(zero)==1)||
					(changeNeeded.subtract(changeValues[i]).compareTo(zero)==0)) {
				
				numberOfChange++;
				changeNeeded = changeNeeded.subtract(changeValues[i]);
			}
			
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
		
		BigDecimal changeNeeded = amountGiven.subtract(totalDue);
		
		HashSet<Integer> indexSet = new HashSet<>();
		
		while(indexSet.size()!=changeValues.length && changeNeeded.compareTo(zero)!= 0) {
			
			int randomIndex = generateRandomIndex();
			
			while(indexSet.contains(randomIndex)) {
				randomIndex = generateRandomIndex();
			}
			
			int numberOfChange = 0;
			
			while((changeNeeded.subtract(changeValues[randomIndex]).compareTo(zero)==1)||
					(changeNeeded.subtract(changeValues[randomIndex]).compareTo(zero)==0)) {
				
				numberOfChange++;
				changeNeeded = changeNeeded.subtract(changeValues[randomIndex]);
			}
			
			if(numberOfChange == 1) {
				change += numberOfChange + " " + changeStringSingle[randomIndex] + ",";
			}
			else if (numberOfChange>1) {
				change += numberOfChange + " " + changeStringPlural[randomIndex] + ",";
			}	
			
			indexSet.add(randomIndex);
		}

		
		return change;
	}
	
	private int generateRandomIndex() {
		int random = (int)(Math.random() * changeValues.length);
		return random;
	}
}
