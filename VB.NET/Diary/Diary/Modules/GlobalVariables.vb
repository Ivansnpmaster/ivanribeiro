''' <summary>
''' Global variables used a lot of times or just some
''' </summary>
''' <remarks></remarks>
Module GlobalVariables

    Public connection As New MySQLConnection_Class

    Public programName As String = "Diary"
    Public stringMySQLConnection As String = "server =localhost; user id =root; password =; database =diaryDB;"
    Public strImageFilter As String = "Images (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp"

End Module