package com.example.cashregister;
import java.util.ArrayList;

import com.example.cashregister.model.Amount;
import com.example.cashregister.util.CashRegisterConstants;
import com.example.cashregister.util.FileParser;


/**
 * @author harithakavuri
 *
 */
public class CashRegisterCSV extends CashRegisterAbst{

	
	
	/**
	 * @param inFile
	 * loop through the amounts
	 * get the change to be given
	 * call the writetoFile from the FileParser
	 * @throws Exception 
	 */
	public  void execute(String inFile, String outFile) throws Exception {
		
		ArrayList<Amount> inputOutputData = FileParser.readFile(inFile);
			
			for(Amount amount:inputOutputData){			
					if(amount.getMsg() != null && amount.getMsg().length() > 0  ){
						if(amount.getMsg().equals(CashRegisterConstants.EMPTYLINE.getMsg())){
							amount.setMsg("");
						}		
					}else{
								amount.setMsg(
										getCashBack(amount.getOwed(),amount.getPaid()));
					}
										
			}
			
			FileParser.writeToFile(outFile, inputOutputData);
			
	}
		
	

}
