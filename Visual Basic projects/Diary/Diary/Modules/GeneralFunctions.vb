Module GeneralFunctions

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

    Public Function IsLastElement(ByVal current As Object, ByVal array() As Object)
        If (current = array(array.Length - 1)) Then
            Return True
        End If
        Return False
    End Function

End Module