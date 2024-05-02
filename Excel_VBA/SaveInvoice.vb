Sub SaveInvoice()

'Call SaveToInvoiceTable Module
Call SaveToInvoiceTable

'Call SaveToLineItemTable Module
Call SaveToLineItemTable

MsgBox "Invoice Saved successfully!"

End Sub
