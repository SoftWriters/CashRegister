CashRegisterSabotta C# Console Application

Author:     Brian Sabotta
Created:    11/1/2019
Purpose:    Code Test for SoftWriters
Tools Used: Visual Studio 2017 + Resharper (for easy refactoring)
.NET Info:  C# 7.0 + .NET 4.6.1

As per the specifications of the code test, the application will take an input file, process all the lines, and write out to an output file.

The input and output files are passed via command line in the following manner:

CashRegisterSabotta.exe [input file path] [output file path]

Default paths have been set in the solution for c:\dev\InputFile.txt and c:\dev\Outputfile.txt, but can be altered to suit testing.

If any errors occur during the operation of the program through a command window, error information will be printed to the console for easy debugging.
If errors occur while debugging in Visual Studio, error information will be printed to the output window for easy debugging.

Based on the example data given, the following choices were made:

  1) an empty space will exist between every line in the output file.
  
  2) transactions that require no change will be represented by empty lines in the output file (since 0 coin counts are excluded from output)
  
  3) transactions containing garbage data will be represented by empty lines in the output file
  
  4) processing of garbage files (that do not contain any valid data) will generate an output file of empty lines
  
  