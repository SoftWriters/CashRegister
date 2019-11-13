package com.kuhn.cashRegister;

/**
 * The Currency class is the middle class of the cashRegister package hierarchy.
 * Currency contains the definitions and methods for all usable currency. 
 * This class can be modified to add support for non US based currency without modifying any other class..
 * 
 * @author 	Sean Kuhn
 * @Date	10/25/2019
 *
 */
public class Currency {
	private Denomination currency[];
	
	//Initializes Currency with denominations common in the united states. Excluded $2 bills and half dollar coins. 
	public Currency() {
		currency = new Denomination[] {
			new Denomination("hundreds",10000),
			new Denomination("fifties",5000),
			new Denomination("twenties",2000),
			new Denomination("tens",1000),
			new Denomination("fives",500),
			new Denomination("ones",100),
			new Denomination("quarters",25),
			new Denomination("dimes",10),
			new Denomination("nickel",5),
			new Denomination("pennies",1)
		};
	}
	public Denomination getDenomination(int index) {
		return this.currency[index];
	}
	public int getCurrencyLength() {
		return this.currency.length;
	}
	public String getCurrencyDenomination(int index) {
		return currency[index].getDenomination();
	}
	public int getCurrencyValue(int index) {
		return currency[index].getValue();
	}
	}

