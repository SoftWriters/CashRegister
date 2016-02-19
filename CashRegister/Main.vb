Imports System.IO
Imports System.Windows.Forms

Public Class Main
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim amtOwed As Decimal = 0
        Dim amtPaid As Decimal = 0
        Dim cashArray() As String
        Dim returnChange As String = ""

        ' Call ShowDialog.
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        ' Test result.
        If result = DialogResult.OK Then
            ' clear listview
            lvwChange.Items.Clear()
            ' Get the file path.
            Dim path As String = OpenFileDialog1.FileName
            Try
                ' Open the path with the Using statement.
                Using r As StreamReader = New StreamReader(path)
                    ' Store contents in this String.
                    Dim line As String

                    ' Read first line.
                    line = r.ReadLine

                    ' Loop over each line in file.
                    Do While (Not line Is Nothing)
                        cashArray = Split(line, ",")

                        ' Clear.
                        amtOwed = 0
                        amtPaid = 0

                        ' Check for proper count in array.
                        If cashArray.Count = 2 Then
                            If IsNumeric(cashArray(0)) Then
                                amtOwed = cashArray(0)
                            End If
                            If IsNumeric(cashArray(1)) Then
                                amtPaid = cashArray(1)
                            End If
                        End If

                        If amtOwed <> 0 And amtPaid <> 0 Then
                            ' Get change string.
                            Dim rc = New Change
                            returnChange = rc.returnChange(amtOwed, amtPaid)
                        Else
                            returnChange = "Input string not properly formatted."
                        End If

                        If cashArray.Count = 2 Then
                            ' Add results to listview.
                            Dim lvi As New ListViewItem(cashArray(0).ToString)
                            lvi.SubItems.Add(cashArray(1).ToString)
                            lvi.SubItems.Add(returnChange.ToString)
                            lvwChange.Items.Add(lvi)
                        Else
                            ' Add results to listview.
                            Dim lvi As New ListViewItem("")
                            lvi.SubItems.Add("")
                            lvi.SubItems.Add(line.ToString & " - " & returnChange.ToString)
                            lvwChange.Items.Add(lvi)
                        End If

                        ' Read in the next line.
                        line = r.ReadLine
                    Loop
                End Using

            Catch ex As Exception
                ' Add error to listview
                Dim lvi As New ListViewItem("Error")
                lvi.SubItems.Add("Error")
                lvi.SubItems.Add(String.Format("{0} & " - " & {1}", ex.Message, ex.InnerException.ToString))
                lvwChange.Items.Add(lvi)

            End Try
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class
