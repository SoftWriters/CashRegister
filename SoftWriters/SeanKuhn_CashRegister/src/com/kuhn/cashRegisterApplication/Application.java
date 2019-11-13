package com.kuhn.cashRegisterApplication;
import java.io.BufferedReader;
import java.io.InputStreamReader;

import com.kuhn.cashRegister.*;
import com.kuhn.cashRegisterInputReader.*;

/**
 * The Application class contains the main runnable method for the CashRegister project
 * 
 * @author 	Sean Kuhn
 * @Date	10/27/2019
 *
 */
public class Application {
	public static void main(String[] Args) throws Exception {
		Till till = new Till();
		BufferedReader consoleReader = new BufferedReader(new InputStreamReader(System.in));
		
		//read in the input and output paths.
		System.out.println("Fully qualified Input Path:");
		String inputPath = consoleReader.readLine();
		System.out.println("Fully Qualified Output Path:");
		String outputPath = consoleReader.readLine();
		consoleReader.close();
		
		//read in the input file
		InputReader inputReader = new InputReader(inputPath);
		StringBuilder output = new StringBuilder();
		double[][] transactions = inputReader.getTransactions();
		
		//Builds output file from transaction array
		for(int i = 0; i < inputReader.getLines(); i++) {
			String change = till.transaction(transactions[i][0], transactions[i][1]);
			System.out.println(change);
			output.append(change);
			if(i != (inputReader.getLines()-1)) {
				output.append(System.getProperty("line.separator"));
			}
			
		}
		
		OutputWriter outputWriter = new OutputWriter(output.toString(),outputPath);
		outputWriter.writeResults();	
	}
}
