Imports MySql.Data.MySqlClient

Public Class Diary

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
        Else
            If (MessageBox.Show("We found a record of this day, are you sure you want to overwrite it ?", programName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then

                Dim strBankWhereStatement(0) As String
                strBankWhereStatement(0) = "date"

                UpdateToMySQL("diary", bankColumns, items, strBankWhereStatement, srtItems)
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

End Class