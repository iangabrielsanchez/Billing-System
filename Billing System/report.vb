'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Public Class report

    Public Shared transaction As String = ""
    Public Shared prc As Double = 0
    Public Shared Sub addlog(ByVal x As Integer)
        Dim logType As String = ""
        Dim log As String = ""
        Dim time = DateTime.Now
        Dim datum = DateTime.Now


        If (x = 1) Then
            logType = "'Attendance'"
            log = "'User " & Login.currentUser & " logged in '"
        ElseIf (x = 2) Then
            logType = "'Attendance'"
            log = "'User " & Login.currentUser & " logged out'"
        ElseIf (x = 3) Then
            logType = "'Sales'"
            log = "'user " & Login.currentUser & transaction & "'"
        End If

        dbfunc.query("INSERT INTO tblreports(logtype, _log, username, _date, _time, prc) VALUES(" & logType & ", " & log & ", '" & Login.currentUser & "', '" & datum & "', '" & time & "', '" & prc & "')")


    End Sub
End Class
