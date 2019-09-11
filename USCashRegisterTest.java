package com.example.cashregister.test;

import com.example.cashregister.CashRegisterFactory;
import com.example.cashregister.CashRegisterType;
import com.example.cashregister.ICashRegister;
/**
 * Class for testing the US Cash Register
 * 
 * @author tivdemo
 *
 */
public class USCashRegisterTest {
	public static void main(String[] args) 
    {
		try
		{			
			if (args.length == 0) {
				System.out.println("\nMissing Input File Parameter\n");
				System.exit(16);
			}
			
			ICashRegister register = CashRegisterFactory.GetCashRegister(CashRegisterType.US_CASH_REGISTER);
			register.process(args[0]);
		}
		catch (Exception ex) {
			String errorMsg = String.format("US CashRegisterTest Failed due to Error = [{0}]", ex);
			System.out.println(errorMsg);
			System.exit(16);
		}
    }
}
