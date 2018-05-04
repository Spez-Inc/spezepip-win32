Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports Gecko
Imports Gecko.DOM


Public Class PrivateForm1
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Const WM_NCHITTEST As Integer = 132
    Private Const HTCLIENT As Integer = 1
    Private Const HTCAPTION As Integer = 2
    Private m_aeroEnabled As Boolean
    Private Const CS_DROPSHADOW As Integer = 131072
    Private Const WM_NCPAINT As Integer = 133
    Private Const WM_ACTIVATEAPP As Integer = 28

    <System.Runtime.InteropServices.DllImport("dwmapi.dll")>
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As MARGINS) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("dwmapi.dll")>
    Public Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As Integer, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("dwmapi.dll")>
    Public Shared Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr
    End Function

    Public Structure MARGINS

        Public leftWidth As Integer

        Public rightWidth As Integer

        Public topHeight As Integer

        Public bottomHeight As Integer
    End Structure

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            m_aeroEnabled = CheckAeroEnabled()
            Dim cp As CreateParams = MyBase.CreateParams
            If Not m_aeroEnabled Then cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Function CheckAeroEnabled() As Boolean
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim enabled As Integer = 0
            DwmIsCompositionEnabled(enabled)
            Return If((enabled = 1), True, False)
        End If

        Return False
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_NCPAINT
                If m_aeroEnabled Then
                    Dim v = 2
                    DwmSetWindowAttribute(Me.Handle, 2, v, 4)
                    Dim margins As MARGINS = New MARGINS() With {.bottomHeight = 1, .leftWidth = 0, .rightWidth = 0, .topHeight = 0}
                    DwmExtendFrameIntoClientArea(Me.Handle, margins)
                End If

            Case Else
        End Select

        MyBase.WndProc(m)
        If m.Msg = WM_NCHITTEST AndAlso CInt(m.Result) = HTCLIENT Then m.Result = CType(HTCAPTION, IntPtr)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim NewBrowser As New GeckoWebBrowser()
        Dim NewTab As New TabPage
        NewBrowser.Tag = NewTab
        NewTab.Tag = NewBrowser
        TabControl1.TabPages.Add(NewTab)
        NewTab.Controls.Add(NewBrowser)
        NewBrowser.Dock = DockStyle.Fill
        'NewBrowser.Navigate(Application.StartupPath & "/data/New Tab - Home.html")
        TabControl1.SelectedTab = NewTab
        AddHandler NewBrowser.ProgressChanged, AddressOf LoadingWeb
        AddHandler NewBrowser.DocumentCompleted, AddressOf Done
        AddHandler Gecko.LauncherDialog.Download, AddressOf LauncherDialog_Download
        NewBrowser.Navigate("file:///" & Application.StartupPath & "/data/htmldoc/private-mode.html")
    End Sub
    Private Sub LoadingWeb(ByVal sender As Object, ByVal e As GeckoProgressEventArgs)
        ProgressBar1.Show()
        ProgressBar1.Width = 10
        ProgressBar1.Maximum = e.MaximumProgress
        ProgressBar1.Value = e.MaximumProgress
    End Sub
    Private Sub Done()
        ProgressBar1.Hide()
        ProgressBar1.Value = 0
        ProgressBar1.Width = 0
        Me.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle & " - Spez Browser"
        DocTitle.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        Link.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString
        TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString
        webIcons()
    End Sub

    Private Sub webIcons()
        Dim web As New WebClient
        Try
            Dim memstream As New MemoryStream(web.DownloadData("http://" & New Uri(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString).Host & "/favicon.ico"))
            Dim icon As New Icon(memstream)
            If ImageList1.Images.Count = -1 Then
                ImageList1.Images.Add(icon.ToBitmap)
                TabControl1.SelectedTab.ImageIndex = 0
            Else
                ImageList1.Images.Clear()
                ImageList1.Images.Add(icon.ToBitmap)
                TabControl1.SelectedTab.ImageIndex = 0
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Info.OSFullName.Contains("Windows XP") Then
            MsgBox("Spez Browser no more supports Windows XP and Vista.", vbCritical, "Sorry for that.")
            End
        End If
        If My.Computer.Info.OSFullName.Contains("Windows Vista") Then
            MsgBox("Spez Browser no more supports Windows XP and Vista.", vbCritical, "Sorry for that.")
            End
        End If
        Xpcom.Initialize("data/engine/")


        Dim field = GetType(GeckoWebBrowser).GetField("WebBrowser")
        If field IsNot Nothing Then
            Dim val = field.GetValue(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser))
            Dim nsIWebBrowser As nsIWebBrowser = DirectCast(val, nsIWebBrowser)
            Xpcom.QueryInterface(Of nsILoadContext)(nsIWebBrowser).SetPrivateBrowsing(True)
        End If

        '-----------------------------------------------------------

            'text
            DocTitle.ForeColor = Color.White

            'form
        BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\dark\bg.png"))
            FormBorderStyle = Nothing

            'buttonmain
        Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\back.png"))
            Button1.Text = ""
            Button1.FlatStyle = FlatStyle.Flat
        Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\next.png"))
            Button2.Text = ""
            Button2.FlatStyle = FlatStyle.Flat
        Button3.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\reload.png"))
            Button3.Text = ""
            Button3.FlatStyle = FlatStyle.Flat
        Button6.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\addtab.png"))
            Button6.Text = ""
            Button6.FlatStyle = FlatStyle.Flat
        Button5.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\menu.png"))
            Button5.Text = ""
            Button5.FlatStyle = FlatStyle.Flat

            'buttoncm
        Button4.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\Close.png"))
        Button7.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\fullscreen.png"))
        Button8.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\minimize.png"))
            Button4.Text = ""
            Button4.FlatStyle = FlatStyle.Flat
            Button7.Text = ""
            Button7.FlatStyle = FlatStyle.Flat
            Button8.Text = ""
            Button8.FlatStyle = FlatStyle.Flat

       
        '-----------------------------------------------------------
        If My.Settings.WelcomeScreen = True Then
            Me.Hide()
            WelcomeScreen.ShowDialog()
        End If
        '-----------------------------------------------------------
        If My.Settings.Lang = "Türkçe" Then
            DocTitle.Text = "Belge Başlığı Burada Görünür."
            Link.Text = "Link/URL Burada Görünür."
            NewTabToolStripMenuItem1.Text = "Yeni Sekme"
            NewWindowToolStripMenuItem.Text = "Yeni Pencere"
            NewPrivateBrowsingWindowToolStripMenuItem.Text = "Yeni Gizli Gezinme Pencresi"
            PrintToolStripMenuItem.Text = "Yazdır"
            PrintPreviewToolStripMenuItem.Text = "Baskı Önizleme"
            ExitPrintPreviewToolStripMenuItem.Text = "Baskı Önizlemesinden Çık"
            SavePageToolStripMenuItem.Text = "Sayfayı kaydet"
            HTMLEditorToolStripMenuItem.Text = "HTML Editör"
            HistoryToolStripMenuItem.Text = "Geçmiş"
            BookmarksToolStripMenuItem.Text = "Yer imleri"
            AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Bu Web Sitesini Yer İmlerine Ekle"
            ShowBookmarksToolStripMenuItem.Text = "Yer İmlerini Göster"
            SettingsStripMenuItem1.Text = "Ayarlar"
            AboutSpezBrowserToolStripMenuItem.Text = "Spez Browser Hakkında"
            ExitToolStripMenuItem.Text = "Çık"
            Library.TabPage1.Text = "Geçmiş"
            Library.TabPage2.Text = "Yer imleri"
            Library.Button1.Text = "Geçmişi Temizle"
            Library.Button2.Text = "Geçmişten Sil"
            Library.Button3.Text = "Web Sayfasına Git"
            Library.Button4.Text = "Web Sayfasına Git"
            Library.Button5.Text = "Yer imlerinden Sil"
            Library.Text = "Kitaplık"
            HTMLEdit.Text = "HTML Editör"
            HTMLEdit.FileToolStripMenuItem.Text = "Dosya"
            HTMLEdit.SaveToolStripMenuItem.Text = "Kaydet"
            HTMLEdit.OpenToolStripMenuItem.Text = "Aç"
            HTMLEdit.ExitToolStripMenuItem.Text = "Çık"
            HTMLEdit.EditToolStripMenuItem.Text = "Düzen"
            HTMLEdit.UndoToolStripMenuItem.Text = "Geri Al"
            HTMLEdit.RedoToolStripMenuItem.Text = "İleri Al"
            HTMLEdit.PreviewToolStripMenuItem.Text = "Önizleme (CTRL + T)"
            Dialog1.Text = "Ayarlar"
            Dialog1.GroupBox1.Text = "Dil"
            Dialog1.Label1.Text = "(Çeviriler %100 Değildir.)"
            Dialog1.GroupBox2.Text = "Ana Sayfa"
            Dialog1.Button1.Text = "Geçerli Olanı Uygula"
            Dialog1.Button2.Text = "Varsayılanı Uygula"
            Dialog1.OK_Button.Text = "Uygula"
            Dialog1.Cancel_Button.Text = "İptal"
        End If
        If My.Settings.Lang = "English" Then
            DocTitle.Text = "Document Title Appears Here."
            Link.Text = "Link/URL Appears Here."
            NewTabToolStripMenuItem1.Text = "New Tab"
            NewWindowToolStripMenuItem.Text = "New Window"
            NewPrivateBrowsingWindowToolStripMenuItem.Text = "New Private Browsing Window"
            PrintToolStripMenuItem.Text = "Print"
            PrintPreviewToolStripMenuItem.Text = "Print Preview"
            ExitPrintPreviewToolStripMenuItem.Text = "Exit Print Preview"
            SavePageToolStripMenuItem.Text = "Save Page"
            HTMLEditorToolStripMenuItem.Text = "HTML Editor"
            HistoryToolStripMenuItem.Text = "History"
            BookmarksToolStripMenuItem.Text = "Bookmarks"
            AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Add This Website To Bookmarks"
            ShowBookmarksToolStripMenuItem.Text = "Show Bookmarks"
            SettingsStripMenuItem1.Text = "Settings"
            AboutSpezBrowserToolStripMenuItem.Text = "About Spez Browser"
            ExitToolStripMenuItem.Text = "Exit"
            Library.TabPage1.Text = "History"
            Library.TabPage2.Text = "Bookmarks"
            Library.Button1.Text = "Clear History"
            Library.Button2.Text = "Remove From History"
            Library.Button3.Text = "Go to Website"
            Library.Button4.Text = "Go to Website"
            Library.Button5.Text = "Remove From Bookmarks"
            Library.Text = "Library"
            HTMLEdit.Text = "HTML Editor"
            HTMLEdit.FileToolStripMenuItem.Text = "File"
            HTMLEdit.SaveToolStripMenuItem.Text = "Save"
            HTMLEdit.OpenToolStripMenuItem.Text = "Open"
            HTMLEdit.ExitToolStripMenuItem.Text = "Exit"
            HTMLEdit.EditToolStripMenuItem.Text = "Edit"
            HTMLEdit.UndoToolStripMenuItem.Text = "Undo"
            HTMLEdit.RedoToolStripMenuItem.Text = "Redo"
            HTMLEdit.PreviewToolStripMenuItem.Text = "Preview (CTRL + T)"
            Dialog1.Text = "Settings"
            Dialog1.GroupBox1.Text = "Language"
            Dialog1.Label1.Text = "(Translations are not 100%.)"
            Dialog1.GroupBox2.Text = "Homepage"
            Dialog1.Button1.Text = "Use Current"
            Dialog1.Button2.Text = "Use Deafult"
            Dialog1.OK_Button.Text = "Apply"
            Dialog1.Cancel_Button.Text = "Cancel"
        End If
        '-----------------------------------------------------------
        Dialog1.ComboBox1.Text = My.Settings.Lang
        Dim NewBrowser As New GeckoWebBrowser
        Dim NewTab As New TabPage
        NewBrowser.Tag = NewTab
        NewTab.Tag = NewBrowser
        TabControl1.TabPages.Add(NewTab)
        NewTab.Controls.Add(NewBrowser)
        NewBrowser.Dock = DockStyle.Fill
        NewBrowser.Navigate("file:///" & Application.StartupPath & "/data/htmldoc/private-mode.html")
        Dialog1.TextBox1.Text = My.Settings.Homepage
        'NewBrowser.Navigate(Application.StartupPath & "/data/New Tab - Home.html")
        TabControl1.SelectedTab = NewTab
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        DocTitle.Font = New Font(font.Families(0), 10)
        Link.Font = New Font(font.Families(0), 7)
        TabControl1.Font = New Font(font.Families(0), 9)
        TabRightClick.Font = New Font(font.Families(0), 9)
        ContextMenuStrip1.Font = New Font(font.Families(0), 9)
        TextBox1.Font = New Font(font.Families(0), 14)
        Me.Font = New Font(font.Families(0), 8)
        '-----------------------------------------------------------
        AddHandler NewBrowser.ProgressChanged, AddressOf LoadingWeb
        AddHandler NewBrowser.DocumentCompleted, AddressOf Done
        AddHandler Gecko.LauncherDialog.Download, AddressOf LauncherDialog_Download
    End Sub
    Private Sub LauncherDialog_Download(ByVal sender As Object, ByVal e As LauncherDialogEvent)
        Dim objTarget As Gecko.nsILocalFile = Gecko.Xpcom.CreateInstance(Of Gecko.nsILocalFile)("@mozilla.org/file/local;1")
        Dim tmp_Loc As String = Application.StartupPath & "\data"
        Dim sx As Object = Nothing
        Dim fx As String = ""
        Dim saveBox As New SaveFileDialog
        Dim win As Object = Gecko.Xpcom.GetService(Of Gecko.nsIWindowWatcher)("@mozilla.org/embedcomp/window-watcher;1")

        Using tmp As New Gecko.nsAString(tmp_Loc)
            objTarget.InitWithPath(tmp)
        End Using

        If e.Filename.Contains(".") Then
            sx = Strings.Split(e.Filename, ".")
            fx = sx(sx.Length - 1).ToUpper & " File (*." & sx(sx.Length - 1) & ")|*." & sx(sx.Length - 1)
        Else
            fx = "File (*.*)|*.*"
        End If

        saveBox.Filter = fx '"HTML File (*.html)|*.html"
        saveBox.Title = "Download Location:"
        saveBox.FileName = e.Filename
        If saveBox.ShowDialog <> System.Windows.Forms.DialogResult.OK And String.IsNullOrEmpty(saveBox.FileName) Then
            Exit Sub
        End If
        Dim source As Gecko.nsIURI = Gecko.IOService.CreateNsIUri(New Uri(e.Url).AbsoluteUri)
        Dim dest As Gecko.nsIURI = Gecko.IOService.CreateNsIUri(New Uri(saveBox.FileName).AbsoluteUri)
        Dim t As Gecko.nsAStringBase = DirectCast(New Gecko.nsAString(System.IO.Path.GetFileName(saveBox.FileName)), Gecko.nsAStringBase)

        Dim persist As Gecko.nsIWebBrowserPersist = Gecko.Xpcom.CreateInstance(Of Gecko.nsIWebBrowserPersist)("@mozilla.org/embedding/browser/nsWebBrowserPersist;1")
        Dim DownloadMan As Gecko.nsIDownloadManager = Gecko.Xpcom.CreateInstance(Of Gecko.nsIDownloadManager)("@mozilla.org/download-manager;1")
        Dim downloadX As Gecko.nsIDownload = DownloadMan.AddDownload(0, source, dest, t, e.Mime, 0, Nothing, DirectCast(persist, Gecko.nsICancelable), False)

        If (downloadX IsNot Nothing) Then
            persist.SetPersistFlagsAttribute(2 Or 32 Or 16384)
            persist.SetProgressListenerAttribute(DirectCast(downloadX, Gecko.nsIWebProgressListener))
            persist.SaveURI(source, Nothing, Nothing, Nothing, Nothing, DirectCast(dest, Gecko.nsISupports), Nothing)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).GoBack()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).GoForward()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Refresh()
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.Controls.Remove(TabControl1.SelectedTab)
        If TabControl1.TabCount = "0" Then
            End
        End If
    End Sub

    Private Sub NewTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewBrowser As New GeckoWebBrowser
        Dim NewTab As New TabPage
        NewBrowser.Tag = NewTab
        NewTab.Tag = NewBrowser
        TabControl1.TabPages.Add(NewTab)
        NewTab.Controls.Add(NewBrowser)
        NewBrowser.Dock = DockStyle.Fill
        NewBrowser.Navigate("file:///" & Application.StartupPath & "/data/htmldoc/private-mode.html")
        TabControl1.SelectedTab = NewTab
        AddHandler NewBrowser.ProgressChanged, AddressOf LoadingWeb
        AddHandler NewBrowser.DocumentCompleted, AddressOf Done
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button4_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        Try
            Button4.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\Close_hover.png"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Try
            Button4.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\Close.png"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button7_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseHover
        Try
            Button7.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\fullscreen_hover.png"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        Try
            Button7.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\fullscreen.png"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button8_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseHover
        Try
            Button8.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\minimize_hover.png"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        Try
            Button8.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\Dark\minimize.png"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(TextBox1.Text)
        End If
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = System.Windows.Forms.Cursor.Position.X - Me.Left
        mousey = System.Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = System.Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = System.Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub Panel3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UpR.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Me.Size = New Size(Me.Size.Width, Me.Size.Height + (Me.Location.Y - MousePosition.Y))
            Me.Location = New Point(Me.Location.X, MousePosition.Y)
        End If
    End Sub

    Private Sub Panel5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DownR.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Me.Size = New Size(Me.Size.Width, MousePosition.Y - Me.Location.Y)
        End If
    End Sub

    Private Sub Panel2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LeftR.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Me.Size = New Size(Me.Size.Width + (Me.Location.X - MousePosition.X), Me.Size.Height)
            Me.Location = New Point(MousePosition.X, Me.Location.Y)
        End If
    End Sub

    Private Sub Panel4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RightR.MouseMove
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Me.Size = New Size(MousePosition.X - Me.Location.X, Me.Size.Height)
        End If
    End Sub

    Private Sub DocTitle_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocTitle.MouseHover
        Panel2.Visible = False
    End Sub

    Private Sub Link_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link.MouseHover
        Panel2.Visible = False
    End Sub

    Private Sub TextBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave
        Panel2.Visible = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SendKeys.Send("+{F10}")
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim print = Xpcom.QueryInterface(Of nsIWebBrowserPrint)(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Window.DomWindow)
        Try
            print.Print(print.GetGlobalPrintSettingsAttribute, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Dim printSettingsSvc = Xpcom.GetService(Of nsIPrintSettingsService)("@mozilla.org/gfx/printsettings-service;1")
        Dim printSettings As nsIPrintSettings = printSettingsSvc.GetNewPrintSettingsAttribute()
        Dim docShell As nsIDocShell = Xpcom.QueryInterface(Of nsIDocShell)(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).WebBrowserFocus)
        docShell.GetContentViewerAttribute().SetPageMode(True, printSettings)
        ExitPrintPreviewToolStripMenuItem.Enabled = True
        ExitPrintPreviewToolStripMenuItem.Visible = True
        PrintPreviewToolStripMenuItem.Enabled = False
        PrintPreviewToolStripMenuItem.Visible = False
    End Sub

    Private Sub PageSoruceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePageToolStripMenuItem.Click
        Try
            Dim dlg As SaveFileDialog = New SaveFileDialog
            dlg.Title = "Save"
            dlg.Filter = "HTML|*.html|All Files|*"
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).SaveDocument(dlg.FileName)
            End If
        Catch ex As Exception
            MsgBox("Save Failed!", vbCritical, "Error")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        Library.Show()
    End Sub

    Private Sub ShowBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowBookmarksToolStripMenuItem.Click
        Library.Show()
        Library.TabControl1.SelectedIndex = 1
    End Sub

    Private Sub AddThisWebsiteToBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddThisWebsiteToBookmarksToolStripMenuItem.Click
        My.Settings.Bookmarks.Add(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString)
        My.Settings.Save()
    End Sub

    Private Sub HTMLEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HTMLEditorToolStripMenuItem.Click
        HTMLEdit.Show()
    End Sub

    Private Sub SettingsStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsStripMenuItem1.Click
        On Error Resume Next
        Dialog1.ShowDialog()
    End Sub

    Private Sub NewTabToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button6.PerformClick()
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseTabToolStripMenuItem.Click
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        If TabControl1.TabCount = 0 Then
            End
        End If
    End Sub

    Private Sub AboutSpezBrowserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutSpezBrowserToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

    Private Sub NewTabToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTabToolStripMenuItem1.Click
        Button6.PerformClick()
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dialog1.ListView1.Items.Clear()
        Dim newwin As New Form1
        newwin.Show()
    End Sub

    Private Sub Panel1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.DoubleClick
        Button7.PerformClick()
    End Sub

    Private Sub NewPrivateBrowsingWindowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewPrivateBrowsingWindowToolStripMenuItem.Click
        Dim newwin As New PrivateForm1
        newwin.Show()
    End Sub

    Private Sub ExitPrintPreviewToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles ExitPrintPreviewToolStripMenuItem.Click
        Dim printSettingsSvc = Xpcom.GetService(Of nsIPrintSettingsService)("@mozilla.org/gfx/printsettings-service;1")
        Dim printSettings As nsIPrintSettings = printSettingsSvc.GetNewPrintSettingsAttribute()
        Dim docShell As nsIDocShell = Xpcom.QueryInterface(Of nsIDocShell)(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).WebBrowserFocus)
        docShell.GetContentViewerAttribute().SetPageMode(Nothing, Nothing)
        ExitPrintPreviewToolStripMenuItem.Enabled = False
        ExitPrintPreviewToolStripMenuItem.Visible = False
        PrintPreviewToolStripMenuItem.Enabled = True
        PrintPreviewToolStripMenuItem.Visible = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If ProgressBar1.Value = 0 Or ProgressBar1.Value = 100 Then
            ProgressBar1.Height = 0
        Else
            ProgressBar1.Height = 3
        End If
    End Sub
End Class
