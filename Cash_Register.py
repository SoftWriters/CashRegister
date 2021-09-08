'''
 Author: Connor Johnson
 Completed: 09/06/2021
 Contains the main code to be run for the Cash Register project
'''

import sys
from calculate_change import *

# Read in data from text file
with open(sys.argv[1], 'r') as f:
    lines = f.readlines()
    
    
# Loop through each line in the text file
counter = 0 # Counter for tracking which line the loop is on
for s in lines:
    counter = counter + 1
    
    # Input from text file is checked that it's formatted correctly and values are assigned
    nums = s.split(",")
    if len(nums) != 2:
        print("Line " + str(counter) + " of input.txt must contain 2 numbers separated by a comma.")
        continue
    try:
        cents = float(nums[1]) - float(nums[0])   #Calculate the change to be given
    except ValueError:
        print("Line " + str(counter) + " of input.txt must contain 2 numbers separated by a comma.")
        continue
    
    cents = int(cents*100+0.5)  # Change cents to an integer that represents the total cents in change
    
    final_change = calculate_change(cents)
    if final_change == None:
        print("Invalid Input. Total due can't be more than amount paid.")
    else:
        print(final_change[0])
        
        

