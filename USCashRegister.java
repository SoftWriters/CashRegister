package com.example.cashregister.us;

import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.ParseException;
import java.util.Locale;

import com.example.cashregister.AbstractCashRegister;
import com.example.cashregister.AbstractCurrency;

/**
 * US implementation for Cash Register
 * 
 * @author tivdemo
 *
 */
public class USCashRegister extends AbstractCashRegister {	
	private static DecimalFormat decimalFormat;
	
	static {
		decimalFormat = (DecimalFormat) NumberFormat.getNumberInstance(new Locale("en", "us"));
		decimalFormat.applyPattern("###.##");
		decimalFormat.setRoundingMode(RoundingMode.UP);
	}
	
	public USCashRegister(AbstractCurrency currency) {
		super(currency);
	}
			
	/**
	 * Parse the input. [Convert decimal to integer - # of pennies]
	 * 
	 * @param input String - The input in decimal format.
	 * @return int - The integer value of the input.
	 */
	public int processInput(String input) throws ParseException {
		return new Double(decimalFormat.parse(input).doubleValue() * 100).intValue();
	}
	
	/**
	 * Get the missing parameter error description. Implemented by the subclass. 
	 * 
	 * @param line String  - The line that contains the parameters
	 * 
	 * @return String - The missing parameter error description
	 */	
	public String getMissingParameterError(String line) {
		return String.format("Missing parameter error [%s]", line);
	}
	
	/**
	 * Get the invalid parameter error description. Implemented by the subclass. 
	 * 
	 * @param line String  - The line that contains the parameters
	 * 
	 * @return String - The invalid parameter error description
	 */
	public String getInvalidParameterError(String line) {
		return String.format("Invalid parameter error [%s]", line);
	}
	
	/**
	 * Get the missing file error description. Implemented by the subclass. 
	 * 
	 * @param filePath String  - The file path
	 * 
	 * @return String - The missing parameter error description
	 */
	public String getMissingFileError(String filePath) {
		return String.format("Unable to locate File = [%s]", filePath);
	}
}