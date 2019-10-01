Cash Register
============

The Problem
-----------
Creative Cash Draw Solutions is a client who wants to provide something different for the cashiers who use their system. The function of the application is to tell the cashier how much change is owed and what denominations should be used. In most cases the app should return the minimum amount of physical change, but the client would like to add a twist. If the total due in cents is divisible by 3, the app should randomly generate the change denominations (but the math still needs to be right :))

Please write a program which accomplishes the clients goals. The program should:

1. Accept a flat file as input
	1. Each line will contain the total due and the amount paid separated by a comma (for example: 2.13,3.00)
	2. Expect that there will be multiple lines
2. Output the change the cashier should return to the customer
	1. The return string should look like: 1 dollar,2 quarters,1 nickel, etc ...
	2. Each new line in the input file should be a new line in the output file

Sample Input
------------
2.12,3.00

1.97,2.00

3.33,5.00

Sample Output
-------------
3 quarters,1 dime,3 pennies

3 pennies

1 dollar,1 quarter,6 nickels,12 pennies

The Solution
--------------
This program (which would be limited to the CCDS.CashRegister namespace were it to be incorporated) accepts a text file as a command-line argument. It then, for each line of text, takes in the cost and payment and returns the change in denominations ordered largest to smallest. The denominations are randomly generated if the cost in units is divisible by three.

This program is made to be easily extensible to other currencies. It should be able to accept any currency with the following minor extensions:
	1. (in Program.cs) code that accepts a token as a second command-line argument to determine the type of currency
	2. (in Currency.cs) long[] and List<KeyValuePair<string, string>> created for the currency in descending order of cost

The currency units are stored as long (Int64) values. Furthermore the smallest complete unit is 1. Therefore the largest possible currency accepted is the maximum positive signed long / 100.

This program handles exceptions with as little direct exception handling as possible. The premise of this decision is that using exception handling to direct the program flow is bad practice. However, all potential errors are addressed and maneuvered around in the program flow.

Previous transactions are stored for data purposes. This program does not store the change denominations given, but it could easily be extended to do so. The rationale for not doing so would be that CCDS would not necessarily need that data for any purposes.

The CryptoRandom class is used to generate the random denominations for the currency. This generates secure random numbers and offers CCDS customers the uniqueness they deserve. After all, unique customers deserve unique change denominations.

Object-oriented design and clean code were the cornerstones of this project during its creation. There was no reason to break convention significantly, and therefore convention was followed. I am very satisfied with the outcome of this project, and I hope you are as well.
