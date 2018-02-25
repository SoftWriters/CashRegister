Imports System.IO

''' <summary>
''' Handles reading input and writing output
''' </summary>
Public Class FileIO

    Sub New()
        'default constructor
    End Sub

    ''' <summary>
    ''' Returns an Array of text
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Function ReadText(ByVal filePath As String) As String()

        'get file path
        Dim path As String = Directory.GetCurrentDirectory()
        path = path.Replace("bin\Debug", "")

        'create the full file path
        filePath = path & filePath

        Dim lines As String() = {}

        'if file exists
        If File.Exists(filePath) Then

            Try
                'read in all lines in the file as a String()
                lines = File.ReadAllLines(filePath)

            Catch ex As Exception
                Throw New System.Exception("Something went wrong with reading lines from the file.")
            End Try

        Else
            Throw New System.Exception("File Not Found!")

        End If

        Return lines

    End Function

    ''' <summary>
    ''' Writes the change due to the designated output file fileString
    ''' </summary>
    ''' <param name="fileString"></param>
    ''' <param name="change"></param>
    Public Sub WriteToOutput(ByVal fileString As String, ByRef change As Data.DataTable)

        'get file path
        Dim path As String = Directory.GetCurrentDirectory()
        path = path.Replace("bin\Debug", "")

        'open the output file so it can be written to
        Dim outputFile As StreamWriter
        Try
            outputFile = New StreamWriter(path & fileString)
        Catch ex As Exception
            Throw New Exception("Cannot write to the designated output file!")
        End Try

        'get number of rows in the change DataTable to loop through
        Dim changeLoop As Integer = change.Rows.Count - 1

        For x As Integer = 0 To changeLoop

            'if no warnings
            If change.Rows.Item(x).Item("Warning") = "" Then

                'get the order of change for this row
                Dim order As Integer() = change.Rows.Item(x).Item("Order")

                'change values as String
                Dim changeString As String = ""

                'build the change String
                For y As Integer = 0 To order.Length - 1

                    'dollars
                    If order.GetValue(y) = 1 Then
                        If Not change.Rows.Item(x).Item("Dollars") = "0" Then
                            Dim noun As String = ""
                            If change.Rows.Item(x).Item("Dollars") = "1" Then
                                noun = " dollar,"
                            Else
                                noun = " dollars,"
                            End If
                            changeString = changeString & change.Rows.Item(x).Item("Dollars").ToString & noun
                        End If
                        'quarters
                    ElseIf order.GetValue(y) = 2 Then
                        If Not change.Rows.Item(x).Item("Quarters") = "0" Then
                            Dim noun As String = ""
                            If change.Rows.Item(x).Item("Quarters") = "1" Then
                                noun = " quarter,"
                            Else
                                noun = " quarters,"
                            End If
                            changeString = changeString & change.Rows.Item(x).Item("Quarters").ToString & noun
                        End If
                        'dimes
                    ElseIf order.GetValue(y) = 3 Then
                        If Not change.Rows.Item(x).Item("Dimes") = "0" Then
                            Dim noun As String = ""
                            If change.Rows.Item(x).Item("Dimes") = "1" Then
                                noun = " dime,"
                            Else
                                noun = " dimes,"
                            End If
                            changeString = changeString & change.Rows.Item(x).Item("Dimes").ToString & noun
                        End If
                        'nickels
                    ElseIf order.GetValue(y) = 4 Then
                        If Not change.Rows.Item(x).Item("Nickels") = "0" Then
                            Dim noun As String = ""
                            If change.Rows.Item(x).Item("Nickels") = "1" Then
                                noun = " nickel,"
                            Else
                                noun = " nickels,"
                            End If
                            changeString = changeString & change.Rows.Item(x).Item("Nickels").ToString & noun
                        End If
                        'pennies
                    ElseIf order.GetValue(y) = 5 Then
                        If Not change.Rows.Item(x).Item("Pennies") = "0" Then
                            Dim noun As String = ""
                            If change.Rows.Item(x).Item("Pennies") = "1" Then
                                noun = " penny,"
                            Else
                                noun = " pennies,"
                            End If
                            changeString = changeString & change.Rows.Item(x).Item("Pennies").ToString & noun
                        End If
                    End If
                Next

                'get rid of last comma
                If Not String.IsNullOrWhiteSpace(changeString) Then
                    If changeString.Substring(changeString.Length - 1) = "," Then
                        changeString = changeString.Substring(0, changeString.Length - 1)
                    End If

                    outputFile.WriteLine(changeString)
                End If
            Else
                'write the warning
                outputFile.WriteLine(change.Rows.Item(x).Item("Warning"))
            End If

        Next

        'close the StreamWriter
        outputFile.Close()

    End Sub

End Class