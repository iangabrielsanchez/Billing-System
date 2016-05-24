'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class DiscountDialog
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "mgrpin") = TextBox1.Text Then
            MainForm.pincorrect = True
            TextBox2.Enabled = True
            Button2.Enabled = True
        Else
            MainForm.pincorrect = False
            TextBox2.Enabled = False
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DiscountDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (MainForm.isAdmin) Then
            TextBox1.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "mgrpin")
            TextBox1.Enabled = False
        Else
            TextBox1.Text = ""
            TextBox1.Enabled = True
        End If

        TextBox2.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Double.Parse(TextBox2.Text)
            MainForm.tableInterface(MainForm.currentTable).lblDiscount.Text = Double.Parse(TextBox2.Text)
            MainForm.discount = Double.Parse(TextBox2.Text)
            Me.Hide()
        Catch ex As Exception
            MsgBox("Please enter a Double or an integer")
            TextBox2.Text = ""
        End Try
    End Sub
End Class