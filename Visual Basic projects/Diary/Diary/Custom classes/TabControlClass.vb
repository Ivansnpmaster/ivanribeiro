Public Class TabControlClass
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(35, 120)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        G.Clear(Color.Gainsboro)

        For i = 0 To TabCount - 1
            Dim TabRectangle As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then
                ' Tab is selected
                G.FillRectangle(Brushes.DarkGray, TabRectangle)
            Else
                ' Tab is not selected
                G.FillRectangle(Brushes.Gray, TabRectangle)
            End If

            If i = 0 Then
                Using ft As Font = CreateFont("Arial", 15, True, False, False)
                    G.DrawString(TabPages(i).Text, ft, Brushes.White, TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End Using
            Else
                G.DrawString(TabPages(i).Text, Font, Brushes.White, TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        Next

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
        MyBase.OnPaint(e)

    End Sub
End Class