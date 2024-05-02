Sub SaveToInvoiceTable()

'Declaring dimension array variables and their subsequent data type
    Dim InvoiceNo As Integer
    Dim CustomerID As Integer
    Dim VehicleVIN As String
    Dim StartDate As Date
    Dim FinishDate As Date
    Dim InvoiceDate As Date
    Dim DueBy As Date
    Dim Paid As String
    Dim InvoiceTotal As Decimal
    Dim RepairDescription As String
    Dim NextInvoiceNo As Range

'Declaring variable ranges
    InvoiceNo = Range("C3")
    CustomerID = Range("C11")
    VehicleVIN = Range("C13")
    StartDate = Range("C5")
    FinishDate = Range("C6")
    InvoiceDate = Range("J3")
    DueBy = Range("J4")
    Paid = Range("C4")
    InvoiceTotal = Range("J58")
    RepairDescription = Range("B56")

'Determine where in the Invoice Table sheet the new invoice will be saved (this .End(xlup) 
'Might need to be modified since I have a table, to use 2 ctrl up arrow keys)
    Set NextInvoiceNo = Sheet7.Range("A1048576").End(xlUp)
    Set NextInvoiceNo = NextInvoiceNo.End(xlUp).Offset(1, 0)

'Put the invoice number and other data into the correct targeted cells
    NextInvoiceNo = InvoiceNo
    NextInvoiceNo.Offset(0, 1) = CustomerID
    NextInvoiceNo.Offset(0, 2) = VehicleVIN
    NextInvoiceNo.Offset(0, 3) = StartDate
    NextInvoiceNo.Offset(0, 4) = FinishDate
    NextInvoiceNo.Offset(0, 5) = InvoiceDate
    NextInvoiceNo.Offset(0, 6) = DueBy
    NextInvoiceNo.Offset(0, 7) = Paid
    NextInvoiceNo.Offset(0, 8) = InvoiceTotal
    NextInvoiceNo.Offset(0, 9) = RepairDescription

End Sub
