'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Imports System.IO

Public Class AddItem

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm.Opacity = 0.75
        checkEdit()

    End Sub


    'Image stuff, browse
    Dim imgName As String
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            Dim dlgImage As FileDialog = New OpenFileDialog()

            dlgImage.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png"

            If dlgImage.ShowDialog() = DialogResult.OK Then
                imgName = dlgImage.FileName
                Dim newimg As New Bitmap(imgName)
                picBox.SizeMode = PictureBoxSizeMode.StretchImage
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
    'Copies the image file into the resources folder 
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


    Public delImg As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        delImg = True
        picBox.Image = Nothing
        imgName = ""
    End Sub

    Dim imgLoc As String = ""
    Public Shared productNumber As String
    Public Shared edit As Boolean
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (
            txtProdNo.Text <> "" Or
            txtProdCode.Text <> "" Or
            txtDesc.Text <> "" Or
            txtPrice.Text <> ""
            ) Then

            Dim prodNo As String = txtProdNo.Text
            Dim prodCode As String = txtProdCode.Text
            Dim description As String = txtDesc.Text
            Dim price As String = txtPrice.Text
            Dim back As Boolean = False

            'Directory of where the images go
            Dim imgDirectory As String = Directory.GetCurrentDirectory() & "\Resources\Images\"

            If (dbfunc.retrieveVariable("SELECT prodnum FROM tblinventory WHERE prodnum = " & prodNo, "prodnum") <> prodNo And dbfunc.retrieveVariable("SELECT prodcode FROM tblinventory WHERE prodcode = '" & prodCode & "'", "prodcode") <> prodCode And Not edit) Then
                'Set the image location and copy the image to the resources directory
                imgLoc = copyfile(imgName, imgDirectory & "inventory.jpg")
                dbfunc.query("INSERT INTO tblinventory(prodnum, prodcode, proddesc, price, imgLoc) VALUES(" & prodNo & ", '" & prodCode & "', '" & description & "', " & price & ", '" & imgLoc & "')")

                back = True
            Else
                'Add studd incase oof prodcode or prodnum already existing
                If (edit) Then
                    If (Not delImg) Then
                        imgLoc = copyfile(imgName, imgDirectory & "inventory.jpg")
                    Else
                        imgLoc = ""
                        delImg = True
                    End If

                    dbfunc.query("UPDATE tblinventory SET prodcode = '" & prodCode &
                                 "', proddesc = '" & description &
                                 "', price = " & price &
                                 ", imgloc = '" & imgLoc &
                                 "' WHERE prodnum = " & prodNo)
                        back = True
                    Else
                        MsgBox("Product already Exists")
                    back = False
                End If
            End If
            If (back) Then
                dbfunc.loadInventory("SELECT * FROM tblInventory")
                btnCancel.PerformClick()
                MainForm.buttonChange = True
            End If
        Else
            MsgBox("Please Fill in all Fields")
        End If
    End Sub
    'Checks if edit is true
    Private Sub checkEdit()
        If (edit) Then
            txtProdNo.Text = productNumber
            txtProdCode.Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & productNumber, "prodcode")
            txtDesc.Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & productNumber, "proddesc")
            txtPrice.Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & productNumber, "price")
            imgLoc = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & productNumber, "imgLoc")

            imgName = imgLoc
            Try
                Dim newimg As New Bitmap(imgName)
                picBox.SizeMode = PictureBoxSizeMode.StretchImage
                picBox.Image = DirectCast(newimg, Image)
            Catch
            End Try
        Else
            txtProdNo.Text = ""
            txtProdCode.Text = ""
            txtDesc.Text = ""
            txtPrice.Text = ""
            imgLoc = ""
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        MainForm.Enabled = True
        MainForm.Opacity = 1.0
        Me.Close()
    End Sub

End Class