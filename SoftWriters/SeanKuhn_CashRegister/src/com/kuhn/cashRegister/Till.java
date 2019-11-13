package com.kuhn.cashRegister;
import java.lang.StringBuilder;
import java.util.Random;
/**
 * The Till class is the top class of the cashRegister package hierarchy. 
 * Till contains all money handling methods, as well as all Currency instantiations.
 * 
 * @author 	Sean Kuhn
 * @Date	10/25/2019
 *
 */
public class Till {
	private Currency currency;
	private int value;
	public Till() {
		currency = new Currency();
		this.value = 25000;
	}
	
	public Till(double value) {
		currency = new Currency();
		this.value = (int) (value * 100);
	}
	
	public void setTillTotal(double value) {
		this.value = (int) (value * 100);
	}
	
	public double getTillTotal() {
		return this.value;
	}

	/**
	 * The transaction method detects errors and calls get change methods based on change divisibility.
	 * @param charge		The amount to be paid.
	 * @param payment		The actual amount paid.
	 * @return				Returns the string containing change instructions.
	 * @throws Exception	Contains information for relevant errors.
	 */
	public String transaction(double charge, double payment) throws Exception {
		int change = (int) ((payment * 100) - (charge * 100));
		this.setTillTotal(this.getTillTotal() + 100 * payment);
		String output = "";
		
		if( change > (this.value)) {
			throw new Exception("Change ammount is greater than available funds!");
		}else if( ((charge * 100) % 1) > 0){
			throw new Exception("Change ammount includes fractions of a penny!");
		}else if((charge * 100) % 3 == 0){
			output = getRandomChange((int) (change));
		}else if(change <= (this.value)){
			output = getBasicChange((int) (change));
		}
		
		return output;
	}
	
	/**
	 * The getBasicChange method calculates the number and type of denominations to return using the fewest bills and coins.
	 * 
	 * @param change	The number of cents to be returned to the purchaser.
	 * @return			Returns a grammatically correct string of change instructions.
	 */
	public String getBasicChange(int change) {
		StringBuilder output = new StringBuilder();

		for(int i = 0; i < currency.getCurrencyLength(); i++) {
			double j = (change / currency.getCurrencyValue(i));
			
			if(j >= 1) {
				this.setTillTotal(this.getTillTotal() - (Math.floor(j) * currency.getCurrencyValue(i)));
				change -= (Math.floor(j) * currency.getCurrencyValue(i));
				output.append((int)Math.floor(j));
				output.append(grammar(i,j));
				
				if(i < currency.getCurrencyLength()-1) {
					output.append(", ");
				}
			}
		}
		
		return output.toString();
	}
	
	/**
	 * The getRandomChange method calculates the number and type of denominations to return using a randomized mix of denominations.
	 * 
	 * @param change	The number of cents to be returned to the purchaser.
	 * @return			Returns a grammatically correct string of change instructions.
	 */
	public String getRandomChange(int change) {
		StringBuilder output = new StringBuilder();

		for(int i = 0; i < currency.getCurrencyLength(); i++) {
			double j = (change / currency.getCurrencyValue(i));
			int tempRand = new Random().nextInt((int)Math.floor(j)+1);
			
			if(i == (currency.getCurrencyLength()-1)) {
				tempRand = change;
			}
			
			if(j >= 1 && change <= (this.value) && tempRand > 0) {
				this.setTillTotal(this.getTillTotal() - (tempRand * currency.getCurrencyValue(i)));
				change -= (tempRand * currency.getCurrencyValue(i));
				output.append(tempRand);
				output.append(grammar(i,j));
				
				if(i < currency.getCurrencyLength()-1) {
					output.append(", ");
				}
			}
		}
		
		return output.toString();
	}
	
	/**
	 * The grammar method takes the denomination index and number of bills or coins and returns the proper plurality of the denomination.
	 * 
	 * @param i		The index of a denomination in currency.getDenomination().
	 * @param j		The number of bills or coins to consider. Relevant states are essentially <= 1 and > 1.
	 * @return		Returns a string containing the name of a denomination in it's proper plurality."
	 */
	public String grammar(int i, double j) {
		String grammer = "";
		
		switch(i) {
		case 0:
			if((int)Math.floor(j) > 1) {
				 grammer = " hundreds";
			} else {
				grammer = " hundred";
			}
			break;
		case 1:
			if((int)Math.floor(j) > 1) {
				grammer = " fifties";
			} else {
				grammer = " fifty";
			}
			break;
		case 2:
			if((int)Math.floor(j) > 1) {
				grammer = " twenties";
			} else {
				grammer =" twenty";
			}
			break;
		case 3:
			if((int)Math.floor(j) > 1) {
				grammer = " tens";
			} else {
				grammer = " ten";
			}
			break;
		case 4:
			if((int)Math.floor(j) > 1) {
				grammer = " fives";
			} else {
				grammer = " five";
			}
			break;
		case 5:
			if((int)Math.floor(j) > 1) {
				grammer = " dollars";
			} else {
				grammer = " dollar";
			}
			break;
		case 6:
			if((int)Math.floor(j) > 1) {
				grammer = " quarters";
			} else {
				grammer = " quarter";
			}
			break;
		case 7:
			if((int)Math.floor(j) > 1) {
				grammer = " dimes";
			} else {
				grammer = " dime";
			}
			break;
		case 8:
			if((int)Math.floor(j) > 1) {
				grammer = " nickels";
			} else {
				grammer = " nickel";
			}
			break;
		case 9:
			if((int)Math.floor(j) > 1) {
				grammer = " pennies";
			} else {
				grammer = " penny";
			}
			break;
		default :
			break;
		}
		
		return grammer;
	}
}
