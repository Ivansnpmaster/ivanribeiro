Public Class Diary

    Dim utility As New Utility

    Private Sub Diary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCurrentBackground()
        LoadDaysAtDatagridView()
    End Sub

    Private Sub LoadCurrentBackground()

        Dim bankColumns() As String = New String() {"image"}
        Dim whereBankColumns() As String = New String() {"current"}
        Dim whereItems() As Object = New Object() {1}

        Dim dt As DataTable = connection.SelectMySQL(bankColumns, "background", whereBankColumns, whereItems)

        If (dt.Rows.Count > 0) Then
            tabControl.TabPages(0).BackgroundImage = utility.ByteToImage(dt.Rows(0).Item(0))
        Else
            tabControl.TabPages(0).BackgroundImage = My.Resources.imgDiary
        End If

    End Sub

    Private Sub tabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl.SelectedIndexChanged

        Select Case tabControl.SelectedIndex
            Case 1
                If (modified) Then
                    LoadDaysAtDatagridView()
                    modified = False
                End If
            Case 3
                If (mustLoadImages) Then
                    LoadImages()
                End If
        End Select

    End Sub

#Region "Tab - My days"

    Private Sub LoadDaysAtDatagridView()

        Dim bankColumns() As String = New String() {"code", "date", "content"}

        Dim days As DataTable = connection.SelectMySQL(bankColumns, "diary")
        Dim cont As Integer = utility.PopulateDatagridView(dgvMyDays, days, True)

        'Just for edit the data format
        For i As Integer = 0 To dgvMyDays.Rows.Count - 1
            Dim newDate As String = dgvMyDays.Rows(i).Cells("data").Value
            dgvMyDays.Rows(i).Cells("data").Value = newDate.Substring(0, 10)
        Next

        lblFoundDaysMyDays.Text = "Days found: " + cont.ToString()

    End Sub

#End Region

