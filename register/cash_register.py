import csv
from decimal import Decimal
import random


DENOMINATIONS_VALUE = {'dollar': Decimal('1.00'),
                'quarter': Decimal('0.25'),
                'dime': Decimal('0.10'),
                'nickel': Decimal('0.05'),
                'penny': Decimal('0.01')}


def calculate_minimum_denominations(change):
    dynamic_change = change
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


def calculate_random_denominations(change):
    denoms = ['dollar', 'quarter', 'dime', 'nickel', 'penny']
    #print(type(change))
    dynamic_change = change
    final_change = []
    while dynamic_change > Decimal('0.00'):
        if dynamic_change >= DENOMINATIONS_VALUE['dollar']:
            random_denom = random.choice(denoms)
            final_change.append(random_denom)
            dynamic_change = (dynamic_change - DENOMINATIONS_VALUE[random_denom])
        elif dynamic_change >= DENOMINATIONS_VALUE['quarter'] and dynamic_change < DENOMINATIONS_VALUE['dollar']:
            exception = ['dollar']
            random_denom = random.choice([denom for denom in denoms if denom not in exception])
            final_change.append(random_denom)
            dynamic_change = (dynamic_change - DENOMINATIONS_VALUE[random_denom])
        elif dynamic_change >= DENOMINATIONS_VALUE['dime'] and dynamic_change < DENOMINATIONS_VALUE['quarter']:
            exception = ['dollar', 'quarter']
            random_denom = random.choice([denom for denom in denoms if denom not in exception])
            final_change.append(random_denom)
            dynamic_change = (dynamic_change - DENOMINATIONS_VALUE[random_denom])
        elif dynamic_change >= DENOMINATIONS_VALUE['nickel'] and dynamic_change < DENOMINATIONS_VALUE['dime']:
            exception = ['dollar', 'quarter', 'dime']
            random_denom = random.choice([denom for denom in denoms if denom not in exception])
            final_change.append(random_denom)
            dynamic_change = (dynamic_change - DENOMINATIONS_VALUE[random_denom])
        elif dynamic_change >= DENOMINATIONS_VALUE['penny'] and dynamic_change < DENOMINATIONS_VALUE['nickel']:
            final_change.append(DENOMINATIONS_VALUE['penny'])
            dynamic_change = (dynamic_change - DENOMINATIONS_VALUE['penny'])
    else:
        pass
    return final_change
    

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


def final_change_output(change_dict):
    final_change_str = ""
    change_copy = {**change_dict}
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


def main():
    print()
    print()
    print("Thank you for using Creative Cash Draw Solutions Cash Register System!")
    print()
    print("In the data.csv file, please enter the price of the item being purchased")
    print()
    print("followed by the amount of money paid, separated by a comma. You may use the")
    print()
    print("data already in the file as a guide to input your own data, or leave it as it is.")
    print()
    print("After adding data, please rerun this file in order to get up to date results.") 
    print()
    print("The data being displayed currently is the data that was in the data.csv file before runtime.") 
    print()
    print()
    print()
    file = csv.reader(open('input/data.csv'), delimiter = ',')
    for line in file:
        (total, paid) = line
        total = Decimal(total)
        paid = Decimal(paid)
        change = paid - total
        rem = change % Decimal('.03')
        DENOMINATIONS_ = {'dollar': 0,
                        'quarter': 0,
                        'dime': 0,
                        'nickel': 0,
                        'penny': 0} 

        if rem != Decimal('0.00'):       
            change = calculate_minimum_denominations(change)
            change = sum_final_change(change, DENOMINATIONS_)
            change = final_change_output(change)
            print(change)
            print()
        else:        
            change = calculate_random_denominations(change)
            change = sum_final_change(change, DENOMINATIONS_)
            change = final_change_output(change)
            print(change)
            print()
        DENOMINATIONS_ = DENOMINATIONS_.fromkeys(DENOMINATIONS_, 0)


if __name__ == "__main__":
    main()