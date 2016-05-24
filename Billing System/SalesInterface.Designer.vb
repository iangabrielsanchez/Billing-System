<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesInterface
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotal_ = New System.Windows.Forms.Label()
        Me.lblTax_ = New System.Windows.Forms.Label()
        Me.lblSubTotal_ = New System.Windows.Forms.Label()
        Me.tblSales = New System.Windows.Forms.ListView()
        Me.lblChkOut = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.lnklblDiscount = New System.Windows.Forms.LinkLabel()
        Me.lblTDC = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblSubTotal.Location = New System.Drawing.Point(345, 316)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSubTotal.Size = New System.Drawing.Size(148, 24)
        Me.lblSubTotal.TabIndex = 17
        Me.lblSubTotal.Text = "Php 0"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiscount
        '
        Me.lblDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblDiscount.Location = New System.Drawing.Point(291, 334)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDiscount.Size = New System.Drawing.Size(202, 24)
        Me.lblDiscount.TabIndex = 16
        Me.lblDiscount.Text = "0"
        Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTax
        '
        Me.lblTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTax.BackColor = System.Drawing.Color.Transparent
        Me.lblTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblTax.Location = New System.Drawing.Point(291, 352)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTax.Size = New System.Drawing.Size(202, 24)
        Me.lblTax.TabIndex = 15
        Me.lblTax.Text = "0"
        Me.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lblTotal.Location = New System.Drawing.Point(278, 373)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotal.Size = New System.Drawing.Size(216, 24)
        Me.lblTotal.TabIndex = 14
        Me.lblTotal.Text = "Php 0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal_
        '
        Me.lblTotal_.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal_.AutoSize = True
        Me.lblTotal_.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lblTotal_.Location = New System.Drawing.Point(2, 373)
        Me.lblTotal_.Name = "lblTotal_"
        Me.lblTotal_.Size = New System.Drawing.Size(56, 24)
        Me.lblTotal_.TabIndex = 12
        Me.lblTotal_.Text = "Total:"
        '
        'lblTax_
        '
        Me.lblTax_.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTax_.AutoSize = True
        Me.lblTax_.Location = New System.Drawing.Point(3, 355)
        Me.lblTax_.Name = "lblTax_"
        Me.lblTax_.Size = New System.Drawing.Size(36, 18)
        Me.lblTax_.TabIndex = 11
        Me.lblTax_.Text = "Tax:"
        '
        'lblSubTotal_
        '
        Me.lblSubTotal_.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal_.AutoSize = True
        Me.lblSubTotal_.Location = New System.Drawing.Point(3, 319)
        Me.lblSubTotal_.Name = "lblSubTotal_"
        Me.lblSubTotal_.Size = New System.Drawing.Size(76, 18)
        Me.lblSubTotal_.TabIndex = 9
        Me.lblSubTotal_.Text = "Sub-Total:"
        '
        'tblSales
        '
        Me.tblSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblSales.AutoArrange = False
        Me.tblSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tblSales.CheckBoxes = True
        Me.tblSales.FullRowSelect = True
        Me.tblSales.GridLines = True
        Me.tblSales.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.tblSales.Location = New System.Drawing.Point(7, 27)
        Me.tblSales.MultiSelect = False
        Me.tblSales.Name = "tblSales"
        Me.tblSales.Size = New System.Drawing.Size(492, 275)
        Me.tblSales.TabIndex = 6
        Me.tblSales.UseCompatibleStateImageBehavior = False
        Me.tblSales.View = System.Windows.Forms.View.Details
        '
        'lblChkOut
        '
        Me.lblChkOut.AutoSize = True
        Me.lblChkOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lblChkOut.Location = New System.Drawing.Point(3, 0)
        Me.lblChkOut.Name = "lblChkOut"
        Me.lblChkOut.Size = New System.Drawing.Size(95, 24)
        Me.lblChkOut.TabIndex = 8
        Me.lblChkOut.Text = "Checkout:"
        Me.lblChkOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrintDocument1
        '
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.Billing_System.My.Resources.Resources.ic_print_white_48dp
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(25, 400)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(224, 47)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Print Bill"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnPay
        '
        Me.btnPay.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPay.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnPay.Enabled = False
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPay.ForeColor = System.Drawing.Color.White
        Me.btnPay.Image = Global.Billing_System.My.Resources.Resources.ic_payment_white_48dp
        Me.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPay.Location = New System.Drawing.Point(258, 400)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(224, 47)
        Me.btnPay.TabIndex = 13
        Me.btnPay.Text = "Pay"
        Me.btnPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPay.UseVisualStyleBackColor = False
        '
        'lnklblDiscount
        '
        Me.lnklblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnklblDiscount.AutoSize = True
        Me.lnklblDiscount.Location = New System.Drawing.Point(3, 334)
        Me.lnklblDiscount.Name = "lnklblDiscount"
        Me.lnklblDiscount.Size = New System.Drawing.Size(71, 18)
        Me.lnklblDiscount.TabIndex = 19
        Me.lnklblDiscount.TabStop = True
        Me.lnklblDiscount.Text = "Discount:"
        '
        'lblTDC
        '
        Me.lblTDC.AutoSize = True
        Me.lblTDC.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTDC.ForeColor = System.Drawing.Color.Transparent
        Me.lblTDC.Location = New System.Drawing.Point(16, 342)
        Me.lblTDC.Name = "lblTDC"
        Me.lblTDC.Size = New System.Drawing.Size(474, 13)
        Me.lblTDC.TabIndex = 20
        Me.lblTDC.Text = "PROPERTY OF TJAKOEN STOLK AND IAN SANCHEZ ALL RIGHTS RESERVED 18/03/2016" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTDC.Visible = False
        '
        'SalesInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.lnklblDiscount)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblSubTotal)
        Me.Controls.Add(Me.lblDiscount)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.lblTotal_)
        Me.Controls.Add(Me.lblTax_)
        Me.Controls.Add(Me.lblSubTotal_)
        Me.Controls.Add(Me.tblSales)
        Me.Controls.Add(Me.lblChkOut)
        Me.Controls.Add(Me.lblTDC)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SalesInterface"
        Me.Size = New System.Drawing.Size(502, 450)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPay As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblSubTotal As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotal_ As Label
    Friend WithEvents lblTax_ As Label
    Friend WithEvents lblSubTotal_ As Label
    Friend WithEvents tblSales As ListView
    Friend WithEvents lblChkOut As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents lnklblDiscount As LinkLabel
    Friend WithEvents lblTDC As Label
End Class
