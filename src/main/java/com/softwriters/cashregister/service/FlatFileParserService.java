package com.softwriters.cashregister.service;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.math.BigDecimal;
import java.util.Scanner;

public class FlatFileParserService {
	
	public FlatFileParserService() {
		
	}
	
	public File processFile(File inputFile) throws IOException {
		
		//Create Change Processing Service
		ChangeProcessingService changeProcessor = new ChangeProcessingService();
		
		//Scan in the input file
		Scanner readFile = new Scanner(inputFile);
		
		//Create an output file
		File output = new File("output.txt");
		output.createNewFile();
		
		//Create a file writer to write to output file
		FileWriter fileWriter = new FileWriter("output.txt");
		//While the scanner sees new tokens
		while(readFile.hasNext()) {
			
			//Grab the next String token and split using a delimiter
			String currentString = readFile.next();
			String[] values = currentString.split(",");
			
			//Convert two numbers to double values
			BigDecimal totalDue = new BigDecimal(values[0]);
			BigDecimal paid = new BigDecimal(values[1]);
			
			//Write change due strings to the file 
			if(isDivisibleByThree(values[0])) {
				fileWriter.write("\n"+changeProcessor.calculateRandomChange(totalDue, paid));
			}
			else {
				fileWriter.write("\n"+changeProcessor.calculateChange(totalDue, paid));
			}
			
			//If more input in file, go to next line
			if(readFile.hasNextLine()) {
				readFile.nextLine();
			}
		}
		
		//close scanner and writer
		fileWriter.close();
		readFile.close();
	
		return output;
	}
	
	
	private boolean isDivisibleByThree(String totalDue) {
		
		int sumOfDigits = 0;
		
		for(int i = 0;i<totalDue.length();i++) {
			
			if(totalDue.charAt(i)!='.') {
				sumOfDigits += (int)totalDue.charAt(i) - '0'; 
			}
		}
		
		if(sumOfDigits%3==0) {
			return true;
		}
		else {
			return false;
		}
		
	}
}
