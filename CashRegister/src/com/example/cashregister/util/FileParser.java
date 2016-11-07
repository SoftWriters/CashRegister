package com.example.cashregister.util;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

import com.example.cashregister.model.Amount;


/**
 * @author harithakavuri
 *
 */
public class FileParser {
	private static final Logger LOGGER = Logger.getLogger( FileParser.class.getName() );
	
	/**
	 * @param filePath
	 * @return data in a ArrayList
	 * reads the file and writes the data to a list
	 * @throws Exception 
	 */
	public static ArrayList<Amount> readFile(String filePath) throws Exception {
		ArrayList<Amount> amounts = new ArrayList<Amount>();
		try{
			FileReader reader = new FileReader(filePath);
            BufferedReader bufferedReader = new BufferedReader(reader);	
			String line = bufferedReader.readLine();		
			while (line != null){				
				amounts.add(CashRegisterUtils.parseStringCSV(line));
				line = bufferedReader.readLine();
			}
			bufferedReader.close();
			}
			catch (Exception ex) {
				System.out.println(CashRegisterConstants.FILENOTFOUND.getMsg());
				throw ex;
			}
		return amounts;
		
	}
	
	/**
	 * @param filePath
	 * @param outputData
	 * writes to a file from a list
	 * if there is no parent directory given, the output file will be stored in user_home/cashRegister/ directory.
	 * if file not found then the out file is stored at user_home/cashRegister/out.txt
	 */
	public static  void writeToFile(String filePath, ArrayList<Amount> outputData){ 
            FileWriter writer = null;
            try{
            writer = new FileWriter(checkFilePath( filePath) );
            }catch(FileNotFoundException fne){
            	filePath = CashRegisterUtils.getUserHome() + File.separator+ "cashRegister" + File.separator+
            			CashRegisterConstants.OUTPUTFILENAME.getMsg();
            	try {
					writer = new FileWriter(checkFilePath(filePath));
				} catch (IOException e) {
					//e.printStackTrace();
					LOGGER.log(Level.SEVERE, e.getMessage(), e);
				}
            }catch (IOException e) {
				//e.printStackTrace();
            	LOGGER.log(Level.SEVERE, e.getMessage(), e);
			}
            try{
            BufferedWriter bufferedWriter = new BufferedWriter(writer);
            for(int i = 0; i < outputData.size(); i++){
	            bufferedWriter.write(outputData.get(i).getMsg());
	            if(i != outputData.size() - 1)
	            	bufferedWriter.newLine();
            }
            bufferedWriter.close();
            }catch (IOException e) {
            	LOGGER.log(Level.SEVERE, e.getMessage(), e);
			}
        } 
		
	

	 private static File checkFilePath( String fileName){

				if(!fileName.contains(File.separator)){
	            	
	            	fileName = CashRegisterUtils.getUserHome() + File.separator+ "cashRegister" + File.separator+fileName;
	        
				}
				File oFile = new File(fileName);
			    if(!oFile.getAbsoluteFile().getParentFile().exists())
	            	oFile.getAbsoluteFile().getParentFile().mkdirs();
			
	        return oFile;		
	         
	 }
}
