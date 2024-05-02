Sub EditorLoadInvoice()

    'Declaring which cell ranges need to be cleared before loading new Invoice
    Range("C3:D6, C8:E11, C13:E17, J3:K4, I8:K11, B20:I29, B33:I52, B56:F59").ClearContents

    'Initialize variables
    Dim invoiceNumber As String
    Dim wsEditor As Worksheet, wsLineItems As Worksheet, wsCustomers As Worksheet, wsVehicles As Worksheet
    Dim found As Range, firstFound As String
    Dim i As Integer

    'Set references to the worksheets
    Set wsEditor = ThisWorkbook.Sheets("Invoice Editor")
    Set wsLineItems = ThisWorkbook.Sheets("Line Item Table")
    Set wsCustomers = ThisWorkbook.Sheets("Customer Table")
    Set wsVehicles = ThisWorkbook.Sheets("Vehicle Table")

    'Prompt user to enter the invoice number
    invoiceNumber = InputBox("Please enter the Invoice Number", "Load Invoice")
    If invoiceNumber = "" Then Exit Sub  ' Exit if no input

    With wsLineItems
        'Find the first occurrence of the invoice number in the Line Item Table
        Set found = .Columns("A").Find(What:=invoiceNumber, LookIn:=xlValues, LookAt:=xlWhole)
        If Not found Is Nothing Then
            firstFound = found.Address
            Do
                'Populate all single value fields from the first found row
                wsEditor.Range("C3").Value = .Cells(found.Row, "A").Value'Invoice No
                wsEditor.Range("C4").Value = .Cells(found.Row, "N").Value'Paid
                wsEditor.Range("C5").Value = .Cells(found.Row, "J").Value'Start Date
                wsEditor.Range("C6").Value = .Cells(found.Row, "K").Value'Finish Date
                wsEditor.Range("J3").Value = .Cells(found.Row, "L").Value'Invoice Date
                wsEditor.Range("J4").Value = .Cells(found.Row, "M").Value'Due By
                wsEditor.Range("C8").Value = .Cells(found.Row, "O").Value'Customer Name
                wsEditor.Range("C13").Value = .Cells(found.Row, "P").Value'Vehicle VIN

                'Check if the current found row is a Labor or Part and populates accordingly
                If .Cells(found.Row, "C").Value = "Labor" Then
                    'Populate Labor related fields
                    For i = 0 To 9  'Assuming up to 10 labor entries
                        If wsEditor.Cells(20 + i, "B").Value = "" Then
                            wsEditor.Cells(20 + i, "B").Value = .Cells(found.Row, "I").Value'Description
                            wsEditor.Cells(20 + i, "F").Value = .Cells(found.Row, "E").Value'Hours
                            wsEditor.Cells(20 + i, "H").Value = .Cells(found.Row, "G").Value'Rate
                            Exit For
                        End If
                    Next i
                ElseIf .Cells(found.Row, "C").Value = "Part" Then
                    'Populate Part related fields
                    For i = 0 To 19  'Assuming up to 20 parts entries
                        If wsEditor.Cells(33 + i, "B").Value = "" Then
                            wsEditor.Cells(33 + i, "B").Value = .Cells(found.Row, "I").Value'Description
                            wsEditor.Cells(33 + i, "F").Value = .Cells(found.Row, "E").Value'Quantity
                            wsEditor.Cells(33 + i, "H").Value = .Cells(found.Row, "G").Value'Cost
                            Exit For
                        End If
                    Next i
                End If

                'Look for the next occurrence
                Set found = .Columns("A").FindNext(found)
            Loop While Not found Is Nothing And found.Address <> firstFound
        Else
            MsgBox "Invoice number not found.", vbExclamation
            Exit Sub
        End If
    End With

    'Searching for data from the Invoice Table
    With ThisWorkbook.Sheets("Invoice Table")
        Set found = .Columns("A").Find(What:=invoiceNumber, LookIn:=xlValues, LookAt:=xlWhole)
        If Not found Is Nothing Then
            wsEditor.Range("B56").Value = found.Cells(1, "J").Value'Description of Repair
            wsEditor.Range("C11").Value = found.Cells(1, "B").Value'Customer ID
        End If
    End With

    'Searching for data from the Customer Table using Customer ID populated prior from Invoice Table
    With wsCustomers
        Set found = .Columns("A").Find(What:=wsEditor.Range("C11").Value, LookIn:=xlValues, LookAt:=xlWhole)
        If Not found Is Nothing Then
            wsEditor.Range("C9").Value = found.Cells(1, "C").Value'Phone Number
            wsEditor.Range("C10").Value = found.Cells(1, "D").Value'Email
            wsEditor.Range("I8").Value = found.Cells(1, "E").Value'Insurance Comp
            wsEditor.Range("I9").Value = found.Cells(1, "F").Value'Claim No
            wsEditor.Range("I10").Value = found.Cells(1, "G").Value'Agent Name
            wsEditor.Range("I11").Value = found.Cells(1, "H").Value'Agent Phone No
        Else
            MsgBox "Customer ID not found in Customer Table.", vbExclamation
        End If
    End With

    'Searching for data from the Vehicle Table using Vehicle VIN populated prior from Invoice Table
    With wsVehicles
        Set found = .Columns("A").Find(What:=wsEditor.Range("C13").Value, LookIn:=xlValues, LookAt:=xlWhole)
        If Not found Is Nothing Then
            wsEditor.Range("C14").Value = found.Cells(1, "B").Value'Vehicle Year
            wsEditor.Range("C15").Value = found.Cells(1, "C").Value'Vehicle Make
            wsEditor.Range("C16").Value = found.Cells(1, "D").Value'Vehicle Model
            wsEditor.Range("C17").Value = found.Cells(1, "E").Value'Vehicle Paint Code
        Else
            MsgBox "Vehicle VIN not found in Vehicle Table.", vbExclamation
        End If
    End With



    MsgBox "Invoice data loaded successfully!"

End Sub
