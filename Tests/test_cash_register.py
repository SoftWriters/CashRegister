from cash_register import ChangeCalculator
import pytest

change = ChangeCalculator()

#----- INITIAL TESTS FOR STRING CONVERSION TO TUPLE-----#
def test_accepts_input_00():                                                           
    money = change.convert_to_float("2.12,3.00")                                       
    assert money == (2.12, 3.00)                                                       

def test_accepts_input_01():                                                           
    money = change.convert_to_float("1.97,2.00")                                       
    assert money == (1.97, 2.00)                                                       

def test_accepts_input_02():                                                           
    money = change.convert_to_float("3.33,5.00")                                       
    assert money == (3.33, 5.00)                                                       

#------BASIC CALCULATIONS-------------------------------#
def test_amt_less_than_total():                                                        
    assert change.change_calculate(4.00, 2.00) == False                              

def test_subtraction():                                                                
    assert change.change_calculate(2.13, 3.00) == "3 quarters, 1 dime, 2 pennies"    

@pytest.mark.skip(reason="This test will fail due to random value")                    
def test_dollar_amt():                                                                 
    money = change.change_calculate(2.00, 5.00)                                      
    assert money == "3 dollars, "                                                      

#------TEST FOR ACCURATE DENOMINATION AMOUNTS-----------#
def test_quarter_amt():                                                                
    money_back = change.change_calculate(2.25, 3.00)                                 
    assert money_back == "3 quarters, "                                                

def test_coins_amt_00():                                                               
    money_back = change.change_calculate(2.13, 3.00)                                 
    assert money_back == "3 quarters, 1 dime, 2 pennies"                               

def test_coins_amt_01():                                                               
    money_back = change.change_calculate(1.97, 2.00)                                 
    assert money_back == "3 pennies"                                                   

@pytest.mark.skip(reason="This test will fail due to random value")                    
def test_coins_amt_02():                                                               
    money_back = change.change_calculate(3.33, 5.00)                                 
    assert money_back == "1 dollar, 2 quarters, 1 dime, 1 nickel, 2 pennies"           