#Region "Tab - New day"

    'Just to reload if some modification happened
    Dim modified As Boolean = True

    Private Sub btnRecordNewDay_Click(sender As Object, e As EventArgs) Handles btnRecordNewDay.Click

        If (dtpDayNewDay.Text.Trim = "") Then
            MessageBox.Show("You must pick a date!", programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        ElseIf (txtContentNewDay.Text.Trim = "") Then
            MessageBox.Show("You must type something!", programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        ElseIf (txtContentNewDay.Text.Length > 50000) Then
            MessageBox.Show("You must type something with no more than 50000 characters!", programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        '---------- Insert variables

        Dim dt As Date = CDate(dtpDayNewDay.Text.Trim)

        Dim bankColumns() As String = New String() {"date", "content"}
        Dim items() As Object = New Object() {dt, txtContentNewDay.Text.Trim}

        '---------- Check existance variables

        Dim srtBankCheck() As String = New String() {"date"}
        Dim srtItems() As Object = New Object() {dt.ToString("yyyy-MM-dd")}

        '---------- Function

        Dim exists As Boolean = connection.CheckExistence("diary", srtBankCheck, srtItems)

        If Not (exists) Then
            connection.InsertToMySQL("diary", bankColumns, items)
            modified = True
        Else
            If (MessageBox.Show("We found a record of this day, are you sure you want to overwrite it ?", programName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then

                Dim strBankWhereStatement(0) As String
                strBankWhereStatement(0) = "date"

                connection.UpdateToMySQL("diary", bankColumns, items, strBankWhereStatement, srtItems, True)
                modified = True
            End If
        End If

    End Sub

    Private Sub dtpDayNewDay_ValueChanged(sender As Object, e As EventArgs) Handles dtpDayNewDay.ValueChanged

        ' Select items from bank
        Dim dt As Date = CDate(dtpDayNewDay.Text.Trim)

        Dim bankColumns() As String = New String() {"content"}
        Dim whereBankColumns() As String = New String() {"date"}
        Dim whereItems() As Object = New Object() {dt.ToString("yyyy-MM-dd")}

        Dim dr As DataTable = connection.SelectMySQL(bankColumns, "diary", whereBankColumns, whereItems)

        If (dr.Rows.Count > 0) Then
            txtContentNewDay.Text = dr.Rows(0).Item("content").ToString
        Else
            txtContentNewDay.Clear()
        End If

    End Sub

#End Region

#Region "Tab - Configurations"

    'Just for reload the images if necessary
    Dim mustLoadImages As Boolean = True

    Private Sub LoadImages()

        If (mustLoadImages) Then
            Dim bankColumns() As String = New String() {"id", "imageName"}
            Dim dt As DataTable = connection.SelectMySQL(bankColumns, "background")

            If (dt.Rows.Count > 0) Then utility.PopulateDatagridView(dgvConfigurationListImages, dt, True)
            mustLoadImages = False
        End If

    End Sub

    Private Sub btnConfigurationsNewOne_Click(sender As Object, e As EventArgs) Handles btnConfigurationsNewOne.Click

        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = Environment.SpecialFolder.MyPictures
        ofd.Filter = strImageFilter

        If ofd.ShowDialog = DialogResult.OK Then
            picBoxConfiguration.Image = Image.FromFile(ofd.FileName)
            selectedNewImage = True
        End If

    End Sub

    'Just to check if some new image was uploaded to picturebox
    Dim selectedNewImage As Boolean = False

    Private Sub btnConfigurationSaveInBank_Click(sender As Object, e As EventArgs) Handles btnConfigurationSaveInBank.Click

        If (selectedNewImage) Then

            Dim selectBankLstIndex() As String = New String() {"id"}
            Dim dt As DataTable = connection.SelectMySQL(selectBankLstIndex, "background")

            Dim arrayImage() As Byte = utility.ImageToByte(picBoxConfiguration)
            Dim bankColumns() As String = New String() {"imageName", "image", "current"}
            Dim itemsToInsert() As Object = New Object() {"Imagem " & dt.Rows(dt.Rows.Count - 1).Item(0) + 1, arrayImage, 0}

            connection.InsertToMySQL("background", bankColumns, itemsToInsert)
            selectedNewImage = False
            mustLoadImages = True
            LoadImages()
        End If

    End Sub

    Private Sub dgvConfigurationListImages_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConfigurationListImages.CellClick

        Dim bankColumns() As String = New String() {"image"}
        Dim whereBankColumns() As String = New String() {"id"}
        Dim whereItems() As Object = New Object() {dgvConfigurationListImages.CurrentRow.Cells(0).Value}

        Dim dt As DataTable = connection.SelectMySQL(bankColumns, "background", whereBankColumns, whereItems)

        If (dt.Rows.Count > 0) Then
            picBoxConfiguration.Image = utility.ByteToImage(dt.Rows(0).Item(0))
        End If

    End Sub

    Private Sub btnConfigurationSetCurrent_Click(sender As Object, e As EventArgs) Handles btnConfigurationSetCurrent.Click

        Dim allItemsToUpdate() As Object = New Object() {0}

        'Update only the selected
        Dim bankColumns() As String = New String() {"current"}
        Dim whereBankColumns() As String = New String() {"id"}
        Dim itemsToUpdate() As Object = New Object() {1}
        Dim whereItems() As Object = New Object() {dgvConfigurationListImages.CurrentRow.Cells(0).Value}

        connection.UpdateToMySQL("background", bankColumns, allItemsToUpdate, bankColumns, itemsToUpdate, False)
        connection.UpdateToMySQL("background", bankColumns, itemsToUpdate, whereBankColumns, whereItems, True)

        LoadCurrentBackground()

    End Sub

    Private Sub btnConfigurationsDeleteSelected_Click(sender As Object, e As EventArgs) Handles btnConfigurationsDeleteSelected.Click

        If (dgvConfigurationListImages.RowCount = 0) Then
            MessageBox.Show("There's nothing to exclude!", programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        ElseIf (dgvConfigurationListImages.RowCount = 1) Then
            MessageBox.Show("Please, add a new one to exclude the selected image!", programName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim whereBankColumns() As String = New String() {"id"}
        Dim whereItems() As Object = New Object() {dgvConfigurationListImages.CurrentRow.Cells(0).Value}

        Dim deleted As Boolean = connection.DeleteMySQL("background", whereBankColumns, whereItems)

        If (deleted) Then
            mustLoadImages = True
            LoadImages()
            picBoxConfiguration.Image = Nothing
            LoadCurrentBackground()
        End If

    End Sub

#End Region

End Class