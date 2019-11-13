package com.kuhn.cashRegister;

/**
 * The Denomination class is the bottom class of the cashRegister package hierarchy. 
 * Denomination defines the methods and values inherent to a denomination object
 * 
 * @author 	Sean Kuhn
 * @Date	10/25/2019
 *
 */
public class Denomination {
	private String denomination;
	private int value;
	
	public Denomination(String denomination, int value) {
		this.denomination = denomination;
		this.value = value;
	}
	
	public void setDenomination(String denomination) {
		this.denomination = denomination;
	}
	public String getDenomination() {
		return this.denomination;
	}
	public void setValue(int value) {
		this.value = value;
	}
	public int getValue() {
		return this.value;
	}
}
