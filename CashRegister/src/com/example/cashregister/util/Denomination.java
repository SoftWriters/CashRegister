package com.example.cashregister.util;


/**
 * @author harithakavuri
 *
 */
public enum Denomination {
	
	TWENTY("Twenty Dollar","Twenty Dollars",2000),
	TEN("Ten Dollar","Tens Dollars",1000),
	FIVE("Five Dollar","Five Dollars",500),
	ONE("Dollar","Dollars",100),
	QUARTER("Quarter","Quarters",25),
	DIME("Dime","Dimes",10),
	NICKEL("Nickel","Nickels",5),
	PENNY("Penny","Pennies",1);
	
	private final String singularDescription;
	private final String pluralDescription;
	private final Integer value;
	
	
	
	/**
	 * @return singularDescription
	 */
	public String getSingularDescription() {
		return singularDescription;
	}
	
	/**
	 * @return pluralDescription
	 */
	public String getPluralDescription() {
		return pluralDescription;
	}
	
	
	/**
	 * @return value
	 */
	public Integer getValue() {
		return value;
	}
	
	/**
	 * @param singularDescrition
	 * @param pluralDescription
	 * @param value
	 */
	Denomination(String singularDescrition,String pluralDescription, Integer value){
		this.singularDescription = singularDescrition;
		this.pluralDescription = pluralDescription;
		this.value = value;
	}
	
	/**
	 * @param noOfBills
	 * @param denomination
	 * @return singular or plural description
	 */
	public static String getDescription(long noOfBills, Denomination denomination) {
		if(noOfBills > 1){
			return (denomination.getPluralDescription());
		}else{
			return (denomination.getSingularDescription());
		}
		
	}
	
}
