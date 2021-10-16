package Register;

import java.io.IOException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Random;

import io.MoneyReader;
import io.MoneyWriter;


public class Register {
		
	public static void main(String[] args) throws IOException {
		Register register = new Register();
		MoneyWriter moneyWriter = new MoneyWriter("Output.txt");
		ArrayList<Double> change = new ArrayList<Double>();

		change = register.payments("Input.txt");
		
		for (int counter = 0; counter < change.size(); counter++) { 
			String cashBack = register.outputChange(change.get(counter));
			System.out.println(cashBack);
			moneyWriter.writeChange(cashBack);
	    } 
		
		moneyWriter.close();
	}
	
	public ArrayList<Double> payments(String fileName) throws IOException{
		ArrayList<Double> change = new ArrayList<Double>();
		MoneyReader moneyReader = new MoneyReader(fileName);
		String line;
				
		while((line = moneyReader.readPayment()) != null) {
			DecimalFormat df = new DecimalFormat("#.##");
			
			double price = Double.parseDouble(line.split(",")[0]);
			double amountGiven = Double.parseDouble(line.split(",")[1]);
			
			double diff = Double.valueOf(df.format(amountGiven - price));
			
			change.add(diff);
		}
		
		moneyReader.close();
		return change;
	}
	
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
			else{
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
