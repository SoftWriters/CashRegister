package com.example.cashregister;

import java.util.logging.Level;
import java.util.logging.Logger;

import com.example.cashregister.util.CashRegisterConstants;

/**
 * @author harithakavuri
 *
 */
public class MainCashRegister {
	private static final Logger LOGGER = Logger.getLogger( MainCashRegister.class.getName() );
	public static void main(String[] args) {
		CashRegister manager = CashRegisterFactory.getCashRegister(CashRegisterConstants.CSV.getMsg());
		String inputFileName = null, outPutFileName = null;
		
		try{
			if(args != null){
				for(String fileName:args){
					String[] fileInfo = fileName.split("=");
					if(fileInfo[0].equalsIgnoreCase(CashRegisterConstants.INPUT.getMsg())){
						inputFileName = fileInfo[1];
					}
					if(fileInfo[0].equalsIgnoreCase(CashRegisterConstants.OUTPUT.getMsg())){
						outPutFileName = fileInfo[1];
					}
				}
			}		
			manager.execute(inputFileName != null?
					inputFileName:CashRegisterConstants.INPUTFILENAME.getMsg(),
					outPutFileName != null?outPutFileName:CashRegisterConstants.OUTPUTFILENAME.getMsg()
					);
		
		}catch (Exception e) {
			System.out.println(e.getMessage());
			LOGGER.log(Level.SEVERE, e.getMessage(), e);
			System.exit(1);
		}
	}
}
