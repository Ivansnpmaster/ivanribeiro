<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_FormattingCPF
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
        Me.dgvCPF = New System.Windows.Forms.DataGridView()
        Me.cpf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFormat = New System.Windows.Forms.Button()
        CType(Me.dgvCPF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCPF
        '
        Me.dgvCPF.AllowUserToAddRows = False
        Me.dgvCPF.AllowUserToDeleteRows = False
        Me.dgvCPF.BackgroundColor = System.Drawing.Color.White
        Me.dgvCPF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCPF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCPF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCPF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cpf})
        Me.dgvCPF.Location = New System.Drawing.Point(12, 12)
        Me.dgvCPF.MultiSelect = False
        Me.dgvCPF.Name = "dgvCPF"
        Me.dgvCPF.ReadOnly = True
        Me.dgvCPF.RowHeadersVisible = False
        Me.dgvCPF.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCPF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCPF.Size = New System.Drawing.Size(342, 247)
        Me.dgvCPF.TabIndex = 0
        Me.dgvCPF.TabStop = False
        '
        'cpf
        '
        Me.cpf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cpf.HeaderText = "CPF"
        Me.cpf.Name = "cpf"
        Me.cpf.ReadOnly = True
        '
        'btnFormat
        '
        Me.btnFormat.Location = New System.Drawing.Point(12, 265)
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(342, 23)
        Me.btnFormat.TabIndex = 1
        Me.btnFormat.Text = "Format"
        Me.btnFormat.UseVisualStyleBackColor = True
        '
        'Form_FormattingCPF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 300)
        Me.Controls.Add(Me.btnFormat)
        Me.Controls.Add(Me.dgvCPF)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form_FormattingCPF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormattingCPF"
        CType(Me.dgvCPF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCPF As System.Windows.Forms.DataGridView
    Friend WithEvents cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnFormat As System.Windows.Forms.Button

End Class
