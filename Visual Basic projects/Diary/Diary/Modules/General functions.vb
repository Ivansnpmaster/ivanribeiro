Module General_functions

    Public programName As String = "Diary"

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

    Public Function IsLastElement(ByVal current As String, ByVal array() As String)
        If (current = array(array.Length - 1)) Then
            Return True
        End If
        Return False
    End Function

    Public Function ConvertToMySQLDataFormat(ByVal dateToFormat As String)
        Dim day, month, year As String

        day = dateToFormat.Substring(0, 2)
        month = dateToFormat.Substring(3, 2)
        year = dateToFormat.Substring(6, 4)

        dateToFormat = year & "-" & month & "-" & day

        Return dateToFormat
    End Function

End Module