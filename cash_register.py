class ChangeCalculator():

    # converting a str flat file into a list
    def convert_to_float(self, currency):

        new_curr = currency.split(",")
        total = float(new_curr[0])
        amt_given = float(new_curr[1])

        return total, amt_given

    def change_calculate(self, total_01, amt_given_01):

        # ***UPDATE***
        # Actually accessing convert_to_float() and returning
        # its value to perform operations in this function

        total_01 = int(total_01 * 100)             # multiply both by 100 to avoid
        amt_given_01 = int(amt_given_01 * 100)     # floating point arithmetic
        
        # returns last to digits to check for divisibility
        total_div_3 = self.get_last_digits(total_01)

        if amt_given_01 < total_01:
            return False
        elif total_div_3 % 3 == 0:
            # runs random function
            total_change = amt_given_01 - total_01
            change = self.random_denominations(total_change / 100)
            return change
        else:
            # runs regular conversion function
            total_change = amt_given_01 - total_01
            change = self.change_denominations(total_change / 100)
            return change

        

    def get_last_digits(self, num):
        # indexes the last two digits of a cast sting then cast again as an integer
        total_coins = int(str(num)[-2:])
        # **NOTES** total_coins = abs(num) % 100 does not work for random
        return total_coins
   
    def change_denominations(self, total_change):

        # mulitplied by 100 again for float arithmetic
        total_change = total_change * 100     
        
        # this dictionary stores the amount of each denomination 
        denom_dict = {
            "dollar_amt": 0,
            "quarter_amt": 0,
            "dime_amt": 0,
            "nickel_amt": 0,
            "penny_amt": 0   
        }
        
        # accessing each dict key and updated total change per function call
        denom_dict["dollar_amt"], total_change = self.denom_conversion(total_change, 100)
        denom_dict["quarter_amt"], total_change = self.denom_conversion(total_change, 25)
        denom_dict["dime_amt"], total_change = self.denom_conversion(total_change, 10)
        denom_dict["nickel_amt"], total_change = self.denom_conversion(total_change, 5)
        denom_dict["penny_amt"], total_change = self.denom_conversion(total_change, 1)

        # variables to access value of dictionary
        dollar_amt = denom_dict["dollar_amt"]
        quarter_amt = denom_dict["quarter_amt"]
        dime_amt = denom_dict["dime_amt"]
        nickel_amt = denom_dict["nickel_amt"]
        penny_amt = denom_dict["penny_amt"]

        denoms = ""

        # conditional statements establishing plurality
        if dollar_amt < 1:
            pass
        elif dollar_amt > 1:
            denoms += f"{dollar_amt} dollars, "
        else:
            denoms += f"{dollar_amt} dollar, "

        if quarter_amt < 1:
            pass 
        elif quarter_amt > 1:
            denoms += f"{quarter_amt} quarters, "
        else:
            denoms += f"{quarter_amt} quarter, "

        if dime_amt < 1:
            pass
        elif dime_amt > 1:
            denoms += f"{dime_amt} dimes, "
        else:
            denoms += f"{dime_amt} dime, "

        if nickel_amt < 1:
            pass
        elif nickel_amt > 1:
            denoms += f"{nickel_amt} nickels, "
        else:
            denoms += f"{nickel_amt} nickel, "

        if penny_amt < 1:
            pass
        elif penny_amt > 1:
            denoms += f"{penny_amt} pennies"
        else:
            denoms += f"{penny_amt} penny"

        print(denoms)
        return denoms


    def denom_conversion(self, total_change, change):

        # looping thru each denomination returning the denom amount and updated total
        # where total_change is the remaining change value and change is an int for
        # each denomination value (i.e., if change = 100, that's a dollar)
        denom_amt = 0
        while total_change >= change:
            if total_change >= change:
                total_change -= change
                denom_amt += 1
            
        return denom_amt, total_change

    def rand_denom_conversion(self, total_change, change, denom_amt):
        
        # similar to denom_conversion() function but instead of
        # looping thru to get maximum amount of each denom, it 
        # only returns one at a time.
        # denom_amt value is updated and returned with each call
        if total_change >= change:
            total_change -= change
            denom_amt += 1

        return denom_amt, total_change

    def random_denominations(self, total_change):
        import random

        # similar to denom_conversion()
        # mult for FP arithmetic
        total_change = total_change * 100

        # dictionary initialized
        DENOMS = {
            "dollar_amt": 0,
            "quarter_amt": 0,
            "dime_amt": 0,
            "nickel_amt": 0,
            "penny_amt": 0   
        }
        

        # elements in rand_list reference which function to call
        # similar to a dice roll. each call returns denom amount
        # and updated total same as denom_conversion()
        rand_list = [1, 2, 3, 4, 5]

        while total_change > 0:
            random_choice = random.choice(rand_list)
            if random_choice == 1:
                DENOMS["dollar_amt"], total_change = self.rand_denom_conversion(total_change, 100, DENOMS["dollar_amt"])
                
            if random_choice == 2:
                DENOMS["quarter_amt"], total_change = self.rand_denom_conversion(total_change, 25, DENOMS["quarter_amt"])
                
            if random_choice == 3:
                DENOMS["dime_amt"], total_change = self.rand_denom_conversion(total_change, 10, DENOMS["dime_amt"])
                
            if random_choice == 4:
                DENOMS["nickel_amt"], total_change = self.rand_denom_conversion(total_change, 5, DENOMS["nickel_amt"])
                
            if random_choice == 5:
                DENOMS["penny_amt"], total_change = self.rand_denom_conversion(total_change, 1, DENOMS["penny_amt"])
            
        # same setup as in denom_conversions() function
        dollar_amt = DENOMS["dollar_amt"]
        quarter_amt = DENOMS["quarter_amt"]
        dime_amt = DENOMS["dime_amt"]
        nickel_amt = DENOMS["nickel_amt"]
        penny_amt = DENOMS["penny_amt"]
        
        
        denoms = ""
        # establishing plurality
        if dollar_amt < 1:
            pass
        elif dollar_amt > 1:
            denoms += f"{dollar_amt} dollars, "
        else:
            denoms += f"{dollar_amt} dollar, "

        if quarter_amt < 1:
            pass 
        elif quarter_amt > 1:
            denoms += f"{quarter_amt} quarters, "
        else:
            denoms += f"{quarter_amt} quarter, "

        if dime_amt < 1:
            pass
        elif dime_amt > 1:
            denoms += f"{dime_amt} dimes, "
        else:
            denoms += f"{dime_amt} dime, "

        if nickel_amt < 1:
            pass
        elif nickel_amt > 1:
            denoms += f"{nickel_amt} nickels, "
        else:
            denoms += f"{nickel_amt} nickel, "

        if penny_amt < 1:
            pass
        elif penny_amt > 1:
            denoms += f"{penny_amt} pennies"
        else:
            denoms += f"{penny_amt} penny"

        print(denoms)
        return denoms