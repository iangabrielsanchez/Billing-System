'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class EnterPin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "mgrpin") = TextBox1.Text Then
            MainForm.pincorrect = True
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub EnterPin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
    End Sub
End Class