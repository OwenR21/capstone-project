Sub SaveAsPDF()

'Declaring dimension array variables and their subsequent data type
    Dim InvoiceNo As Long
    Dim CustomerName As String
    Dim FileName As String
    Dim Path As String

'Declaring variable ranges and/or values
    InvoiceNo = Range("C3")
    CustomerName = Range("C8")
    FileName = InvoiceNo & " - " & CustomerName
    Path = "D:\School\IT-Capstone\Saved_Invoices\"

    ActiveSheet.PageSetup.Zoom = 72
    ActiveSheet.ExportAsFixedFormat Type:=xlTypePDF, ignoreprintareas:=False, Filename:=Path & Filename

End Sub
