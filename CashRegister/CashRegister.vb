Imports System.Collections.Generic
Imports System.Data

Public Class CashRegister

    'store input from file in a DataTable
    Dim input As New DataTable
    Dim amountOwed As New DataColumn("Owed")
    Dim amountPaid As New DataColumn("Paid")

    'store change in a DataTable
    Dim change As New DataTable
    Dim dollars As New DataColumn("Dollars")
    Dim quarters As New DataColumn("Quarters")
    Dim dimes As New DataColumn("Dimes")
    Dim nickels As New DataColumn("Nickels")
    Dim pennies As New DataColumn("Pennies")
    Dim changeOrder As New DataColumn("Order")
    Dim warning As New DataColumn("Warning")

    Sub New()
        'add columns to input DataTable
        input.Columns.Add(amountOwed)
        input.Columns.Add(amountPaid)

        'change data types
        changeOrder.DataType = System.Type.GetType("System.Int32[]")

        'add columns to change DataTable
        change.Columns.Add(dollars)
        change.Columns.Add(quarters)
        change.Columns.Add(dimes)
        change.Columns.Add(nickels)
        change.Columns.Add(pennies)
        change.Columns.Add(changeOrder)
        change.Columns.Add(warning)


    End Sub

    Sub ParseNewData(ByVal data As String())

        'number of loops
        Dim loopCount As Integer = data.Length - 1
        'loop through input String() and add values to input DataTable
        For x As Integer = 0 To loopCount

            'split the current line into a String() based on a comma character
            Dim tempInput As String() = data.GetValue(x).ToString.Split(New Char() {","c})

            'create a new DataRow using the input DataTable schema
            Dim newRow As DataRow = input.NewRow()

            'add the first value to the amount owed
            newRow("Owed") = tempInput.GetValue(0)

            'add the second value to the amount paid
            newRow("Paid") = tempInput.GetValue(1)

            'add the row to the 
            input.Rows.Add(newRow)

        Next

    End Sub

    Function GetChange() As DataTable


        'number of rows in input DataTable
        Dim rowLoop As Integer = input.Rows.Count

        For y As Integer = 0 To rowLoop - 1

            'create a new DataRow using the change DataTable schema
            Dim newRow As DataRow = change.NewRow()
            newRow("Dollars") = 0
            newRow("Quarters") = 0
            newRow("Dimes") = 0
            newRow("Nickels") = 0
            newRow("Pennies") = 0
            newRow("Order") = {1, 2, 3, 4, 5}
            newRow("Warning") = ""

            'current owed value
            Dim currentOwed As Decimal

            'current paid value
            Dim currentPaid As Decimal

            'if the current row has a value for owed
            If Not String.IsNullOrWhiteSpace(input.Rows.Item(y).Item(0)) Then
                'save it
                currentOwed = input.Rows.Item(y).Item(0)

            End If

            'if the current row has a value for paid
            If Not String.IsNullOrWhiteSpace(input.Rows.Item(y).Item(1)) Then
                'save it
                currentPaid = input.Rows.Item(y).Item(1)

            End If

            'calculate change
            Dim changeAmount As Decimal = currentPaid - currentOwed

            'if not enough change was provided
            If changeAmount < 0 Then
                'then make new row with warning
                newRow.Item("Warning") = "Insufficient funds provided"
            Else
                'check to see if the change is divisible by three 
                Dim changeAmountDivisibleByThree As String = ((changeAmount) / 3.0).ToString()

                'if the change is divisble by three, there won't be anything after the decimal place.
                If changeAmountDivisibleByThree.Substring(changeAmountDivisibleByThree.IndexOf(".")).Length > 1 Then
                    'calculate change normally
                    '1 = dollar
                    '2 = quarter
                    '3 = dime
                    '4 = nickel
                    '5 = penny

                    'add the order to the row
                    newRow.Item("Order") = {1, 2, 3, 4, 5}
                    CalculateChange(changeAmount, newRow, newRow.Item("Order"))
                Else
                    'create an Integer Array using random values from 1 to 5
                    Dim randomOrder As New List(Of Integer)
                    Dim random As New Random()
                    For z As Integer = 0 To 4
                        randomOrder.Add(random.Next(1, 6))
                    Next
                    'add the order to the row
                    newRow.Item("Order") = randomOrder.ToArray()

                    'calculate change using random algorithm
                    CalculateChange(changeAmount, newRow, newRow.Item("Order"))
                End If

            End If

            'add the row to the 
            change.Rows.Add(newRow)

        Next

        Return change

    End Function

    Private Sub CalculateChange(ByVal changeAmount As Decimal,
                             ByRef newRow As DataRow, ByVal order As Integer())

        'get current value of change
        Dim currentValue As Decimal = changeAmount

        'loop through the order of calculating change
        For b As Integer = 0 To order.Length - 1
            '1 = dollar
            '2 = quarter
            '3 = dime
            '4 = nickel
            '5 = penny

            If order.GetValue(b) = 1 Then
                HandleDollars(currentValue, newRow, order.GetValue(b))
            ElseIf order.GetValue(b) = 2 Then
                HandleQuarters(currentValue, newRow)
            ElseIf order.GetValue(b) = 3 Then
                HandleDimes(currentValue, newRow)
            ElseIf order.GetValue(b) = 4 Then
                HandleNickels(currentValue, newRow)
            ElseIf order.GetValue(b) = 5 Then
                HandlePennies(currentValue, newRow)
            End If

        Next

    End Sub

    Private Sub HandleDollars(ByRef currentValue As Decimal, ByRef newRow As DataRow, ByVal nextDenomination As Integer)
        If currentValue - 1.0 >= 0 Then
            newRow.Item("Dollars") = newRow.Item("Dollars") + 1
            currentValue = currentValue - 1.0
            HandleDollars(currentValue, newRow)
        Else
            'determine which handler to use next
            If nextDenomination = 1 Then
                HandleDollars(currentValue, newRow, order.GetValue(b))
            ElseIf order.GetValue(b) = 2 Then
                HandleQuarters(currentValue, newRow)
            ElseIf order.GetValue(b) = 3 Then
                HandleDimes(currentValue, newRow)
            ElseIf order.GetValue(b) = 4 Then
                HandleNickels(currentValue, newRow)
            ElseIf order.GetValue(b) = 5 Then
                HandlePennies(currentValue, newRow)
            End If

        End If
    End Sub

    Private Sub HandleQuarters(ByRef currentValue As Decimal, ByRef newRow As DataRow)
        If currentValue - 0.25 >= 0 Then
            newRow.Item("Quarters") = newRow.Item("Quarters") + 1
            currentValue = currentValue - 0.25
            HandleQuarters(currentValue, newRow)
        End If
    End Sub

    Private Sub HandleDimes(ByRef currentValue As Decimal, ByRef newRow As DataRow)
        If currentValue - 0.1 >= 0 Then
            newRow.Item("Dimes") = newRow.Item("Dimes") + 1
            currentValue = currentValue - 0.1
            HandleDimes(currentValue, newRow)
        End If
    End Sub

    Private Sub HandleNickels(ByRef currentValue As Decimal, ByRef newRow As DataRow)
        If currentValue - 0.05 >= 0 Then
            newRow.Item("Nickels") = newRow.Item("Nickels") + 1
            currentValue = currentValue - 0.05
            HandleNickels(currentValue, newRow)
        End If
    End Sub

    Private Sub HandlePennies(ByRef currentValue As Decimal, ByRef newRow As DataRow)
        If currentValue - 0.01 >= 0 Then
            newRow.Item("Pennies") = newRow.Item("Pennies") + 1
            currentValue = currentValue - 0.05
            HandlePennies(currentValue, newRow)
        End If
    End Sub

End Class