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
        Me.tabConfigurations = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabBackground = New System.Windows.Forms.TabPage()
        Me.dgvConfigurationListImages = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.imageName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConfigurationSaveInBank = New System.Windows.Forms.Button()
        Me.btnConfigurationSetCurrent = New System.Windows.Forms.Button()
        Me.picBoxConfiguration = New System.Windows.Forms.PictureBox()
        Me.btnConfigurationsDeleteSelected = New System.Windows.Forms.Button()
        Me.btnConfigurationsNewOne = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabControl.SuspendLayout()
        Me.tabMyDays.SuspendLayout()
        CType(Me.dgvMyDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNewDay.SuspendLayout()
        Me.tabConfigurations.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabBackground.SuspendLayout()
        CType(Me.dgvConfigurationListImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBoxConfiguration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabMyDays)
        Me.tabControl.Controls.Add(Me.tabNewDay)
        Me.tabControl.Controls.Add(Me.tabConfigurations)
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
        Me.lblFoundDaysMyDays.Location = New System.Drawing.Point(272, 383)
        Me.lblFoundDaysMyDays.Name = "lblFoundDaysMyDays"
        Me.lblFoundDaysMyDays.Size = New System.Drawing.Size(98, 14)
        Me.lblFoundDaysMyDays.TabIndex = 1
        Me.lblFoundDaysMyDays.Text = "Days found: 0"
        Me.lblFoundDaysMyDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvMyDays
        '
        Me.dgvMyDays.AllowUserToAddRows = False
        Me.dgvMyDays.AllowUserToDeleteRows = False
        Me.dgvMyDays.AllowUserToResizeColumns = False
        Me.dgvMyDays.AllowUserToResizeRows = False
        Me.dgvMyDays.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMyDays.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMyDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMyDays.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.code, Me.data, Me.content})
        Me.dgvMyDays.Location = New System.Drawing.Point(18, 8)
        Me.dgvMyDays.MultiSelect = False
        Me.dgvMyDays.Name = "dgvMyDays"
        Me.dgvMyDays.ReadOnly = True
        Me.dgvMyDays.RowHeadersVisible = False
        Me.dgvMyDays.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvMyDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyDays.Size = New System.Drawing.Size(352, 372)
        Me.dgvMyDays.TabIndex = 0
        Me.dgvMyDays.TabStop = False
        '
        'code
        '
        Me.code.FillWeight = 50.0!
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Width = 50
        '
        'data
        '
        Me.data.HeaderText = "Date"
        Me.data.Name = "data"
        Me.data.ReadOnly = True
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
        Me.btnRecordNewDay.Location = New System.Drawing.Point(16, 371)
        Me.btnRecordNewDay.Name = "btnRecordNewDay"
        Me.btnRecordNewDay.Size = New System.Drawing.Size(356, 23)
        Me.btnRecordNewDay.TabIndex = 4
        Me.btnRecordNewDay.Text = "Record"
        Me.btnRecordNewDay.UseVisualStyleBackColor = True
        '
        'lblContentNewDay
        '
        Me.lblContentNewDay.AutoSize = True
        Me.lblContentNewDay.Location = New System.Drawing.Point(13, 72)
        Me.lblContentNewDay.Name = "lblContentNewDay"
        Me.lblContentNewDay.Size = New System.Drawing.Size(63, 14)
        Me.lblContentNewDay.TabIndex = 3
        Me.lblContentNewDay.Text = "Content:"
        '
        'txtContentNewDay
        '
        Me.txtContentNewDay.Location = New System.Drawing.Point(16, 89)
        Me.txtContentNewDay.Multiline = True
        Me.txtContentNewDay.Name = "txtContentNewDay"
        Me.txtContentNewDay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContentNewDay.Size = New System.Drawing.Size(356, 276)
        Me.txtContentNewDay.TabIndex = 2
        '
        'dtpDayNewDay
        '
        Me.dtpDayNewDay.CustomFormat = ""
        Me.dtpDayNewDay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDayNewDay.Location = New System.Drawing.Point(16, 27)
        Me.dtpDayNewDay.Name = "dtpDayNewDay"
        Me.dtpDayNewDay.Size = New System.Drawing.Size(118, 22)
        Me.dtpDayNewDay.TabIndex = 1
        Me.dtpDayNewDay.TabStop = False
        '
        'lblDayNewDay
        '
        Me.lblDayNewDay.AutoSize = True
        Me.lblDayNewDay.Location = New System.Drawing.Point(13, 10)
        Me.lblDayNewDay.Name = "lblDayNewDay"
        Me.lblDayNewDay.Size = New System.Drawing.Size(35, 14)
        Me.lblDayNewDay.TabIndex = 0
        Me.lblDayNewDay.Text = "Day:"
        '
        'tabConfigurations
        '
        Me.tabConfigurations.Controls.Add(Me.TabControl1)
        Me.tabConfigurations.Location = New System.Drawing.Point(124, 4)
        Me.tabConfigurations.Name = "tabConfigurations"
        Me.tabConfigurations.Size = New System.Drawing.Size(388, 402)
        Me.tabConfigurations.TabIndex = 3
        Me.tabConfigurations.Text = "Configurations"
        Me.tabConfigurations.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabBackground)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(388, 402)
        Me.TabControl1.TabIndex = 6
        '
        'tabBackground
        '
        Me.tabBackground.Controls.Add(Me.dgvConfigurationListImages)
        Me.tabBackground.Controls.Add(Me.GroupBox1)
        Me.tabBackground.Controls.Add(Me.Label1)
        Me.tabBackground.Location = New System.Drawing.Point(4, 23)
        Me.tabBackground.Name = "tabBackground"
        Me.tabBackground.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBackground.Size = New System.Drawing.Size(380, 375)
        Me.tabBackground.TabIndex = 0
        Me.tabBackground.Text = "Background"
        Me.tabBackground.UseVisualStyleBackColor = True
        '
        'dgvConfigurationListImages
        '
        Me.dgvConfigurationListImages.AllowUserToAddRows = False
        Me.dgvConfigurationListImages.AllowUserToDeleteRows = False
        Me.dgvConfigurationListImages.AllowUserToResizeColumns = False
        Me.dgvConfigurationListImages.AllowUserToResizeRows = False
        Me.dgvConfigurationListImages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConfigurationListImages.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvConfigurationListImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConfigurationListImages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.imageName})
        Me.dgvConfigurationListImages.Location = New System.Drawing.Point(9, 26)
        Me.dgvConfigurationListImages.MultiSelect = False
        Me.dgvConfigurationListImages.Name = "dgvConfigurationListImages"
        Me.dgvConfigurationListImages.ReadOnly = True
        Me.dgvConfigurationListImages.RowHeadersVisible = False
        Me.dgvConfigurationListImages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvConfigurationListImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConfigurationListImages.Size = New System.Drawing.Size(365, 184)
        Me.dgvConfigurationListImages.TabIndex = 1
        Me.dgvConfigurationListImages.TabStop = False
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.FillWeight = 50.0!
        Me.id.HeaderText = "Code"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'imageName
        '
        Me.imageName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.imageName.DataPropertyName = "imageName"
        Me.imageName.HeaderText = "Name"
        Me.imageName.Name = "imageName"
        Me.imageName.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConfigurationSaveInBank)
        Me.GroupBox1.Controls.Add(Me.btnConfigurationSetCurrent)
        Me.GroupBox1.Controls.Add(Me.picBoxConfiguration)
        Me.GroupBox1.Controls.Add(Me.btnConfigurationsDeleteSelected)
        Me.GroupBox1.Controls.Add(Me.btnConfigurationsNewOne)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 216)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 153)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image info:"
        '
        'btnConfigurationSaveInBank
        '
        Me.btnConfigurationSaveInBank.Location = New System.Drawing.Point(6, 50)
        Me.btnConfigurationSaveInBank.Name = "btnConfigurationSaveInBank"
        Me.btnConfigurationSaveInBank.Size = New System.Drawing.Size(207, 30)
        Me.btnConfigurationSaveInBank.TabIndex = 6
        Me.btnConfigurationSaveInBank.TabStop = False
        Me.btnConfigurationSaveInBank.Text = "Save in list"
        Me.btnConfigurationSaveInBank.UseVisualStyleBackColor = True
        '
        'btnConfigurationSetCurrent
        '
        Me.btnConfigurationSetCurrent.Location = New System.Drawing.Point(6, 112)
        Me.btnConfigurationSetCurrent.Name = "btnConfigurationSetCurrent"
        Me.btnConfigurationSetCurrent.Size = New System.Drawing.Size(207, 30)
        Me.btnConfigurationSetCurrent.TabIndex = 5
        Me.btnConfigurationSetCurrent.TabStop = False
        Me.btnConfigurationSetCurrent.Text = "Set current"
        Me.btnConfigurationSetCurrent.UseVisualStyleBackColor = True
        '
        'picBoxConfiguration
        '
        Me.picBoxConfiguration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBoxConfiguration.Location = New System.Drawing.Point(219, 21)
        Me.picBoxConfiguration.Name = "picBoxConfiguration"
        Me.picBoxConfiguration.Size = New System.Drawing.Size(140, 120)
        Me.picBoxConfiguration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBoxConfiguration.TabIndex = 0
        Me.picBoxConfiguration.TabStop = False
        '
        'btnConfigurationsDeleteSelected
        '
        Me.btnConfigurationsDeleteSelected.Location = New System.Drawing.Point(6, 81)
        Me.btnConfigurationsDeleteSelected.Name = "btnConfigurationsDeleteSelected"
        Me.btnConfigurationsDeleteSelected.Size = New System.Drawing.Size(207, 30)
        Me.btnConfigurationsDeleteSelected.TabIndex = 4
        Me.btnConfigurationsDeleteSelected.TabStop = False
        Me.btnConfigurationsDeleteSelected.Text = "Delete selected"
        Me.btnConfigurationsDeleteSelected.UseVisualStyleBackColor = True
        '
        'btnConfigurationsNewOne
        '
        Me.btnConfigurationsNewOne.Location = New System.Drawing.Point(6, 19)
        Me.btnConfigurationsNewOne.Name = "btnConfigurationsNewOne"
        Me.btnConfigurationsNewOne.Size = New System.Drawing.Size(207, 30)
        Me.btnConfigurationsNewOne.TabIndex = 3
        Me.btnConfigurationsNewOne.TabStop = False
        Me.btnConfigurationsNewOne.Text = "New one"
        Me.btnConfigurationsNewOne.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "List of images:"
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
        Me.tabConfigurations.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabBackground.ResumeLayout(False)
        Me.tabBackground.PerformLayout()
        CType(Me.dgvConfigurationListImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picBoxConfiguration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControlClass
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabMyDays As TabPage
    Friend WithEvents tabNewDay As TabPage
    Friend WithEvents dgvMyDays As System.Windows.Forms.DataGridView
    Friend WithEvents lblFoundDaysMyDays As System.Windows.Forms.Label
    Friend WithEvents lblDayNewDay As System.Windows.Forms.Label
    Friend WithEvents dtpDayNewDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContentNewDay As System.Windows.Forms.TextBox
    Friend WithEvents lblContentNewDay As System.Windows.Forms.Label
    Friend WithEvents btnRecordNewDay As System.Windows.Forms.Button
    Friend WithEvents code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents content As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabConfigurations As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvConfigurationListImages As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents picBoxConfiguration As System.Windows.Forms.PictureBox
    Friend WithEvents btnConfigurationsNewOne As System.Windows.Forms.Button
    Friend WithEvents btnConfigurationsDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents btnConfigurationSetCurrent As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabBackground As System.Windows.Forms.TabPage
    Friend WithEvents btnConfigurationSaveInBank As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imageName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
