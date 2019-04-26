This is a eclipse based java project.

CashRegister project takes an argument for the input file name and for the output file name.
If the folder structure is not present for the output file it creates the structure.
If no file name is passed it uses the default input.txt in project and the ${user.home}/cashRegister/out.txt file.

Denomination is an enum file which consists of denomination in pennies,description for 
single and multiple units.

CashRegisterConstants is an enum with all the constants used in the project.

FileParser consists of read and write methods to a file.

Amount is a model class with owed, paid and a msg.

CashRegister is an interface, which has a method called "execute with inFile and outFile as parameters".
CashRegisterAbst is an abstract class which has common methods to get the change and check the denominations.
CashRegisterCSV is a concrete class for processing csv input file and write to outFile.
CashRegisterFactory has a getCashRegister method that returns CashRegister object based on the requested type (now it supports CSV type).
 
CashRegisterUtils has utility methods used in the project. 
 
 MainCashREgister is the main file and executable file.

The arguments to be passed to the MainCashRegister inFile="input fileName with location" outFile="output file".
arguments example inFile=/Users/harithakavuri/cashRegister/input.txt  outFile=/Users/harithakavuri/cashRegister/output.txt