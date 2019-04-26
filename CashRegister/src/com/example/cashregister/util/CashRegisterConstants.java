/**
 * 
 */
package com.example.cashregister.util;

/**
 * @author harithakavuri
 *
 */
public enum CashRegisterConstants {

	MISSINGAMOUNTS("Missing amounts error"),
	INVALIDMONEY("Invalid data entered. Not valid money."),
	INVALIPAIDDMONEY("Invalid Paid Amount."),
	INVALIDOWEDMONEY("Invalid Owed Money."),
	EXAXTAMOUNT("Paid is equal to owed."),
	LESSAMOUNTPAID("Transaction not completed. Amount still owed"),
	FILENOTFOUND("File not found."),
	OUTPUTFILENAME("out.txt"),
	EMPTYLINE("empty"),
	INPUTFILENAME("input.txt"),
	INPUT("inFile"),
	OUTPUT("outFile"),
	CSV("csv");
	
	private final String msg;
	private CashRegisterConstants(String msg) {
		this.msg = msg;
	}
	public String getMsg() {
		return msg;
	}
}
