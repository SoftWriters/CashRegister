package Register;

import java.io.IOException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Random;

import io.MoneyReader;
import io.MoneyWriter;

/**
 * The Register class holds the main method for the CashRegister project.
 * The class first loads the input file that contains a price and amount paid,
 * then calculates the change that is needed to be given back. Once the change is
 * calculated, it is printed to a Receipt.txt file.
 * 
 * @author chasekeady
 *
 */
public class Register {
	
	/**
	 * The main method for the CashRegister project. This method will loop
	 * through a list of change and prints the result to Receipt.txt 
	 * 
	 * @param args
	 * @throws IOException
	 */
	public static void main(String[] args) throws IOException {
		Register register = new Register();
		MoneyWriter moneyWriter = new MoneyWriter("Receipt.txt");
		ArrayList<Double> change = new ArrayList<Double>();

		change = register.payments("Input.txt");
		
		for (int counter = 0; counter < change.size(); counter++) { 
			String cashBack = register.outputChange(change.get(counter));
			System.out.println(cashBack);
			moneyWriter.writeChange(cashBack);
	    } 
		
		moneyWriter.close();
	}
	
	/**
	 * Reads price and amount from Input.txt file, calculates the change
	 * that is needed to be handed back, and inserts that value into an ArrayList.
	 * The ArrayList is then returned.
	 * 
	 * @param fileName - the name of the file the payment are loaded from
	 * @throws IOException
	 */
	public ArrayList<Double> payments(String fileName) throws IOException{
		ArrayList<Double> change = new ArrayList<Double>();
		MoneyReader moneyReader = new MoneyReader(fileName);
		String line;
				
		while((line = moneyReader.readPayment()) != null) {
			DecimalFormat df = new DecimalFormat("#.##");
			
			double price = Double.parseDouble(line.split(",")[0].trim());
			double amountGiven = Double.parseDouble(line.split(",")[1].trim());
			
			double diff = Double.valueOf(df.format(amountGiven - price));
			
			change.add(diff);
		}
		
		moneyReader.close();
		return change;
	}
	
	/**
	 * Returns a string that contains the bills and coins that makeup
	 * the change needed to be handed back.
	 * 
	 * @param change - amount needed to be returned
	 * @throws IOException
	 */
	public String outputChange(double change) throws IOException {
		if(change < 0) {
			String cashBack = "";
			cashBack= "Insufficient Funds";
			return cashBack;
		}else if(change == 0) {
			String cashBack = "";
			cashBack = "Exact Change Given";
			return cashBack;
		}else {
			//Calculates how many of each bill are needed to makeup the change
			DecimalFormat df = new DecimalFormat("#.##");
			Change cashBack = new Change(df);
			while(change >= 1) {
				change = cashBack.hundreds(change);
				change = cashBack.fifties(change);
				change = cashBack.twenties(change);
				change = cashBack.tens(change);
				change = cashBack.fives(change);
				change = cashBack.ones(change);
			}
			
			//If change in cents is divisible by 3, the change given back will be random
			if((change != 0) && (((change * 100) % 3) == 0)) {
				Random rand = new Random();
				int[] cases = {1, 5, 10, 25};
				while(change >0) {
					int i = cases[rand.nextInt(4)];
					switch(i) {
						case 1:
							change = cashBack.pennies(change);
							break;
						case 5:
							change = cashBack.nickels(change);
							break;
						case 10:
							change = cashBack.dimes(change);
							break;
						case 25:
							change = cashBack.quarters(change);
							break;
					}
					
				}
			}
			//If the change, in cents, is not divisible by 3, the minimum amount of coins will be returned
			else {
				while(change > 0) {
					change = cashBack.quarters(change);
					change = cashBack.dimes(change);
					change = cashBack.nickels(change);
					change = cashBack.pennies(change);
				}
			}
			
			return cashBack.printChange();
		}
	}

}
