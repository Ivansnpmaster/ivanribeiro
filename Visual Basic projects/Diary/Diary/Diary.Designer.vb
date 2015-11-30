<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Diary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tabControl = New TabControlClass()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.tabMyDays = New System.Windows.Forms.TabPage()
        Me.dgvMyDays = New System.Windows.Forms.DataGridView()
        Me.tabNewDay = New System.Windows.Forms.TabPage()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conteudo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabControl.SuspendLayout()
        Me.tabMyDays.SuspendLayout()
        CType(Me.dgvMyDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabMyDays)
        Me.tabControl.Controls.Add(Me.tabNewDay)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl.ItemSize = New System.Drawing.Size(35, 120)
        Me.tabControl.Location = New System.Drawing.Point(0, 0)
        Me.tabControl.Multiline = True
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(516, 410)
        Me.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabControl.TabIndex = 0
        '
        'tabMain
        '
        Me.tabMain.BackgroundImage = Global.Diary.My.Resources.Resources.imgDiary
        Me.tabMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabMain.Location = New System.Drawing.Point(124, 4)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(388, 402)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'tabMyDays
        '
        Me.tabMyDays.BackColor = System.Drawing.Color.White
        Me.tabMyDays.Controls.Add(Me.Label1)
        Me.tabMyDays.Controls.Add(Me.dgvMyDays)
        Me.tabMyDays.Location = New System.Drawing.Point(124, 4)
        Me.tabMyDays.Name = "tabMyDays"
        Me.tabMyDays.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMyDays.Size = New System.Drawing.Size(388, 402)
        Me.tabMyDays.TabIndex = 1
        Me.tabMyDays.Text = "My days"
        '
        'dgvMyDays
        '
        Me.dgvMyDays.AllowUserToAddRows = False
        Me.dgvMyDays.AllowUserToDeleteRows = False
        Me.dgvMyDays.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMyDays.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMyDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMyDays.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.data, Me.conteudo})
        Me.dgvMyDays.Location = New System.Drawing.Point(18, 30)
        Me.dgvMyDays.MultiSelect = False
        Me.dgvMyDays.Name = "dgvMyDays"
        Me.dgvMyDays.ReadOnly = True
        Me.dgvMyDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyDays.Size = New System.Drawing.Size(352, 150)
        Me.dgvMyDays.TabIndex = 0
        Me.dgvMyDays.TabStop = False
        '
        'tabNewDay
        '
        Me.tabNewDay.BackColor = System.Drawing.Color.White
        Me.tabNewDay.Location = New System.Drawing.Point(124, 4)
        Me.tabNewDay.Name = "tabNewDay"
        Me.tabNewDay.Size = New System.Drawing.Size(388, 402)
        Me.tabNewDay.TabIndex = 2
        Me.tabNewDay.Text = "New day"
        '
        'codigo
        '
        Me.codigo.FillWeight = 60.0!
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 60
        '
        'data
        '
        Me.data.FillWeight = 80.0!
        Me.data.HeaderText = "Data"
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 80
        '
        'conteudo
        '
        Me.conteudo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.conteudo.HeaderText = "Conteúdo"
        Me.conteudo.Name = "conteudo"
        Me.conteudo.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(230, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dias registrados: 0"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Diary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 410)
        Me.Controls.Add(Me.tabControl)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Diary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diary"
        Me.tabControl.ResumeLayout(False)
        Me.tabMyDays.ResumeLayout(False)
        Me.tabMyDays.PerformLayout()
        CType(Me.dgvMyDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControlClass
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabMyDays As TabPage
    Friend WithEvents tabNewDay As TabPage
    Friend WithEvents dgvMyDays As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents conteudo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
