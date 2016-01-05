Public Class Main

    Dim panelBase As Panel
    Dim indexButton As Integer

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' -- Botão início
        Dim imgInicio As New Bitmap(btnInicio.Image, 32, 32)
        btnInicio.Image = imgInicio
        ' -- Fim - Botão início

        Dim imgFuncionario As New Bitmap(btnFuncionario.Image, 32, 32)
        btnFuncionario.Image = imgFuncionario

        panelBase = New Panel
        panelBase.Name = "panelHome"
        panelBase.Left = 0
        panelBase.Height = panelMain.Height
        panelBase.Width = panelMain.Width
        panelBase.BackColor = Color.SlateGray
        Controls.Add(panelBase)
    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        If indexButton <> 0 Then
            ResetarPanel()
        End If
        indexButton = 0
    End Sub

    Private Sub btnFuncionario_Click(sender As Object, e As EventArgs) Handles btnFuncionario.Click

        If (indexButton = 1) Then
            ResetarPanel()
            indexButton = 0
            Exit Sub
        End If

        indexButton = 1

        If Not (panelBase Is Nothing) And (panelBase.Controls.Count > 0) Then
            Dim con As Control
            For controlIndex As Integer = panelBase.Controls.Count - 1 To 0 Step -1
                con = panelBase.Controls(controlIndex)
                If Not con.Name.Contains("btnFuncionario") Then
                    panelBase.Controls.Remove(con)
                End If
            Next
        End If

        For i As Integer = 0 To panelMain.Width Step 1
            panelBase.Left = i
            PauseDelay(100000)
        Next

        ' -- Botão de cadastro

        Dim btnFuncionarioCadastro As New Button
        panelBase.Controls.Add(btnFuncionarioCadastro)

        btnFuncionarioCadastro.Name = "btnFuncionarioCadastro"
        btnFuncionarioCadastro.Text = "CADASTRO"
        btnFuncionarioCadastro.ForeColor = Color.Black
        btnFuncionarioCadastro.BackColor = Color.White
        btnFuncionarioCadastro.Parent = panelBase
        btnFuncionarioCadastro.Size = New Point(panelBase.Width, 48)
        btnFuncionarioCadastro.FlatStyle = FlatStyle.Flat
        btnFuncionarioCadastro.FlatAppearance.BorderSize = 0
        btnFuncionarioCadastro.Top = 0
        btnFuncionarioCadastro.ImageAlign = ContentAlignment.MiddleLeft
        btnFuncionarioCadastro.TextImageRelation = TextImageRelation.Overlay
        btnFuncionarioCadastro.TextAlign = ContentAlignment.MiddleCenter

        ' -- Fim - Botão de cadastro

        ' -- Botão de consulta

        Dim btnFuncionarioConsulta As New Button
        panelBase.Controls.Add(btnFuncionarioConsulta)

        btnFuncionarioConsulta.Name = "btnFuncionarioConsulta"
        btnFuncionarioConsulta.Text = "CONSULTA"
        btnFuncionarioConsulta.ForeColor = Color.Black
        btnFuncionarioConsulta.BackColor = Color.White
        btnFuncionarioConsulta.Parent = panelBase
        btnFuncionarioConsulta.Size = New Point(panelBase.Width, 48)
        btnFuncionarioConsulta.FlatStyle = FlatStyle.Flat
        btnFuncionarioConsulta.FlatAppearance.BorderSize = 0
        btnFuncionarioConsulta.Top = btnFuncionarioCadastro.Height
        btnFuncionarioConsulta.ImageAlign = ContentAlignment.MiddleLeft
        btnFuncionarioConsulta.TextImageRelation = TextImageRelation.Overlay
        btnFuncionarioConsulta.TextAlign = ContentAlignment.MiddleCenter

        ' -- Fim - Botão de consulta

        ' -- Botão de consulta

        Dim btnFuncionarioVendas As New Button
        panelBase.Controls.Add(btnFuncionarioVendas)

        btnFuncionarioVendas.Name = "btnFuncionarioConsulta"
        btnFuncionarioVendas.Text = "VENDAS"
        btnFuncionarioVendas.ForeColor = Color.Black
        btnFuncionarioVendas.BackColor = Color.White
        btnFuncionarioVendas.Parent = panelBase
        btnFuncionarioVendas.Size = New Point(panelBase.Width, 48)
        btnFuncionarioVendas.FlatStyle = FlatStyle.Flat
        btnFuncionarioVendas.FlatAppearance.BorderSize = 0
        btnFuncionarioVendas.Top = btnFuncionarioConsulta.Top + btnFuncionarioConsulta.Height
        btnFuncionarioVendas.ImageAlign = ContentAlignment.MiddleLeft
        btnFuncionarioVendas.TextImageRelation = TextImageRelation.Overlay
        btnFuncionarioVendas.TextAlign = ContentAlignment.MiddleCenter

        ' -- Fim - Botão de consulta

        Dim imgCadastro As Bitmap = My.Resources.arrows_circle_plus
        Dim imgCadastro2 As New Bitmap(imgCadastro, 32, 32)
        btnFuncionarioCadastro.Image = imgCadastro2

        Dim imgConsulta As Bitmap = My.Resources.arrows_circle_remove
        Dim imgConsulta2 As New Bitmap(imgConsulta, 32, 32)
        btnFuncionarioConsulta.Image = imgConsulta2

        Dim imgVendas As Bitmap = My.Resources.arrows_circle_check
        Dim imgVendas2 As New Bitmap(imgVendas, 32, 32)
        btnFuncionarioVendas.Image = imgVendas2


    End Sub

    Private Sub ResetarPanel()
        If Not (panelBase Is Nothing) And (panelBase.Controls.Count > 0) Then
            For i As Integer = panelMain.Width To 0 Step -1
                panelBase.Left = i
                PauseDelay(100000)
            Next

            Dim con As Control
            For controlIndex As Integer = panelBase.Controls.Count - 1 To 0 Step -1
                con = panelBase.Controls(controlIndex)
                panelBase.Controls.Remove(con)
            Next
        End If
    End Sub

    Private Sub PauseDelay(ByVal contador As Integer)
        Dim i As Integer = 0

        While i < contador
            i += 1
        End While
    End Sub

End Class