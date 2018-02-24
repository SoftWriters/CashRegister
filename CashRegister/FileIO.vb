Option Strict On
Option Explicit On
Imports Microsoft.VisualBasic
Imports System.IO
Imports System

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

        Dim lines As String() = {}

        'if file exists
        If File.Exists(filePath) Then

            Try

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
    ''' Writes a String Array of Values to a text file
    ''' </summary>
    ''' <param name="lines"></param>
    ''' <param name="filePath"></param>
    ''' <param name="overwrite"></param>
    Sub WriteToFile(ByVal lines As String(), ByVal filePath As String, Optional ByVal overwrite As Boolean = True, Optional ByVal tries As Integer = 0)

        'if overwrite is true
        If overwrite = True Then
            'just write to the file
            Try
                File.WriteAllLines(filePath, lines)
            Catch ex As Exception
                Throw New System.Exception("Could not write to location: " & filePath)
            End Try

        Else
            tries = tries + 1

            'try 3 times and if that doesn't work, throw an Exception
            If tries <> 3 Then

                Dim random As New Random()

                'create a new file name
                filePath = filePath.Replace(".txt", random.Next(1, 100000).ToString & ".txt")
                Try
                    File.WriteAllLines(filePath, lines)
                Catch ex As Exception
                    'try again
                    Console.WriteLine("Attempting to create a valid file name again")
                    WriteToFile(lines, filePath, False, tries)
                End Try

            Else
                Throw New Exception("Cannot create new file, specify a unique filename!")
            End If

        End If

    End Sub

End Class
