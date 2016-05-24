<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProdCode = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtProdNo = New System.Windows.Forms.TextBox()
        Me.lblImage = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblProdNo = New System.Windows.Forms.Label()
        Me.lblTDC = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtProdCode)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.picBox)
        Me.GroupBox1.Controls.Add(Me.txtPrice)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.txtProdNo)
        Me.GroupBox1.Controls.Add(Me.lblImage)
        Me.GroupBox1.Controls.Add(Me.lblPrice)
        Me.GroupBox1.Controls.Add(Me.lblDesc)
        Me.GroupBox1.Controls.Add(Me.lblProdNo)
        Me.GroupBox1.Controls.Add(Me.lblTDC)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 438)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add New Entry"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button1.Image = Global.Billing_System.My.Resources.Resources.no
        Me.Button1.Location = New System.Drawing.Point(268, 351)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 33)
        Me.Button1.TabIndex = 13
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(11, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Product Code:"
        '
        'txtProdCode
        '
        Me.txtProdCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtProdCode.Location = New System.Drawing.Point(121, 70)
        Me.txtProdCode.Name = "txtProdCode"
        Me.txtProdCode.Size = New System.Drawing.Size(187, 24)
        Me.txtProdCode.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnSave.Image = Global.Billing_System.My.Resources.Resources.yes
        Me.btnSave.Location = New System.Drawing.Point(14, 399)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(118, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnCancel.Image = Global.Billing_System.My.Resources.Resources.no
        Me.btnCancel.Location = New System.Drawing.Point(206, 399)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 32)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnBrowse.Location = New System.Drawing.Point(121, 351)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(145, 33)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'picBox
        '
        Me.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBox.Location = New System.Drawing.Point(121, 160)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(187, 185)
        Me.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBox.TabIndex = 7
        Me.picBox.TabStop = False
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtPrice.Location = New System.Drawing.Point(121, 130)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(185, 24)
        Me.txtPrice.TabIndex = 4
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtDesc.Location = New System.Drawing.Point(121, 100)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(186, 24)
        Me.txtDesc.TabIndex = 3
        '
        'txtProdNo
        '
        Me.txtProdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtProdNo.Location = New System.Drawing.Point(121, 41)
        Me.txtProdNo.Name = "txtProdNo"
        Me.txtProdNo.Size = New System.Drawing.Size(186, 24)
        Me.txtProdNo.TabIndex = 1
        '
        'lblImage
        '
        Me.lblImage.AutoSize = True
        Me.lblImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblImage.Location = New System.Drawing.Point(49, 163)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Size = New System.Drawing.Size(52, 18)
        Me.lblImage.TabIndex = 3
        Me.lblImage.Text = "Image:"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblPrice.Location = New System.Drawing.Point(54, 133)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(46, 18)
        Me.lblPrice.TabIndex = 2
        Me.lblPrice.Text = "Price:"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblDesc.Location = New System.Drawing.Point(13, 103)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(87, 18)
        Me.lblDesc.TabIndex = 1
        Me.lblDesc.Text = "Description:"
        '
        'lblProdNo
        '
        Me.lblProdNo.AutoSize = True
        Me.lblProdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblProdNo.Location = New System.Drawing.Point(11, 44)
        Me.lblProdNo.Name = "lblProdNo"
        Me.lblProdNo.Size = New System.Drawing.Size(88, 18)
        Me.lblProdNo.TabIndex = 0
        Me.lblProdNo.Text = "Product No:"
        '
        'lblTDC
        '
        Me.lblTDC.AutoSize = True
        Me.lblTDC.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTDC.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTDC.Location = New System.Drawing.Point(-38, 263)
        Me.lblTDC.Name = "lblTDC"
        Me.lblTDC.Size = New System.Drawing.Size(474, 13)
        Me.lblTDC.TabIndex = 9
        Me.lblTDC.Text = "PROPERTY OF TJAKOEN STOLK AND IAN SANCHEZ ALL RIGHTS RESERVED 18/03/2016" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTDC.Visible = False
        '
        'AddItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(338, 443)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents picBox As PictureBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents txtProdNo As TextBox
    Friend WithEvents lblImage As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblDesc As Label
    Friend WithEvents lblProdNo As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProdCode As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblTDC As Label
End Class
