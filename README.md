Cash Register
============

Submission for Darryl Faint on 1/17/2016
-----------
I've written my submission for this problem as a console application in C# using Visual Studio 2015 targeting the .NET Framework 4.5.2.  Once you've pulled down my solution you can run it two ways:

1. Open the solution and click the Start button.  I have modified the CashRegister project properties under the Debug tab to take two command line arguments, the amounts.txt file that contained the examples from the requirements which I included in the solution, and an output.txt file that will be recreated on every run with the results.
2. Open the solution and build it with F6 or using the menu by clicking Build -> Build Solution.  Once the solution is built you need to navigate to the bin directory for Debug/Release using the command line.  You can then run the program here by specifying your own files with this usage:        				    ```CashRegister input_file output_file```

Thank you in advance for your time and consideration with this submission.

The Problem
-----------
Creative Cash Draw Solutions is a client who wants to provide something different for the cashiers who use their system. The function of the application is to tell the cashier how much change is owed, and what denominations should be used. In most cases the app should return the minimum amount of physical change, but the client would like to add a twist. If the "owed" amount is divisible by 3, the app should randomly generate the change denominations (but the math still needs to be right :))

Please write a program which accomplishes the clients goals. The program should:

1. Accept a flat file as input
	1. Each line will contain the amount owed and the amount paid separated by a comma (for example: 2.13,3.00)
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

*Remember the last one is random

The Fine Print
--------------
Please use whatever technology and techniques you feel are applicable to solve the problem. We suggest that you approach this exercise as if this code was part of a larger system. The end result should be representative of your abilities and style.

Please fork this repository. When you have completed your solution, please issue a pull request to notify us that you are ready.

Have fun.
