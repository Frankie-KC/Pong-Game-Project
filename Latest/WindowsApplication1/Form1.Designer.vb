<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Gamewindow = New System.Windows.Forms.PictureBox()
        Me.PlayBT = New System.Windows.Forms.Button()
        Me.Timer_clock = New System.Windows.Forms.Timer(Me.components)
        Me.HowToPlayBT = New System.Windows.Forms.Button()
        Me.DifficultyOptions = New System.Windows.Forms.ComboBox()
        Me.DifficultyLB = New System.Windows.Forms.Label()
        Me.SpongIMG = New System.Windows.Forms.PictureBox()
        Me.poweron = New System.Windows.Forms.CheckBox()
        CType(Me.Gamewindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpongIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gamewindow
        '
        Me.Gamewindow.BackColor = System.Drawing.Color.Gray
        Me.Gamewindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gamewindow.Location = New System.Drawing.Point(0, 0)
        Me.Gamewindow.Name = "Gamewindow"
        Me.Gamewindow.Size = New System.Drawing.Size(584, 561)
        Me.Gamewindow.TabIndex = 0
        Me.Gamewindow.TabStop = False
        '
        'PlayBT
        '
        Me.PlayBT.Cursor = System.Windows.Forms.Cursors.Default
        Me.PlayBT.FlatAppearance.BorderSize = 0
        Me.PlayBT.Location = New System.Drawing.Point(257, 280)
        Me.PlayBT.Name = "PlayBT"
        Me.PlayBT.Size = New System.Drawing.Size(75, 23)
        Me.PlayBT.TabIndex = 1
        Me.PlayBT.Text = "Start!"
        Me.PlayBT.UseVisualStyleBackColor = True
        '
        'Timer_clock
        '
        Me.Timer_clock.Interval = 10
        '
        'HowToPlayBT
        '
        Me.HowToPlayBT.Cursor = System.Windows.Forms.Cursors.Default
        Me.HowToPlayBT.FlatAppearance.BorderSize = 0
        Me.HowToPlayBT.Location = New System.Drawing.Point(257, 309)
        Me.HowToPlayBT.Name = "HowToPlayBT"
        Me.HowToPlayBT.Size = New System.Drawing.Size(75, 23)
        Me.HowToPlayBT.TabIndex = 2
        Me.HowToPlayBT.Text = "How to play"
        Me.HowToPlayBT.UseVisualStyleBackColor = True
        '
        'DifficultyOptions
        '
        Me.DifficultyOptions.FormattingEnabled = True
        Me.DifficultyOptions.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.DifficultyOptions.Location = New System.Drawing.Point(239, 230)
        Me.DifficultyOptions.Name = "DifficultyOptions"
        Me.DifficultyOptions.Size = New System.Drawing.Size(121, 21)
        Me.DifficultyOptions.TabIndex = 4
        Me.DifficultyOptions.Text = "1"
        '
        'DifficultyLB
        '
        Me.DifficultyLB.AutoSize = True
        Me.DifficultyLB.BackColor = System.Drawing.Color.Gray
        Me.DifficultyLB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DifficultyLB.Location = New System.Drawing.Point(190, 233)
        Me.DifficultyLB.Name = "DifficultyLB"
        Me.DifficultyLB.Size = New System.Drawing.Size(50, 13)
        Me.DifficultyLB.TabIndex = 5
        Me.DifficultyLB.Text = "Difficulty:"
        '
        'SpongIMG
        '
        Me.SpongIMG.BackColor = System.Drawing.Color.Gray
        Me.SpongIMG.Image = CType(resources.GetObject("SpongIMG.Image"), System.Drawing.Image)
        Me.SpongIMG.Location = New System.Drawing.Point(226, 166)
        Me.SpongIMG.Name = "SpongIMG"
        Me.SpongIMG.Size = New System.Drawing.Size(152, 49)
        Me.SpongIMG.TabIndex = 6
        Me.SpongIMG.TabStop = False
        '
        'poweron
        '
        Me.poweron.AutoSize = True
        Me.poweron.BackColor = System.Drawing.Color.Gray
        Me.poweron.Checked = True
        Me.poweron.CheckState = System.Windows.Forms.CheckState.Checked
        Me.poweron.Location = New System.Drawing.Point(259, 257)
        Me.poweron.Name = "poweron"
        Me.poweron.Size = New System.Drawing.Size(73, 17)
        Me.poweron.TabIndex = 7
        Me.poweron.Text = "Powerups"
        Me.poweron.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 561)
        Me.Controls.Add(Me.poweron)
        Me.Controls.Add(Me.SpongIMG)
        Me.Controls.Add(Me.DifficultyLB)
        Me.Controls.Add(Me.DifficultyOptions)
        Me.Controls.Add(Me.HowToPlayBT)
        Me.Controls.Add(Me.PlayBT)
        Me.Controls.Add(Me.Gamewindow)
        Me.MinimumSize = New System.Drawing.Size(250, 250)
        Me.Name = "Form1"
        Me.Text = "Bing-Bong"
        CType(Me.Gamewindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpongIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Gamewindow As PictureBox
    Friend WithEvents PlayBT As Button
    Friend WithEvents Timer_clock As Timer
    Friend WithEvents HowToPlayBT As Button
    Friend WithEvents DifficultyOptions As ComboBox
    Friend WithEvents DifficultyLB As Label
    Friend WithEvents SpongIMG As PictureBox
    Friend WithEvents poweron As CheckBox
End Class
