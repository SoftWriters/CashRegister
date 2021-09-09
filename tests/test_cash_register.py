import os, pytest, sys
from decimal import Decimal

myPath = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, myPath + '/../')

from register import cash_register

#two complete, add more
def test_sum_final_change_return_type():
    DENOMINATIONS_ = {'dollar': 0,
                'quarter': 0,
                'dime': 0,
                'nickel': 0,
                'penny': 0}
    change = ['quarter', 'dime', 'penny']
    final_change = cash_register.sum_final_change(change, DENOMINATIONS_)
    assert type(final_change) is dict


def test_sum_final_change_empty_input():
    DENOMINATIONS_ = {'dollar': 0,
                'quarter': 0,
                'dime': 0,
                'nickel': 0,
                'penny': 0}
    change = ['quarter', 'dime', 'penny']
    final_change = cash_register.sum_final_change(change, DENOMINATIONS_)
    assert DENOMINATIONS_['quarter'] == 1


def test_calculate_minimum_denominations_change_is_decimal():
    change = 0.01
    with pytest.raises(TypeError):
        cash_register.calculate_minimum_denominations(change)


def test_calculate_minimum_denominations_return_not_empty():
    change = Decimal('1.11')
    change = cash_register.calculate_minimum_denominations(change)
    assert print(len(change)) != 0


def test_calculate_random_denominations_change_is_decimal():
    change = 0.01
    with pytest.raises(TypeError):
        cash_register.calculate_random_denominations(change)


def test_calculate_random_denominations_return_not_empty():
    change = Decimal('1.11')
    change = cash_register.calculate_minimum_denominations(change)
    assert print(len(change)) != 0


def test_final_change_output_return_str():
    change = {'dollar': 0, 'quarter': 4, 'dime': 4, 'nickel': 4, 'penny': 8}
    output = cash_register.final_change_output(change)
    assert type(output) is str


def test_final_change_input_dict():
    change = ['sting1', 'string2', 'string3']
    with pytest.raises(TypeError):
        cash_register.final_change_output(change)


def test_final_change_output_not_empty():
    change = {'dollar': 0, 'quarter': 4, 'dime': 4, 'nickel': 4, 'penny': 8}
    output = cash_register.final_change_output(change)
    assert len(output) > 0