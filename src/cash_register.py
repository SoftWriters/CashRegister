import csv
from decimal import Decimal

# load and read file
file = csv.reader(open('file.csv'), delimiter = ',')

# dictionary for denomination and value?
# is this structure necesary?
DENOMINATIONS = {#'hundred_dollar': 100.00,
                #'fifty_dollar': 50.00,
                #'twenty_dollar': 20.00,
                #'ten_dollar': 10.00,
                #'five_dollar': 5.00,
                'dollar': float(1.00),
                'quarter': float(0.25),
                'dime': float(0.10),
                'nickel': float(0.05),
                'penny': float(0.01)}

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
        dynamic_change = (dynamic_change - 1)
        round(dynamic_change, 2)
        print(dynamic_change)
    while dynamic_change <= DENOMINATIONS['dollar'] and dynamic_change >= DENOMINATIONS['quarter']:
        final_change.append('quarter')
        dynamic_change = (dynamic_change - 0.25)
        print(dynamic_change)
        round(float(dynamic_change), 4)
        print(dynamic_change)
    while dynamic_change <= DENOMINATIONS['quarter'] and dynamic_change >= DENOMINATIONS['dime']:
        final_change.append('dime')
        dynamic_change = (dynamic_change - 0.10)
        round(dynamic_change, 4)
        #print(dynamic_change)
    while dynamic_change <= DENOMINATIONS['dime'] and dynamic_change >= DENOMINATIONS['nickel']:
        final_change.append('nickel')
        dynamic_change = (dynamic_change - 0.05)
        round(dynamic_change, 4)
        #print(dynamic_change)
    while dynamic_change <= DENOMINATIONS['nickel'] and dynamic_change >= DENOMINATIONS['penny']:
        final_change.append('penny')
        dynamic_change = (dynamic_change - 0.01)
        round(dynamic_change, 4)
        #print(dynamic_change)
    return final_change
    

# def calculate_random_denomonations(change):
#     initial_change = change


for line in file:
    (total, paid) = line
    total = float(total)
    paid = float(paid)
    change = calculate_change(total, paid)
    #print(change)
    # check if change is not divisble by three
    # if (change % 3) != 0:
    #     change = calculate_minimum_denominations(change)
    # else:
    #     change = calculate_random_denomonations(change)
    change = calculate_minimum_denominations(change)
    #print(change) 