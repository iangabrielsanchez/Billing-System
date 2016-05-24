<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbxAdmin = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.lblImage = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.lblMI = New System.Windows.Forms.Label()
        Me.txtMI = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblLName = New System.Windows.Forms.Label()
        Me.txtLastname = New System.Windows.Forms.TextBox()
        Me.lblFName = New System.Windows.Forms.Label()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblTDC = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTDC)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.cbxAdmin)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.picBox)
        Me.GroupBox1.Controls.Add(Me.lblImage)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtConfirmPassword)
        Me.GroupBox1.Controls.Add(Me.lblMI)
        Me.GroupBox1.Controls.Add(Me.txtMI)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.lblLName)
        Me.GroupBox1.Controls.Add(Me.txtLastname)
        Me.GroupBox1.Controls.Add(Me.lblFName)
        Me.GroupBox1.Controls.Add(Me.txtFName)
        Me.GroupBox1.Controls.Add(Me.lblUsername)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 347)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add New User"
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button2.Image = Global.Billing_System.My.Resources.Resources.no
        Me.Button2.Location = New System.Drawing.Point(440, 190)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 27)
        Me.Button2.TabIndex = 17
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbxAdmin
        '
        Me.cbxAdmin.AutoSize = True
        Me.cbxAdmin.Location = New System.Drawing.Point(156, 238)
        Me.cbxAdmin.Name = "cbxAdmin"
        Me.cbxAdmin.Size = New System.Drawing.Size(100, 33)
        Me.cbxAdmin.TabIndex = 16
        Me.cbxAdmin.Text = "Admin"
        Me.cbxAdmin.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button1.Location = New System.Drawing.Point(349, 190)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 27)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'picBox
        '
        Me.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBox.Location = New System.Drawing.Point(349, 62)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(125, 125)
        Me.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBox.TabIndex = 15
        Me.picBox.TabStop = False
        '
        'lblImage
        '
        Me.lblImage.AutoSize = True
        Me.lblImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblImage.Location = New System.Drawing.Point(332, 31)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Size = New System.Drawing.Size(94, 18)
        Me.lblImage.TabIndex = 14
        Me.lblImage.Text = "User Picture:"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnSave.Image = Global.Billing_System.My.Resources.Resources.yes
        Me.btnSave.Location = New System.Drawing.Point(101, 293)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(118, 32)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnCancel.Image = Global.Billing_System.My.Resources.Resources.no
        Me.btnCancel.Location = New System.Drawing.Point(291, 293)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 32)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(14, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Confirm Password:"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtConfirmPassword.Location = New System.Drawing.Point(156, 193)
        Me.txtConfirmPassword.MaxLength = 16
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(158, 24)
        Me.txtConfirmPassword.TabIndex = 5
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'lblMI
        '
        Me.lblMI.AutoSize = True
        Me.lblMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblMI.Location = New System.Drawing.Point(59, 106)
        Me.lblMI.Name = "lblMI"
        Me.lblMI.Size = New System.Drawing.Size(91, 18)
        Me.lblMI.TabIndex = 9
        Me.lblMI.Text = "Middle Initial:"
        '
        'txtMI
        '
        Me.txtMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtMI.Location = New System.Drawing.Point(156, 103)
        Me.txtMI.MaxLength = 2
        Me.txtMI.Name = "txtMI"
        Me.txtMI.Size = New System.Drawing.Size(46, 24)
        Me.txtMI.TabIndex = 2
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblPassword.Location = New System.Drawing.Point(71, 169)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(79, 18)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtPassword.Location = New System.Drawing.Point(156, 163)
        Me.txtPassword.MaxLength = 16
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(158, 24)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblLName
        '
        Me.lblLName.AutoSize = True
        Me.lblLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblLName.Location = New System.Drawing.Point(66, 136)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(84, 18)
        Me.lblLName.TabIndex = 5
        Me.lblLName.Text = "Last Name:"
        '
        'txtLastname
        '
        Me.txtLastname.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtLastname.Location = New System.Drawing.Point(156, 133)
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(158, 24)
        Me.txtLastname.TabIndex = 3
        '
        'lblFName
        '
        Me.lblFName.AutoSize = True
        Me.lblFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblFName.Location = New System.Drawing.Point(65, 76)
        Me.lblFName.Name = "lblFName"
        Me.lblFName.Size = New System.Drawing.Size(85, 18)
        Me.lblFName.TabIndex = 3
        Me.lblFName.Text = "First Name:"
        '
        'txtFName
        '
        Me.txtFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtFName.Location = New System.Drawing.Point(156, 73)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(158, 24)
        Me.txtFName.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.lblUsername.Location = New System.Drawing.Point(69, 46)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(81, 18)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtUsername.Location = New System.Drawing.Point(156, 43)
        Me.txtUsername.MaxLength = 16
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(158, 24)
        Me.txtUsername.TabIndex = 0
        '
        'lblTDC
        '
        Me.lblTDC.AutoSize = True
        Me.lblTDC.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTDC.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTDC.Location = New System.Drawing.Point(25, 328)
        Me.lblTDC.Name = "lblTDC"
        Me.lblTDC.Size = New System.Drawing.Size(474, 13)
        Me.lblTDC.TabIndex = 9
        Me.lblTDC.Text = "PROPERTY OF TJAKOEN STOLK AND IAN SANCHEZ ALL RIGHTS RESERVED 18/03/2016" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTDC.Visible = False
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 353)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddUser"
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
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents lblMI As Label
    Friend WithEvents txtMI As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblLName As Label
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents lblFName As Label
    Friend WithEvents txtFName As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents picBox As PictureBox
    Friend WithEvents lblImage As Label
    Friend WithEvents cbxAdmin As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents lblTDC As Label
End Class
