/**
 * 
 */
package com.example.cashregister;

import java.util.Random;

import com.example.cashregister.util.CashRegisterConstants;
import com.example.cashregister.util.Denomination;

/**
 * @author harithakavuri
 *
 */
public abstract class CashRegisterAbst implements CashRegister{


	/**
	 * @param owed
	 * @param paid
	 * @return change description
	 */
	protected String getCashBack(long owed, long paid) {
		
		long totalChange = paid - owed;
		
		if (totalChange == 0)
			return CashRegisterConstants.EXAXTAMOUNT.getMsg();
		
		if (totalChange < 0)
			return CashRegisterConstants.LESSAMOUNTPAID.getMsg();
		
		return processEachDemomination(totalChange, ((owed % 3) == 0));
	}
	
	
	/**
	 * @param change
	 * @param twist
	 * @return description
	 * Loop through the denominations and check the twist
	 */
	protected String processEachDemomination(long change, boolean twist) {
		StringBuilder sb = new StringBuilder();
		for (Denomination denomination : Denomination.values()) {
			if (change >= denomination.getValue())
			{
				long noOfBills = change / denomination.getValue();
				
				if (noOfBills != 1 && twist && denomination != Denomination.PENNY) 
					noOfBills = new Random().nextInt((int)noOfBills);

				if (noOfBills > 0) {
					if (sb.length() > 0)
						sb.append(", ");
					sb.append(noOfBills);
					sb.append(" ");
					sb.append(Denomination.getDescription(noOfBills, denomination));				
					change -= (denomination.getValue() * noOfBills);
				}
			}
		
		}
	
		return sb.toString();
	}
	

}
