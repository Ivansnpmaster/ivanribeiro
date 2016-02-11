Imports MySql.Data.MySqlClient

''' <summary>
''' Class that can handle with some kinds of operations with MySQL database
''' </summary>
''' <remarks>Before use this class, you must have MySQL dll in your application library!</remarks>
Public Class MySQLConnection_Class

    Dim utility As New Utility

    Public Function MySQLConnection() As MySqlConnection
        Return New MySqlConnection(stringMySQLConnection)
    End Function

    ''' <summary>
    ''' Insert to MySQL database
    ''' </summary>
    ''' <param name="tableToInsert">Table name</param>
    ''' <param name="bankColumns">String array of bank columns name</param>
    ''' <param name="itemsToInsert">Object array containing items to insert</param>
    Public Function InsertToMySQL(ByVal tableToInsert As String, ByVal bankColumns() As String, ByVal itemsToInsert() As Object)

        Dim insertString As String = "INSERT INTO " + tableToInsert + " ("
        Dim shift2(bankColumns.Length - 1) As String

        For i As Integer = 0 To bankColumns.Length - 1 Step 1
            If Not utility.IsLastElement(bankColumns(i), bankColumns) Then
                insertString += bankColumns(i) + ", "
            Else
                insertString += bankColumns(i) + ") VALUES ("
            End If

            shift2(i) = "@" + bankColumns(i)
        Next

        For j As Integer = 0 To shift2.Length - 1 Step 1
            If Not utility.IsLastElement(shift2(j), shift2) Then
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

                MessageBox.Show("Successfully recorded!", programName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True

            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message + vbNewLine + insertString, programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                con.Close()
            End Try
        End Using

        Return False

    End Function

    ''' <summary>
    ''' Update MySQL database with where statements
    ''' </summary>
    ''' <param name="tableToUpdate">Table name</param>
    ''' <param name="bankColumns">String array of bank columns name</param>
    ''' <param name="itemsToUpdate">Object array containing items to update</param>
    ''' <param name="whereBankColumns">Where bank columns name </param>
    ''' <param name="whereItems">Object array with where items to update</param>
    ''' <returns>If updated successfully, returns <c>True</c>, otherwise, <c>False</c></returns>
    ''' <remarks>Be sure to use this only when you know there's something to update</remarks>
    Public Function UpdateToMySQL(ByVal tableToUpdate As String, ByVal bankColumns() As String, ByVal itemsToUpdate() As Object, ByVal whereBankColumns() As String, ByVal whereItems() As Object, ByVal wantMessage As Boolean)

        Dim updateString As String = "UPDATE " + tableToUpdate + " SET "

        Dim shift2((bankColumns.Length + whereBankColumns.Length) - 1) As String

        For i As Integer = 0 To bankColumns.Length - 1 Step 1

            shift2(i) = "@" + bankColumns(i)

            If Not utility.IsLastElement(bankColumns(i), bankColumns) Then
                updateString += bankColumns(i) + " = "
                updateString += shift2(i) + ", "
            Else
                updateString += bankColumns(i) + " = "
                updateString += shift2(i) + " WHERE "
            End If
        Next

        For j As Integer = 0 To whereBankColumns.Length - 1 Step 1

            shift2(j + bankColumns.Length) = "@" + whereBankColumns(j) + (j + bankColumns.Length - 1).ToString()

            If Not utility.IsLastElement(whereBankColumns(j), whereBankColumns) Then
                updateString += whereBankColumns(j) + " = "
                updateString += shift2(j + bankColumns.Length) + ", AND "
            Else
                updateString += whereBankColumns(j) + " = "
                updateString += shift2(j + bankColumns.Length)
            End If
        Next

        Using con As MySqlConnection = MySQLConnection()
            Try
                con.Open()

                Dim dr As MySqlDataReader
                Dim cmd As New MySqlCommand(updateString, con)

                For i As Integer = 0 To itemsToUpdate.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(i), itemsToUpdate(i)))
                Next

                For j As Integer = bankColumns.Length To shift2.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(j), whereItems(j - bankColumns.Length)))
                Next

                dr = cmd.ExecuteReader()
                dr.Close()
                con.Close()

                If (wantMessage) Then MessageBox.Show("Informations updated!", programName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True

            Catch ex As Exception
                MessageBox.Show("Error! " + ex.Message + vbNewLine + updateString, programName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using

        Return False
    End Function

    ''' <summary>
    ''' Select from MySQL database with where statements
    ''' </summary>
    ''' <param name="bankColumns">String array of bank columns name</param>
    ''' <param name="tableToSelect">Table name</param>
    ''' <param name="whereBankColumns">Where bank columns name </param>
    ''' <param name="whereItems">Object array with where items to search</param>
    ''' <returns>DataTable object with the select</returns>
    Public Function SelectMySQL(ByVal bankColumns() As String, ByVal tableToSelect As String, ByVal whereBankColumns() As String, ByVal whereItems() As Object) As DataTable

        Dim selectString As String = " SELECT "
        Dim shift2((bankColumns.Length + whereBankColumns.Length) - 1) As String

        For i As Integer = 0 To bankColumns.Length - 1 Step 1
            If Not utility.IsLastElement(bankColumns(i), bankColumns) Then
                selectString += bankColumns(i) + ", "
            Else
                selectString += bankColumns(i) + " FROM "
            End If
        Next

        selectString += tableToSelect


        selectString += " WHERE "

        For j As Integer = 0 To whereBankColumns.Length - 1 Step 1
            shift2(j) = "@" + whereBankColumns(j)

            If Not utility.IsLastElement(whereBankColumns(j), whereBankColumns) Then
                selectString += whereBankColumns(j) + " = "
                selectString += shift2(j) + ", AND "
            Else
                selectString += whereBankColumns(j) + " = "
                selectString += shift2(j)
            End If
        Next


        Using con As MySqlConnection = MySQLConnection()
            Try
                con.Open()

                Dim cmd As New MySqlCommand(selectString, con)

                For i As Integer = 0 To whereItems.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(i), whereItems(i)))
                Next

                Using da As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        da.Fill(dt)
                        con.Close()
                        Return dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error! " + ex.Message + vbNewLine + selectString, programName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using

        Return Nothing
    End Function

    ''' <summary>
    ''' Simple select from MySQL database
    ''' </summary>
    ''' <param name="bankColumns">String array of bank columns name</param>
    ''' <param name="tableToSelect">Table name</param>
    ''' <returns>DataTable object with the select</returns>
    Public Function SelectMySQL(ByVal bankColumns() As String, ByVal tableToSelect As String) As DataTable

        Dim selectString As String = " SELECT "

        For i As Integer = 0 To bankColumns.Length - 1 Step 1
            If Not utility.IsLastElement(bankColumns(i), bankColumns) Then
                selectString += bankColumns(i) + ", "
            Else
                selectString += bankColumns(i) + " FROM "
            End If
        Next

        selectString += tableToSelect

        Using con As MySqlConnection = MySQLConnection()
            Try
                con.Open()

                Dim cmd As New MySqlCommand(selectString, con)

                Using da As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        da.Fill(dt)
                        con.Close()
                        Return dt
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error! " + ex.Message + vbNewLine + selectString, programName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using

        Return Nothing
    End Function

    Public Function CheckExistence(ByVal tableToCheck As String, ByVal bankColumns() As Object, ByVal itemsToCheck() As Object)

        Dim sql As String = "SELECT "

        For i As Integer = 0 To bankColumns.Length - 1 Step 1
            If Not utility.IsLastElement(bankColumns(i), bankColumns) Then
                sql += bankColumns(i) + ", "
            Else
                sql += bankColumns(i) + " "
            End If
        Next

        sql += "FROM " + tableToCheck + " WHERE "

        For i As Integer = 0 To itemsToCheck.Length - 1 Step 1
            If Not utility.IsLastElement(itemsToCheck(i), itemsToCheck) Then
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
                MessageBox.Show("Error: " + ex.Message, programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                conn.Close()
            End Try

            Return False
        End Using
    End Function

    ''' <summary>
    ''' Simple delete from MySQL database with where statements
    ''' </summary>
    ''' <param name="tableToDelete">Table to delete</param>
    ''' <param name="whereBankColumns">Where bank columns name</param>
    ''' <param name="whereItems">Where items term</param>
    ''' <returns>If deleted successfully, returns <c>True</c>, otherwise, returns <c>False</c></returns>
    ''' <remarks></remarks>
    Public Function DeleteMySQL(ByVal tableToDelete As String, ByVal whereBankColumns() As String, ByVal whereItems() As Object)

        Dim deleteString As String = String.Format("DELETE FROM {0} WHERE ", tableToDelete)
        Dim shift2(whereItems.Length - 1) As String

        For i As Integer = 0 To shift2.Length - 1 Step 1
            shift2(i) = "@" + whereBankColumns(i)
        Next

        For j As Integer = 0 To whereBankColumns.Length - 1 Step 1

            deleteString += String.Format("{0}={1}", whereBankColumns(j), shift2(j))

            If Not (utility.IsLastElement(whereBankColumns(j), whereBankColumns)) Then
                deleteString += " AND "
            End If
        Next

        Using con As MySqlConnection = MySQLConnection()
            Try
                con.Open()
                Dim cmd As MySqlCommand = New MySqlCommand(deleteString, con)

                For i As Integer = 0 To whereItems.Length - 1 Step 1
                    cmd.Parameters.Add(New MySqlParameter(shift2(i), whereItems(i)))
                Next

                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Successfully deleted!", programName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True

            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message + vbNewLine + deleteString, programName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                con.Close()
            End Try
        End Using

        Return False

    End Function

End Class