'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved

Imports System.Data.OleDb
Imports System.IO

Public Class dbfunc
    Private Shared con As New OleDbConnection

    'Creates the connection
    Private Shared Sub connect()
        Dim dbProvider As String
        Dim dbSource As String
        Dim database As String
        Dim fullDatabasePath As String
        Dim currentDirectory As String

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"

        database = "dbSystem.mdb"
        currentDirectory = Directory.GetCurrentDirectory()

        fullDatabasePath = currentDirectory & "/Resources/" & database
        dbSource = "Data Source = " & fullDatabasePath

        con.ConnectionString = dbProvider & dbSource
    End Sub

    'Establishes and Tests the connection
    Public Shared Function testConnection() As Boolean
        Try
            connect()
            con.Open()
            Console.WriteLine("Connection Successful")
            con.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error, cannot connect to database")
            Application.Exit()
            Return False
        End Try
    End Function
    'Subprogram for general MySql queries
    Shared Function query(ByVal sql As String) As Boolean
        Dim cmd As New OleDbCommand(sql, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            con.Close()

            MsgBox(ex.ToString)
            Return False
        End Try
        Return True
    End Function
    'Foor retrieving values from the database
    Shared Function retrieveVariable(ByVal sql As String, ByVal row As String) As String
        Dim cmd As New OleDbCommand(sql, con)
        Dim var As String = ""
        Try
            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                While reader.Read
                    var = reader(row).ToString
                End While
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Something went wrong in dbfunc, Retrieve Record" & ex.ToString)
            Return "You're not supposed to see this"
        End Try
        Return var
    End Function

    Shared Function retrieveList(ByVal sql As String, ByVal row As String) As String()
        Dim cmd As New OleDbCommand(sql, con)
        Dim var As String = ""
        Dim strList As String() = {"null"}

        Try
            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                Dim ctr As Integer = 0
                While reader.Read

                    var = reader.GetString(0)
                    strList(ctr) = var
                    ctr = ctr + 1
                    ReDim Preserve strList(ctr)
                End While
                ReDim Preserve strList(ctr - 1)
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            'MsgBox("Something went wrong in dbfunc, Retrieve LIST" & ex.ToString)
            Return strList
        End Try
        Return strList
    End Function

    'Loads the Inventory table in main form
    Public Shared Sub loadInventory(ByVal Sql As String)
        MainForm.tblInventory.Items.Clear()
        Dim cmd As New OleDbCommand(Sql, con)

        Dim arr(5) As String
        Dim itm As ListViewItem
        Try
            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                While reader.Read
                    arr(0) = reader("prodnum")
                    arr(1) = reader("prodcode")
                    arr(2) = reader("proddesc")
                    arr(3) = reader("price")
                    arr(4) = reader("imgloc")
                    itm = New ListViewItem(arr)
                    MainForm.tblInventory.Items.Add(itm)
                End While
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Something went wrong in dbfunc, load Inventory")
        End Try
    End Sub
    'Loads the user table in the mainform
    Public Shared Sub loadUsers(ByVal Sql As String)
        MainForm.tblusers.Items.Clear()
        Dim cmd As New OleDbCommand(Sql, con)

        Dim arr(6) As String
        Dim itm As ListViewItem
        Try
            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                While reader.Read
                    arr(0) = reader("username")
                    arr(1) = reader("firstname")
                    arr(2) = reader("lastname")
                    arr(3) = reader("middleinitial")
                    arr(4) = reader("imgloc")
                    arr(5) = reader("admin")
                    itm = New ListViewItem(arr)
                    MainForm.tblusers.Items.Add(itm)
                End While
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Something went wrong in dbfunc, load Users")
        End Try
    End Sub
    'Loads the quick list table used in sales
    Public Shared Sub loadQuickList()
        MainForm.tblInventory.Items.Clear()
        Dim Sql As String = "SELECT * FROM tblInventory"
        Dim cmd As New OleDbCommand(Sql, con)

        Dim arr(3) As String
        Dim itm As ListViewItem
        Try
            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                While reader.Read
                    arr(0) = reader("prodnum")
                    arr(1) = reader("prodcode")
                    arr(2) = reader("proddesc")
                    itm = New ListViewItem(arr)
                    PopupInventory.tblQuickKey.Items.Add(itm)
                End While
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Something went wrong in dbfunc, load Quick List")
        End Try
    End Sub
    'Load Reports
    Public Shared Sub loadReports(ByVal Sql As String)
        MainForm.tblReports.Items.Clear()
        Dim cmd As New OleDbCommand(Sql, con)

        Dim arr(2) As String
        Dim itm As ListViewItem
        Try
            con.Open()
            Using reader As OleDbDataReader = cmd.ExecuteReader
                While reader.Read
                    arr(0) = reader("_time")
                    arr(1) = reader("_log")
                    itm = New ListViewItem(arr)
                    MainForm.tblReports.Items.Add(itm)
                End While
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.ToString)
            MsgBox("Something went wrong in dbfunc, load Reports")
        End Try
    End Sub
    'Search Product

    Public Shared Sub searchProd()
        MainForm.txtProdSearch.AutoCompleteCustomSource.Clear()

        'put what to include in autocomplete source here:
        Dim colname = New String() {
            "proddesc"
        }
        Dim cmd
        For Each item As String In colname
            cmd = New OleDbCommand("SELECT " & item & " FROM tblinventory", con)
            Try
                con.Open()
                Using reader As OleDbDataReader = cmd.ExecuteReader
                    While reader.Read
                        MainForm.txtProdSearch.AutoCompleteCustomSource.Add(reader(item).ToString())
                    End While
                End Using

                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.ToString)
                MsgBox("Something went wrong in dbfunc, load Reports")
            End Try
        Next
    End Sub
End Class
