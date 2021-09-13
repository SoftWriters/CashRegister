from cash_register import ChangeCalculator

c = ChangeCalculator()

print("Please enter total and amount given")

total, amt_given = c.convert_to_float(input())
calc = c.change_calculate(total, amt_given)
