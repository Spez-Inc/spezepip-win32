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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SettingsStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Link = New System.Windows.Forms.Label()
        Me.DocTitle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewTabToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewPrivateBrowsingWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitPrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HTMLEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddThisWebsiteToBookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowBookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutSpezBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LeftR = New System.Windows.Forms.Panel()
        Me.UpR = New System.Windows.Forms.Panel()
        Me.RightR = New System.Windows.Forms.Panel()
        Me.DownR = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloseTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabRightClick.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.goback
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(110, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 30)
        Me.Button1.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button1, "Back")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.goforward
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(158, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 30)
        Me.Button2.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button2, "Forward")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.refresh
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(206, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 30)
        Me.Button3.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button3, "Refresh")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(291, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(449, 29)
        Me.TextBox1.TabIndex = 1
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.new_tab
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(252, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(30, 30)
        Me.Button6.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button6, "New Tab")
        Me.Button6.UseVisualStyleBackColor = True
        '
        'SettingsStripMenuItem1
        '
        Me.SettingsStripMenuItem1.Name = "SettingsStripMenuItem1"
        Me.SettingsStripMenuItem1.Size = New System.Drawing.Size(302, 22)
        Me.SettingsStripMenuItem1.Text = "Settings"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 60)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Link)
        Me.Panel2.Controls.Add(Me.DocTitle)
        Me.Panel2.Location = New System.Drawing.Point(291, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(449, 29)
        Me.Panel2.TabIndex = 3
        '
        'Link
        '
        Me.Link.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Link.Font = New System.Drawing.Font("Calibri", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Link.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Link.Location = New System.Drawing.Point(0, 15)
        Me.Link.Name = "Link"
        Me.Link.Size = New System.Drawing.Size(449, 14)
        Me.Link.TabIndex = 1
        Me.Link.Text = "Link/URL Appears Here."
        Me.Link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DocTitle
        '
        Me.DocTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.DocTitle.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.DocTitle.Location = New System.Drawing.Point(0, 0)
        Me.DocTitle.Name = "DocTitle"
        Me.DocTitle.Size = New System.Drawing.Size(449, 15)
        Me.DocTitle.TabIndex = 0
        Me.DocTitle.Text = "Document Title Appears Here."
        Me.DocTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PictureBox1.Location = New System.Drawing.Point(99, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1, 28)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.FullScreen
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(64, 20)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(20, 20)
        Me.Button7.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button7, "Maximise")
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.close
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(12, 21)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(20, 20)
        Me.Button4.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button4, "Close")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.menu_icon
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button5.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(754, 14)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(30, 30)
        Me.Button5.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button5, "Menu")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewTabToolStripMenuItem1, Me.NewWindowToolStripMenuItem, Me.NewPrivateBrowsingWindowToolStripMenuItem, Me.ToolStripSeparator4, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.ExitPrintPreviewToolStripMenuItem, Me.SavePageToolStripMenuItem, Me.HTMLEditorToolStripMenuItem, Me.ToolStripSeparator2, Me.HistoryToolStripMenuItem, Me.BookmarksToolStripMenuItem, Me.ToolStripSeparator3, Me.SettingsStripMenuItem1, Me.AboutSpezBrowserToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(303, 314)
        '
        'NewTabToolStripMenuItem1
        '
        Me.NewTabToolStripMenuItem1.Name = "NewTabToolStripMenuItem1"
        Me.NewTabToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.NewTabToolStripMenuItem1.Size = New System.Drawing.Size(302, 22)
        Me.NewTabToolStripMenuItem1.Text = "New Tab"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.NewWindowToolStripMenuItem.Text = "New Window"
        '
        'NewPrivateBrowsingWindowToolStripMenuItem
        '
        Me.NewPrivateBrowsingWindowToolStripMenuItem.Name = "NewPrivateBrowsingWindowToolStripMenuItem"
        Me.NewPrivateBrowsingWindowToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewPrivateBrowsingWindowToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.NewPrivateBrowsingWindowToolStripMenuItem.Text = "New Private Browsing Window"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(299, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Preview"
        '
        'ExitPrintPreviewToolStripMenuItem
        '
        Me.ExitPrintPreviewToolStripMenuItem.Enabled = False
        Me.ExitPrintPreviewToolStripMenuItem.Name = "ExitPrintPreviewToolStripMenuItem"
        Me.ExitPrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ExitPrintPreviewToolStripMenuItem.Text = "Exit Print Preview"
        Me.ExitPrintPreviewToolStripMenuItem.Visible = False
        '
        'SavePageToolStripMenuItem
        '
        Me.SavePageToolStripMenuItem.Name = "SavePageToolStripMenuItem"
        Me.SavePageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SavePageToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.SavePageToolStripMenuItem.Text = "Save Page"
        '
        'HTMLEditorToolStripMenuItem
        '
        Me.HTMLEditorToolStripMenuItem.Name = "HTMLEditorToolStripMenuItem"
        Me.HTMLEditorToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.HTMLEditorToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.HTMLEditorToolStripMenuItem.Text = "HTML Editor"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(299, 6)
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'BookmarksToolStripMenuItem
        '
        Me.BookmarksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddThisWebsiteToBookmarksToolStripMenuItem, Me.ShowBookmarksToolStripMenuItem})
        Me.BookmarksToolStripMenuItem.Name = "BookmarksToolStripMenuItem"
        Me.BookmarksToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BookmarksToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.BookmarksToolStripMenuItem.Text = "Bookmarks"
        '
        'AddThisWebsiteToBookmarksToolStripMenuItem
        '
        Me.AddThisWebsiteToBookmarksToolStripMenuItem.Name = "AddThisWebsiteToBookmarksToolStripMenuItem"
        Me.AddThisWebsiteToBookmarksToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Add This Website To Bookmarks"
        '
        'ShowBookmarksToolStripMenuItem
        '
        Me.ShowBookmarksToolStripMenuItem.Name = "ShowBookmarksToolStripMenuItem"
        Me.ShowBookmarksToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ShowBookmarksToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.ShowBookmarksToolStripMenuItem.Text = "Show Bookmarks"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(299, 6)
        '
        'AboutSpezBrowserToolStripMenuItem
        '
        Me.AboutSpezBrowserToolStripMenuItem.Name = "AboutSpezBrowserToolStripMenuItem"
        Me.AboutSpezBrowserToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.AboutSpezBrowserToolStripMenuItem.Text = "About Spez Browser"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(299, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Button8
        '
        Me.Button8.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.minimize
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(38, 21)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(20, 20)
        Me.Button8.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.Button8, "Minimize")
        Me.Button8.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(94, 115)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(250, 250)
        Me.WebBrowser1.TabIndex = 5
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(2, 62)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(796, 3)
        Me.ProgressBar1.TabIndex = 6
        '
        'LeftR
        '
        Me.LeftR.BackColor = System.Drawing.Color.Transparent
        Me.LeftR.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.LeftR.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftR.Location = New System.Drawing.Point(0, 2)
        Me.LeftR.Name = "LeftR"
        Me.LeftR.Size = New System.Drawing.Size(2, 596)
        Me.LeftR.TabIndex = 7
        '
        'UpR
        '
        Me.UpR.BackColor = System.Drawing.Color.Transparent
        Me.UpR.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.UpR.Dock = System.Windows.Forms.DockStyle.Top
        Me.UpR.Location = New System.Drawing.Point(0, 0)
        Me.UpR.Name = "UpR"
        Me.UpR.Size = New System.Drawing.Size(798, 2)
        Me.UpR.TabIndex = 8
        '
        'RightR
        '
        Me.RightR.BackColor = System.Drawing.Color.Transparent
        Me.RightR.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.RightR.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightR.Location = New System.Drawing.Point(798, 0)
        Me.RightR.Name = "RightR"
        Me.RightR.Size = New System.Drawing.Size(2, 598)
        Me.RightR.TabIndex = 9
        '
        'DownR
        '
        Me.DownR.BackColor = System.Drawing.Color.Transparent
        Me.DownR.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.DownR.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DownR.Location = New System.Drawing.Point(0, 598)
        Me.DownR.Name = "DownR"
        Me.DownR.Size = New System.Drawing.Size(800, 2)
        Me.DownR.TabIndex = 10
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'TabControl1
        '
        Me.TabControl1.ContextMenuStrip = Me.TabRightClick
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(2, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(796, 533)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 11
        '
        'TabRightClick
        '
        Me.TabRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseTabToolStripMenuItem})
        Me.TabRightClick.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.TabRightClick.Name = "RightClickForCloseTab"
        Me.TabRightClick.Size = New System.Drawing.Size(171, 26)
        '
        'CloseTabToolStripMenuItem
        '
        Me.CloseTabToolStripMenuItem.Name = "CloseTabToolStripMenuItem"
        Me.CloseTabToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseTabToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.CloseTabToolStripMenuItem.Text = "Close Tab"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.Spez_Browser.My.Resources.Resources.backgroundbrowser
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.LeftR)
        Me.Controls.Add(Me.UpR)
        Me.Controls.Add(Me.RightR)
        Me.Controls.Add(Me.DownR)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "Form1"
        Me.Text = "Spez Browser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabRightClick.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LeftR As System.Windows.Forms.Panel
    Friend WithEvents UpR As System.Windows.Forms.Panel
    Friend WithEvents RightR As System.Windows.Forms.Panel
    Friend WithEvents DownR As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Link As System.Windows.Forms.Label
    Friend WithEvents DocTitle As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SavePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HTMLEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddThisWebsiteToBookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowBookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CloseTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutSpezBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents NewTabToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewPrivateBrowsingWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitPrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer

End Class
