package com.example.cashregister;

import java.text.ParseException;

/**
 * Interface implemented by all Cash Register classes.
 * 
 * @author tivdemo
 *
 */
public interface ICashRegister {
	
	/**
	 * Process the input file.	  
	 * 
	 * @param fileName String - The input file name
	 */
	public void process(String fileName);
	
	/**
	 * Parse the input.
	 * 
	 * @param input String - The input in decimal format.
	 * @return int - The integer value of the input.
	 * 
	 * @throws ParseException on invalid input
	 */
	public int processInput(String input) throws ParseException;
}
