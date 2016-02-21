Public Class Utility

    Public Function CreateFont(ByVal fontName As String, ByVal fontSize As Integer, ByVal isBold As Boolean, ByVal isItalic As Boolean, ByVal isStrikeout As Boolean) As Drawing.Font

        Dim styles As FontStyle = FontStyle.Regular

        If (isBold) Then
            styles = styles Or FontStyle.Bold
        End If
        If (isItalic) Then
            styles = styles Or FontStyle.Italic
        End If
        If (isStrikeout) Then
            styles = styles Or FontStyle.Strikeout
        End If

        Dim newFont As New Drawing.Font(fontName, fontSize, styles)
        Return newFont

    End Function

    Public Function IsLastElement(ByVal current As Object, ByVal array() As Object)

        If (current = array(array.Length - 1)) Then
            Return True
        End If
        Return False

    End Function

    Public Function PopulateDatagridView(ByVal grid As DataGridView, ByVal dataTable As DataTable, ByVal clearBefore As Boolean) As Integer

        If (clearBefore) Then grid.Rows.Clear()

        Dim i As Integer = 0

        If dataTable.Rows.Count > 0 Then
            While i < dataTable.Rows.Count
                grid.Rows.Add()
                For j As Integer = 0 To grid.ColumnCount - 1
                    grid.Rows(i).Cells(j).Value = dataTable.Rows(i).Item(j).ToString()
                Next
                i += 1
            End While
        End If

        Return i

    End Function

    Public Function ImageToByte(ByVal pictureBox As PictureBox) As Byte()

        Dim memoryStream As New IO.MemoryStream
        pictureBox.Image.Save(memoryStream, Imaging.ImageFormat.Jpeg)

        Dim arrayImage() As Byte = memoryStream.GetBuffer
        memoryStream.Close()

        Return arrayImage

    End Function

    Public Function ByteToImage(ByVal imageBytes() As Byte) As Image

        Dim imageData As Byte() = DirectCast(imageBytes, Byte())
        Dim memoryStream As New IO.MemoryStream(imageData)
        Dim pictureBox As New PictureBox
        pictureBox.Image = Image.FromStream(memoryStream)
        memoryStream.Close()

        Return pictureBox.Image

    End Function

    Function StringColumnsConcat(ByVal columns As String()) As String

        Dim result As String = ""

        For i As Integer = 0 To columns.Length - 1
            If (IsLastElement(columns(i), columns)) Then
                result += columns(i)
                Continue For
            End If
            result += columns(i) + ","
        Next

        Return result

    End Function

    Public Sub PrepareDatagridView(ByVal dataGridView As DataGridView, ByVal columns As String())
        For i As Integer = 0 To columns.Length - 1
            Dim newString As String = columns(i).Substring(columns(i).IndexOf(".") + 1)
            dataGridView.Columns.Add(newString, StrConv(newString, VbStrConv.ProperCase))
            dataGridView.Columns(i).Name = newString
        Next
    End Sub

End Class