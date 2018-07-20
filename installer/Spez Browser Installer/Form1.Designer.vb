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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Close_Button = New System.Windows.Forms.Button()
        Me.Minimaze_Button = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(392, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "The only web browser that built for everyone."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(106, 362)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Spez Browser"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(141, 225)
        Me.ProgressBar1.MarqueeAnimationSpeed = 1
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(409, 3)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(141, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(409, 46)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Downloading"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Spez_Browser_Setup.My.Resources.Resources.spezbrowsericon
        Me.PictureBox1.Location = New System.Drawing.Point(50, 351)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(194, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(299, 38)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Getting required files..."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 1
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Spez_Browser_Setup.My.Resources.Resources.button
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(312, 288)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Try again"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Close_Button
        '
        Me.Close_Button.BackColor = System.Drawing.Color.Transparent
        Me.Close_Button.BackgroundImage = Global.Spez_Browser_Setup.My.Resources.Resources.close
        Me.Close_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Close_Button.FlatAppearance.BorderSize = 0
        Me.Close_Button.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_Button.Location = New System.Drawing.Point(12, 12)
        Me.Close_Button.Name = "Close_Button"
        Me.Close_Button.Size = New System.Drawing.Size(20, 20)
        Me.Close_Button.TabIndex = 9
        Me.Close_Button.UseVisualStyleBackColor = False
        '
        'Minimaze_Button
        '
        Me.Minimaze_Button.BackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.BackgroundImage = Global.Spez_Browser_Setup.My.Resources.Resources.minimize
        Me.Minimaze_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Minimaze_Button.FlatAppearance.BorderSize = 0
        Me.Minimaze_Button.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Minimaze_Button.Location = New System.Drawing.Point(38, 12)
        Me.Minimaze_Button.Name = "Minimaze_Button"
        Me.Minimaze_Button.Size = New System.Drawing.Size(20, 20)
        Me.Minimaze_Button.TabIndex = 8
        Me.Minimaze_Button.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Spez_Browser_Setup.My.Resources.Resources.bg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(686, 447)
        Me.Controls.Add(Me.Close_Button)
        Me.Controls.Add(Me.Minimaze_Button)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(686, 447)
        Me.MinimumSize = New System.Drawing.Size(686, 447)
        Me.Name = "Form1"
        Me.Text = "Spez Browser Installer"
        Me.TransparencyKey = System.Drawing.Color.Red
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Close_Button As System.Windows.Forms.Button
    Friend WithEvents Minimaze_Button As System.Windows.Forms.Button

End Class
