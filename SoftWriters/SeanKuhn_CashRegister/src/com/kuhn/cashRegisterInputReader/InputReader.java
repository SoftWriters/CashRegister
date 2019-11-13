package com.kuhn.cashRegisterInputReader;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

/**
 * The InputReader class contains methods for locating and parsing .csv files.
 * 
 * @author 	Sean Kuhn
 * @Date	10/31/2019
 *
 */
public class InputReader {
	private String path;
	
	
	public InputReader(String path) throws FileNotFoundException {
		this.path = path;
		
	}

	public int getLines() throws IOException {
		
		int lines = 0;
		File file = new File(this.path);
		FileReader fileReader = new FileReader(file);
		BufferedReader bufferedReader = new BufferedReader(fileReader);
		while(bufferedReader.readLine() != null) lines++;
		bufferedReader.close();
		fileReader.close();
		return lines;
	}
	
	/**
	 * The readFile method reads a csv file into a string array.
	 * 
	 * @return	Returns a string array.
	 * @throws 	IOException
	 */
	public String[] readFile() throws IOException {
		
		int lines = this.getLines();
		String[] csv = new String[lines];
		File file = new File(this.path);
		FileReader fileReader = new FileReader(file);
		BufferedReader bufferedReader = new BufferedReader(fileReader);
				
		for(int i = 0; i < lines; i++) {
			csv[i] = bufferedReader.readLine();
		}
				
		bufferedReader.close();
		fileReader.close();
		return csv;
	}
	
	/**
	 * The getTraansactions method takes the string array from readFile, and parses the entire transaction set into a 2d array.
	 * 
	 * @return	Returns a 2d double array.
	 * @throws 	IOException
	 */
	public double[][] getTransactions() throws IOException{
		String[] csv = readFile();
		double[][] transactions = new double[csv.length][2];
		for(int i = 0; i < csv.length; i++) {
			String[] line = csv[i].split(",");
			transactions[i][0] = Double.valueOf(line[0]);
			transactions[i][1] = Double.valueOf(line[1]);
		}
		return transactions;
	}
}
