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

        Dim insertString As String = "INSERT INTO " + tableToInsert + " ("
        Dim shift2(bankColumns.Length - 1) As String

        For i As Integer = 0 To bankColumns.Length - 1 Step 1
            If Not IsLastElement(bankColumns(i), bankColumns) Then
                insertString += bankColumns(i) + ", "
            Else
                insertString += bankColumns(i) + ") VALUES ("
            End If

            shift2(i) = "@" + bankColumns(i)
        Next

        For j As Integer = 0 To shift2.Length - 1 Step 1
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

                For i As Integer = 0 To itemsToInsert.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(i), itemsToInsert(i)))
                Next

                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Gravado com sucesso!", programName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message + vbNewLine + insertString, programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                con.Close()
            End Try
        End Using

        Return False

    End Function

    Public Function UpdateMySQL(ByVal tableToUpdate As String, ByVal bankColumns() As String, ByVal itemsToUpdate() As Object, ByVal whereBankColumns() As String, ByVal whereItems() As Object)

        Dim updateString As String = "UPDATE " + tableToUpdate + " SET "

        Dim shift2((bankColumns.Length - 1) + (whereBankColumns.Length - 1)) As String

        For i As Integer = 0 To bankColumns.Length - 1 Step 1

            shift2(i) = "@" + bankColumns(i)

            If Not IsLastElement(bankColumns(i), bankColumns) Then
                updateString += bankColumns(i) + " ="
                updateString += shift2(i) + ", "
            Else
                updateString += bankColumns(i) + " ="
                updateString += shift2(i) + " WHERE "
            End If
        Next

        For j As Integer = 0 To whereBankColumns.Length - 1 Step 1

            shift2(j + bankColumns.Length - 1) = "@" + whereBankColumns(j)

            If Not IsLastElement(whereBankColumns(j), whereBankColumns) Then
                updateString += whereBankColumns(j) + " = "
                updateString += shift2(j + bankColumns.Length - 1) + ", AND "
            Else
                updateString += whereBankColumns(j) + " = "
                updateString += shift2(j + bankColumns.Length - 1)
            End If
        Next

        MessageBox.Show(updateString)

        Using con As MySqlConnection = MySQLConnection()
            Try
                con.Open()

                Dim dr As MySqlDataReader
                Dim cmd As New MySqlCommand(updateString, con)

                For i As Integer = 0 To itemsToUpdate.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(i), itemsToUpdate(i)))
                Next

                For j As Integer = bankColumns.Length - 1 To shift2.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(j), whereItems(j - bankColumns.Length - 1)))
                Next

                dr = cmd.ExecuteReader()
                dr.Close()
                con.Close()

                MessageBox.Show("Informations updated!", programName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True

            Catch ex As Exception
                MessageBox.Show("Error!" + ex.Message + vbNewLine + updateString, programName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using

        Return False
    End Function

    Public Function CheckExistence(ByVal tableToCheck As String, ByVal bankColumns() As Object, ByVal itemsToCheck() As Object)

        Dim sql As String = "SELECT "

        For i As Integer = 0 To bankColumns.Length - 1 Step 1
            If Not IsLastElement(bankColumns(i), bankColumns) Then
                sql += bankColumns(i) + ", "
            Else
                sql += bankColumns(i) + " "
            End If
        Next

        sql += "FROM " + tableToCheck + " WHERE "

        For i As Integer = 0 To itemsToCheck.Length - 1 Step 1
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