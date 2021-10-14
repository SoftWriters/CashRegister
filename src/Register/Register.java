package Register;

import java.io.IOException;

import Reader.MoneyReader;


public class Register {
	
	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		Register register = new Register();
		register.loadPayments("Input.txt");
	}
	
	public void loadPayments(String fileName) throws IOException{
		MoneyReader moneyReader = new MoneyReader(fileName);
		String line;
				
		while((line = moneyReader.readPayment()) != null) {
			double price = Double.parseDouble(line.split(",")[0]);
			double amountGiven = Double.parseDouble(line.split(",")[1]);
			
			System.out.println(price + "," + amountGiven);
		}
		
		moneyReader.close();
	}

}
