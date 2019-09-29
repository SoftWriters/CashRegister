package resources.javafiles;
import java.io.*;
/**
 * CashRegisterIO requires a path to the intended input file as the only argument. After 
 * instantiating a CashRegister, the main method uses java.io.BufferedReader the main method in 
 * CashRegisterIO reads in the input file line by line. 
 * 
 * After executing the getChange method from CashRegister, the resulting line is written to the 
 * output file using java.io.FileWriter before the next line is read from the input file. 
 * CashRegisterIO's main method is made aware of any exceptions and handles them within a try-catch 
 * block.  
 * 
 * For ease of locating offending lines in the input file, a change limit of $1million was 
 * implemented in CashRegisterIO rather than CashRegister. Greater change due amounts will be 
 * skipped when writing to output and an error is printed to screen.
 * 
 * @author 	Zach Grimaldi, zpg6@pitt.edu, zachgrimaldi.com
 * @version 1.0
 * @since 	2019-09-29
 */
class CashRegisterIO {
	
	/**
	 * CashRegisterIO requires a path to the intended input file as the only argument. After 
	 * instantiating a CashRegister, the main method uses java.io.BufferedReader the main method in 
	 * CashRegisterIO reads in the input file line by line. 
	 * 
	 * After executing the getChange method from CashRegister, the resulting line is written to the 
	 * output file using java.io.FileWriter before the next line is read from the input file. 
	 * CashRegisterIO's main method is made aware of any exceptions and handles them within a try-
	 * catch block.  
	 * 
	 * For ease of locating offending lines in the input file, a change limit of $1million was 
	 * implemented in CashRegisterIO rather than CashRegister. Greater change due amounts will be 
	 * skipped when writing to output and an error is printed to screen.
	 * 
	 * @param args[0] path to input text file being processed
	 * @throws FileNotFoundException verifies existence of input file specified in args
	 * @throws IOException catches if the IO stream is interrupted 
	 * @throws NumberFormatException ensures the valid format expected according to instructions
	 * @throws ArrayOutOfBoundsException confirms that both a price and amount paid are included
	 */
	public static void main(String[] args) {
			
		if (args.length <1) {
			System.out.println("Format: java resources.javafiles.CashRegisterIO [input file path]\nPlease try again.");
			System.exit(1);
		}
		CashRegister register = new CashRegister();
		String nextLine = "";
		int counter = 0;
		int errors = 0;
		try {
			// open input stream to path specified in args.
			BufferedReader readIn = new BufferedReader(new FileReader(args[0]));
			// open output stream to file "output.txt" in working directory
			FileWriter writeOUT = new FileWriter("output.txt");
			while ((nextLine = readIn.readLine()) != null) {
				counter++;
				String[] splitLine = nextLine.split(",");
				splitLine[0] = splitLine[0].replace(".", "");
				splitLine[1] = splitLine[1].replace(".", "");
				if (splitLine[0].length()>10 || splitLine[1].length()>10) {
					System.out.println("CashRegister skipped '"+args[0]+"' line "+counter+": '"+nextLine+"'");
					System.out.println("Please limit entries to less than 1000000.00 (one-million dollars).");
					counter--;
					continue;
				}
				int price = Integer.parseInt(splitLine[0]);
				int tendered = Integer.parseInt(splitLine[1]);
				writeOUT.write(register.getChange(price,tendered));
				writeOUT.append(System.lineSeparator());
			}
			System.out.println("CashRegister successfully executed "+counter+" transactions to output.txt");
			readIn.close();   		
			writeOUT.close();
		} 
		catch(FileNotFoundException ex0) {
			System.out.println("File '"+args[0]+"' not found.\nFormat: java resources.javafiles.CashRegisterIO [path to input file]");
			System.exit(1);        
		}
		catch(IOException ex1) {
			System.out.println("Failed or interrupted I/O operations. Please retry.");
			System.exit(1);
		}
		catch (NumberFormatException ex2) {
			System.out.println("Number formatting error in '"+args[0]+"' at\nline "+counter+": '"+nextLine+"'");
			System.out.println("Each line should contain 'totalDue,AmountPaid' (ex:  2.13,3.00 )");
			System.out.println("Do not include a '$'. Do not include commas for larger values.");
			System.exit(1);
		}
		catch (ArrayIndexOutOfBoundsException ex3) {
			System.out.println("Number formatting error in '"+args[0]+"' at\nline "+counter+": '"+nextLine+"'");
			System.out.println("Each line should contain 'totalDue,AmountPaid' (ex:  2.13,3.00 )");
			System.out.println("Do not include a '$'. Do not include commas for larger values.");
			System.exit(1);
		}
		catch(Exception ex4) {
			ex4.printStackTrace();
			System.exit(1);
		} // end try-catch block
	} // end main
} // EOF CashRegisterIO