import csv
from decimal import Decimal

'''
TO-DO LIST:
1) Find way to calculate denominations randomly
2) Write a clear main method
3) Testing ideas
    - test for decimal types to ensure there are no floats
    - test type of output in calculate_minimum_denominations
6) Clean up so it adheres to Python coding standards
7) Change all code to work for up to 10, 20, maybe even 50 dollar bills
'''

# load and read file
file = csv.reader(open('data.csv'), delimiter = ',')

# using decimal class to avoid memory loss with floating points
DENOMINATIONS_VALUE = {'dollar': Decimal('1.00'),
                'quarter': Decimal('0.25'),
                'dime': Decimal('0.10'),
                'nickel': Decimal('0.05'),
                'penny': Decimal('0.01')}


DENOMINATIONS_ = {'dollar': 0,
                'quarter': 0,
                'dime': 0,
                'nickel': 0,
                'penny': 0} 


def calculate_minimum_denominations(change):
    dynamic_change = change

    '''
    final_change is a list that keeps track of each individual denomination to be returned,
    for example, ['dollar', 'quarter', 'quarter', 'quarter', 'dime', 'penny', 'penny', 'penny'].
    The total amount of each denomination will be calculated using this list before being returned as output.
    '''

    final_change = []

    while dynamic_change >= DENOMINATIONS_VALUE['dollar']:
        final_change.append('dollar')
        dynamic_change = (dynamic_change - DENOMINATIONS_VALUE['dollar'])
    while dynamic_change <= DENOMINATIONS_VALUE['dollar'] and dynamic_change > DENOMINATIONS_VALUE['quarter']:
        final_change.append('quarter')
        dynamic_change = (dynamic_change - DENOMINATIONS_VALUE['quarter'])
    while dynamic_change <= DENOMINATIONS_VALUE['quarter'] and dynamic_change > DENOMINATIONS_VALUE['dime']:
        final_change.append('dime')
        dynamic_change = (dynamic_change - DENOMINATIONS_VALUE['dime'])
    while dynamic_change <= DENOMINATIONS_VALUE['dime'] and dynamic_change > DENOMINATIONS_VALUE['nickel']:
        final_change.append('nickel')
        dynamic_change = (dynamic_change - DENOMINATIONS_VALUE['nickel'])
    while dynamic_change <= DENOMINATIONS_VALUE['nickel'] and dynamic_change >= DENOMINATIONS_VALUE['penny']:
        final_change.append('penny')
        dynamic_change = dynamic_change - DENOMINATIONS_VALUE['penny'] 
    return final_change


# def calculate_random_denomonations(change):
#     initial_change = change
    

def sum_final_change(final_change, DENOMINATIONS_):
    for denomination in final_change:
        if denomination == 'dollar':
            DENOMINATIONS_['dollar'] += 1
        elif denomination == 'quarter':
            DENOMINATIONS_['quarter'] += 1
        elif denomination == 'dime':
            DENOMINATIONS_['dime'] += 1
        elif denomination == 'nickel':
            DENOMINATIONS_['nickel'] += 1
        else:
            DENOMINATIONS_['penny'] += 1
    return DENOMINATIONS_


# must be a way to condense this, it's 40 lines
def final_change_output(change_dict):
    final_change_str = ""
    #print("dict:")
    #print(change_dict)
    change_copy = {**change_dict}
    #print(change_dict)
    for denom in change_copy:
        if change_copy['dollar'] > 0:
            if change_copy[denom] == 1:
                final_change_str = final_change_str + "1 dollar, "
                change_copy[denom] = 0
            elif change_copy[denom] > 1:
                final_change_str = final_change_str + f"{change_copy['dollar']} dollars, "
                change_copy[denom] = 0
        if change_copy['quarter'] > 0:
            if change_copy[denom] == 1:
                final_change_str = final_change_str + "1 quarter, "
                change_copy[denom] = 0
            elif change_copy[denom] > 1:
                final_change_str = final_change_str + f"{change_copy['quarter']} quarters, "
                change_copy[denom] = 0
        if change_copy['dime'] > 0:
            if change_copy[denom] == 1:
                final_change_str = final_change_str + "1 dime, "
                change_copy[denom] = 0
            elif change_copy[denom] > 1:
                final_change_str = final_change_str + f"{change_copy['dime']} dimes, "
                change_copy[denom] = 0
        if change_copy['nickel'] > 0:
            if change_copy[denom] == 1:
                final_change_str = final_change_str + "1 nickel, "
                change_copy[denom] = 0
            elif change_copy[denom] > 1:
                final_change_str = final_change_str + f"{change_copy['nickel']} nickels, "
                change_copy[denom] = 0
        if change_copy['penny'] > 0:
            if change_copy[denom] == 1:
                final_change_str = final_change_str + "1 penny, "
                change_copy[denom] = 0
            elif change_copy[denom] > 1:
                final_change_str = final_change_str + f"{change_copy['penny']} pennies, "
                change_copy[denom] = 0
    return final_change_str


for line in file:
    (total, paid) = line
    total = Decimal(total)
    paid = Decimal(paid)
    change = paid - total
    rem = change % Decimal('.03')
    if rem != Decimal('0.00'):       
        change = calculate_minimum_denominations(change)
        change = sum_final_change(change, DENOMINATIONS_)
        change = final_change_output(change)
        print(change)
        print()
    else:        
        #change = calculate_random_denomonations(change)
        print("divisible by three")
        print()
    DENOMINATIONS_ = DENOMINATIONS_.fromkeys(DENOMINATIONS_, 0)
    