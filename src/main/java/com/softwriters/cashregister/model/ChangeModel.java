package com.softwriters.cashregister.model;

import java.math.BigDecimal;

public class ChangeModel {

	private BigDecimal value;
	
	private String currencyNameSingular;
	
	private String currencyNamePlural;
	
	public ChangeModel(String value, String currencyNameSingular, String currencyNamePlural) {
		this.value = new BigDecimal(value);
		this.currencyNameSingular = currencyNameSingular;
		this.currencyNamePlural = currencyNamePlural;
	}

	public BigDecimal getValue() {
		return value;
	}

	public void setValue(BigDecimal value) {
		this.value = value;
	}

	public String getCurrencyNameSingular() {
		return currencyNameSingular;
	}

	public void setCurrencyNameSingular(String currencyNameSingular) {
		this.currencyNameSingular = currencyNameSingular;
	}

	public String getCurrencyNamePlural() {
		return currencyNamePlural;
	}

	public void setCurrencyNamePlural(String currencyNamePlural) {
		this.currencyNamePlural = currencyNamePlural;
	}
	
	public String getCurrencyName(int numberOfDenominations) {
		if(numberOfDenominations>1) {
			return this.currencyNamePlural;
		}
		else {
			return this.currencyNameSingular;
		}
	}
	
}
