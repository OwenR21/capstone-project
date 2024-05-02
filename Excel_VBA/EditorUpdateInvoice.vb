Sub EditorUpdateInvoice()
    
    'Initialize variables
    Dim invoiceNumber As String
    Dim wsEditor As Worksheet, wsLineItems As Worksheet, wsInvoices As Worksheet, wsArchive As Worksheet
    Dim found As Range, deleteRange As Range, archiveRange As Range
    Dim lastRow As Long, copyRow As Range

    'Set references to the worksheets
    Set wsEditor = ThisWorkbook.Sheets("Invoice Editor")
    Set wsLineItems = ThisWorkbook.Sheets("Line Item Table")
    Set wsInvoices = ThisWorkbook.Sheets("Invoice Table")
    Set wsArchive = ThisWorkbook.Sheets("Invoice Archive")

    'Prompt user to enter the invoice number
    invoiceNumber = wsEditor.Range("C3").Value
    If invoiceNumber = "" Then
        MsgBox "Invoice number is empty.", vbExclamation
        Exit Sub  'Exit if no input
    End If

    'Archive and delete matching entries in the Line Item Table
    With wsLineItems
        lastRow = .Cells(.Rows.Count, "A").End(xlUp).Row
        For i = lastRow To 1 Step -1 'Reverse loop to handle deletions correctly
            If .Cells(i, "A").Value = invoiceNumber Then
                'Prepare the range to archive
                If archiveRange Is Nothing Then
                    Set archiveRange = .Rows(i)
                Else
                    Set archiveRange = Union(archiveRange, .Rows(i))
                End If
            End If
        Next i

        'Copy to Archive Sheet before deleting
        If Not archiveRange Is Nothing Then
            archiveRange.Copy
            wsArchive.Cells(wsArchive.Rows.Count, "A").End(xlUp).Offset(1, 0).PasteSpecial Paste:=xlPasteValuesAndNumberFormats
            archiveRange.Delete
        End If
    End With

    'Reset archiveRange for next table use
    Set archiveRange = Nothing

    'Delete matching entries in the Invoice Table without archiving
    With wsInvoices
        lastRow = .Cells(.Rows.Count, "A").End(xlUp).Row
        For i = lastRow To 1 Step -1 'Reverse loop to handle deletions correctly
            If .Cells(i, "A").Value = invoiceNumber Then
                If deleteRange Is Nothing Then
                    Set deleteRange = .Rows(i)
                Else
                    Set deleteRange = Union(deleteRange, .Rows(i))
                End If
            End If
        Next i

        'Delete all marked rows at once
        If Not deleteRange Is Nothing Then
            deleteRange.Delete
        End If
    End With

    'Call SaveToInvoiceTable Module
    Call SaveToInvoiceTable

    'Call SaveToLineItemTable Module
    Call SaveToLineItemTable

    Application.CutCopyMode = False
    MsgBox "Invoice has been successfully updated!"

End Sub
