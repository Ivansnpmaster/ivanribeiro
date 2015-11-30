Imports MySql.Data.MySqlClient

Module ConnectionModule

    Public table As String = "diary"
    Public db As String = "diaryDB"

    Public Function MySQLConnection() As MySqlConnection
        Dim stringMySQLConnection As String = "server =localhost; user id =root; password =; database =" + db + ";"
        Return New MySqlConnection(stringMySQLConnection)
    End Function

    Public Function InsertToMySQL(ByVal tableToInsert As String, ByVal columns() As String)

        Dim insertString As String = ""



        Return insertString

    End Function

    Public Function CheckExistence(ByVal tableToCheck As String,
                                   ByVal bankColumns() As String,
                                   ByVal itemsToCheck() As String)

        Dim sql As String = "SELECT "

        For i As Integer = 0 To bankColumns.Length - 2
            If Not IsLastElement(bankColumns(i), bankColumns) Then
                sql += bankColumns(i) + ", "
            Else
                sql += bankColumns(i) + " "
            End If
        Next

        sql += "FROM " + tableToCheck + " WHERE "

        For i As Integer = 0 To itemsToCheck.Length - 2
            If Not IsLastElement(itemsToCheck(i), itemsToCheck) Then
                sql += bankColumns(i) + "='" + itemsToCheck(i) + "' AND "
            Else
                sql += bankColumns(i) + "='" + itemsToCheck(i) + "'"
            End If
        Next

        Using conn As MySqlConnection = MySQLConnection()

            Try
                conn.Open()

                Dim cmd As MySqlCommand = New MySqlCommand(sql, conn)

                Dim rd As MySqlDataReader

                rd = cmd.ExecuteReader

                If rd.HasRows Then
                    conn.Close()
                    Return True
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                conn.Close()
            End Try

            Return False
        End Using

    End Function

End Module