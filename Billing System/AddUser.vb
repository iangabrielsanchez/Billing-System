'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Imports System.IO

Public Class AddUser
    Private Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm.Opacity = 0.75

        checkEdit()
    End Sub

    'Image stuff
    Dim imgName As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dlgImage As FileDialog = New OpenFileDialog()

            dlgImage.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png"

            If dlgImage.ShowDialog() = DialogResult.OK Then
                imgName = dlgImage.FileName
                Dim newimg As New Bitmap(imgName)
                picBox.SizeMode = PictureBoxSizeMode.Zoom
                picBox.Image = DirectCast(newimg, Image)
            End If

            dlgImage = Nothing
        Catch ae As System.ArgumentException
            imgName = " "
            MessageBox.Show(ae.Message.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    'Copies the image into resources folder
    Private Function copyfile(ByVal oldlink As String, ByVal newlink As String) As String
        Dim sOld As String = oldlink
        Dim sNew As String = newlink

        Dim sNewDir As String = Path.GetDirectoryName(sNew) & Path.DirectorySeparatorChar
        Dim sNewFile As String = Path.GetFileNameWithoutExtension(sNew)
        Dim sNewExtn As String = Path.GetExtension(sNew)
        Dim x As Integer = 0

        If File.Exists(sNew) Then
            Do
                x = x + 1
                sNew = sNewDir & sNewFile & CStr(x) & sNewExtn
            Loop While File.Exists(sNew)
        End If
        Try
            File.Copy(sOld, sNew)
        Catch
            Return ""
        End Try
        Return sNew
    End Function


    Dim imgLoc As String = ""
    Public Shared userN As String
    Public Shared edit As Boolean
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (
                txtFName.Text = "" Or
                txtLastname.Text = "" Or
                txtMI.Text = "" Or
                txtUsername.Text = "" Or
                txtPassword.Text = "" Or
                txtConfirmPassword.Text = ""
            ) Then
            MsgBox("Please Fill in all Fields")
        Else
            Dim firstName As String = txtFName.Text
            Dim lastName As String = txtLastname.Text
            Dim MI As String = txtMI.Text
            Dim userName As String = txtUsername.Text.ToLower
            Dim password As String = txtPassword.Text
            Dim back As Boolean

            Dim admin As String
            If (cbxAdmin.Checked = True) Then
                admin = "y"
            Else
                admin = "n"
            End If


            'Directory of where the images go
            Dim imgDirectory As String = Directory.GetCurrentDirectory() & "\Resources\Images\"

            If (txtPassword.Text = txtConfirmPassword.Text) Then
                If (dbfunc.retrieveVariable("SELECT username FROM tblusers WHERE username = '" & userName & "'", "username") <> userName And Not edit) Then
                    'Set the image location and copy the image to the resources directory
                    If (Not delImg) Then
                        imgLoc = copyfile(imgName, imgDirectory & "user.jpg")
                    Else
                        imgLoc = ""
                        delImg = True
                    End If

                    dbfunc.query("INSERT INTO tblusers(username, _password, firstname, lastname, middleinitial, imgloc, admin)
                VALUES('" & userName & "', '" & password & "', '" & firstName & "', '" & lastName & "', '" & MI & "', '" & imgLoc & "', '" & admin & "')")
                    back = True
                Else
                    If (edit) Then
                        If (Not delImg) Then
                            imgLoc = copyfile(imgName, imgDirectory & "user.jpg")
                        Else
                            imgLoc = ""
                            delImg = True
                        End If

                        dbfunc.query("UPDATE tblusers " &
                        "SET username = '" & userName &
                        "', _password = '" & password &
                        "', firstname = '" & firstName &
                        "', lastname = '" & lastName &
                        "', middleinitial = '" & MI &
                        "', imgloc = '" & imgLoc &
                        "', admin = '" & admin &
                        "' WHERE username = '" & userN & "'")
                        back = True
                    Else
                        MsgBox("User already Exists")
                        back = False
                    End If
                End If
                If (back) Then
                    MainForm.loadUserImg()
                    dbfunc.loadUsers("SELECT * FROM tblusers")
                    btnCancel.PerformClick()
                End If
            Else
                MsgBox("Passwords Do not match")
            End If
        End If
    End Sub
    'Checks if edit boolean is true
    Private Sub checkEdit()
        If (edit) Then
            txtUsername.Text = userN
            txtFName.Text = dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & userN & "'", "firstname")
            txtLastname.Text = dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & userN & "'", "lastname")
            txtMI.Text = dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & userN & "'", "middleinitial")
            txtPassword.Text = ""
            txtPassword.Text = ""
            imgLoc = dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & userN & "'", "imgLoc")

            Dim admin As String = dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & userN & "'", "admin")
            If (admin = "y") Then
                cbxAdmin.Checked = True
            Else
                cbxAdmin.Checked = False
            End If


            imgName = imgLoc
            Try
                Dim newimg As New Bitmap(imgName)
                picBox.SizeMode = PictureBoxSizeMode.StretchImage
                picBox.Image = DirectCast(newimg, Image)
            Catch
            End Try
        Else
            txtUsername.Text = ""
            txtFName.Text = ""
            txtLastname.Text = ""
            txtMI.Text = ""
            txtPassword.Text = ""
            txtPassword.Text = ""
            imgLoc = ""
            cbxAdmin.Checked = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        MainForm.Enabled = True
        MainForm.Opacity = 1.0
        Me.Close()
    End Sub

    Private delImg As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delImg = True
        picBox.Image = Nothing
    End Sub
End Class