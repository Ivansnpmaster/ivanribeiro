Public Class Diary

    Private Sub Diary_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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

        'Dim dateToRecord As Date = ConvertToMySQLDataFormat(dtpDayNewDay.Text.Trim)

        Dim dt As Date = ConvertToMySQLDataFormat(dtpDayNewDay.Text.Trim)

        Dim bankColumns(1) As String
        bankColumns(0) = "date"
        bankColumns(1) = "content"

        Dim items(1) As Object
        items(0) = dt
        items(1) = txtContentNewDay.Text.Trim

        Dim srtItems(1) As String

        For i As Integer = 0 To items.Length - 1 Step 1
            srtItems(i) = Convert.ToString(items(i))
            MessageBox.Show(srtItems(i))
        Next

        Dim exists As Boolean = CheckExistence("diary", bankColumns, srtItems)

        If (exists = False) Then
            InsertToMySQL("diary", bankColumns, items)
        Else
            If (MessageBox.Show("We found a record of this day, are you sure you want to overwrite it ?", programName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                ' Update function
            End If
        End If

    End Sub

End Class