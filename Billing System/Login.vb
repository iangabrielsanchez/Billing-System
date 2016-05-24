'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class Login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        txtUser.Text = ""
        txtPassword.Text = ""
        If (Not dbfunc.testConnection()) Then
            Me.Close()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = " " & FormatDateTime(Date.Now, DateFormat.LongDate) & "   " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
    End Sub

    Public Shared currentUser As String = ""
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUser.Text.ToLower
        Dim password As String = txtPassword.Text
        If Not Trim(username) = "" Or Not Trim(password) = "" Then
            If (dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & username & "'", "username") = username) Then
                If (dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & username & "'", "_password") = password) Then
                    currentUser = username
                    Me.Hide()
                    report.addlog(1)
                    MainForm.Opacity = 0
                    MainForm.Show()
                Else
                    MsgBox("Invalid Credentials")
                End If
            Else
                MsgBox("Invalid Credentials")
            End If
        Else
            MsgBox("Invalid Credentials")
        End If
    End Sub

    'When you press the close button
    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class




