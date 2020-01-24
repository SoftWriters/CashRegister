Cash Register

This application allows a user to select a flat input file from their machine containing one to many lines of data. The contents of the input file will be displayed on the screen for the user's reference. Each line in the input file will correspond to the same line in the output file. The output will be displayed on the screen as well as written to a file for the user to download. The output file will display the amount of change owed to the customer for each line of valid data. In most cases the minimum amount of physical change will be produced. If total due in cents is divisible by three, the change denominations will be randomized. This will be noted in the output with the phrase '(Total due in cents was divisible by 3; Denominations are randomly generated.)' In order for data to be processed it must contain two comma separated decimal values. The first value represents total amount due and the second represents the amount the customer has paid. If data is not in the correct format or if the amount the customer has paid is higher than the total due, the phrase 'Invalid Input' will be printed for that line of data. A sample input file has been provided containing both valid and invalid data.

Solution Notes:
The solution for the two projects in this application was created using Visual Studio 2019 Community Edition. CashRegister project contains the WinForms application written in C# using the .NET Framework. UnitTests project contains 21 Unit Tests which test the functionality of the CashRegister project. This project uses the Microsoft Unit Test Framework.

Technologies Used:
1.) Microsoft Windows Forms
2.) .NET Framework v4.7.2
3.) C# version v7.3
4.) Microsoft Unit Test Framework v1.3.2
5.) SimpleInjector v4.8.1 (for Dependency Injection)
