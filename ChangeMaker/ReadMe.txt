This solution consists of two projects -- the ChangeMaker libraries, and the Console App driver.

You can run the ConsoleApp1.exe in a dos prompt and provide a filepath / filename arguments for a test input file and a test output file and it will process the input and output the results accordingly. You may have to run VS as administrator to output to C: or choose a folder in Documents.
(i.e. ConsoleApp1.exe C:\Files\TestInput.txt C:\FilesTestOutput.txt)

You can also run ConsoleApp1.exe without any arguments and it will prompt for an input file and an output file. If run with one argument it will assume that is the input file.
Output is mirrored between the Console and the output log file.

---------------------

There is one configuration file that is required -- Currencies.xml (within the Config folder in ChangeMaker). 
This file will be used to initialize all valid currencies for the system.
This was done to allow for international currencies / future-proofing the system.
You may change any of the currency names or values, but each Currency must have a name, a value, and a plural denomination name.

---------------------

The ChangeMaker libraries consist of ValidCurrencies, Currency and Transaction classes.

ValidCurrencies is the list of currencies initialized from Currencies.xml
Currency is a generic Currency class, which consists of a Denomination Name, a plural name, and a value (string and decimal)
Transaction is a class that encapsulates a buy/sell transaction, in which change is calculated.

Transaction has two public methods -- CalculateChange and DisplayChange.
CalculateChange forks into two logical branches depending on the divisibility of the 'cost', providing normal or randomized change values.
