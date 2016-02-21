Public Class QueryExecution

    Dim utility As New Utility

    Private Sub QueryExecution_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim columns() As String = New String() {"login.id", "login.nome", "cliente.idade"}
        Dim params() As String = New String() {"@id"}
        Dim items() As Object = New Object() {1}

        Dim sql As String = "SELECT " + utility.StringColumnsConcat(columns) + " FROM login INNER JOIN cliente ON login.id = cliente.id WHERE login.id = " + params(0)

        If Not (dgvQueryTest.ColumnCount > 0) Then utility.PrepareDatagridView(dgvQueryTest, columns)

        Dim dt As DataTable = connection.ExecuteSQLCommand(sql, params, items)
        utility.PopulateDatagridView(dgvQueryTest, dt, True)

    End Sub

End Class