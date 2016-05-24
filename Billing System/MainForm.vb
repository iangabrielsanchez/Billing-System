'Billing System
'Created by Tjakoen A. Stolk & Ian Gabriel Sancez
'    18/03/2016
'All rights reserved


Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class MainForm

    'Too determine if the user is an admin or not
    Public isAdmin As Boolean
    Public pincorrect As Boolean = False
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loading.Show()
        loadAssets()
        'Loading.Hide()
        Loading.Close()
        Me.Opacity = 100

    End Sub

    'Loading of Assets
    Public Sub loadAssets()
        Dim admin As String = dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & Login.currentUser & "'", "admin")
        If (admin = "y") Then
            isAdmin = True
        Else
            isAdmin = False
        End If

        'Set the resto name and user text
        lblLoggedInAs.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bname")
        lblCurrUser.Text = "Logged in as:  " & dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & Login.currentUser & "'", "username")
        'Set the table limit
        tablelimit = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "_tables")

        'Enable/Disable Admin related stuff
        If (isAdmin) Then
            btnAdmin.Enabled = True
            btnAdmin.Show()
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True

            loadSettings()
            loadUsers()
        Else
            btnAdmin.Enabled = False
            btnAdmin.Hide()
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnReports.Enabled = False
            btnReports.Hide()
            btnInventory.Enabled = False
            btnInventory.Hide()

        End If

        'Loar Reports Table
        loadReports()
        'Resets the preview product
        resetProd()
        'Load the inventory
        loadInventory()
        'Load the sales buttons
        loadSalesButtons()
        'Bring sales up as the first tab
        grpSales.BringToFront()
        'Adds a table automtically to sales
        addtable()
        'Sets up the search for prod
        dbfunc.searchProd()
        'loads the user image
        loadUserImg()

    End Sub
    Private Sub loadInventory()
        'Set view property
        tblInventory.View = View.Details
        tblInventory.GridLines = True
        tblInventory.FullRowSelect = True

        'Add column header
        tblInventory.Columns.Add("Product Number", 100)
        tblInventory.Columns.Add("Product Code", 100)
        tblInventory.Columns.Add("Description", 100)
        tblInventory.Columns.Add("Price", 100)
        tblInventory.Columns.Add("Image Location", 100)

        dbfunc.loadInventory("SELECT * FROM tblInventory")
    End Sub
    Private Sub loadUsers()
        'Set view property
        tblusers.View = View.Details
        tblusers.GridLines = True
        tblusers.FullRowSelect = True

        'Add column header
        tblusers.Columns.Add("User Name", 100)
        tblusers.Columns.Add("First Name", 100)
        tblusers.Columns.Add("Last Name", 100)
        tblusers.Columns.Add("Middle Initial", 100)
        tblusers.Columns.Add("Image Location", 100)
        tblusers.Columns.Add("Admin", 100)

        dbfunc.loadUsers("SELECT * FROM tblusers")
    End Sub
    Private Sub loadReports()
        'Set view property
        tblReports.View = View.Details
        tblReports.GridLines = True
        tblReports.FullRowSelect = True

        'Add column header
        tblReports.Columns.Add("Date and Time", 100)
        tblReports.Columns.Add("Log", 800)

        cbxReports.SelectedIndex = 0
        dbfunc.loadReports("SELECT * FROM tblReports WHERE logtype = 'Attendance'")
    End Sub
    Private Sub loadSettings()
        'In the Settings menu
        txtSetSysName.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bname")
        txtSetTIN.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "tinNo")
        txtSetBusinessAdd1.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bAdd1")
        txtSetBusinessAdd2.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bAdd2")
        txtSetBusinessAdd3.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "bAdd3")
        txtContactNo.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "conNo")
        VAT = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "TAX"))
        txtSetVAT.Text = VAT.ToString
        txtMaxTBLNum.Text = tablelimit.ToString
        txtPin.Text = dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "mgrpin")
    End Sub
    Public Sub loadUserImg()
        Try
            Dim imgName As String = (dbfunc.retrieveVariable("SELECT * FROM tblusers WHERE username = '" & Login.currentUser & "'", "imgLoc"))
            Dim newimg As New System.Drawing.Bitmap(imgName)
            pbxUser.SizeMode = PictureBoxSizeMode.StretchImage
            pbxUser.Image = DirectCast(newimg, System.Drawing.Image)
        Catch
            pbxUser.Image = Nothing
        End Try
    End Sub


    'Menu Buttons
    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        dbfunc.loadInventory("SELECT * FROM tblinventory")
        grpInventory.BringToFront()
    End Sub
    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        dbfunc.loadUsers("SELECT * FROM tblusers")
        loadSettings()
        grpAdmin.BringToFront()
    End Sub
    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        dbfunc.loadReports("SELECT * FROM tblReports WHERE logtype = 'Attendance'")
        cbxReports.SelectedIndex = 0
        grpReports.BringToFront()
    End Sub
    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        grpSales.BringToFront()
        resetProd()

        'If changes were made to the inventory, the salesbuttons will reload
        If (buttonChange) Then
            loadSalesButtons()
        End If
    End Sub
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Application.Restart()
    End Sub

    'Inventory Buttons
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddItem.edit = False
        AddItem.GroupBox1.Text = "Add New Entry"
        Me.Enabled = False
        AddItem.Show()
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If (tblInventory.SelectedItems.Count > 0) Then
            AddItem.productNumber = tblInventory.FocusedItem.SubItems(0).Text
            AddItem.GroupBox1.Text = "Edit Entry"
            AddItem.edit = True
            Me.Enabled = False
            AddItem.Show()
        Else
            MsgBox("Please select an item first")
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If (tblInventory.SelectedItems.Count > 0) Then
            Dim productNumber As String = tblInventory.FocusedItem.SubItems(0).Text

            Dim style = MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or
                        MsgBoxStyle.Critical

            If MsgBox("Delete Selected Entry?", style, "Confirm") = MsgBoxResult.Ok Then
                dbfunc.query("DELETE FROM tblinventory WHERE prodnum = " & productNumber)
            End If
            dbfunc.loadInventory("SELECT * FROM tblInventory")
            buttonChange = True
        Else
            MsgBox("Please select an item first")
        End If
    End Sub

    'Reports
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxReports.SelectedIndexChanged
        loadfilters()
    End Sub


    'User Admin Settings Buttons
    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        AddUser.edit = False
        AddUser.GroupBox1.Text = "Add New User"
        Me.Enabled = False
        AddUser.Show()
    End Sub
    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If (tblusers.SelectedItems.Count > 0) Then
            Dim username As String = tblusers.FocusedItem.SubItems(0).Text

            Dim style = MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or
                        MsgBoxStyle.Critical

            If (username <> Login.currentUser) Then
                If MsgBox("Delete Selected User?", style, "Confirm") = MsgBoxResult.Ok Then
                    dbfunc.query("DELETE FROM tblUsers WHERE username = '" & username & "'")
                End If
                dbfunc.loadUsers("SELECT * FROM tblusers")
            Else
                MsgBox("Cannot delete currently logged user")
            End If

        Else
            MsgBox("Please select an item first")
        End If
    End Sub
    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        If (tblusers.SelectedItems.Count > 0) Then
            AddUser.userN = tblusers.FocusedItem.SubItems(0).Text
            AddUser.GroupBox1.Text = "Edit User"
            AddUser.edit = True
            Me.Enabled = False
            AddUser.Show()
        Else
            MsgBox("Please select an item first")
        End If
    End Sub
    'Settings Admin Settings Button
    Dim settings As Boolean = False
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim style = MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or
                        MsgBoxStyle.Critical

        If MsgBox("Are you sure you want to Save the new settings? Any pending transaction will be discarded ?", style, "Confirm") = MsgBoxResult.Ok Then
            If (txtSetSysName.Text = "" Or
            txtSetTIN.Text = "" Or
            txtSetBusinessAdd1.Text = "" Or
            txtSetBusinessAdd2.Text = "" Or
            txtSetBusinessAdd3.Text = "" Or
            txtContactNo.Text = "" Or
            txtSetVAT.Text = "" Or
            txtPin.Text = "" Or
            txtMaxTBLNum.Text = "") Then
                MsgBox("Please fill all fields")
            Else
                dbfunc.query("UPDATE tblsettings SET " &
                "bname = '" & txtSetSysName.Text & "', " &
                "tinNo = '" & txtSetTIN.Text & "', " &
                "bAdd1 = '" & txtSetBusinessAdd1.Text & "', " &
                "bAdd2 = '" & txtSetBusinessAdd2.Text & "', " &
                "bAdd3 = '" & txtSetBusinessAdd3.Text & "',  " &
                "conNo = '" & txtContactNo.Text & "', " &
                "TAX = " & txtSetVAT.Text & ", " &
                "_tables = " & txtMaxTBLNum.Text & ", " &
                "mgrpin = '" & txtPin.Text & "' WHERE setNum = 1")

                settings = True
                reload.r()
            End If
        End If
    End Sub
    'What happens when the form closes
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (Not settings) Then
            report.addlog(2)
            settings = True
        End If
        Application.Exit()
    End Sub






    Private Sub txtUserSearch_TextChanged(sender As Object, e As EventArgs) Handles txtUserSearch.TextChanged
        dbfunc.loadUsers("SELECT * FROM tblusers WHERE " &
        "((username LIKE '%" & txtUserSearch.Text & "%') OR " &
        "(firstname LIKE '%" & txtUserSearch.Text & "%') OR " &
        "(middleinitial LIKE '%" & txtUserSearch.Text & "%') OR" &
        "(lastname LIKE '%" & txtUserSearch.Text & "%'))")
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        dbfunc.loadInventory("SELECT * FROM tblinventory WHERE (" &
        "([proddesc] LIKE '%" & txtSearch.Text & "%') OR " &
        "([prodnum] LIKE '%" & txtSearch.Text & "%') OR " &
        "([proddesc] LIKE '%" & txtSearch.Text & "%'))")
    End Sub
    'When the txt prod search is pressed down
    Private Sub txtProdSearch_KeyPress(sender As Object, e As KeyEventArgs) Handles txtProdSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter And dbfunc.retrieveVariable("Select * FROM tblinventory WHERE proddesc = '" & txtProdSearch.Text & "'", "proddesc") = txtProdSearch.Text Then
                ProductNumber = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE proddesc = '" & txtProdSearch.Text & "'", "prodnum"))
                If (ProductNumber <> 0) Then
                    If (tabSales.TabCount > 0) Then
                        addSalesItem()
                    Else
                        MsgBox("Please Add a Sales table")
                    End If
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                Dim newitem As Boolean = True


                'proddesc LIKE '%" & txtProdSearch.Text & "%'" 
                'Increment item if it exists on the sales
                For index As Integer = 0 To tableInterface(currentTable).tblSales.Items.Count - 1
                    If (dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UCASE(proddesc) = UCASE('" & txtProdSearch.Text.ToUpper & "')", "prodcode") = tableInterface(currentTable).tblSales.Items(index).SubItems(0).Text) Then
                        Dim qty As Integer = Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(1).Text)
                        Dim price As Integer = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UCASE(proddesc) = UCASE('" & txtProdSearch.Text.ToUpper & "')", "price"))

                        tableInterface(currentTable).tblSales.Items(index).SubItems(1).Text = (qty + 1).ToString
                        tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text = (Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text) + price).ToString

                        newitem = False
                    End If
                Next

                'Add new Item
                If (newitem) Then
                    Dim product As String = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UCASE(proddesc) = UCASE('" & txtProdSearch.Text & "')", "prodcode")
                    Dim qty As Integer = 1
                    Dim Price As Integer = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UCASE(proddesc) = UCASE('" & txtProdSearch.Text & "')", "price")

                    Dim arr(3) As String
                    Dim itm As ListViewItem
                    arr(0) = product
                    arr(1) = qty
                    arr(2) = Price

                    itm = New ListViewItem(arr)

                    tableInterface(currentTable).tblSales.Items.Add(itm)
                End If

                tableInterface(currentTable).Button1.Enabled = False
                computesubtotal()
            End If
        Catch ex As Exception
        End Try
    End Sub


    'Sales Related Stuff

    'Loads the buttons and the images they contain
    Public buttonChange As Boolean = False
    Public Sub loadSalesButtons()
        'Incase a change was made to the buttons during inventory
        If (buttonChange) Then
            Loading.Show()
            grpSales.Enabled = False
        End If

        Dim buttons As Button() =
        {
        btnQuickKey1,
        btnQuickKey2,
        btnQuickKey3,
        btnQuickKey4,
        btnQuickKey5,
        btnQuickKey6,
        btnQuickKey7,
        btnQuickKey8,
        btnQuickKey9,
        btnQuickKey10,
        btnQuickKey11,
        btnQuickKey12,
        btnQuickKey13,
        btnQuickKey14,
        btnQuickKey15,
        btnQuickKey16,
        btnQuickKey17,
        btnQuickKey18,
        btnQuickKey19,
        btnQuickKey20,
        btnQuickKey21,
        btnQuickKey22,
        btnQuickKey23,
        btnQuickKey24,
        btnQuickKey25
        }
        For number As Integer = 1 To 25
            Dim prodNo As Integer = dbfunc.retrieveVariable("SELECT * FROM tblsalesbuttons WHERE btnNo = " & number, "prodNo")
            If (prodNo <> 0) Then
                buttons(number - 1).Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & prodNo, "prodcode")

                Try
                    If (dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & prodNo, "imgLoc") <> "") Then
                        buttons(number - 1).BackgroundImage = System.Drawing.Image.FromFile(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & prodNo, "imgLoc"))
                    Else
                        buttons(number - 1).BackgroundImage = Nothing
                    End If
                Catch
                End Try
            Else
                buttons(number - 1).Text = ""
                Try
                    buttons(number - 1).BackgroundImage = Nothing
                Catch
                End Try
            End If
        Next

        'Incase a change was made to the buttons during inventory
        If (buttonChange) Then
            Loading.Hide()
            Loading.Close()
            buttonChange = False
        End If

        grpSales.Enabled = True
    End Sub

    'Sales Buttons (ALOT)
    Dim ProductNumber As Integer
    Dim button As Integer
    'For 2nd or double click
    Dim lastbutton As Integer

    'Mouse clicks Action Events
    Private Sub btnQuickKey_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles btnQuickKey1.MouseDown,
                btnQuickKey2.MouseDown,
                btnQuickKey3.MouseDown,
                btnQuickKey4.MouseDown,
                btnQuickKey5.MouseDown,
                btnQuickKey6.MouseDown,
                btnQuickKey7.MouseDown,
                btnQuickKey8.MouseDown,
                btnQuickKey9.MouseDown,
                btnQuickKey10.MouseDown,
                btnQuickKey11.MouseDown,
                btnQuickKey12.MouseDown,
                btnQuickKey13.MouseDown,
                btnQuickKey14.MouseDown,
                btnQuickKey15.MouseDown,
                btnQuickKey16.MouseDown,
                btnQuickKey17.MouseDown,
                btnQuickKey18.MouseDown,
                btnQuickKey19.MouseDown,
                btnQuickKey20.MouseDown,
                btnQuickKey21.MouseDown,
                btnQuickKey22.MouseDown,
                btnQuickKey23.MouseDown,
                btnQuickKey24.MouseDown,
                btnQuickKey25.MouseDown

        Dim btn As Button = CType(sender, Button)
        getbutton(btn)

        'For double click
        If (e.Button = MouseButtons.Left And lastbutton = button) Then
            ProductNumber = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblsalesbuttons WHERE btnNo = " & button, "prodNo"))
            If (ProductNumber <> 0) Then
                If (tabSales.TabCount > 0) Then
                    addSalesItem()
                Else
                    MsgBox("Please Add a Sales table")
                End If
            End If
            'For single click
        ElseIf (e.Button = MouseButtons.Left) Then
            lastbutton = button
            ProductNumber = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblsalesbuttons WHERE btnNo = " & button, "prodNo"))
            If (ProductNumber <> 0) Then
                If (tabSales.TabCount > 0) Then
                    viewProduct()
                Else
                    MsgBox("Please Add a Sales table")
                End If
            End If
            'For right click
        ElseIf (e.Button = MouseButtons.Right) Then
            If (isAdmin) Then
                PopupInventory.button = button
                PopupInventory.Show()
            End If


        End If
    End Sub
    'Get the button that clicked
    Private Sub getbutton(ByVal btn As Button)
        Select Case (btn.Name)
            Case btnQuickKey1.Name
                button = 1
            Case btnQuickKey2.Name
                button = 2
            Case btnQuickKey3.Name
                button = 3
            Case btnQuickKey4.Name
                button = 4
            Case btnQuickKey5.Name
                button = 5
            Case btnQuickKey6.Name
                button = 6
            Case btnQuickKey7.Name
                button = 7
            Case btnQuickKey8.Name
                button = 8
            Case btnQuickKey9.Name
                button = 9
            Case btnQuickKey10.Name
                button = 10
            Case btnQuickKey11.Name
                button = 11
            Case btnQuickKey12.Name
                button = 12
            Case btnQuickKey13.Name
                button = 13
            Case btnQuickKey14.Name
                button = 14
            Case btnQuickKey15.Name
                button = 15
            Case btnQuickKey16.Name
                button = 16
            Case btnQuickKey17.Name
                button = 17
            Case btnQuickKey18.Name
                button = 18
            Case btnQuickKey19.Name
                button = 19
            Case btnQuickKey20.Name
                button = 20
            Case btnQuickKey21.Name
                button = 21
            Case btnQuickKey22.Name
                button = 22
            Case btnQuickKey23.Name
                button = 23
            Case btnQuickKey24.Name
                button = 24
            Case btnQuickKey25.Name
                button = 25
        End Select
    End Sub

    'Places the selected product in the preview pane
    Private Sub viewProduct()
        If (tabSales.TabCount > 0) Then
            btnAddItem.Enabled = True
        End If
        lblProdCode.Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "prodcode")
        lblProdDesc.Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "proddesc")
        lblPrice.Text = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "price")
        Try
            imgPreview.BackgroundImage = System.Drawing.Image.FromFile(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "imgLoc"))
        Catch

        End Try

    End Sub
    'Resets the values of the preview pane
    Public Sub resetProd()
        btnAddItem.Enabled = False
        lblProdCode.Text = ""
        lblProdDesc.Text = ""
        lblPrice.Text = ""
        imgPreview.BackgroundImage = Nothing
    End Sub




    'Outside cause I shared it with SalesInterface
    Public VAT As Integer
    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        addSalesItem()
    End Sub
    Public Sub addSalesItem()
        Dim newitem As Boolean = True


        'Increment item if it exists on the sales
        For index As Integer = 0 To tableInterface(currentTable).tblSales.Items.Count - 1
            If (dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "prodcode") = tableInterface(currentTable).tblSales.Items(index).SubItems(0).Text) Then
                Dim qty As Integer = Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(1).Text)
                Dim price As Integer = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "price"))

                tableInterface(currentTable).tblSales.Items(index).SubItems(1).Text = (qty + 1).ToString
                tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text = (Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text) + price).ToString

                newitem = False
            End If
        Next

        'Add new Item
        If (newitem) Then
            Dim product As String = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "prodcode")
            Dim qty As Integer = 1
            Dim Price As Integer = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE prodnum = " & ProductNumber, "price")

            Dim arr(3) As String
            Dim itm As ListViewItem
            arr(0) = product
            arr(1) = qty
            arr(2) = Price

            itm = New ListViewItem(arr)

            tableInterface(currentTable).tblSales.Items.Add(itm)
        End If

        tableInterface(currentTable).Button1.Enabled = False
        computesubtotal()
    End Sub

    Public Sub computesubtotal()
        Dim subPrice As Integer = 0
        For index As Integer = 0 To tableInterface(currentTable).tblSales.Items.Count - 1
            subPrice = subPrice + Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text)
        Next


        taxTotal = ((VAT / 100) * subPrice)
        Try
            discount = Double.Parse(tableInterface(currentTable).lblDiscount.Text)
        Catch ex As Exception
            discount = 0.00
        End Try
        'Compute for tax dedsuction
        tableInterface(currentTable).lblSubTotal.Text = "Php " & subPrice
        tableInterface(currentTable).lblTax.Text = taxTotal

        totprice = subPrice - discount

        'Compute for Total (No discount yet)
        tableInterface(currentTable).lblTotal.Text = "Php " & subPrice - discount
    End Sub


    Dim tablelimit = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblsettings WHERE setNum = 1", "_tables"))
    Public tableInterface(tablelimit) As SalesInterface
    Public currentTable As Integer
    'SalesInterface object array to set values individually
    Private Sub btnAddTable_Click(sender As Object, e As EventArgs) Handles btnAddTable.Click
        addtable()
    End Sub
    Public Sub addtable()
        If tabSales.TabCount + 1 <> tableInterface.Length Then  'if tabcount reaches != max
            Dim newPage As New TabPage()            'temporary value

            tableInterface(tabSales.TabCount + 1) = New SalesInterface()
            currentTable = tabSales.TabCount + 1

            tableInterface(tabSales.TabCount + 1).Show()    'shows the newly created tab

            tabSales.TabPages.Add(tabSales.TabCount, "Table" & tabSales.TabCount + 1)
            tabSales.SelectedTab = tabSales.TabPages(tabSales.TabCount - 1)
            tabSales.TabPages(tabSales.SelectedIndex).Controls.Add(tableInterface(tabSales.TabCount))
            'tableInterface(tabSales.TabCount).Show()


        Else
            MsgBox("Maximum Table Limit Reached!")
        End If

    End Sub


    'When we try to close a tab
    Private Sub btnCloseTab_Click(sender As Object, e As EventArgs) Handles btnCloseTab.Click
        If (Not isAdmin) Then
            EnterPin.ShowDialog()
            If pincorrect Then
                pincorrect = False
                resetProd()
                tabSales.SelectedTab.Hide()
                tabSales.TabPages.RemoveAt(tabSales.SelectedIndex)
            End If
        Else
            Dim style = MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or
                        MsgBoxStyle.Critical

            If MsgBox("Delete Table?", style, "Confirm") = MsgBoxResult.Ok Then
                resetProd()
                tabSales.SelectedTab.Hide()
                tabSales.TabPages.RemoveAt(tabSales.SelectedIndex)
            End If
        End If

        If (tabSales.TabCount < 1) Then
            addtable()
            resetProd()
        End If
    End Sub

    'Variables for computing the subtotal
    Public Shared totprice As Double
    Public Shared cashinput As Double
    Public Shared change As Double
    Public Shared discount As Double
    Public Shared taxTotal As Double

    'values that we pass reset when we change tabss
    Private Sub tabSales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabSales.SelectedIndexChanged

        'Changes the currentTable when moving tabs
        currentTable = tabSales.SelectedIndex + 1

    End Sub
    Dim savepdf As New SaveFileDialog
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        savepdf.Filter = "PDF Files | *.pdf"
        savepdf.DefaultExt = "pdf"
        savepdf.ShowDialog()
        If savepdf.FileName = "" Then
            Exit Sub
        Else
            ExportDataToPDFTable()
            MsgBox("PDF Created Successfully")
        End If
    End Sub

    Public Function GetDataTable(ByVal LS_VIEW As ListView) As DataTable
        ''LS_VIEW.Items.Clear()
        'Dim DT_TAB As New DataTable
        ''Try

        'If LS_VIEW.Items.Count < 1 Then
        '        Return DT_TAB
        '    Else
        '        For i As Integer = 0 To LS_VIEW.Items(0).SubItems.Count - 1
        '            Dim DCOL As New DataColumn(LS_VIEW.Columns(i).Text)
        '            DT_TAB.Columns.Add(DCOL)
        '        Next
        '    End If
        '    For i As Integer = 0 To LS_VIEW.Items.Count - 1
        '        Dim DROW As DataRow = DT_TAB.NewRow
        '        For j As Integer = 0 To LS_VIEW.Items(i).SubItems.Count - 1
        '            DROW(LS_VIEW.Columns(j).Text) = LS_VIEW.Items(i).SubItems(j).Text
        '        Next
        '        DT_TAB.Rows.Add(DROW)
        '    Next
        ''Catch
        ''   Return DT_TAB
        ''End Try

        'Return DT_TAB
        Dim table As New DataTable

        For Each item As ListViewItem In tblReports.Items
            table.Columns.Add(item.ToString)
            For Each it In item.SubItems
                table.Rows.Add(it.ToString)
            Next
        Next
        Return table
    End Function

    Private Sub ExportDataToPDFTable()
        Dim paragraph As New Paragraph
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 40, 40, 40, 10)
        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(savepdf.FileName, FileMode.Create))
        doc.Open()

        Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        Dim p1 As New Phrase
        Dim totalsalesifier As String = dbfunc.retrieveVariable("SELECT totsales FROM tbltotal", "totsales")
        p1 = New Phrase(New Chunk("Total Sales: Php" & totalsalesifier, font12BoldRed))
        doc.Add(p1)

        'Create instance of the pdf table and set the number of column in that table
        Dim PdfTable As New PdfPTable(5)
        PdfTable.TotalWidth = 490.0F
        'fix the absolute width of the table
        PdfTable.LockedWidth = True
        'relative col widths in proportions - 1,4,1,1 and 1
        Dim widths As Single() = New Single() {1.0F, 4.0F, 1.0F, 1.0F, 1.0F}
        PdfTable.SetWidths(widths)
        PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
        PdfTable.SpacingBefore = 1.0F

        'pdfCell Decleration
        Dim PdfPCell As PdfPCell = Nothing

        'Assigning values to each cell as phrases
        PdfPCell = New PdfPCell(New Phrase(New Chunk("ID", font12Bold)))
        'Alignment of phrase in the pdfcell
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        'Add pdfcell in pdftable
        PdfTable.AddCell(PdfPCell)
        PdfPCell = New PdfPCell(New Phrase(New Chunk("Log", font12Bold)))
        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
        PdfTable.AddCell(PdfPCell)

        Dim dt As DataTable = GetDataTable(tblReports)
        If dt IsNot Nothing Then
            'Now add the data from datatable to pdf table
            For rows As Integer = 0 To dt.Rows.Count - 1
                For column As Integer = 0 To dt.Columns.Count - 1
                    PdfPCell = New PdfPCell(New Phrase(dt.Rows(rows)(column).ToString(), font12Normal))
                    If column = 0 Or column = 1 Then
                        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                    Else
                        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                    End If
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            'Adding pdftable to the pdfdocument
            doc.Add(PdfTable)
        End If
        doc.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        loadfilters()
    End Sub

    Private Sub loadfilters()
        Dim logtype As String = cbxReports.SelectedItem.ToString

        If (logtype = "Attendance Reports") Then
            dbfunc.loadReports("SELECT * FROM tblReports WHERE logtype = 'Attendance' AND FORMAT([_date],'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "'")
            Label6.Visible = False
            Label7.Visible = False
        ElseIf (logtype = "Sales Reports") Then
            dbfunc.loadReports("SELECT * FROM tblReports WHERE logtype = 'Sales' AND FORMAT([_date],'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "'")
            Label6.Visible = True
            Label7.Visible = True
            Dim prcs As String() = dbfunc.retrieveList("SELECT [prc] FROM tblreports WHERE logtype = 'Sales' AND FORMAT([_date],'Short Date') = '" & DateTimePicker1.Value.Date.ToString("d") & "'", "prc")
            Dim totprice As Double = 0
            For x As Integer = 0 To prcs.Length - 1
                'MsgBox(prcs(x))
                totprice = totprice + Double.Parse(prcs(x))
            Next


            Label7.Text = totprice
        End If
    End Sub


    'Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

    '    If e.KeyCode = Keys.Enter Then
    '        MsgBox("enter")
    '        Dim newitem As Boolean = True


    '        'proddesc LIKE '%" & txtProdSearch.Text & "%'" 
    '        'Increment item if it exists on the sales
    '        For index As Integer = 0 To tableInterface(currentTable).tblSales.Items.Count - 1
    '            If (dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UPPER(proddesc) = UPPER('" & txtProdSearch.Text.ToUpper & "')", "prodcode") = tableInterface(currentTable).tblSales.Items(index).SubItems(0).Text) Then
    '                Dim qty As Integer = Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(1).Text)
    '                Dim price As Integer = Integer.Parse(dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UPPER(proddesc) = UPPER('" & txtProdSearch.Text.ToUpper & "')", "price"))

    '                tableInterface(currentTable).tblSales.Items(index).SubItems(1).Text = (qty + 1).ToString
    '                tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text = (Integer.Parse(tableInterface(currentTable).tblSales.Items(index).SubItems(2).Text) + price).ToString

    '                newitem = False
    '            End If
    '        Next

    '        'Add new Item
    '        If (newitem) Then
    '            Dim product As String = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UPPER(proddesc) = UPPER('" & txtProdSearch.Text.ToUpper & "')", "prodcode")
    '            Dim qty As Integer = 1
    '            Dim Price As Integer = dbfunc.retrieveVariable("SELECT * FROM tblinventory WHERE UPPER(proddesc) = UPPER('" & txtProdSearch.Text.ToUpper & "')", "price")

    '            Dim arr(3) As String
    '            Dim itm As ListViewItem
    '            arr(0) = product
    '            arr(1) = qty
    '            arr(2) = Price

    '            itm = New ListViewItem(arr)

    '            tableInterface(currentTable).tblSales.Items.Add(itm)
    '        End If

    '        tableInterface(currentTable).Button1.Enabled = False
    '        computesubtotal()
    '    End If
    'End Sub
End Class