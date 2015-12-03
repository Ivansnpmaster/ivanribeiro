Imports MySql.Data.MySqlClient

Module ConnectionModule

    Public table As String = "diary"
    Public db As String = "diaryDB"

    Public Function MySQLConnection() As MySqlConnection
        Dim stringMySQLConnection As String = "server =localhost; user id =root; password =; database =" + db + ";"
        Return New MySqlConnection(stringMySQLConnection)
    End Function

    ' Need some tests
    Public Function InsertToMySQL(ByVal tableToInsert As String, ByVal bankColumns() As String, ByVal itemsToInsert() As Object)

        Dim insertString As String = "INSER INTO " + tableToInsert + " ("
        Dim shift2(bankColumns.Length - 1) As String

        For i As Integer = 0 To bankColumns.Length - 2 Step 1
            If Not IsLastElement(bankColumns(i), bankColumns) Then
                insertString += bankColumns(i) + ", "
            Else
                insertString += bankColumns(i) + ") VALUES ("
            End If

            shift2(i) = "@" + bankColumns(i)
        Next

        For j As Integer = 0 To shift2.Length - 2 Step 1
            If Not IsLastElement(shift2(j), shift2) Then
                insertString += shift2(j) + ", "
            Else
                insertString += shift2(j) + ")"
            End If
        Next

        Using con As MySqlConnection = MySQLConnection()
            Try
                con.Open()

                Dim cmd As MySqlCommand = New MySqlCommand(insertString, con)

                For i As Integer = 0 To itemsToInsert.Length - 2 Step 1
                    cmd.Parameters.AddWithValue(shift2(i), itemsToInsert(i))
                Next

                cmd.ExecuteNonQuery()
                con.Close()

                Return True

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End Using

        Return False

    End Function

    ' Also need some tests
    Public Function CheckExistence(ByVal tableToCheck As String,
                                   ByVal bankColumns() As String,
                                   ByVal itemsToCheck() As String)

        Dim sql As String = "SELECT "

        For i As Integer = 0 To bankColumns.Length - 2 Step 1
            If Not IsLastElement(bankColumns(i), bankColumns) Then
                sql += bankColumns(i) + ", "
            Else
                sql += bankColumns(i) + " "
            End If
        Next

        sql += "FROM " + tableToCheck + " WHERE "

        For i As Integer = 0 To itemsToCheck.Length - 2 Step 1
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