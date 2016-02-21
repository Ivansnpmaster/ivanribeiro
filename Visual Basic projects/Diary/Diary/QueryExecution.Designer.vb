<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryExecution
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
        Me.dgvQueryTest = New System.Windows.Forms.DataGridView()
        CType(Me.dgvQueryTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQueryTest
        '
        Me.dgvQueryTest.AllowUserToAddRows = False
        Me.dgvQueryTest.AllowUserToDeleteRows = False
        Me.dgvQueryTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQueryTest.Location = New System.Drawing.Point(12, 12)
        Me.dgvQueryTest.Name = "dgvQueryTest"
        Me.dgvQueryTest.ReadOnly = True
        Me.dgvQueryTest.Size = New System.Drawing.Size(495, 354)
        Me.dgvQueryTest.TabIndex = 0
        '
        'QueryExecution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 378)
        Me.Controls.Add(Me.dgvQueryTest)
        Me.Name = "QueryExecution"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Execution"
        CType(Me.dgvQueryTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvQueryTest As System.Windows.Forms.DataGridView
End Class
