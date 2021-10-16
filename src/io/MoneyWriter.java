package io;

import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

public class MoneyWriter {
	
	private PrintWriter out;
	
	public MoneyWriter(String fileName) throws IOException{
		out = new PrintWriter(new FileWriter(fileName));
	}
	
	public void writeChange(String output) {
		out.println(output);
	}
	
	public void close() throws IOException {
		out.close();
	}
}
