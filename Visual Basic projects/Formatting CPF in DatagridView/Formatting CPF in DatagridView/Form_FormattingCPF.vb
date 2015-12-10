Public Class Form_FormattingCPF

    Private Sub Form_FormattingCPF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvCPF
            .Rows.Add("00000000000")
            .Rows.Add("11111111111")
            .Rows.Add("22222222222")
            .Rows.Add("33333333333")
            .Rows.Add("44444444444")
            .Rows.Add("55555555555")
            .Rows.Add("66666666666")
            .Rows.Add("77777777777")
            .Rows.Add("88888888888")
            .Rows.Add("99999999999")
        End With
    End Sub

    Private Sub btnFormat_Click(sender As Object, e As EventArgs) Handles btnFormat.Click
        For i As Integer = 0 To dgvCPF.RowCount - 1
            Dim cpfNotFormated As Long = dgvCPF.Rows(i).Cells("cpf").Value
            Dim cpf = String.Format("{0:000\.000\.000\-00}", cpfNotFormated)
            dgvCPF.Rows(i).Cells("cpf").Value = cpf
        Next
    End Sub

End Class