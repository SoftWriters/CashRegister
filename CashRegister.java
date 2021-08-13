import java.io.File;
import java.util.Random;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class CashRegister {
	public static void main (String[] args) throws IOException, FileNotFoundException {
		//Try block used if file fails to open
		try {
			//Open File
			File testData = new File(System.getProperty("user.dir") + "\\testdata.txt");
			//Write to File
			FileWriter fWriter = new FileWriter(testData, true);
			//Read data from File
			Scanner fReader = new Scanner(testData);
			fWriter.write("\n");
			while (fReader.hasNextLine()) {
				String input = fReader.nextLine();
				//Error checking format
				if (input.matches("\\d*.\\d{2},\\d*.\\d{2}") || input.matches("\\d*.\\d{2},\\d*") || input.matches("\\d*,\\d*.\\d{2}") || input.matches("\\d*,\\d*")) {
					String[] data = input.split(",");
					int costInCents = (int) (Double.parseDouble(data[0]) * 100);
					int paidInCents = (int) (Double.parseDouble(data[1]) * 100);
					if (costInCents > paidInCents) {
						fWriter.write("Cost too high.\n");
					}
					else {
						//If amount in cents is divisible by 3, use randomized solution
						fWriter.write(solution(paidInCents - costInCents, costInCents % 3 == 0) + "\n");
					}
				}
				else {
					fWriter.write("Invalid Formatting.\n");
				}
			}
			fWriter.close();
			fReader.close();
		} catch (FileNotFoundException e) {
			System.out.println("File not found.");
		} catch (IOException e) {
			System.out.println("IOException.");
		}
		
	}

	public static String solution(int difference, boolean isDivisible) {
		Random rand = new Random();
		//Solution built in this string
		String solution = "";
		// Variable to track how many of each change increment to give
		int multiple = 0;
		if (difference >= 10000) {
			multiple = difference / 10000;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 10000;
				solution = solution + Integer.toString(multiple) + " hundred" + addLetterS(multiple);
			}
		}
		if (difference >= 5000) {
			multiple = difference / 5000;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 5000;
				if (multiple == 1) {
					solution = solution + Integer.toString(multiple) + " fifty,";
				}
				else {
					solution = solution + Integer.toString(multiple) + " fifties,";
				}
			}
		}
		if (difference >= 2000) {
			multiple = difference / 2000;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 2000;
				if (multiple == 1) {
					solution = solution + Integer.toString(multiple) + " twenty,";
				}
				else {
					solution = solution + Integer.toString(multiple) + " twenties,";
				}
			}
		}
		if (difference >= 1000) {
			multiple = difference / 1000;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 1000;
				solution = solution + Integer.toString(multiple) + " ten" + addLetterS(multiple);
			}
		}
		if (difference >= 500) {
			multiple = difference / 500;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 500;
				solution = solution + Integer.toString(multiple) + " five" + addLetterS(multiple); 
			}
		}
		if (difference >= 100) {
			multiple = difference / 100;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 100;
				solution = solution + Integer.toString(multiple) + " dollar" + addLetterS(multiple);
			}
		}
		if (difference >= 25) {
			multiple = difference / 25;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 25;
				solution = solution + Integer.toString(multiple) + " quarter" + addLetterS(multiple);
			}
		}
		if (difference >= 10) {
			multiple = difference / 10;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 10;
				solution = solution + Integer.toString(multiple) + " dime" + addLetterS(multiple);
			}
		}
		if (difference >= 5) {
			multiple = difference / 5;
			if (isDivisible)
				multiple = rand.nextInt(multiple);
			if (multiple != 0) {
				difference -= multiple * 5;
				solution = solution + Integer.toString(multiple) + " nickel" + addLetterS(multiple);
			}
		}
		if (difference > 0) {
			solution = solution + Integer.toString(difference);
			if (difference == 1) {
				solution += " penny";
			}
			else {
				solution += " pennies";
			}
		}
		//Error checking for exact change
		if (solution.length() != 0) {
			//Removes trailing comma if present
			if (solution.charAt(solution.length() - 1) == ',') {
				solution = solution.substring(0, solution.length() - 1);
			}
			return solution;
		}
		else {
			return "No Change Given.";	
		}
	}
	
	
	// Helper function to format solution string
	public static String addLetterS(int multiple) {
		if (multiple > 1)
			return "s,";
		return ",";
	}
}
