'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class PopupInventory
    Private Sub PopupInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        settable()
        dbfunc.loadQuickList()
    End Sub
    Public Sub settable()
        tblQuickKey.View = View.Details
        tblQuickKey.GridLines = False
        tblQuickKey.FullRowSelect = True

        'Add column header
        tblQuickKey.Columns.Add("Product Number", 100)
        tblQuickKey.Columns.Add("Product Code", 100)
        tblQuickKey.Columns.Add("Description", 100)
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public button As Integer 'Currently Selected button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (tblQuickKey.SelectedItems.Count > 0) Then
            Dim prodNo As String = tblQuickKey.FocusedItem.SubItems(0).Text

            If (dbfunc.query("UPDATE tblsalesbuttons SET prodNo = " & prodNo & " WHERE btnNo = " & button)) Then
                Me.Close()
                MainForm.buttonChange = True
                MainForm.loadSalesButtons()
            End If
        Else
            MsgBox("Please select an item first")
        End If
    End Sub
    'Remove button from Collection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim style = MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or
                        MsgBoxStyle.Critical
        If MsgBox("Delete Button?", style, "Confirm") = MsgBoxResult.Ok Then
            If (dbfunc.query("UPDATE tblsalesbuttons SET prodNo = 0 WHERE btnNo = " & button)) Then
                Me.Close()
                MainForm.buttonChange = True
                MainForm.loadSalesButtons()
            End If
        End If
    End Sub
End Class