<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeScreen))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Close_Button = New System.Windows.Forms.Button()
        Me.Minimaze_Button = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_next_001 = New System.Windows.Forms.Button()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Close_Button)
        Me.Panel1.Controls.Add(Me.Minimaze_Button)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 48)
        Me.Panel1.TabIndex = 6
        '
        'Close_Button
        '
        Me.Close_Button.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.close
        Me.Close_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Close_Button.FlatAppearance.BorderSize = 0
        Me.Close_Button.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_Button.Location = New System.Drawing.Point(12, 14)
        Me.Close_Button.Name = "Close_Button"
        Me.Close_Button.Size = New System.Drawing.Size(20, 20)
        Me.Close_Button.TabIndex = 0
        Me.Close_Button.UseVisualStyleBackColor = True
        '
        'Minimaze_Button
        '
        Me.Minimaze_Button.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.minimize
        Me.Minimaze_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Minimaze_Button.FlatAppearance.BorderSize = 0
        Me.Minimaze_Button.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Minimaze_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Minimaze_Button.Location = New System.Drawing.Point(38, 14)
        Me.Minimaze_Button.Name = "Minimaze_Button"
        Me.Minimaze_Button.Size = New System.Drawing.Size(20, 20)
        Me.Minimaze_Button.TabIndex = 0
        Me.Minimaze_Button.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.button
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(370, 343)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 26)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "English"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.button
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(370, 375)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(74, 26)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Türkçe"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(776, 143)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select Your Language" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dilinizi Seçin"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 436)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(776, 104)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "(You Can Change Language From ""Settings"" Menu.)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(""Ayarlar"" Menüsünden Dili Değiş" & _
            "tirebilirsiniz.)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.ss1
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(162, 168)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(476, 306)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(162, 490)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(476, 63)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "You Finally Found The Best Quality, Most Professional And Best Text Editor!"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(776, 99)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Welcome Spez Browser!"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label4.Visible = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 1
        '
        'btn_next_001
        '
        Me.btn_next_001.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_next_001.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.button
        Me.btn_next_001.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_next_001.FlatAppearance.BorderSize = 0
        Me.btn_next_001.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_next_001.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_next_001.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_next_001.Location = New System.Drawing.Point(374, 567)
        Me.btn_next_001.Name = "btn_next_001"
        Me.btn_next_001.Size = New System.Drawing.Size(52, 26)
        Me.btn_next_001.TabIndex = 13
        Me.btn_next_001.Text = "Next"
        Me.btn_next_001.UseVisualStyleBackColor = True
        Me.btn_next_001.Visible = False
        '
        'Timer4
        '
        Me.Timer4.Interval = 1
        '
        'Timer5
        '
        Me.Timer5.Interval = 1
        '
        'WelcomeScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.blur
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 640)
        Me.Controls.Add(Me.btn_next_001)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WelcomeScreen"
        Me.Text = "Spez Bijiben"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Close_Button As System.Windows.Forms.Button
    Friend WithEvents Minimaze_Button As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents btn_next_001 As System.Windows.Forms.Button
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents Timer5 As System.Windows.Forms.Timer
End Class
