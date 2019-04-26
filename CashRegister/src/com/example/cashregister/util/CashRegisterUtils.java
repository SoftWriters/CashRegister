package com.example.cashregister.util;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.ParseException;
import java.util.Locale;
import java.util.logging.Level;
import java.util.logging.Logger;

import com.example.cashregister.model.Amount;

/**
 * @author harithakavuri
 *
 */
public class CashRegisterUtils {
	
	/**
	 * @param amount
	 * @return amount in pennies
	 * @throws ParseException
	 */
	public static int formatStringtoPennies(String amount) throws ParseException {
		DecimalFormat decimalFormat = (DecimalFormat) NumberFormat.getNumberInstance(new Locale("en", "us"));
		decimalFormat.applyPattern("###.##");
		return new Double(decimalFormat.parse(amount).doubleValue() * 100).intValue();
	}
	private static final Logger LOGGER = Logger.getLogger( CashRegisterUtils.class.getName() );
	public static Amount parseStringCSV(String data){
		Amount amount = new Amount();
		if (data.trim().length() == 0){
			amount.setMsg(CashRegisterConstants.EMPTYLINE.getMsg());
		}else {
			String[] amounts = data.split(",");
			
			if (amounts.length != 2)
				amount.setMsg(CashRegisterConstants.MISSINGAMOUNTS.getMsg());
			else {
				try {
					amount.setOwed(formatStringtoPennies(amounts[0].trim()));
				}
				catch (ParseException ex){
					amount.setMsg(CashRegisterConstants.INVALIDOWEDMONEY.getMsg());	
					
				}
				try {
					amount.setPaid(formatStringtoPennies(amounts[1].trim()));
				}
				catch (ParseException ex){
					LOGGER.log(Level.WARNING, ex.getMessage(), ex);
					amount.setMsg(amount.getMsg() != null && amount.getMsg().length()> 0?
						amount.getMsg() + " "+	CashRegisterConstants.INVALIPAIDDMONEY.getMsg():
							CashRegisterConstants.INVALIPAIDDMONEY.getMsg());
					
				}
			}					
		}
		
		return amount;
	}
	
	public static String getUserHome(){
		 return System.getProperty("user.home");
	}
	
	
	
	

}
