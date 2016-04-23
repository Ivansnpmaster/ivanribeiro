<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.btnFuncionario = New System.Windows.Forms.Button()
        Me.btnInicio = New System.Windows.Forms.Button()
        Me.panelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panelMain.Controls.Add(Me.btnFuncionario)
        Me.panelMain.Controls.Add(Me.btnInicio)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(212, 502)
        Me.panelMain.TabIndex = 0
        '
        'btnFuncionario
        '
        Me.btnFuncionario.FlatAppearance.BorderSize = 0
        Me.btnFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFuncionario.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFuncionario.ForeColor = System.Drawing.Color.White
        Me.btnFuncionario.Image = Global.Custom_menu.My.Resources.Resources.Superman_icon
        Me.btnFuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFuncionario.Location = New System.Drawing.Point(0, 57)
        Me.btnFuncionario.Name = "btnFuncionario"
        Me.btnFuncionario.Size = New System.Drawing.Size(212, 36)
        Me.btnFuncionario.TabIndex = 1
        Me.btnFuncionario.Text = "Funcionário"
        Me.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFuncionario.UseVisualStyleBackColor = True
        '
        'btnInicio
        '
        Me.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnInicio.FlatAppearance.BorderSize = 0
        Me.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInicio.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicio.ForeColor = System.Drawing.Color.White
        Me.btnInicio.Image = Global.Custom_menu.My.Resources.Resources.arrows_circle_check
        Me.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInicio.Location = New System.Drawing.Point(0, 15)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Size = New System.Drawing.Size(212, 36)
        Me.btnInicio.TabIndex = 0
        Me.btnInicio.Text = "Início"
        Me.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInicio.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 502)
        Me.Controls.Add(Me.panelMain)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelMain As System.Windows.Forms.Panel
    Friend WithEvents btnInicio As System.Windows.Forms.Button
    Friend WithEvents btnFuncionario As System.Windows.Forms.Button

End Class
