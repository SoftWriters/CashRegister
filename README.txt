Connor Johnson
Cash Register Project
Completed: 09/06/2021


This project is used to find the coins that would be needed to give a certain amount of change. It takes a text file as input that should contain a list of values.
Each line in the text file should contain 2 numbers separated by a comma. The first number is the price of something that is being payed for. The second number is the amount
of money that the customer payed with. The program takes these numbers and returns the change that should be given back to the customers in dollars and coins. It normally
gives change in the least possible number of coins, except when the total change in cents is divisible by three. In this case, the different denominations of change given
is randomized while still adding up to the correct amount of change. If any lines in the input file are formatted incorrectly, they will be skipped, and the user will be
notified of the incorrectly formatted lines. The test python file contains unit tests to make sure the calculate change method works correctly for a range of values.

Files: Cash_Register.py, calculate_change.py, calculate_change_test.py

Cash_Register.py: This is the file that contains the main and is used to the run the applicaiton.
calculate_change.py: Contains a method that calculates the change and is called by Cash_Register.py
calculate_change_test.py: Contains a few unit tests to test the functionality of calculate_change.py

Running the application: Type the following command in the terminal
python Cash_Register.py [filename]
Example: python Cash_Register.py input.txt

Example Input:
1.33, 2.00
2.71,4.00
1.45,%4.00^
1.50

Example Output:
2 quarters, 1 dime, 1 nickel, 2 pennies
3 quarters, 1 dime, 1 nickel, 39 pennies
Line 3 of input.txt must contain 2 numbers separated by a comma.
Line 4 of input.txt must contain 2 numbers separated by a comma.

Modules: random, numpy, sys

Known Bugs: There are currently no known bugs contained in this project.