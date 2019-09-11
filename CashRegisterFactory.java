package com.example.cashregister;

import com.example.cashregister.us.USCashRegister;
import com.example.cashregister.us.USCurrency;

/**
 * Factory class for Cash Registers. 
 * 
 * @author tivdemo
 *
 */
public abstract class CashRegisterFactory {
	/**
	 * Lock used for implmenting Singleton lazy cache of Cash Registers. 
	 */
	private static final Object lock = new Object();
	
	/**
	 * Cash Registers instances
	 */
	private static ICashRegister instanceUS;
	
	/**
	 * Get the Cash Register for the given type.
	 * 
	 * @param type CashRegisterType - The Cash Register type.
	 * @return ICashRegister - The Cash Register.
	 */
	public static ICashRegister GetCashRegister(CashRegisterType type) {
		
		switch (type)
		{
			case US_CASH_REGISTER:
				return getUSCashRegister();
			//
			// Add other Cash Registers as necessary
			//
					
			default:
				return getUSCashRegister();
		}
	}
	
	/**
	 * Instantiate the US Cash Register [Singleton - lazy cache]
	 * 
	 * @return USCashRegister - The US Cash Register.
	 */
	private static ICashRegister getUSCashRegister() {
		if (instanceUS == null)
		{
			synchronized(lock) {
				if (instanceUS == null)
					instanceUS = new USCashRegister(new USCurrency());
			}
		}
		
		return instanceUS;
	}
}
