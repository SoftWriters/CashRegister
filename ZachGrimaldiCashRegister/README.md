Cash Register
=============

The Problem
-----------

To view full instructions for this project, see [SoftWriters/CashRegister](https://github.com/SoftWriters/CashRegister).

Sample Expected Input
---------------------
2.12,3.00

1.97,2.00

3.33,5.00

Sample Output
-------------
3 quarters,1 dime,3 pennies

3 pennies

1 dollar,1 quarter,6 nickels,12 pennies

*Remember the last one is random




Usage
=====

*Please ensure you have the latest version of Java JDK/JRE.*

With **ZachGrimaldiCashRegister/** as your working directory:

1. `javac resources/javafiles/*.java`
2. `java resources.javafiles.CashRegisterIO [input file path]`





My Approach
===========

Java
----

To target the .NET Framework, I chose to implement CashRegister in Java rather than another language due to my comfort programming in its syntax and some clear advantages including, but not limited to:

+ Code Reusability
+ Exceptions
+ Platform-Independence
+ Garbage Collection
+ Class Inheritance
+ Java Compiler

File Structure & Access
-----------------------

I implemented CashRegister as a two-file package:

- `resources/javafiles/CashRegister.java`	 
	
	*Class File without main method*
	
- `resources/javafiles/CashRegisterIO.java`	 
	
	*Run File with main method*
	

While considering this solution as a part of a larger system, I inherently assumed it would be packaged with other Java files and kept security in mind. Hence, CashRegisterIO and CashRegister are packaged and maintain package-protected access privileges. Moreover, only no-modifier and private-modifier methods exist within the package. 

Code and Program Styling
------------------------

This project intends to demonstrate my personal styling "code of conduct". Easy to read and well-commented code saves hours on the time clock should I or someone else want to implement this code elsewhere, fix a bug, or make an update. That's why on every project, I pay extra attention to:

- Proper spacing and indentation
- Consistent camelCase naming conventions
- Complete bracketing for control statements
- Java documentation-standard comments (ready for javadoc)
- Exceptions handled in try-catch blocks and reported accurately to the user
- and more!

The above, as well as previously mentioned advantages to Java, allowed me to submit a concise and legible, yet robust and well-documented implementation of the CashRegister problem totaling just under 400 lines (mostly comments and close brackets). Not styled how you prefer? I am not set in my ways whatsoever, just doing my best with what I know!

How it Works
------------

**CashRegisterIO**

- CashRegisterIO requires a path to the intended input file as the only argument. Using java.io.BufferedReader the main method in CashRegisterIO reads in the input file line by line. 
- After executing the getChange method from CashRegister, the resulting line is written to the output file using java.io.FileWriter before the next line is read from the input file. 
- CashRegisterIO's main method is made aware of any possible I/O, Number Formating, or Array Index Out of Bounds Exceptions and handles them within a try-catch block.  
- For ease of locating offending lines in the input file, a change limit of $1million was implemented in CashRegisterIO rather than CashRegister. Greater change due amounts will be skipped when writing to output and an error is printed to screen.

**CashRegister**

The implementation of class CashRegister has two primary functions to compute change:

- If the amount due (price) in the transaction is a multiple of $0.03 (3 cents), 
CashRegister will return the change due in random denominations of change using java.util.Random

- Otherwise, CashRegister will return the minimum amount of physical change.

CashRegister computes change due to a customer given a price and a tendered amount. This implementation of CashRegister utilizes unit of currency "US cents" (100 US cents = 1 US dollar). Values therefore must be converted to US cents prior to use of this implementation of CashRegister. Change is then exported as a String containing denominations of:

- US dollars, quarters, dimes, nickels, and pennies.

By design, this method operates recursively rather than iteratively to favor faster runtime because (in a real-world scenario):

- A cashier is much more likely to make next-dollar change or break the next highest bill than ask a cashier for thousands of dollars in change in one-dollar bills or coins. A typical cash drawer has a limited capacity for several reasons. To minimize losses from theft, cash drawers purposefully only contain a limited amount of change based on the industry, daily sales, time of day, etc. Even more practically speaking, change of more than $1000 or so would be more of a banking transaction beyond the scope of this implementation focusing on Point of Sale (POS) transactions.
- To overcome StackOverflowError produced in these unlikely cases, if the change due is more than $5000, the customer is given 5000 one-dollar bills in a single recursive instance for the optimal change-making function and 3500 one-dollar bills (preserving some randomness) for the random change-making function. Likewise, while CashRegister can take parameters of any positive int primitive, change that can be calculated is limited to $1million. This is handled within CashRegisterIO for ease of locating offending lines in the input file.


Further Thoughts
----------------
 
Just to share where my head is at, I'm excited about the recursive solution I derived, but am left wondering if I played it too safe. Some features (bells and whistles, really!) I decided against to keep my solution simple and per the given instructions:

- Average transaction runtime reporting
- $100, $50, $20, $10, and $5 bills as options for change denominations 
- Some choices for change at CashRegisterIO startup (ex: give optimal change, give random change, give first one-dollar bill of change in quarters instead, make sure my change includes a penny, etc.)

I am also curious to implement a recursive solution that could handle change-making in the random case for much larger values of $1trillion or more!


Questions?
==========
*For further information, see Java documentation-style comments within files CashRegister.java and CashRegisterIO.java*

Still confused? Please feel free to email me at **zpg6@pitt.edu**
