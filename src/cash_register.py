import csv
from decimal import Decimal

"""
TO-DO LIST:
1) Find way to calculate denominations randomly
2) Write a clear main method
3) Testing
4) Probably remove calculate_change() and put it somewhere else
5) Find way to go through the final_change list and sum up and display the values 
   how it they ask in the sample output in the readme
6) Clean up so it adheres to Python coding standards
"""

# load and read file
file = csv.reader(open('file.csv'), delimiter = ',')

# using decimal class to avoid memory loss with floating points
DENOMINATIONS = {'dollar': Decimal('1.00'),
                'quarter': Decimal('0.25'),
                'dime': Decimal('0.10'),
                'nickel': Decimal('0.05'),
                'penny': Decimal('0.01')}


# do I really need this method?
def calculate_change(total, paid):
    change = paid - total
    round(change, 4)
    return change


def calculate_minimum_denominations(change):
    dynamic_change = change
    # final_change is a list that keep strack each individual 
    final_change = []

    while dynamic_change >= DENOMINATIONS['dollar']:
        final_change.append('dollar')
        dynamic_change = (dynamic_change - DENOMINATIONS['dollar'])
    while dynamic_change <= DENOMINATIONS['dollar'] and dynamic_change > DENOMINATIONS['quarter']:
        final_change.append('quarter')
        dynamic_change = (dynamic_change - DENOMINATIONS['quarter'])
    while dynamic_change <= DENOMINATIONS['quarter'] and dynamic_change > DENOMINATIONS['dime']:
        final_change.append('dime')
        dynamic_change = (dynamic_change - DENOMINATIONS['dime'])
    while dynamic_change <= DENOMINATIONS['dime'] and dynamic_change > DENOMINATIONS['nickel']:
        final_change.append('nickel')
        dynamic_change = (dynamic_change - DENOMINATIONS['nickel'])
    while dynamic_change <= DENOMINATIONS['nickel'] and dynamic_change >= DENOMINATIONS['penny']:
        final_change.append('penny')
        dynamic_change = dynamic_change - DENOMINATIONS['penny']        
    return final_change
    

# def calculate_random_denomonations(change):
#     initial_change = change

# convert this to an actual main method
for line in file:
    (total, paid) = line
    total = Decimal(total)
    paid = Decimal(paid)
    change = calculate_change(total, paid)
    #print(change)
    # check if change is not divisble by three
    # if (change % 3) != 0:
    #     change = calculate_minimum_denominations(change)
    # else:
    #     change = calculate_random_denomonations(change)
    change = calculate_minimum_denominations(change)
    print(change) 