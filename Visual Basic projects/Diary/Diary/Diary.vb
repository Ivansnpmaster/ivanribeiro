Public Class Diary

    Private Sub Diary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDaysAtDatagridView()
    End Sub

    Private Sub LoadDaysAtDatagridView()

        dgvMyDays.Rows.Clear()

        Dim bankColumns(2) As String
        bankColumns(0) = "code"
        bankColumns(1) = "date"
        bankColumns(2) = "content"

        Dim days As DataTable = SelectMySQL(bankColumns, table)

        If days.Rows.Count > 0 Then
            Dim i As Integer = 0
            While i < days.Rows.Count
                dgvMyDays.Rows.Add()
                dgvMyDays.Rows(i).Cells(bankColumns(0)).Value = days.Rows(i).Item(bankColumns(0)).ToString
                'DatagridView doesn't accept 'date' as column name
                dgvMyDays.Rows(i).Cells("data").Value = days.Rows(i).Item(bankColumns(1)).ToString.Substring(0, 10)
                dgvMyDays.Rows(i).Cells(bankColumns(2)).Value = days.Rows(i).Item(bankColumns(2)).ToString
                i += 1
            End While
        End If

        lblFoundDaysMyDays.Text = "Days found: " + dgvMyDays.RowCount.ToString

    End Sub

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

        Dim bankColumns(1) As String
        bankColumns(0) = "date"
        bankColumns(1) = "content"

        Dim items(1) As Object
        items(0) = dt
        items(1) = txtContentNewDay.Text.Trim

        '---------- Check existance variables

        Dim srtBankCheck(0) As String
        srtBankCheck(0) = "date"

        Dim srtItems(0) As Object
        srtItems(0) = dt.ToString("yyyy-MM-dd")

        '---------- Function

        Dim exists As Boolean = CheckExistence("diary", srtBankCheck, srtItems)

        If Not (exists) Then
            InsertToMySQL("diary", bankColumns, items)
            modified = True
        Else
            If (MessageBox.Show("We found a record of this day, are you sure you want to overwrite it ?", programName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then

                Dim strBankWhereStatement(0) As String
                strBankWhereStatement(0) = "date"

                UpdateToMySQL("diary", bankColumns, items, strBankWhereStatement, srtItems)
                modified = True
            End If
        End If

    End Sub

    Private Sub dtpDayNewDay_ValueChanged(sender As Object, e As EventArgs) Handles dtpDayNewDay.ValueChanged

        ' Select items from bank
        Dim dt As Date = CDate(dtpDayNewDay.Text.Trim)

        Dim bankColumns(0) As String
        bankColumns(0) = "content"

        Dim whereBankColumns(0) As String
        whereBankColumns(0) = "date"

        Dim whereItems(0) As Object
        whereItems(0) = dt.ToString("yyyy-MM-dd")

        Dim dr As DataTable = SelectMySQL(bankColumns, "diary", whereBankColumns, whereItems)

        If dr.Rows.Count > 0 Then
            txtContentNewDay.Text = dr.Rows(0).Item("content").ToString
        Else
            txtContentNewDay.Clear()
        End If

    End Sub

    'Just reload if some modification happened
    Dim modified As Boolean = True

    Private Sub tabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl.SelectedIndexChanged

        Select Case tabControl.SelectedIndex
            Case 1
                If modified Then
                    LoadDaysAtDatagridView()
                    modified = False
                End If
        End Select

    End Sub

End Class