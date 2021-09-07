'''
 Author: Connor Johnson
 Completed: 09/06/2021
 Contains some unit tests for calculate_change method
'''

from calculate_change import *
import numpy

coin_values = [100, 25, 10, 5, 1]

# Testing a range of positive values
for t in range(0, 500):
    change = numpy.dot(calculate_change(t)[1], coin_values)
    assert change == t, "Change is not the correct amount. Should be " + str(t) + ", but return is " + str(change)
    
# Testing a range of negative values
for t in range(-100, 0):
    assert calculate_change(t) == None, "Method should return None since it is passed a negative integer"
    
# Testing a non integer argument
assert calculate_change("some_string") == None, "Method chould return none since it is passed a non integer"