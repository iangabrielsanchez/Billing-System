'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class SalesInterface
    Dim defaultsChanged As Boolean
    Dim TextToPrint As String = ""
    Dim StringToPrint(50) As String
    Dim ItemLines As Integer
    Dim isBill As Boolean = True

    Private Sub SalesInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        defaultsChanged = False
        Me.Dock = DockStyle.Fill

        'Set view property
        tblSales.View = View.Details
        tblSales.GridLines = True
        tblSales.FullRowSelect = False

        'Add column header
        tblSales.Columns.Add("Product", 100)
        tblSales.Columns.Add("Qty", 50)
        tblSales.Columns.Add("Price", 50)


        'Display the VAT value for the tax

        lblTax_.Text = "TAX (" & MainForm.VAT.ToString & "%):"
    End Sub
    Dim tabController As New MainForm
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(MainForm.Width)
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        isBill = False
        InputCash.Show()
    End Sub


    'When we click delete
    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles tblSales.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If (Not MainForm.isAdmin) Then
                    EnterPin.ShowDialog()
                    If MainForm.pincorrect Then
                        tblSales.Items.Remove(tblSales.SelectedItems.Item(0))
                        MainForm.pincorrect = False
                        MainForm.computesubtotal()
                    Else
                        MsgBox("Wrong pin!")
                    End If
                Else
                    Dim style = MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or
                        MsgBoxStyle.Critical

                    If MsgBox("Delete Selected Entry?", style, "Confirm") = MsgBoxResult.Ok Then
                        tblSales.Items.Remove(tblSales.SelectedItems.Item(0))
                        MainForm.computesubtotal()
                    End If
                End If
            Else

            End If
        Catch

        End Try

    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub PrintHeader()

        TextToPrint = ""

        'send Business Name
        Dim StringToPrint As String = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bname")
        Dim LineLen As Integer = StringToPrint.Length
        Dim spcLen1 As New String(" "c, Math.Round((33 - LineLen) / 2)) 'This line is used to center text in the middle of the receipt
        TextToPrint &= spcLen1 & StringToPrint & Environment.NewLine

        'send address name
        StringToPrint = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bAdd1")
        LineLen = StringToPrint.Length
        Dim spcLen2 As New String(" "c, Math.Round((33 - LineLen) / 2))
        TextToPrint &= spcLen2 & StringToPrint & Environment.NewLine

        'add2
        StringToPrint = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bAdd2")
        LineLen = StringToPrint.Length
        Dim spcLen3 As New String(" "c, Math.Round((33 - LineLen) / 2))
        TextToPrint &= spcLen3 & StringToPrint & Environment.NewLine

        'add3
        StringToPrint = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bAdd3")
        LineLen = StringToPrint.Length
        Dim spcLen4 As New String(" "c, Math.Round((33 - LineLen) / 2))
        TextToPrint &= spcLen4 & StringToPrint & Environment.NewLine


        ' send phone number
        StringToPrint = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "conNo")
        LineLen = StringToPrint.Length
        Dim spcLen5 As New String(" "c, Math.Round((33 - LineLen) / 2))
        TextToPrint &= spcLen5 & StringToPrint & Environment.NewLine

        'TIN
        StringToPrint = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "tinNo")
        LineLen = StringToPrint.Length
        Dim spcLen6 As New String(" "c, Math.Round((33 - LineLen) / 2))
        TextToPrint &= spcLen6 & StringToPrint & Environment.NewLine

    End Sub


    Public Sub addItem(item As String, qty As Integer, indivprice As Double, totprice As Double, x As Integer)
        StringToPrint(x) = item & "   " & qty & "    " & "P" & indivprice & "    " & "P" & totprice

        If Not isBill Then
            report.transaction = " sold " & qty & " " & item & "(s) " & "for PHP " & totprice & " with a " & MainForm.VAT.ToString & "% VAT inclusion of " & MainForm.taxTotal & " and a discount of " & MainForm.discount
            report.prc = totprice
            Dim totalsales As Double = Double.Parse(dbfunc.retrieveVariable("SELECT totsales FROM tbltotal", "totsales"))
            report.addlog(3)
        End If
    End Sub

    Public Sub ItemsToBePrinted()

        Dim LineLen As String = 30
        Dim spcLen5 As New String(" "c, Math.Round((30 - LineLen)))


        TextToPrint &= vbCrLf & "Desc    QTY   iPrice    tPrice" & Environment.NewLine
        Dim limit = ItemLines - 1

        For x As Integer = 0 To limit
            Dim price As Double = Double.Parse(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodcode = '" & tblSales.Items(x).SubItems(0).Text & "'", "price").ToString)
            addItem(tblSales.Items(x).SubItems(0).Text, Integer.Parse(tblSales.Items(x).SubItems(1).Text), price, Double.Parse(tblSales.Items(x).SubItems(2).Text), x)
            TextToPrint &= StringToPrint(x) & Environment.NewLine
        Next
    End Sub
    Public Sub printFooter()
        TextToPrint &= Environment.NewLine & Environment.NewLine
        Dim globalLengt As Integer = 0

        'SubTotal Amount
        Dim StringToPrint As String = "Sub Total   " & lblSubTotal.Text
        Dim LineLen As String = StringToPrint.Length
        globalLengt = StringToPrint.Length
        Dim spcLen5 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= Environment.NewLine & spcLen5 & StringToPrint & Environment.NewLine

        'Tax Amount
        StringToPrint = "Tax         Php " & lblTax.Text
        LineLen = globalLengt
        Dim spcLen6 As New String(" "c, Math.Round((26 - LineLen)))
        If Not StringToPrint = "Tax         $0.00" Then
            TextToPrint &= spcLen6 & StringToPrint & Environment.NewLine
        End If

        'Discount Amount
        StringToPrint = "Discount    " & "Php " & MainForm.discount
        LineLen = globalLengt
        Dim spcLen7 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= spcLen7 & StringToPrint & Environment.NewLine

        'Total Amount
        StringToPrint = "Total       Php " & lblTax.Text
        LineLen = globalLengt
        Dim spcLen8 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= spcLen8 & StringToPrint & Environment.NewLine & Environment.NewLine

        'Cash Entered Amount
        StringToPrint = "Cash        " & "Php " & MainForm.cashinput
        LineLen = globalLengt
        Dim spcLen9 As New String(" "c, Math.Round((26 - LineLen)))
        If Not StringToPrint = "Cash        $0.00" Then
            TextToPrint &= spcLen9 & StringToPrint & Environment.NewLine
        End If

        'Change Amount
        StringToPrint = "Change      Php " & MainForm.change
        LineLen = globalLengt
        Dim spcLen10 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= Environment.NewLine & spcLen10 & StringToPrint & Environment.NewLine

        TextToPrint &= Environment.NewLine & Environment.NewLine

        'Signature line
        StringToPrint = "_______________"
        LineLen = globalLengt
        Dim spcLen11 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= spcLen11 & StringToPrint & Environment.NewLine

        'Signature
        StringToPrint = "Signature"
        LineLen = globalLengt
        Dim spcLen12 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= Environment.NewLine & spcLen12 & StringToPrint & Environment.NewLine
    End Sub
    Public Sub printBillFooter()
        TextToPrint &= Environment.NewLine & Environment.NewLine
        TextToPrint &= vbCrLf & "Payment" & Environment.NewLine
        Dim globalLengt As Integer = 0

        'SubTotal Amount
        Dim StringToPrint As String = "Sub Total   " & lblSubTotal.Text
        Dim LineLen As String = StringToPrint.Length
        globalLengt = StringToPrint.Length
        Dim spcLen5 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= Environment.NewLine & spcLen5 & StringToPrint & Environment.NewLine

        'Tax Amount
        StringToPrint = "Tax         Php " & lblTax.Text
        LineLen = globalLengt
        Dim spcLen6 As New String(" "c, Math.Round((26 - LineLen)))
        If Not StringToPrint = "Tax         $0.00" Then
            TextToPrint &= spcLen6 & StringToPrint & Environment.NewLine
        End If

        'Discount Amount
        StringToPrint = "Discount    " & "Php " & MainForm.discount
        LineLen = globalLengt
        Dim spcLen7 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= spcLen7 & StringToPrint & Environment.NewLine

        TextToPrint &= Environment.NewLine

        'Total Amount
        StringToPrint = "Total       " & lblTotal.Text
        LineLen = globalLengt
        Dim spcLen8 As New String(" "c, Math.Round((26 - LineLen)))
        TextToPrint &= spcLen8 & StringToPrint & Environment.NewLine & Environment.NewLine


    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Static currentChar As Integer
        Dim textfont As Font = New Font("Courier New", 10, FontStyle.Bold)

        Dim h, w As Integer
        Dim left, top As Integer
        With PrintDocument1.DefaultPageSettings
            h = 0
            w = 0
            left = 0
            top = 0
        End With


        Dim lines As Integer = CInt(Math.Round(h / 1))
        Dim b As New Rectangle(left, top, w, h)
        Dim format As StringFormat
        format = New StringFormat(StringFormatFlags.LineLimit)
        Dim line, chars As Integer


        e.Graphics.MeasureString(Mid(TextToPrint, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(TextToPrint.Substring(currentChar, chars), New Font("Courier New", 10, FontStyle.Bold), Brushes.Black, b, format)


        currentChar = currentChar + chars
        If currentChar < TextToPrint.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            currentChar = 0
        End If
    End Sub
    Public Sub print()
        PrintHeader()
        ItemsToBePrinted()

        If Not isBill Then
            printFooter()
        Else
            printBillFooter()
        End If

        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ItemLines = tblSales.Items.Count
        isBill = True
        print()
        btnPay.Enabled = True
    End Sub

    Private Sub lnklblDiscount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblDiscount.LinkClicked
        DiscountDialog.ShowDialog()
        If MainForm.pincorrect Then
            MainForm.pincorrect = False
            If (DiscountDialog.TextBox2.Text <> "") Then
                lblDiscount.Text = DiscountDialog.TextBox2.Text
            Else
                lblDiscount.Text = 0
            End If
            MainForm.computesubtotal()
        End If
        DiscountDialog.Close()
    End Sub

    'Check if the checkboxes are all checked
    Private Sub tblSales_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles tblSales.ItemCheck
        Dim items As Integer = -1
        Dim checked As Integer = 0

        For index As Integer = 0 To tblSales.Items.Count - 1
            items += 1
            If tblSales.Items(index).Checked = True Then
                checked += 1
            End If
        Next

        If (items = checked) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
End Class
