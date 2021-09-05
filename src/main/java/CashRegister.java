import jdk.swing.interop.DispatcherWrapper;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.*;

public class CashRegister {
    Denomination tenDollar = new Denomination("Ten Dollar Bill", 10.00);
    Denomination fiveDollar = new Denomination("Five Dollar Bill", 5.00);
    Denomination dollar = new Denomination("Dollar", 1.00);
    Denomination quarter = new Denomination("Quarter", 0.25);
    Denomination nickel = new Denomination("Nickel", 0.05);
    Denomination penny = new Denomination("Penny", 0.01);

    List<Denomination> denominations = new ArrayList<>();

    public CashRegister() {
        this.tenDollar = tenDollar;
        this.fiveDollar = fiveDollar;
        this.dollar = dollar;
        this.quarter = quarter;
        this.nickel = nickel;
        this.penny = penny;
        this.denominations = denominations;

        this.denominations.add(tenDollar);
        this.denominations.add(fiveDollar);
        this.denominations.add(dollar);
        this.denominations.add(quarter);
        this.denominations.add(nickel);
        this.denominations.add(penny);
    }

    // Main method
    public static void main(String[] args) throws IOException {
        CashRegister cr = new CashRegister();
        cr.fileReader();

    }

    // Method for reading from file and writing from file
    public void fileReader() throws IOException {

        File file = new File("InputFile.txt");
        Scanner fileScanner = new Scanner(file);
        FileWriter output = new FileWriter("OutputFile.txt");
        PrintWriter printWriter = new PrintWriter(output);


        try {
            while (fileScanner.hasNextLine()) {
                String line = fileScanner.nextLine();
                double pp = Double.parseDouble(line.split(",")[0]);
                double ch = Double.parseDouble(line.split(",")[1]);
                double cashBack = pp - ch;
                if (ch < pp) {
                    printWriter.println("ERROR");

                } else if (ch == pp) {
                    printWriter.println("ZERO");

                } else if(cashBack % 3 == 0){
                    printWriter.println(getRandomCoin().title);
                } else { printWriter.println(this.getCashChange(pp, ch));
                }
            }
        } catch (Exception e) {
            System.out.println("error");
        }
        output.close();
    }

    // Helper method for finding random coin
    public Denomination getRandomCoin() {
        int coin = (int) Math.floor(Math.random() * this.denominations.size());
        return this.denominations.get(coin);
    }

    private String getCashChange(double price, double cash) {

        int tenDollars = 0;
        int fiveDollars = 0;
        int dollar = 0;
        int quarters = 0;
        int dimes = 0;
        int nickels = 0;
        int pennies = 0;


        double cashBack = cash - price;
        StringBuilder change = new StringBuilder();

        while (cashBack > 0.01d) {
            if (cashBack >= 10.0d) {
                tenDollars++;
                cashBack -= 10.0d;
            } else if (cashBack >= 5.0d) {
                fiveDollars++;
                cashBack -= 5.0d;
            } else if (cashBack >= 1.0d) {
                dollar++;
                cashBack -= 1.0d;
            } else if (cashBack >= 0.25d) {
                quarters++;
                cashBack -= 0.25d;
            } else if (cashBack >= 0.1d) {
                dimes++;
                cashBack -= 0.1d;
            } else if (cashBack >= 0.05d) {
                nickels++;
                cashBack -= 0.05d;
            } else {
                pennies++;
                cashBack -= 0.01d;
            }
        }
            if (tenDollars == 1){
                change.append(tenDollars + " Ten Dollar Bill, ");
            } else if (tenDollars > 1){
                change.append(tenDollars + " Ten Dollar Bills, ");
            }
            if(fiveDollars == 1){
                change.append(fiveDollars + " Five Dollar Bill, ");
            } else if(fiveDollars > 1){
                change.append(fiveDollars + " Five Dollar Bills, ");
            }
            if(dollar == 1){
                change.append(dollar + " Dollar, ");
            } else if(dollar > 1){
                change.append(dollar + " Dollars, ");
            }
            if(quarters == 1){
                change.append(quarters + " Quarter, ");
            } else if (quarters > 1){
                change.append(quarters + " Quarters, ");
            }
            if(dimes == 1){
                change.append(dimes + " Dime, ");
            } else if (dimes > 1){
                change.append(dimes + " Dimes, ");
            }
            if(nickels == 1){
                change.append(nickels + " Nickel, ");
            } else if (nickels > 1){
                change.append(nickels + " Nickels");
            }
            if(pennies == 1){
                change.append(pennies + " Penny, ");
            } else if (pennies > 1){
                change.append(pennies + " Pennies, ");
            }

            change.delete(change.length() - 2, change.length());

        return change.toString();
        }

        public int randomCashBack(){
        return 0;
        }






}






