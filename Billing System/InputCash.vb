'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class InputCash
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        MainForm.computesubtotal()
        Try
            If Double.Parse(TextBox1.Text) >= MainForm.totprice Then
                Button1.Enabled = True
                Label3.Text = "Php " & Double.Parse(TextBox1.Text) - MainForm.totprice
            End If
        Catch
        End Try
    End Sub

    Public isClicked As Boolean = False
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text <> "") Then

            MainForm.change = Double.Parse(TextBox1.Text) - MainForm.totprice
            MainForm.cashinput = Double.Parse(TextBox1.Text)

            'Remove the transaction
            MainForm.tabSales.SelectedTab.Hide()
            MainForm.tabSales.TabPages.RemoveAt(MainForm.tabSales.SelectedIndex)

            Me.Hide()

            Try
                MainForm.tableInterface(MainForm.currentTable + 1).print()
            Catch ex As Exception
                MsgBox("ERROR! Printing Failed")
            End Try



            'Disable add button if no tables exists
            If (MainForm.tabSales.TabCount < 1) Then
                MainForm.resetProd()
                MainForm.addtable()
            End If

            isClicked = True
            Me.Close()
        Else
            MsgBox("Please Enter an Amount")
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub InputCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class