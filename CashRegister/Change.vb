Public Class Change
    Dim changeAmount As Decimal = 0

    Public Function returnChange(amtOwed As Decimal, amtPaid As Decimal) As String
        Dim strChange As String = ""
        Dim dollarsReturned As Integer = 0
        Dim quartersReturned As Integer = 0
        Dim dimesReturned As Integer = 0
        Dim nickelsReturned As Integer = 0
        Dim centsReturned As Integer = 0
        Dim RandomClass As New Random()

        Try
            'Get change amount
            changeAmount = amtPaid - amtOwed

            ' check if divisible by 3
            If amtOwed Mod 3 = 0 Then
                Do Until changeAmount = 0
                    Select Case RandomClass.Next(1, 6)
                        Case 1 'Dollars
                            'Calculate dollars returned
                            dollarsReturned += dollarCount(changeAmount, True)
                        Case 2 'Quarters
                            'Calculate quarters returned
                            quartersReturned += quarterCount(changeAmount, True)
                        Case 3 'Dimes
                            'Calculate dimes returned
                            dimesReturned += dimeCount(changeAmount, True)
                        Case 4 'Nickels
                            'Calculate nickels returned
                            nickelsReturned += nickelCount(changeAmount, True)
                        Case 5 'Cents
                            'Calculate cents returned
                            centsReturned += centCount(changeAmount, True)
                    End Select

                Loop
            Else
                'Calculate dollars returned
                dollarsReturned = dollarCount(changeAmount, False)
                'Calculate quarters returned
                quartersReturned = quarterCount(changeAmount, False)
                'Calculate dimes returned
                dimesReturned = dimeCount(changeAmount, False)
                'Calculate nickels returned
                nickelsReturned = nickelCount(changeAmount, False)
                'Calculate cents returned
                centsReturned = centCount(changeAmount, False)
            End If

            'build change string
            If dollarsReturned > 0 Then
                strChange += dollarsReturned.ToString
                If dollarsReturned = 1 Then
                    strChange += " dollar, "
                Else
                    strChange += " dollars, "
                End If
            End If

            If quartersReturned > 0 Then
                strChange += quartersReturned.ToString
                If quartersReturned = 1 Then
                    strChange += " quarter, "
                Else
                    strChange += " quarters, "
                End If
            End If

            If dimesReturned > 0 Then
                strChange += dimesReturned.ToString
                If dimesReturned = 1 Then
                    strChange += " dime, "
                Else
                    strChange += " dimes, "
                End If
            End If

            If nickelsReturned > 0 Then
                strChange += nickelsReturned.ToString
                If nickelsReturned = 1 Then
                    strChange += " nickel, "
                Else
                    strChange += " nickels, "
                End If
            End If

            If centsReturned > 0 Then
                strChange += centsReturned.ToString
                If centsReturned = 1 Then
                    strChange += " penny"
                Else
                    strChange += " pennies"
                End If
            End If

            strChange = strChange.TrimEnd().TrimEnd(",")

        Catch ex As Exception
            'return error
            Return String.Format("{0} & " - " & {1}", ex.Message, ex.InnerException.ToString)
        End Try

        'return change string
        Return strChange
    End Function

    Private Function dollarCount(amount As Decimal, bSingle As Boolean) As Integer
        Dim dollarCountReturn As Integer = 0
        Dim dollarValue As Decimal = CDec(1.0)

        If bSingle = True Then
            If changeAmount >= dollarValue Then
                changeAmount -= dollarValue
                dollarCountReturn = 1
            End If
        Else
            dollarCountReturn = changeAmount - (changeAmount Mod dollarValue)
            changeAmount = changeAmount Mod dollarValue
        End If

        Return dollarCountReturn
    End Function

    Private Function quarterCount(amount As Decimal, bSingle As Boolean) As Integer
        Dim quarterCountReturn As Integer = 0
        Dim quarterValue As Decimal = CDec(0.25)

        If bSingle = True Then
            If changeAmount >= quarterValue Then
                changeAmount -= quarterValue
                quarterCountReturn = 1
            End If
        Else
            quarterCountReturn = (changeAmount - (changeAmount Mod quarterValue)) / quarterValue
            changeAmount = changeAmount Mod quarterValue
        End If

        Return quarterCountReturn
    End Function

    Private Function dimeCount(amount As Decimal, bSingle As Boolean) As Integer
        Dim dimeCountReturn As Integer = 0
        Dim dimeValue As Decimal = CDec(0.1)

        If bSingle = True Then
            If changeAmount >= dimeValue Then
                changeAmount -= dimeValue
                dimeCountReturn = 1
            End If
        Else
            dimeCountReturn = (changeAmount - (changeAmount Mod dimeValue)) / dimeValue
            changeAmount = changeAmount Mod dimeValue
        End If

        Return dimeCountReturn
    End Function

    Private Function nickelCount(amount As Decimal, bSingle As Boolean) As Integer
        Dim nickelCountReturn As Integer = 0
        Dim nickelValue As Decimal = CDec(0.05)

        If bSingle = True Then
            If changeAmount >= nickelValue Then
                changeAmount -= nickelValue
                nickelCountReturn = 1
            End If
        Else
            nickelCountReturn = (changeAmount - (changeAmount Mod nickelValue)) / nickelValue
            changeAmount = changeAmount Mod nickelValue
        End If

        Return nickelCountReturn
    End Function

    Private Function centCount(amount As Decimal, bSingle As Boolean) As Integer
        Dim centCountReturn As Integer = 0
        Dim centValue As Decimal = CDec(0.01)

        If bSingle = True Then
            If changeAmount >= centValue Then
                changeAmount -= centValue
                centCountReturn = 1
            End If
        Else
            centCountReturn = (changeAmount - (changeAmount Mod centValue)) / centValue
            changeAmount = changeAmount Mod centValue
        End If

        Return centCountReturn
    End Function

End Class
