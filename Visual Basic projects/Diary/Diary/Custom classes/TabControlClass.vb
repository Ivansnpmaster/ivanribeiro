Public Class TabControlClass
    Inherits TabControl

    Dim utility As New Utility

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
        Dim b As New Bitmap(Width, Height)
        Dim g As Graphics = Graphics.FromImage(b)

        g.Clear(Color.Gainsboro)

        For i = 0 To TabCount - 1
            Dim TabRectangle As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then
                ' Tab is selected
                g.FillRectangle(Brushes.DarkGray, TabRectangle)
            Else
                ' Tab is not selected
                g.FillRectangle(Brushes.Gray, TabRectangle)
            End If

            If i = 0 Then
                Using ft As Font = utility.CreateFont("Consolas", 15, True, False, False)
                    g.DrawString(TabPages(i).Text, ft, Brushes.White, TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End Using
            Else
                g.DrawString(TabPages(i).Text, Font, Brushes.White, TabRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        Next

        e.Graphics.DrawImage(b.Clone, 0, 0)
        g.Dispose() : b.Dispose()
        MyBase.OnPaint(e)
    End Sub

End Class