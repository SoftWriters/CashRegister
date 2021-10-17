package io;

import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

public class MoneyWriter {
	
	private PrintWriter out;
	
	/**
	 * Standard constructor for creating a MoneyWriter
	 * 
	 * @param fileName - the name of the new file 
	 * @throws IOException
	 */
	public MoneyWriter(String fileName) throws IOException{
		out = new PrintWriter(new FileWriter(fileName));
	}
	
	/**
	 * Writes a line to the new file
	 */
	public void writeChange(String output) {
		out.println(output);
	}
	
	/**
	 * Closes the MoneyWriter instance
	 * 
	 * @throws IOException
	 */
	public void close() throws IOException {
		out.close();
	}
}
