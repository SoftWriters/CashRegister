package Register;

import java.text.DecimalFormat;

public class Change {
	private int hundreds;
	private int fifties;
	private int twenties;
	private int tens;
	private int fives;
	private int ones;
	private int quarters;
	private int dimes;
	private int nickels;
	private int pennies;
	private String cashBack;
	private DecimalFormat df;
	
	public Change(DecimalFormat df){
		this.df = df;
	}
	
	public double hundreds(double change) {
		if((int)(change/100) > 0){
			hundreds = (int)(change/100);
			change =  Double.valueOf(df.format(change - (hundreds * 100)));
		}
		return change;
	}
	
	public double fifties(double change) {
		if((int)(change/50) >0){
			fifties = (int)(change/50);
			change =  Double.valueOf(df.format(change - (fifties * 50)));
		}
		return change;
	}
	
	public double twenties(double change) {
		if((int)(change/20) >0){
			twenties = (int)(change/20);
			change =  Double.valueOf(df.format(change - (twenties * 20)));
		}
		return change;
	}
	
	public double tens(double change) {
		if((int)(change/10) >0){
			tens = (int)(change/10);
			change =  Double.valueOf(df.format(change - (tens * 10)));
		}
		return change;
	}
	
	public double fives(double change) {
		if((int)(change/5) >0){
			fives = (int)(change/5);
			change =  Double.valueOf(df.format(change - (fives * 5)));
		}
		return change;
	}
	
	public double ones(double change) {
		if(change-1 > 0) {
			ones = 0;
			while(change >= 1) {
				change = Double.valueOf(df.format(change -1));
				ones++;
			}
		}
		return change;
	}
	
	public double quarters(double change) {
		if((int)(change/.25) > 0) {
			quarters = (int)(change/.25);
			change =  Double.valueOf(df.format(change - (quarters * .25)));
		}
		return change;
	}
	
	public double dimes(double change) {
		if((int)(change/.10) > 0) {
			dimes = (int)(change/.10);
			change =  Double.valueOf(df.format(change - (dimes * .10)));
		}
		return change;
	}
	
	public double nickels(double change) {
		if((int)(change/.05) > 0) {
			nickels = (int)(change/.05);
			change =  Double.valueOf(df.format(change - (nickels * .05)));
		}
		return change;
	}
	
	public double pennies(double change) {
		if((int)(change/.01) > 0) {
			pennies = (int)(change/.01);
			change = change - (pennies * .01);
		}
		return change;
	}
	
	public String printChange() {
		cashBack = "";
		if(hundreds != 0){
			cashBack += hundreds + " HUNDREDS(S). ";
		}
	    if(fifties != 0){
			cashBack += fifties + " FIFTIES. ";
		}
		if(twenties != 0){
			cashBack += twenties + " TWENTIES. ";
		}
		if(tens != 0){
			cashBack += tens + " TEN(S). ";
		}
		if(fives != 0){
			cashBack += fives + " FIVE(S). ";
		}
		if(ones != 0){
			cashBack += ones + " ONE(S). ";
		}
		if(quarters != 0){
			cashBack += quarters + " QUARTER(S). ";
		}
		if(dimes != 0){
			cashBack += dimes + " DIME(S). ";
		}
		if(nickels != 0){
			cashBack += nickels + " NICKEL(S). ";
		}
		if(pennies != 0){
			cashBack += pennies + " PENNIES. ";
		}
		
		return cashBack;
	}
}
