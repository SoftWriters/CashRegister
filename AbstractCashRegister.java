package com.example.cashregister;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.text.ParseException;
import com.example.cashregister.ICashRegister;

/**
 * Base class for Cash Registers.
 * 
 * @author tivdemo
 *
 */
public abstract class AbstractCashRegister implements ICashRegister {
	private final AbstractCurrency currency;
	
	/**
	 * Constructor
	 * 
	 * @param currency AbstractCurrency - The currency.
	 */
	public AbstractCashRegister(AbstractCurrency currency) {
		this.currency = currency;
	}
	
	/**
	 * Parse the input. Implemented by the subclass. 
	 * 
	 * @param input String - The input in decimal format.
	 * @return int - The integer value of the input.
	 */
	public abstract int processInput(String input) throws ParseException;
	
	/**
	 * Get the missing parameter error description. Implemented by the subclass. 
	 * 
	 * @param line String  - The line that contains the parameters
	 * 
	 * @return String - The missing parameter error description
	 */
	public abstract String getMissingParameterError(String line);
	
	/**
	 * Get the invalid parameter error description. Implemented by the subclass. 
	 * 
	 * @param line String  - The line that contains the parameters
	 * 
	 * @return String - The invalid parameter error description
	 */
	public abstract String getInvalidParameterError(String line);
	
	/**
	 * Get the missing file error description. Implemented by the subclass. 
	 * 
	 * @param filePath String  - The file path
	 * 
	 * @return String - The missing parameter error description
	 */
	public abstract String getMissingFileError(String filePath);
	
	/**
	 * Get change in denominations of the associated currency.
	 * 
	 * @param amountOwed int - The amount owed.
	 * @param amountPaid int - The amount paid
	 * 
	 * @return String- Descriptive string identifying the change to be paid
	 */
	public String getChange(int amountOwed, int amountPaid) {
		int change = amountPaid - amountOwed;
		
		if (change == 0)
			return currency.getNoChangeDescription();
		
		if (change < 0)
			return currency.getAmountPaidLessThanAmountOwed();
		
		return currency.process(change, ((amountOwed % 3) == 0));
	}	
	
	/**
	 * Process the input file.	  
	 * 
	 * @param fileName String - The input file name
	 */
	public void process(String filePath) {
		try (FileInputStream file =  new FileInputStream(new File(filePath));
			 BufferedReader reader = new BufferedReader(new InputStreamReader(file)))
		{
			int amountOwed = 0;
			int amountPaid = 0;
			
			String line = reader.readLine();
			
			while (line != null)
			{				
				if (line.trim().length() == 0)
					System.out.println("");				// Skip blank lines
				else if (line.charAt(0) == '*') 	
					System.out.println(line);			// Skip comment lines
				else {
					String[] input = line.split(",");
					
					if (input.length != 2)
						System.out.println(String.format("%s", getMissingParameterError(line)));
					else {
						try {
							amountOwed = processInput(input[0].trim());
							amountPaid = processInput(input[1].trim());
							System.out.println(getChange(amountOwed, amountPaid));
						}
						catch (ParseException ex){
							System.out.println(String.format("%s", getInvalidParameterError(line)));
						}
					}					
				}
				
				line = reader.readLine();
			}
		}
		catch (Exception ex) {
			System.out.println(String.format("%s", getMissingFileError(filePath)));
			System.exit(16);
		}
	}		
}

