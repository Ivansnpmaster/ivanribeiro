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
        Me.lblFoundDaysMyDays = New System.Windows.Forms.Label()
        Me.dgvMyDays = New System.Windows.Forms.DataGridView()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.content = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabNewDay = New System.Windows.Forms.TabPage()
        Me.btnRecordNewDay = New System.Windows.Forms.Button()
        Me.lblContentNewDay = New System.Windows.Forms.Label()
        Me.txtContentNewDay = New System.Windows.Forms.TextBox()
        Me.dtpDayNewDay = New System.Windows.Forms.DateTimePicker()
        Me.lblDayNewDay = New System.Windows.Forms.Label()
        Me.tabControl.SuspendLayout()
        Me.tabMyDays.SuspendLayout()
        CType(Me.dgvMyDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNewDay.SuspendLayout()
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
        Me.tabMyDays.Controls.Add(Me.lblFoundDaysMyDays)
        Me.tabMyDays.Controls.Add(Me.dgvMyDays)
        Me.tabMyDays.Location = New System.Drawing.Point(124, 4)
        Me.tabMyDays.Name = "tabMyDays"
        Me.tabMyDays.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMyDays.Size = New System.Drawing.Size(388, 402)
        Me.tabMyDays.TabIndex = 1
        Me.tabMyDays.Text = "My days"
        '
        'lblFoundDaysMyDays
        '
        Me.lblFoundDaysMyDays.AutoSize = True
        Me.lblFoundDaysMyDays.Location = New System.Drawing.Point(272, 183)
        Me.lblFoundDaysMyDays.Name = "lblFoundDaysMyDays"
        Me.lblFoundDaysMyDays.Size = New System.Drawing.Size(98, 14)
        Me.lblFoundDaysMyDays.TabIndex = 1
        Me.lblFoundDaysMyDays.Text = "Found days: 0"
        Me.lblFoundDaysMyDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.dgvMyDays.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.code, Me.data, Me.content})
        Me.dgvMyDays.Location = New System.Drawing.Point(18, 30)
        Me.dgvMyDays.MultiSelect = False
        Me.dgvMyDays.Name = "dgvMyDays"
        Me.dgvMyDays.ReadOnly = True
        Me.dgvMyDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyDays.Size = New System.Drawing.Size(352, 150)
        Me.dgvMyDays.TabIndex = 0
        Me.dgvMyDays.TabStop = False
        '
        'code
        '
        Me.code.FillWeight = 60.0!
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Width = 60
        '
        'data
        '
        Me.data.FillWeight = 80.0!
        Me.data.HeaderText = "Data"
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 80
        '
        'content
        '
        Me.content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.content.HeaderText = "Content"
        Me.content.Name = "content"
        Me.content.ReadOnly = True
        '
        'tabNewDay
        '
        Me.tabNewDay.BackColor = System.Drawing.Color.White
        Me.tabNewDay.Controls.Add(Me.btnRecordNewDay)
        Me.tabNewDay.Controls.Add(Me.lblContentNewDay)
        Me.tabNewDay.Controls.Add(Me.txtContentNewDay)
        Me.tabNewDay.Controls.Add(Me.dtpDayNewDay)
        Me.tabNewDay.Controls.Add(Me.lblDayNewDay)
        Me.tabNewDay.Location = New System.Drawing.Point(124, 4)
        Me.tabNewDay.Name = "tabNewDay"
        Me.tabNewDay.Size = New System.Drawing.Size(388, 402)
        Me.tabNewDay.TabIndex = 2
        Me.tabNewDay.Text = "New day"
        '
        'btnRecordNewDay
        '
        Me.btnRecordNewDay.Location = New System.Drawing.Point(42, 353)
        Me.btnRecordNewDay.Name = "btnRecordNewDay"
        Me.btnRecordNewDay.Size = New System.Drawing.Size(313, 23)
        Me.btnRecordNewDay.TabIndex = 4
        Me.btnRecordNewDay.Text = "Record"
        Me.btnRecordNewDay.UseVisualStyleBackColor = True
        '
        'lblContentNewDay
        '
        Me.lblContentNewDay.AutoSize = True
        Me.lblContentNewDay.Location = New System.Drawing.Point(39, 100)
        Me.lblContentNewDay.Name = "lblContentNewDay"
        Me.lblContentNewDay.Size = New System.Drawing.Size(63, 14)
        Me.lblContentNewDay.TabIndex = 3
        Me.lblContentNewDay.Text = "Content:"
        '
        'txtContentNewDay
        '
        Me.txtContentNewDay.Location = New System.Drawing.Point(42, 117)
        Me.txtContentNewDay.Multiline = True
        Me.txtContentNewDay.Name = "txtContentNewDay"
        Me.txtContentNewDay.Size = New System.Drawing.Size(313, 230)
        Me.txtContentNewDay.TabIndex = 2
        '
        'dtpDayNewDay
        '
        Me.dtpDayNewDay.CustomFormat = ""
        Me.dtpDayNewDay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDayNewDay.Location = New System.Drawing.Point(42, 52)
        Me.dtpDayNewDay.Name = "dtpDayNewDay"
        Me.dtpDayNewDay.Size = New System.Drawing.Size(118, 22)
        Me.dtpDayNewDay.TabIndex = 1
        Me.dtpDayNewDay.TabStop = False
        '
        'lblDayNewDay
        '
        Me.lblDayNewDay.AutoSize = True
        Me.lblDayNewDay.Location = New System.Drawing.Point(39, 35)
        Me.lblDayNewDay.Name = "lblDayNewDay"
        Me.lblDayNewDay.Size = New System.Drawing.Size(35, 14)
        Me.lblDayNewDay.TabIndex = 0
        Me.lblDayNewDay.Text = "Day:"
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
        Me.tabNewDay.ResumeLayout(False)
        Me.tabNewDay.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControlClass
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabMyDays As TabPage
    Friend WithEvents tabNewDay As TabPage
    Friend WithEvents dgvMyDays As System.Windows.Forms.DataGridView
    Friend WithEvents lblFoundDaysMyDays As System.Windows.Forms.Label
    Friend WithEvents lblDayNewDay As System.Windows.Forms.Label
    Friend WithEvents code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents content As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpDayNewDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContentNewDay As System.Windows.Forms.TextBox
    Friend WithEvents lblContentNewDay As System.Windows.Forms.Label
    Friend WithEvents btnRecordNewDay As System.Windows.Forms.Button
End Class
