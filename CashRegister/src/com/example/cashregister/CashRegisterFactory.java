/**
 * 
 */
package com.example.cashregister;

import com.example.cashregister.util.CashRegisterConstants;

/**
 * @author harithakavuri
 *
 */
public class CashRegisterFactory {
	public static CashRegister getCashRegister(String type){
		if(type.equalsIgnoreCase(CashRegisterConstants.CSV.getMsg()))
			return new CashRegisterCSV();
		return null;
	}
}
