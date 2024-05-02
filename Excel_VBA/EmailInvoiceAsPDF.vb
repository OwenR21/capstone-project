Sub EmailInvoiceAsPDF()

'Creating Email variables and setting them
    Dim EmailApp As Object
    Set EmailApp = CreateObject("Outlook.Application")

    Dim EmailItem As Object
    Set EmailItem = EmailApp.CreateItem(0)

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

'Creating email using customer email on file, invoiceno, entering body text, and attaching PDF
    With EmailItem
        .To = Range("C10")
        .Subject = "Invoice No: " & InvoiceNo
        .Body = "Please find invoice attached."
        .Attachments.Add (Path & FileName & ".pdf") 
        .Display
    End With
      
End Sub
