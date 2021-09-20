package com.softwriters.cashregister.service;

import java.math.BigDecimal;
import java.util.HashSet;

import com.softwriters.cashregister.util.ChangeUtil;

public class ChangeProcessingService {
	
	public ChangeProcessingService() {
		
	}
	
	public String calculateChange(BigDecimal totalDue, BigDecimal amountGiven) {
		
		String change = "";
		//Determine change needed
		BigDecimal changeNeeded = amountGiven.subtract(totalDue);
		
		for(int i=0;i<ChangeUtil.change.length;i++) {
			
			int numberOfChange = 0;
			
			//iterate from highest change value to lowest and subtract till less than zero or zero		
			while((changeNeeded.subtract(ChangeUtil.change[i].getValue()).compareTo(ChangeUtil.zero)==1)||
					(changeNeeded.subtract(ChangeUtil.change[i].getValue()).compareTo(ChangeUtil.zero)==0)) {
				
				//track number of change denominations and subtract from total change required
				numberOfChange++;
				changeNeeded = changeNeeded.subtract(ChangeUtil.change[i].getValue());
			}
			//create strings for change based on number of change denominations
			if(numberOfChange>0)
				change += numberOfChange + " " + ChangeUtil.change[i].getCurrencyName(numberOfChange) + ",";
			
			
		}
		
		return change.substring(0, change.length()-1);
	}
	
	public String calculateRandomChange(BigDecimal totalDue, BigDecimal amountGiven) {
		
		String change = "";
		
		//Determine change needed
		BigDecimal changeNeeded = amountGiven.subtract(totalDue);
		
		//Create a hash set to keep track of used change value indexes
		HashSet<Integer> indexSet = new HashSet<>();
		
		//While all denominations haven't been used and change needed isn't zero
		while(indexSet.size()!=ChangeUtil.change.length && changeNeeded.compareTo(ChangeUtil.zero)!= 0) {
			
			//generate random index
			int randomIndex = generateRandomIndex();
			
			//check to see if random index already used; if so re-calculate till find one
			while(indexSet.contains(randomIndex)) {
				randomIndex = generateRandomIndex();
			}
			
			int numberOfChange = 0;
			
			//subtract change till at zero or less than zero
			while((changeNeeded.subtract(ChangeUtil.change[randomIndex].getValue()).compareTo(ChangeUtil.zero)==1)||
					(changeNeeded.subtract(ChangeUtil.change[randomIndex].getValue()).compareTo(ChangeUtil.zero)==0)) {
				
				numberOfChange++;
				changeNeeded = changeNeeded.subtract(ChangeUtil.change[randomIndex].getValue());
			}
			
			if(numberOfChange>0)
				change += numberOfChange + " " + ChangeUtil.change[randomIndex].getCurrencyName(numberOfChange) + ",";
			
			//Add index to set
			indexSet.add(randomIndex);
		}

		
		return change.substring(0, change.length()-1);
	}
	
	private int generateRandomIndex() {
		int random = (int)(Math.random() * ChangeUtil.change.length);
		return random;
	}
}
