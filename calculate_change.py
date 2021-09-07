'''
 Author: Connor Johnson
 Completed: 09/06/2021
 Contains the calculate_change method used in Cash_Register.py
'''

import random

# Names and values of coin denominations, pennies are excluded because they are handled differently
coin_values = [100, 25, 10, 5]
coin_names = ['dollar', 'quarter', 'dime', 'nickel'] 


def calculate_change(cents):
    '''
    calculate_change takes an amount in cents and calculates the change in coins that would be given for this amount
    cents: The amount of cents in change as an integer
    return: Returns a tuple containing a string that has the description of change and a list containing the value of each denomination; dollars, quarters, etc.
            Returns None if cents is not a positive integer
    '''
    # Checks that cents is a positive integer
    if type(cents) != int or cents < 0:
        return None
    # Handles if cents is equal to zero
    if cents == 0:
        return ('No change', [0,0,0,0,0])
    
    coin_string = ''                # Final string to be returned
    div_by_3 = cents%3 == 0   # Boolean variable that is true if the total change is divisible by 3
    
    coin_cents = [0] * 5     # Tracks the number of each denomination, will be returned by this function

    for i in range(0,4):
        # Number of each denomination is determined, picked randomly if the total cents is divisible by 3
        if(div_by_3):
            num_coins = random.randint(0,int(cents/coin_values[i]))
            cents = cents - num_coins*coin_values[i]
        else:    
            num_coins = int(cents/coin_values[i])
            cents = cents%coin_values[i]
        
        coin_cents[i] = num_coins
        
        if num_coins == 0:  # Add nothing to string if number of that coin type is zero
            continue  
        
        # Add the number of each denomination to the final string
        coin_string = coin_string + str(num_coins) + ' ' +  coin_names[i]
        if num_coins > 1:
            coin_string = coin_string + 's'
        coin_string = coin_string + ', '
    
    # All remaining cents are set as pennies
    coin_cents[4] = cents
    if cents > 0:
        coin_string = coin_string + '1 penny' if cents == 1 else coin_string + str(cents) + ' pennies'
        
    # The resulting string and array of coins is returned
    return (coin_string, coin_cents)