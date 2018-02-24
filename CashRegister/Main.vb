Imports System.Data
Imports System.IO

Public Class Main

    Public Shared Sub Main()
        'new FileIO object
        Dim fileIO As FileIO = New FileIO()

        'get file path
        Dim path As String = Directory.GetCurrentDirectory()
        path = path.Replace("bin\Debug", "")

        'Read in lines from file
        Dim input As String() = fileIO.ReadText(path & "Files\Input.txt")

        'make a new Cash Register
        Dim cashRegister As New CashRegister()

        'send the data to the Cash Register
        cashRegister.ParseNewData(input)

        'get the change from the Cash Register
        Dim change As DataTable = cashRegister.GetChange()

        'open the output file
        Dim outputFile As StreamWriter
        Try
            outputFile = New StreamWriter(path & "Files\Output.txt")
        Catch ex As Exception
            Throw New Exception("Cannot write to the designated output file!")
        End Try

        'Write change values to a file

        'get number of rows in the change DataTable to loop through
        Dim changeLoop As Integer = change.Rows.Count - 1

        For x As Integer = 0 To changeLoop

            'if no warnings
            If change.Rows.Item(0).Item("Warning") = "" Then

                'get the order of change for this row
                Dim order As Integer() = change.Rows.Item(0).Item("Order")

                'change values as String
                Dim changeString As String = ""

                'build the change String
                For y As Integer = 0 To order.Length - 1

                    If order.GetValue(y) = 1 Then
                        changeString = changeString & change.Rows.Item(x).Item("Dollars").ToString & " dollars,"
                    ElseIf order.GetValue(y) = 2 Then
                        changeString = changeString & change.Rows.Item(x).Item("Quarters").ToString & " quarters,"
                    ElseIf order.GetValue(y) = 3 Then
                        changeString = changeString & change.Rows.Item(x).Item("Dimes").ToString & " dimes,"
                    ElseIf order.GetValue(y) = 4 Then
                        changeString = changeString & change.Rows.Item(x).Item("Nickels").ToString & " nickels,"
                    ElseIf order.GetValue(y) = 5 Then
                        changeString = changeString & change.Rows.Item(x).Item("Pennies").ToString & " pennies,"
                    End If

                Next

                'get rid of last comma
                If changeString.Substring(changeString.Length - 1) = "," Then
                    changeString = changeString.Substring(0, changeString.Length - 1)
                End If

                outputFile.WriteLine(changeString)

            Else

                'write the warning
                outputFile.WriteLine(change.Rows.Item(0).Item("Warning"))

            End If

        Next

        outputFile.Close()

    End Sub
End Class