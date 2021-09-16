import jdk.swing.interop.DispatcherWrapper;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.*;


public class CashRegister {
    Denomination tenDollar = new Denomination("Ten Dollar Bill", 10.00);
    Denomination fiveDollar = new Denomination("Five Dollar Bill", 5.00);
    Denomination dollar = new Denomination("One Dollar Bill", 1.00);
    Denomination quarter = new Denomination("Quarter", 0.25);
    // Oh wow, dimes!
    Denomination dime = new Denomination("Dime", 0.10);
    Denomination nickel = new Denomination("Nickel", 0.05);
    Denomination penny = new Denomination("Penny", 0.01);

    List<Denomination> denominations = new ArrayList<>();

    public CashRegister() {
        this.tenDollar = tenDollar;
        this.fiveDollar = fiveDollar;
        this.dollar = dollar;
        this.quarter = quarter;
        this.dime = dime;
        this.nickel = nickel;
        this.penny = penny;
        this.denominations = denominations;

        this.denominations.add(tenDollar);
        this.denominations.add(fiveDollar);
        this.denominations.add(dollar);
        this.denominations.add(quarter);
        this.denominations.add(dime);
        this.denominations.add(nickel);
        this.denominations.add(penny);
    }

    // Main method
    public static void main(String[] args) throws IOException {
        CashRegister cr = new CashRegister();
        cr.fileReader();


    }

    // Method for reading from file and writing to file
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
                    printWriter.println(this.randomCashBack(pp, ch));
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
        //Method for finding random cash back
        //Now with dimes!
        public String randomCashBack(double price, double cash){

            //doubles to track counts of coins selected
            double tenDollars = 0;
            double fiveDollars = 0;
            double dollars = 0;
            double quarters = 0;
            double dimes = 0;
            double nickels = 0;
            double pennies = 0;
            // variables to store data about random selection
            Denomination random;
            double maxRandoms;
            double chooseRandoms;

            // Arraylist to initially store selected coins as strings.
            // Can contain duplicates and has no order
            List<String> stringList = new ArrayList();

            // Calculate cashBack required
            double cashBack = cash - price;
           //initialize stringbuilder to hold output
            StringBuilder change = new StringBuilder();

            // Main engine
            // Selects denomination randomly then selects amount of chosen denomination randomly
            // While loop runs until no more change is required
            while (cashBack > 0) {
                random = this.getRandomCoin();
                // Gives us maximum number of randoms
                maxRandoms = Math.floor(cashBack / random.getValue());
                chooseRandoms = Math.floor(Math.random() * (maxRandoms + 1));


                if(chooseRandoms  > 0){
                    cashBack -= chooseRandoms * random.getValue();
                    // Round to 2 decimal places
                    cashBack = Math.round(cashBack * 100.0) / 100.0;
                    // Switch to make sure the amount of coins returned is tracked
                    switch (random.getTitle()) {
                        case "Ten Dollar Bill":
                            tenDollars += chooseRandoms;
                            break;
                        case "Five Dollar Bill":
                            fiveDollars += chooseRandoms;
                            break;
                        case "One Dollar Bill":
                            dollars += chooseRandoms;
                            break;
                        case "Quarter":
                            quarters += chooseRandoms;
                            break;
                        case "Dime":
                            dimes += chooseRandoms;
                            break;
                        case "Nickel":
                            nickels += chooseRandoms;
                            break;
                        case "Penny":
                            pennies += chooseRandoms;
                            break;
                        default:
                            System.out.println("Something went wrong with the random switch");
                            break;
                    }
                    // Each time a denomination is selected, a string of that denomination is added
                    // to the unordered ArrayList (with duplicates)
                    stringList.add(random.getTitle());
                }
            }

            // Duplicates are removed and a high-to-low order is established
            // by creating a new ArrayList and iterating through this.denominations
            // Strings are added if they are contained in the original list 'stringList'
            List<String> finalList = new ArrayList<>();

            for(int i = 0; i < this.denominations.size(); i++){
                String coin = this.denominations.get(i).getTitle();
                if(stringList.contains(coin)) {
                    finalList.add(coin);
                }
            }
            // Switch used for the StringBuilder
            // Takes two helper methods singleOrPlural and builderHelper that format output
            // and reduce repetition, respectively.
            for(int i = 0; i < finalList.size(); i++) {
                switch (finalList.get(i)) {
                    case "Ten Dollar Bill":
                        change.append(builderHelper(finalList.get(i), tenDollars));
                        break;
                    case "Five Dollar Bill":
                        change.append(builderHelper(finalList.get(i), fiveDollars));
                        break;
                    case "One Dollar Bill":
                        change.append(builderHelper(finalList.get(i), dollars));
                        break;
                    case "Quarter":
                        change.append(builderHelper(finalList.get(i), quarters));
                        break;
                    case "Dime":
                        change.append(builderHelper(finalList.get(i), dimes));
                        break;
                    case "Nickel":
                        change.append(builderHelper(finalList.get(i), nickels));
                        break;
                    case "Penny":
                        change.append(builderHelper(finalList.get(i), pennies));
                        break;
                    default:
                        System.out.println("Something went wrong with the string builder switch");
                        break;
                }
            }
            // Takes off last comma and space from the StringBuilder
            change.setLength(change.length() - 2);
            return change.toString();
        }

        // Helper to decide whether denomination should be printed plural or singular
        public String singleOrPlural(String title, double amount) {
            if (amount == 1) {
                return title;
            } else {
                // We hardcoded because we only have one case
                if (title.equals("Penny")) {
                    return "Pennies";
                } else {
                    return title + "s";
                }
            }
        }
        // Reduces repetition in the String Builder switch
        public String builderHelper(String coinString, double coin){
        return (int)coin + " " + this.singleOrPlural(coinString, coin) + ", ";
        }
}






