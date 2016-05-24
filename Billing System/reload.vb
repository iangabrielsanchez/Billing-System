'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved



'Just a class to reload the mainform
Public Class reload
    Public Shared Sub r()
        MainForm.Close()
        MainForm.Opacity = 0
        MainForm.Show()
    End Sub
End Class
