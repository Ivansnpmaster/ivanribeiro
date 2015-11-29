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
        Me.tabNewDay = New System.Windows.Forms.TabPage()
        Me.tabControl.SuspendLayout()
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
        Me.tabControl.Size = New System.Drawing.Size(511, 410)
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
        Me.tabMain.Size = New System.Drawing.Size(383, 402)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'tabMyDays
        '
        Me.tabMyDays.BackColor = System.Drawing.Color.White
        Me.tabMyDays.Location = New System.Drawing.Point(124, 4)
        Me.tabMyDays.Name = "tabMyDays"
        Me.tabMyDays.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMyDays.Size = New System.Drawing.Size(383, 402)
        Me.tabMyDays.TabIndex = 1
        Me.tabMyDays.Text = "My days"
        '
        'tabNewDay
        '
        Me.tabNewDay.BackColor = System.Drawing.Color.White
        Me.tabNewDay.Location = New System.Drawing.Point(124, 4)
        Me.tabNewDay.Name = "tabNewDay"
        Me.tabNewDay.Size = New System.Drawing.Size(383, 402)
        Me.tabNewDay.TabIndex = 2
        Me.tabNewDay.Text = "New day"
        '
        'Diary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 410)
        Me.Controls.Add(Me.tabControl)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Diary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diary"
        Me.tabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControlClass
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabMyDays As TabPage
    Friend WithEvents tabNewDay As TabPage
End Class
