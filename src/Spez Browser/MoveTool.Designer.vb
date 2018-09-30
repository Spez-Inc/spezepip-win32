<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoveTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoveTool))
        Me.S1 = New System.Windows.Forms.Panel()
        Me.S2 = New System.Windows.Forms.Panel()
        Me.S3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.D1 = New System.Windows.Forms.Label()
        Me.T1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Next_button = New System.Windows.Forms.Button()
        Me.Back_button = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.S1.SuspendLayout()
        Me.S2.SuspendLayout()
        Me.S3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'S1
        '
        Me.S1.Controls.Add(Me.S2)
        Me.S1.Controls.Add(Me.Label1)
        Me.S1.Controls.Add(Me.PictureBox1)
        Me.S1.Controls.Add(Me.RadioButton2)
        Me.S1.Controls.Add(Me.RadioButton1)
        Me.S1.Controls.Add(Me.D1)
        Me.S1.Controls.Add(Me.T1)
        Me.S1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.S1.Location = New System.Drawing.Point(0, 0)
        Me.S1.Name = "S1"
        Me.S1.Size = New System.Drawing.Size(624, 441)
        Me.S1.TabIndex = 0
        '
        'S2
        '
        Me.S2.Controls.Add(Me.S3)
        Me.S2.Controls.Add(Me.Label3)
        Me.S2.Controls.Add(Me.Label2)
        Me.S2.Controls.Add(Me.Label4)
        Me.S2.Controls.Add(Me.Button1)
        Me.S2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.S2.Location = New System.Drawing.Point(0, 0)
        Me.S2.Name = "S2"
        Me.S2.Size = New System.Drawing.Size(624, 441)
        Me.S2.TabIndex = 6
        Me.S2.Visible = False
        '
        'S3
        '
        Me.S3.Controls.Add(Me.RichTextBox1)
        Me.S3.Controls.Add(Me.WebBrowser1)
        Me.S3.Controls.Add(Me.Label5)
        Me.S3.Controls.Add(Me.ProgressBar1)
        Me.S3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.S3.Location = New System.Drawing.Point(0, 0)
        Me.S3.Name = "S3"
        Me.S3.Size = New System.Drawing.Size(624, 441)
        Me.S3.TabIndex = 8
        Me.S3.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 26)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Importing..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 355)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(614, 19)
        Me.ProgressBar1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(24, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(368, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Click the 'Select' button and select bookmark file. Then Click 'Import' button. "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Select the bookmark file"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(600, 80)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "File: not selected"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(275, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(213, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(399, 255)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(29, 89)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(178, 285)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(309, 89)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(82, 17)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.Text = "From Firefox"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(216, 89)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton1.Size = New System.Drawing.Size(87, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "From Chrome"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'D1
        '
        Me.D1.AutoSize = True
        Me.D1.ForeColor = System.Drawing.Color.Gray
        Me.D1.Location = New System.Drawing.Point(24, 64)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(483, 13)
        Me.D1.TabIndex = 1
        Me.D1.Text = "This tool copies bookmarks from your old browser. Select your old browser and fol" & _
    "low the instructions."
        '
        'T1
        '
        Me.T1.AutoSize = True
        Me.T1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.T1.Location = New System.Drawing.Point(24, 24)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(348, 26)
        Me.T1.TabIndex = 1
        Me.T1.Text = "Welcome to Bookmark Import Tool"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 380)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(624, 61)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Next_button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Back_button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(461, 396)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(151, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Next_button
        '
        Me.Next_button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Next_button.Location = New System.Drawing.Point(78, 3)
        Me.Next_button.Name = "Next_button"
        Me.Next_button.Size = New System.Drawing.Size(70, 27)
        Me.Next_button.TabIndex = 1
        Me.Next_button.Text = "Next >"
        Me.Next_button.UseVisualStyleBackColor = True
        '
        'Back_button
        '
        Me.Back_button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Back_button.Enabled = False
        Me.Back_button.Location = New System.Drawing.Point(3, 3)
        Me.Back_button.Name = "Back_button"
        Me.Back_button.Size = New System.Drawing.Size(69, 27)
        Me.Back_button.TabIndex = 0
        Me.Back_button.Text = "< Back"
        Me.Back_button.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "HTML Bookmark File|*.html|All files|*.*"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(27, 64)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(573, 267)
        Me.RichTextBox1.TabIndex = 13
        Me.RichTextBox1.Text = ""
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(371, 12)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(250, 42)
        Me.WebBrowser1.TabIndex = 12
        Me.WebBrowser1.Visible = False
        '
        'MoveTool
        '
        Me.AcceptButton = Me.Next_button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.S1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MoveTool"
        Me.Text = "Bookmark Import..."
        Me.S1.ResumeLayout(False)
        Me.S1.PerformLayout()
        Me.S2.ResumeLayout(False)
        Me.S2.PerformLayout()
        Me.S3.ResumeLayout(False)
        Me.S3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents S1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents D1 As System.Windows.Forms.Label
    Friend WithEvents T1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Next_button As System.Windows.Forms.Button
    Friend WithEvents Back_button As System.Windows.Forms.Button
    Friend WithEvents S2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents S3 As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
End Class
