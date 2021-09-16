#Guriqbal Singh
#September 10, 2021
#Cash Register - SoftWriters - 
import math
import random

                                    #Assign values to each denomination and update cents
def change(cents):                  #this function will determine how much change is owed to the customer //logic
    dollars =0                      #Assign Dollars to value 0  
    quarters =0                     #Assign Quarters to value 0 
    dimes =0                        #Assign Dimes to value 0    
    nickels =0                      #Assign Nickels to value 0
    pennies =0                      #Assign Pennies to value 0
    dollars = int(cents / 100)      #Dollars
    cents = cents - (dollars * 100)
    quarters = math.trunc(cents/25) #Convert Cents to quarters
    cents = cents - (quarters*25)   #subtract converted quarters from cents
    dimes = math.trunc(cents/10)    #Convert Cents to dimes
    cents = cents - (dimes*10)      #subtract converted dimes from cents
    nickels = math.trunc(cents/5)   #Convert Cents to nickels
    cents = cents - (nickels*5)     #subtract converted nickles from cents
    pennies = cents                 
    data=""


                         #return all the data 
    
    if(float(dollars)!=0):          #if dollars is != 0          if value is > 0 then append the string
        if(data==""):
            data = "Dollars: ", float("{:.2f}".format(dollars))            
        else:
            data = data ," , Dollars: ", float("{:.2f}".format(dollars))    
    if (float(quarters) != 0):      #if quarters is != 0
        if (data == ""):
            data = "Quarters: ", float("{:.2f}".format(quarters))   
        else:
            data = data ," , Quarters: ", float("{:.2f}".format(quarters))  
    if (float(dimes) != 0):         #if dimes is  != 0
        if (data == ""):
            data = "Dimes: ", float("{:.2f}".format(dimes))                 
        else:
            data = data," , Dimes: ", float("{:.2f}".format(dimes))     
    if (float(nickels) != 0):       #if nickels is  != 0
        if (data == ""):
            data = "Nickles: ", float("{:.2f}".format(nickels))             
        else:
            data = data ," , Nickels: ", float("{:.2f}".format(nickels))    
    if (pennies != 0 and cents!=0): #if pennies is  != 0
        if (data == ""):
            data = "Pennies: ", float("{:.2f}".format(pennies))             
        else:
            data = data ," , Pennies: ", float("{:.2f}".format(pennies))    

    #format the results so that it looks clean and not overloaded with parentheses. 
    data = str(data)
    data = data.replace("(","")
    data = data.replace(")", "")
    return data


datatoWrite = []    #for the outputfile 
f = open("output.txt", "w")
with open ("test.txt") as file:                         #open test.txt 
    for line in file:                                   #read file line by line
        line = line.rstrip("\n").split(",")             #seprate lines by commas and remove "\n"
        total_due = float(line[1])-float(line[0])       #calculation for the amount due to the customer 
        cents = total_due*100                           #Convert total into Cents
        data = str((change(cents)))                     #call the change function 
        datatoWrite.append(data)
        print(data)
    for line in datatoWrite:
        f.write("%s\n" % line)                          #print the results in output.txt 
    f.close()                               
