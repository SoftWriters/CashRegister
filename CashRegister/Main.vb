Imports System.IO

Public Class Main


    Public Sub Main()
        'new FileIO object
        Dim fileIO As FileIO = New FileIO()

        'get file path
        Dim path As String = Directory.GetCurrentDirectory()
        path = path.Replace("bin\Debug", "")

        'Read in lines from file
        Dim input As String() = fileIO.ReadText(path & "Files\Input.txt")

        Dim cashRegister As New CashRegister.CashRegisterObject

        'Write output to file
        File.WriteAllLines(path & "Files\Output.txt", input)

    End Sub
End Class