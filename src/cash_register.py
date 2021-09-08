import csv
from decimal import Decimal

# load and read file
file = csv.reader(open('file.csv'), delimiter = ',')

# using decimal class to avoid memory loss with floating points
DENOMINATIONS = {'dollar': Decimal('1.00'),
                'quarter': Decimal('0.25'),
                'dime': Decimal('0.10'),
                'nickel': Decimal('0.05'),
                'penny': Decimal('0.01')}


def calculate_change(total, paid):
    change = paid - total
    round(change, 4)
    return change


def calculate_minimum_denominations(change):
    dynamic_change = change
    # final_change should be of string type
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