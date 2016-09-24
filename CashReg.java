import java.util.Random;
import java.io.File;
import java.io.FileWriter;
import java.io.*;
import java.lang.String;
import java.io.BufferedReader;

public class CashReg {

  public enum Denoms {
           dollar,
           quarter,
           dime,
           nickel,
           pennies
  };
       
  public static void main(String[] args) throws IOException {
                    
       //Read input data file
      File fin = new File("infile.txt");
      BufferedReader br = new BufferedReader(new FileReader(fin));
      String line = null;
      while ((line = br.readLine()) != null ) {
          
           if (!line.isEmpty()) {
              String tokens[] = line.split(",");
              double x = Double.parseDouble(tokens[0]);
              double y = Double.parseDouble(tokens[1]);
              double change = y - x;
               
             FileWriter fw = null;
             int max=0, min=0;
             boolean twist = false;
             double[] denominatons = new double [] {1.0, 0.25, 0.10, 0.05, 0.01};
             
             double temp = x / 3.0;
             double temp1 = roundToTwoDecimalPlaces(temp);
             double tempresult = x - (temp1 * 3.0);
             
             if  (tempresult == 0.0) {
                 twist = true;
                 max = denominatons.length - 1 ;
                 min = 0;
             } 
       
            change = roundToTwoDecimalPlaces(change);
       
            int i = 0;
            Random rand = new Random();
       
           while (change != 0) {
                   
                   if (twist) {
                     i = min + rand.nextInt((max - min) + 1); 
                   }
                  double m =  change / denominatons[i];
                  double z = (long) m * denominatons[i];
                  String s = "";
                  if ((long) m!=0) {
                      s = (long) m + " "+ Denoms.values()[i] + ", ";
                  }
                  
                  //write the results to a file
                  try {
                      File fout = new File("outfile.txt");
                      if (fout.exists()) {fout.delete(); fout.createNewFile();   }
                      fw = new FileWriter(fout,true);      
                      fw.write(s);
                      fw.flush();
                  } catch (IOException e) {
                      e.printStackTrace();
                  }
                  
                  if (z!=0) {
                     change = change - z;
                     change = roundToTwoDecimalPlaces(change);
                  } 
                  
                  if (twist == false) { i++ ;} 
                  else {
                      i = min + rand.nextInt((max - min) + 1);  
                  }
                  
           }
           
           try {
               fw.write('\n');
               fw.flush();
           } catch (IOException e) {
               e.printStackTrace();
           }
              
          } //end of iff
      } //end of while reading file
       
      
       
  }
 
  
  private static double roundToTwoDecimalPlaces(double in) {
      double result = Math.round(in * 100.0) / 100.0;    
      return result;      
  }
  
 
  
}