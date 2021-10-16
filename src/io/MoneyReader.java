package io;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

/**
 * The MoneyReader class reads in all the prices and payments into the project
 * 
 * @author chasekeady
 *
 */
public class MoneyReader {
	
	private BufferedReader in;
	
	/**
	 * Standard constructor for creating a MoneyReader
	 * 
	 * @param fileName - the name of the file that will be read from 
	 * @throws FileNotFoundException
	 */
	public MoneyReader(String fileName) throws FileNotFoundException {
		in = new BufferedReader(new FileReader(fileName));
	}
	
	/**
	 * Reads in a line from the file
	 * 
	 * @throws IOException
	 */
	public String readPayment() throws IOException {
		String line  = in.readLine();
		return  line;

	}
	
	/**
	 * Closes the MoneyReader instance
	 * 
	 * @throws IOException
	 */
	public void close() throws IOException {
		in.close();
	}
}
