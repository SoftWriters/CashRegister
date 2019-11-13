# Cash Register
---
The requirement for this program is to create a cash register application that takes transaction data as input, and outputs change instructions. Change should be handled in the lowest number of bills and coins, unless the amount due is divisible by 3. If the amount due is divisible by 3, then the number of each denomination is randomized to give the customer correct change, but in mixed up denominations eg. 80 cents change could return as 1 nickel, 75 pennies.

This program is divided into three main packages;


1. com.kuhn.cashRegister
	* the cashRegister package contains a hierarchy of classes used to control the money changing process.
	a.Denomination is the lowest class in the cashRegister hierarchy, and contains only two parameters: Denomination and value.

	b.Currency is the middle class in the cashRegister hierarchy, and contains a set of denomination instances. These instances can be modified to add support for non-standard currency types.
	
	c.Till is the highest class in the cashRegister hierarchy, and contains the opening till value, instantiated currency object, and all money handling methods.
		i. The transaction method detects errors and calls get change methods based on change divisibility.
		ii.	The getBasicChange method calculates the number and type of denominations to return using the fewest bills and coins.
		iii. The getRandomChange method calculates the number and type of denominations to return using a randomized mix of denominations.
		iv. The grammar method takes the denomination index and number of bills or coins and returns the proper plurality of the denomination.

2. com.kuhn.cashRegisterInputReader
	* the cashRegisterInputReader package contains the classes necessary for reading from and writing to files.

3. com.kuhn.cashRegisterApplication
	* the cashRegisterApplication package contains the runnable class as well as supporting documentation.

# Limitations
---
Input files formatted as charge,payment do not specify the amount and type of bills or coins given in the transaction. since this is not present, there is not good way to track individual denominations. If a Till object was initialized with a finite number of each bill and coin, the getChange methods would have to handle shortages. eg. 40 cents in change is due but only 3 dimes are left to give. two nickels are substituted for the "4th" dime. As transactions are completed, the transaction amount is added to the till as a lump sum, making it impossible to track denomination shorting.