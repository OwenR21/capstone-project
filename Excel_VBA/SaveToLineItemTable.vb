Sub SaveToLineItemTable()

    'Initialize variables
    Dim InvoiceNo As Integer
    Dim LineItem As Integer
    Dim LineType As String
    Dim Units As Integer
    Dim UnitType As String
    Dim RateCost As Integer
    Dim Description As String
    Dim StartDate As Date
    Dim FinishDate As Date
    Dim InvoiceDate As Date
    Dim DueBy As Date
    Dim Paid As String
    Dim CustomerName As String
    Dim VehicleVIN As String
    Dim InvoiceTotal As Double
    Dim wsSource As Worksheet, wsDest As Worksheet
    Dim Cell As Range
    Dim Table As ListObject
    Dim NewRow As ListRow
    
    'Set worksheets
    Set wsSource = ActiveSheet
    Set wsDest = ThisWorkbook.Sheets("Line Item Table")
    Set Table = wsDest.ListObjects("Line_Item_Table")

    'Declaring variable ranges
    InvoiceNo = wsSource.Range("C3").Value
    StartDate = wsSource.Range("C5").Value
    FinishDate = wsSource.Range("C6").Value
    InvoiceDate = wsSource.Range("J3").Value
    DueBy = wsSource.Range("J4").Value
    Paid = wsSource.Range("C4").Value
    CustomerName = wsSource.Range("C8").Value
    VehicleVIN = wsSource.Range("C13").Value
    InvoiceTotal = wsSource.Range("J58").Value

    'Loop through Service/Labor Performed
    LineItem = 1
    For Each Cell In wsSource.Range("B20:B29")
        If Not IsEmpty(Cell.Value) Then
            'Add a new row to the table for each line item
            Set NewRow = Table.ListRows.Add

            With NewRow
                .Range(1, Table.ListColumns("Invoice No.").Index).Value = InvoiceNo
                .Range(1, Table.ListColumns("Line Item").Index).Value = LineItem
                .Range(1, Table.ListColumns("Line Type").Index).Value = "Labor"
                .Range(1, Table.ListColumns("Units").Index).Value = Cell.Offset(0, 1).Value
                .Range(1, Table.ListColumns("Unit Type").Index).Value = "Hour"
                .Range(1, Table.ListColumns("Rate/Cost").Index).Value = Cell.Offset(0, 3).Value
                .Range(1, Table.ListColumns("Description").Index).Value = Cell.Value
                .Range(1, Table.ListColumns("Start Date").Index).Value = StartDate
                .Range(1, Table.ListColumns("Finish Date").Index).Value = FinishDate
                .Range(1, Table.ListColumns("Invoice Date").Index).Value = InvoiceDate
                .Range(1, Table.ListColumns("Due By").Index).Value = DueBy
                .Range(1, Table.ListColumns("Paid Y/N").Index).Value = Paid
                .Range(1, Table.ListColumns("Customer Name").Index).Value = CustomerName
                .Range(1, Table.ListColumns("Vehicle VIN").Index).Value = VehicleVIN
                .Range(1, Table.ListColumns("Invoice Total").Index).Value = InvoiceTotal
            End With
            
            LineItem = LineItem + 1
        End If
    Next Cell

    'Reset LineItem for Materials/Parts
    LineItem = 1
    For Each Cell In wsSource.Range("B33:B52")
        If Not IsEmpty(Cell.Value) Then
            'Add a new row to the table for each part
            Set NewRow = Table.ListRows.Add

            With NewRow
                .Range(1, Table.ListColumns("Invoice No.").Index).Value = InvoiceNo
                .Range(1, Table.ListColumns("Line Item").Index).Value = LineItem
                .Range(1, Table.ListColumns("Line Type").Index).Value = "Part"
                .Range(1, Table.ListColumns("Units").Index).Value = Cell.Offset(0, 1).Value
                .Range(1, Table.ListColumns("Unit Type").Index).Value = "Part"
                .Range(1, Table.ListColumns("Rate/Cost").Index).Value = Cell.Offset(0, 3).Value
                .Range(1, Table.ListColumns("Description").Index).Value = Cell.Value
                .Range(1, Table.ListColumns("Start Date").Index).Value = StartDate
                .Range(1, Table.ListColumns("Finish Date").Index).Value = FinishDate
                .Range(1, Table.ListColumns("Invoice Date").Index).Value = InvoiceDate
                .Range(1, Table.ListColumns("Due By").Index).Value = DueBy
                .Range(1, Table.ListColumns("Paid Y/N").Index).Value = Paid
                .Range(1, Table.ListColumns("Customer Name").Index).Value = CustomerName
                .Range(1, Table.ListColumns("Vehicle VIN").Index).Value = VehicleVIN
                .Range(1, Table.ListColumns("Invoice Total").Index).Value = InvoiceTotal
            End With

            LineItem = LineItem + 1
        End If
    Next Cell

End Sub
