Imports System.Data

''' <summary>
''' Runs one time using predefined input and output files
''' </summary>
Public Class Main

    Public Shared Sub Main()
        'new FileIO object
        Dim fileIO As FileIO = New FileIO()

        'Read in lines from file
        Dim input As String() = fileIO.ReadText("Files\Input.txt")

        'make a new Cash Register
        Dim cashRegister As New CashRegister()

        'send the data to the Cash Register
        cashRegister.ParseNewData(input)

        'get the change from the Cash Register
        Dim change As DataTable = cashRegister.GetChange()

        'write the results to the designated file
        fileIO.WriteToOutput("Files\Output.txt", change)

    End Sub
End Class