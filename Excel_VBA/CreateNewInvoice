Sub CreateNewInvoice()

'Declaring dimension array variables and their subsequent data type
Dim InvoiceNo As Long
Dim LastInvoiceNo As Long
Dim Sheet7 As Worksheet
Dim Sheet1 As Worksheet

'Declaring which cell ranges need to be cleared
Range("C4:D6, C8:E8, C13:E13, J4:K4, B20:I29, B33:I52, B56:F59").ClearContents

'Declaring and updating Invoice No. to next Invoice No. 
Set Sheet7 = ThisWorkbook.Sheets("Invoice Table")
Set Sheet1 = ThisWorkbook.Sheets("Invoice Generator")

'Find the last non empty cell in Column A of Sheet7
InvoiceNo = Sheet7.Columns(1).End(xlDown)

'Add +1 to the invoice number
InvoiceNo = invoiceNo + 1

'Copy the updated invoice number to cell C3 on Sheet1
Sheet1.Range("C3").Value = InvoiceNo

'Selecting active cell for user
Range("C8:E8").Select

ThisWorkbook.Save

End Sub
