package Register;

import java.io.IOException;
import java.text.DecimalFormat;

/**
 * The Change class calculates how much of each bill and coin
 * are needed to makeup the change to be given back.
 * 
 * @author chasekeady
 *
 */
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
	
	
	/**
	 * Standard constructor for the Change class
	 * 
	 * @param df - formats doubles in class to 2 decimal places
	 */
	public Change(DecimalFormat df){
		this.df = df;
	}
	
	/**
	 * Calculates how many hundred dollar bills are needed to make the change
	 * to be given back. Returns how much change is left after hundred dollar
	 * bills are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double hundreds(double change) {
		if((int)(change/100) > 0){
			hundreds = (int)(change/100);
			change =  Double.valueOf(df.format(change - (hundreds * 100)));
		}
		return change;
	}
	
	/**
	 * Calculates how many fifty dollar bills are needed to make the change
	 * to be given back. Returns how much change is left after fifty dollar
	 * bills are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double fifties(double change) {
		if((int)(change/50) >0){
			fifties = (int)(change/50);
			change =  Double.valueOf(df.format(change - (fifties * 50)));
		}
		return change;
	}
	
	/**
	 * Calculates how many twenty dollar bills are needed to make the change
	 * to be given back. Returns how much change is left after twenty dollar
	 * bills are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double twenties(double change) {
		if((int)(change/20) >0){
			twenties = (int)(change/20);
			change =  Double.valueOf(df.format(change - (twenties * 20)));
		}
		return change;
	}
	
	/**
	 * Calculates how many ten dollar bills are needed to make the change
	 * to be given back. Returns how much change is left after ten dollar
	 * bills are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double tens(double change) {
		if((int)(change/10) >0){
			tens = (int)(change/10);
			change =  Double.valueOf(df.format(change - (tens * 10)));
		}
		return change;
	}
	
	/**
	 * Calculates how many five dollar bills are needed to make the change
	 * to be given back. Returns how much change is left after five dollar
	 * bills are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double fives(double change) {
		if((int)(change/5) >0){
			fives = (int)(change/5);
			change =  Double.valueOf(df.format(change - (fives * 5)));
		}
		return change;
	}
	
	/**
	 * Calculates how many one dollar bills are needed to make the change
	 * to be given back. Returns how much change is left after one dollar
	 * bills are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double ones(double change) {
		if(change-1 >= 0) {
			ones = 0;
			while(change >= 1) {
				change = Double.valueOf(df.format(change -1));
				ones++;
			}
		}
		return change;
	}
	
	/**
	 * Calculates how many quarters are needed to make the change
	 * to be given back. Returns how much change is left after the 
	 * quarters are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double quarters(double change) {
		if((int)(change/.25) > 0) {
			quarters = (int)((change*100)/(.25*100));
			change =  Double.valueOf(df.format(change - (quarters * .25)));
		}
		return change;
	}
	
	/**
	 * Calculates how many dimes are needed to make the change
	 * to be given back. Returns how much change is left after the 
	 * dimes are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double dimes(double change) {
		if((int)(change/.10) > 0) {
			dimes = (int)((change*100)/(.10*100));
			change =  Double.valueOf(df.format(change - (dimes * .10)));
		}
		return change;
	}
	
	/**
	 * Calculates how many nickels are needed to make the change
	 * to be given back. Returns how much change is left after the 
	 * nickels are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double nickels(double change) {
		if((int)(change/.05) > 0) {
			nickels = (int)((change*100)/(.05*100));
			change =  Double.valueOf(df.format(change - (nickels * .05)));
		}
		return change;
	}
	
	/**
	 * Calculates how many pennies are needed to make the change
	 * to be given back. Returns how much change is left after the 
	 * pennies are accounted for.
	 * 
	 * @param change - amount needed to be returned
	 */
	public double pennies(double change) {
		if((int)(change/.01) > 0) {
			pennies = (int)(change/.01);
			change = change - (pennies * .01);
		}
		return change;
	}
	
	/**
 	 * Returns a string that contains the bills and coins that makeup
	 * the change needed to be handed back.
	 */
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
