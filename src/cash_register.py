import csv
from decimal import Decimal

# load and read file
file = csv.reader(open('file.csv'), delimiter = ',')

# dictionary for denomination and value?
# is this structure necesary?
DENOMINATIONS = {'hundred_dollar': 100.00,
                'fifty_dollar': 50.00,
                'twenty_dollar': 20.00,
                'ten_dollar': 10.00,
                'five_dollar': 5.00,
                'one_dollar': 1.00,
                'quarter': 0.25,
                'dime': 0.10,
                'nickel': 0.05,
                'penny': 0.01}

def calculate_change(total, paid):
    change = paid - total
    return change


def calculate_minimum_denominations(change):
    initial_change = change
    # final_change should be a string
    final_change = 
    if initial_change >= DENOMINATIONS['hundred_dollar']



def calculate_random_denomonations(change):
    initial_change = change




for line in file:
    (total, paid) = line
    total = Decimal(total)
    paid = Decimal(paid)
    change = calculate_change(total, paid)
    print(change)
    # check if change is not divisble by three
    if (change % 3) != 0:
        change = calculate_minimum_denominations(change)
    else:
        change = calculate_random_denomonations(change)
    return change