package com.kuhn.cashRegisterInputReader;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;

/**
 * The OutputWriter class takes a writes a string to a specified path
 * 
 * @author 	Sean Kuhn
 * @Date	11/03/2019
 *
 */
public class OutputWriter {
	private String output;
	private String path;
	
	public OutputWriter(String output, String path) {
		this.output = output;
		this.path = path;
	}
	
	/**
	 * The writeResults method writes an entire batch of change instructions to the output path.
	 * 
	 * @throws IOException
	 */
	public void writeResults() throws IOException 
	{
	    String output = this.output;
	     
	    BufferedWriter writer = new BufferedWriter(new FileWriter(this.path));
	    writer.write(output);
	    writer.close();
	}
}
