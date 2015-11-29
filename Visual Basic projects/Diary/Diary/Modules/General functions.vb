Module General_functions

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

End Module
