Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports Gecko
Imports Gecko.DOM
Imports System.Threading


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
        NewBrowser.Navigate("file:///" & Application.StartupPath & "/data/htmldoc/private-mode.html")
        AddHandler NewBrowser.CreateWindow, AddressOf BrowCreateWindow
        Dim field = GetType(GeckoWebBrowser).GetField("WebBrowser")
        If field IsNot Nothing Then
            Dim val = field.GetValue(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser))
            Dim nsIWebBrowser As nsIWebBrowser = DirectCast(val, nsIWebBrowser)
            Xpcom.QueryInterface(Of nsILoadContext)(nsIWebBrowser).SetPrivateBrowsing(True)
        End If
    End Sub
    Private Sub LoadingWeb(ByVal sender As Object, ByVal e As GeckoProgressEventArgs)
        ProgressBar1.Show()
        ProgressBar1.Width = 1
        ProgressBar1.Maximum = e.MaximumProgress
        ProgressBar1.Value = e.MaximumProgress
        If TabControl1.TabPages.Count = 1 Then
            TabControl1.ItemSize = New Size(0, 1)
            TabControl1.SizeMode = TabSizeMode.Fixed
        ElseIf TabControl1.TabPages.Count < 15 Then
            TabControl1.ItemSize = New Size(TabControl1.Width / TabControl1.TabPages.Count - 1.5, 0)
            TabControl1.SizeMode = TabSizeMode.Fixed
        Else
            TabControl1.ItemSize = New Size(128, 0)
            TabControl1.SizeMode = TabSizeMode.Fixed
        End If
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
        If (CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).CanGoBack = False) Then
            If My.Settings.Theme = "Windows Style" Then
                Button1.Enabled = False
            Else
                Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\backdis.png"))
            End If
        Else
            If My.Settings.Theme = "Windows Style" Then
                Button1.Enabled = True
            Else
                Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\back.png"))
            End If
        End If
        If (CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).CanGoForward = False) Then
            If My.Settings.Theme = "Windows Style" Then
                Button2.Enabled = False
            Else
                Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\nextdis.png"))
            End If
        Else
            If My.Settings.Theme = "Windows Style" Then
                Button2.Enabled = True
            Else
                Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\next.png"))
            End If
        End If
        If TextBox1.Text.Contains("about:") Then
            Link.ForeColor = Color.DodgerBlue
            Link.Text = "🌐  " & Link.Text
        ElseIf TextBox1.Text.Contains("/data/htmldoc/new-tab.html") Or TextBox1.Text.Contains("/data/htmldoc/welcome.html") Or TextBox1.Text.Contains("/data/htmldoc/private-mode.html") Or TextBox1.Text.Contains("/data/htmldoc/getting.html") Then
            Link.ForeColor = Color.DodgerBlue
            Link.Text = "🌐  Spez Browser Page"
            TextBox1.Text = Nothing
        ElseIf TextBox1.Text.Contains("https://") Then
            Link.ForeColor = Color.Green
            Link.Text = "🔒 " & Link.Text
        Else
            Link.ForeColor = Color.Gray
        End If
        UpdateAutoComplete()
    End Sub

    Private Sub UpdateAutoComplete()

        'Loop through each listbox item and add it to the Autocomplete source
        For i As Integer = 0 To Library.ListBox1.Items.Count - 1
            TextBox1.AutoCompleteCustomSource.Add(Library.ListBox1.Items(i))
        Next
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
        'text
        DocTitle.ForeColor = Color.White

        'txtbox
        URLPanel.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\dark\searchbar.png"))
        Dim clr As New TextBox
        Dim rs As String
        Dim gs As String
        Dim bs As String
        clr.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\themes\dark\rgbtextbox.txt")
        ''findred
        Dim a As String
        Dim b As String
        a = "R="
        b = InStr(clr.Text, a)
        If b Then
            clr.Focus()
            clr.SelectionStart = b - 1
            clr.SelectionLength = Len(a) + 3
            rs = clr.SelectedText.ToString
            rs = rs.Remove(0, 2)
        End If
        ''findgreen
        Dim c As String
        Dim d As String
        c = "G="
        d = InStr(clr.Text, c)
        If d Then
            clr.Focus()
            clr.SelectionStart = b - 1
            clr.SelectionLength = Len(c) + 3
            gs = clr.SelectedText.ToString
            gs = gs.Remove(0, 2)
        End If
        ''findblue
        Dim ee As String
        Dim f As String
        ee = "B="
        f = InStr(clr.Text, ee)
        If f Then
            clr.Focus()
            clr.SelectionStart = b - 1
            clr.SelectionLength = Len(ee) + 3
            bs = clr.SelectedText.ToString
            bs = bs.Remove(0, 2)
        End If
        ''apply
        Dim r As Integer = Convert.ToInt64(rs)
        Dim g As Integer = Convert.ToInt64(gs)
        Dim bb As Integer = Convert.ToInt64(bs)
        TextBox1.BackColor = System.Drawing.Color.FromArgb(r, g, bb)
        TextBox1.ForeColor = Color.White

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
            If Thread.CurrentThread.CurrentUICulture.Name.ToString.Contains("tr") Then
                My.Settings.Lang = "Türkçe"
            ElseIf Thread.CurrentThread.CurrentUICulture.Name.ToString.Contains("de") Then
                My.Settings.Lang = "Deutsch"
            Else
                My.Settings.Lang = "English"
            End If
            My.Settings.Homepage = ("file:///" & Application.StartupPath & "/data/htmldoc/new-tab.html")
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
            FavoritesToolStripMenuItem.Text = "Favoriler"
            AddThisWebsiteToFavoritesToolStripMenuItem.Text = "Bu Web Sitesini Favorilere Ekle"
            ShowFavoritesToolStripMenuItem.Text = "Favorileri Göster"
            SettingsStripMenuItem1.Text = "Tercihler"
            SupportToolStripMenuItem.Text = "Destek"
            AboutSpezBrowserToolStripMenuItem.Text = "Spez Browser Hakkında"
            ExitToolStripMenuItem.Text = "Çık"
            Library.TabPage1.Text = "Geçmiş"
            Library.TabPage2.Text = "Yer imleri"
            Library.TabPage3.Text = "Favoriler"
            Library.Button2.Text = "Geçmişten Sil"
            Library.Button3.Text = "Web Sayfasına Git"
            Library.Button4.Text = "Web Sayfasına Git"
            Library.Button5.Text = "Yer imlerinden Sil"
            Library.Button1.Text = "Web Sayfasına Git"
            Library.Button6.Text = "Favorilerden Sil"
            Library.Button7.Text = "İçe Aktar..."
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
            Dialog1.Text = "Tercihler"
            Dialog1.GroupBox1.Text = "Dil"
            Dialog1.Label1.Text = "(Çeviriler %100 Değildir.)"
            Dialog1.GroupBox2.Text = "Ana Sayfa"
            Dialog1.Button1.Text = "Geçerli Olanı Uygula"
            Dialog1.Button2.Text = "Varsayılanı Uygula"
            Dialog1.OK_Button.Text = "Uygula"
            Dialog1.Cancel_Button.Text = "İptal"
            Dialog1.TabControl1.TabPages(0).Text = "Genel"
            Dialog1.TabControl1.TabPages(1).Text = "Temalar"
            Dialog1.LinkLabel1.Text = "Daha fazla Spez Browser teması al"
            GeckoPreferences.User("intl.accept_languages") = "tr"
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
            FavoritesToolStripMenuItem.Text = "Favorites"
            AddThisWebsiteToFavoritesToolStripMenuItem.Text = "Add This Website To Favorites"
            ShowFavoritesToolStripMenuItem.Text = "Show Favorites"
            SettingsStripMenuItem1.Text = "Preferences"
            SupportToolStripMenuItem.Text = "Support"
            AboutSpezBrowserToolStripMenuItem.Text = "About Spez Browser"
            ExitToolStripMenuItem.Text = "Exit"
            Library.TabPage1.Text = "History"
            Library.TabPage2.Text = "Bookmarks"
            Library.TabPage3.Text = "Favorites"
            Library.Button2.Text = "Remove From History"
            Library.Button3.Text = "Go to Website"
            Library.Button4.Text = "Go to Website"
            Library.Button5.Text = "Remove From Bookmarks"
            Library.Button1.Text = "Go to Website"
            Library.Button6.Text = "Remove From Favorites"
            Library.Button7.Text = "Import..."
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
            Dialog1.Text = "Preferences"
            Dialog1.GroupBox1.Text = "Language"
            Dialog1.Label1.Text = "(Translations are not 100%.)"
            Dialog1.GroupBox2.Text = "Homepage"
            Dialog1.Button1.Text = "Use Current"
            Dialog1.Button2.Text = "Use Deafult"
            Dialog1.OK_Button.Text = "Apply"
            Dialog1.Cancel_Button.Text = "Cancel"
            Dialog1.TabControl1.TabPages(0).Text = "General"
            Dialog1.TabControl1.TabPages(1).Text = "Themes"
            Dialog1.LinkLabel1.Text = "Get More Spez Browser Theme"
            GeckoPreferences.User("intl.accept_languages") = "en-us"
        End If
        If My.Settings.Lang = "Deutsch" Then
            DocTitle.Text = "Der Dokumentkopf erscheint hier."
            Link.Text = "Link/URL hier sichtbar."
            NewTabToolStripMenuItem1.Text = "Neuer Tab"
            NewWindowToolStripMenuItem.Text = "Neues Fenster"
            NewPrivateBrowsingWindowToolStripMenuItem.Text = "Neues Inkognito-Navigationsfenster"
            PrintToolStripMenuItem.Text = "Drucken"
            PrintPreviewToolStripMenuItem.Text = "Druckvorschau"
            ExitPrintPreviewToolStripMenuItem.Text = "Beenden Sie die Druckvorschau"
            SavePageToolStripMenuItem.Text = "Seite speichern"
            HTMLEditorToolStripMenuItem.Text = "HTML Editor"
            HistoryToolStripMenuItem.Text = "Geschichte"
            BookmarksToolStripMenuItem.Text = "Lesezeichen"
            AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Lesezeichen dieser Website"
            ShowBookmarksToolStripMenuItem.Text = "Lesezeichen anzeigen"
            FavoritesToolStripMenuItem.Text = "Favoriten"
            AddThisWebsiteToFavoritesToolStripMenuItem.Text = "Fügen Sie diese Website Ihren Favoriten hinzu"
            ShowFavoritesToolStripMenuItem.Text = "Favoriten anzeigen"
            SettingsStripMenuItem1.Text = "Voreinstellungen"
            SupportToolStripMenuItem.Text = "Unterstützung"
            AboutSpezBrowserToolStripMenuItem.Text = "Über Spez Browser"
            ExitToolStripMenuItem.Text = "Ausfahrt"
            Library.TabPage1.Text = "Geschichte"
            Library.TabPage2.Text = "Lesezeichen"
            Library.TabPage3.Text = "Favoriten"
            Library.Button2.Text = "Aus dem Verlauf löschen"
            Library.Button3.Text = "Gehe zur Webseite"
            Library.Button4.Text = "Gehe zur Webseite"
            Library.Button5.Text = "Löschen von Lesezeichen"
            Library.Button1.Text = "Gehe zur Webseite"
            Library.Button6.Text = "Aus den Favoriten löschen"
            Library.Button7.Text = "Einführen..."
            Library.Text = "Bibliothek"
            HTMLEdit.Text = "HTML Editor"
            HTMLEdit.FileToolStripMenuItem.Text = "Datei"
            HTMLEdit.SaveToolStripMenuItem.Text = "Speichern"
            HTMLEdit.OpenToolStripMenuItem.Text = "Hungrig"
            HTMLEdit.ExitToolStripMenuItem.Text = "Ausfahrt"
            HTMLEdit.EditToolStripMenuItem.Text = "Layout"
            HTMLEdit.UndoToolStripMenuItem.Text = "Rückgängig machen"
            HTMLEdit.RedoToolStripMenuItem.Text = "Weiterleiten"
            HTMLEdit.PreviewToolStripMenuItem.Text = "Vorschau (CTRL + T)"
            Dialog1.Text = "Voreinstellungen"
            Dialog1.GroupBox1.Text = "Sprache"
            Dialog1.Label1.Text = "(Übersetzt ist nicht 100%.)"
            Dialog1.GroupBox2.Text = "Startseite"
            Dialog1.Button1.Text = "Übernehmen Current"
            Dialog1.Button2.Text = "Übernehmen Standard"
            Dialog1.OK_Button.Text = "Anwenden"
            Dialog1.Cancel_Button.Text = "Stornierung"
            Dialog1.TabControl1.TabPages(0).Text = "Allgemeines"
            Dialog1.TabControl1.TabPages(1).Text = "Themen"
            Dialog1.LinkLabel1.Text = "Holen Sie sich mehr Spez Browser Theme"
            GeckoPreferences.User("intl.accept_languages") = "de"
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
        TextBox1.Font = New Font(font.Families(0), TextBox1.Font.Size)
        Me.Font = New Font(font.Families(0), 8)
        '-----------------------------------------------------------
        AddHandler NewBrowser.ProgressChanged, AddressOf LoadingWeb
        AddHandler NewBrowser.DocumentCompleted, AddressOf Done
        AddHandler NewBrowser.CreateWindow, AddressOf BrowCreateWindow
        '-----------------------------------------------------------
        If My.Settings.WelcomeScreen = True Then
            My.Settings.WelcomeScreen = False
            CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("file:///" & Application.StartupPath & "/data/htmldoc/welcome.html")
        End If
        '-----------------------------------------------------------
        Dim url As String = Command$()
        If Not Environment.GetCommandLineArgs.Count = 1 Then
            url = url.Replace("--priv", "")
            url = url.Replace("""", "")
            If url.StartsWith(" ") Then
                url = url.Remove(0, 1)
            End If
            If url.Contains("\") Then
                url = "file:\\\" & url
            End If
            CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(url)
        End If
        '-----------------------------------------------------------
        Dim field = GetType(GeckoWebBrowser).GetField("WebBrowser")
        If field IsNot Nothing Then
            Dim val = field.GetValue(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser))
            Dim nsIWebBrowser As nsIWebBrowser = DirectCast(val, nsIWebBrowser)
            Xpcom.QueryInterface(Of nsILoadContext)(nsIWebBrowser).SetPrivateBrowsing(True)
        End If
    End Sub

    Private Sub LauncherDialog_Download(ByVal sender As Object, ByVal e As Gecko.LauncherDialogEvent)
        Dim objTarget As nsILocalFile = Xpcom.CreateInstance(Of nsILocalFile)("@mozilla.org/file/local;1")

        Using tmp As nsAString = New nsAString(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & vbTab & "emp.tmp")
            objTarget.InitWithPath(tmp)
        End Using

        Dim myStream As Stream
        Dim saveFileDialog1 As SaveFileDialog = New SaveFileDialog()
        saveFileDialog1.Filter = "All files (*.*)|*.*"
        saveFileDialog1.Title = "Download Location:"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        saveFileDialog1.FileName = e.Filename

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then

            If (CSharpImpl1.__Assign(myStream, saveFileDialog1.OpenFile())) IsNot Nothing Then
                Dim source As nsIURI = IOService.CreateNsIUri(e.Url)
                Dim dest As nsIURI = IOService.CreateNsIUri(New Uri(saveFileDialog1.FileName).AbsoluteUri)
                Dim t As nsAStringBase = CType(New nsAString(System.IO.Path.GetFileName(saveFileDialog1.FileName)), nsAStringBase)
                Dim persist As nsIWebBrowserPersist = Xpcom.CreateInstance(Of nsIWebBrowserPersist)("@mozilla.org/embedding/browser/nsWebBrowserPersist;1")
                Dim nst As nsITransfer = Xpcom.CreateInstance(Of nsITransfer)("@mozilla.org/transfer;1")
                nst.Init(source, dest, t, e.Mime, 0, Nothing, persist, False)

                If nst IsNot Nothing Then
                    persist.SetPersistFlagsAttribute(2 Or 32 Or 16384)
                    persist.SetProgressListenerAttribute(CType(nst, nsIWebProgressListener))
                    persist.SaveURI(source, Nothing, Nothing, CUInt(Gecko.nsIHttpChannelConsts.REFERRER_POLICY_NO_REFERRER), Nothing, Nothing, CType(dest, nsISupports), Nothing)
                End If

                myStream.Close()
            End If
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
        Dim field = GetType(GeckoWebBrowser).GetField("WebBrowser")
        If field IsNot Nothing Then
            Dim val = field.GetValue(CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser))
            Dim nsIWebBrowser As nsIWebBrowser = DirectCast(val, nsIWebBrowser)
            Xpcom.QueryInterface(Of nsILoadContext)(nsIWebBrowser).SetPrivateBrowsing(True)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form1.Close()
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
            If TextBox1.Text = "about:spezbrowabout" Then
                About.ShowDialog()
            ElseIf TextBox1.Text = "about:welcome" Then
                CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("file:///" & Application.StartupPath & "/data/htmldoc/welcome.html")
            ElseIf TextBox1.Text = "about:gettingstarted" Then
                CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("file:///" & Application.StartupPath & "/data/htmldoc/getting.html")
            Else
                Dim textArray = TextBox1.Text.Split(" ")
                If (TextBox1.Text.Contains(".") AndAlso
                    Not TextBox1.Text.Contains(" ") AndAlso
                    Not TextBox1.Text.Contains(" .") AndAlso
                    Not TextBox1.Text.Contains(". ")) OrElse
                    textArray(0).Contains(":/") OrElse textArray(0).Contains(":\") OrElse textArray(0).Contains(":") Then
                    CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(TextBox1.Text)
                Else
                    CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("https://google.com/search?q=" & TextBox1.Text)
                End If
            End If
        End If
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown, Link.MouseDown, DocTitle.MouseDown
        drag = True
        mousex = System.Windows.Forms.Cursor.Position.X - Me.Left
        mousey = System.Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove, Link.MouseMove, DocTitle.MouseMove
        If drag Then
            Me.Top = System.Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = System.Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp, Link.MouseUp, DocTitle.MouseUp
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

    Private Sub DocTitle_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocTitle.Click
        Panel2.Visible = False
        TextBox1.Focus()
    End Sub

    Private Sub Link_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link.Click
        Panel2.Visible = False
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("about:blank")
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        Try
            If TabControl1.TabPages.Count = 1 Then
                TabControl1.ItemSize = New Size(0, 1)
                TabControl1.SizeMode = TabSizeMode.Fixed
            ElseIf TabControl1.TabPages.Count < 15 Then
                TabControl1.ItemSize = New Size(TabControl1.Width / TabControl1.TabPages.Count - 1.5, 0)
                TabControl1.SizeMode = TabSizeMode.Fixed
            Else
                TabControl1.ItemSize = New Size(128, 0)
                TabControl1.SizeMode = TabSizeMode.Fixed
            End If
        Catch ex As Exception

        End Try
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
        Dim pHelp As New ProcessStartInfo
        pHelp.FileName = Application.ExecutablePath
        pHelp.Arguments = Nothing
        pHelp.UseShellExecute = True
        pHelp.WindowStyle = ProcessWindowStyle.Normal
        Dim proc As Process = Process.Start(pHelp)
    End Sub

    Private Sub Panel1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.DoubleClick
        Button7.PerformClick()
    End Sub

    Private Sub NewPrivateBrowsingWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPrivateBrowsingWindowToolStripMenuItem.Click
        Dim pHelp As New ProcessStartInfo
        pHelp.FileName = Application.ExecutablePath
        pHelp.Arguments = "--priv"
        pHelp.UseShellExecute = True
        pHelp.WindowStyle = ProcessWindowStyle.Normal
        Dim proc As Process = Process.Start(pHelp)
    End Sub

    Private Sub ExitPrintPreviewToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitPrintPreviewToolStripMenuItem.Click
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

    Private Sub SupportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupportToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("https://spezcomputerhelp.weebly.com/spez-apps.html")
    End Sub

    Private Sub ShowFavoritesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowFavoritesToolStripMenuItem.Click
        Library.Show()
        Library.TabControl1.SelectedIndex = 2
    End Sub

    Private Sub PrivateForm1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Try
            If TabControl1.TabPages.Count = 1 Then
                TabControl1.ItemSize = New Size(0, 1)
                TabControl1.SizeMode = TabSizeMode.Fixed
            ElseIf TabControl1.TabPages.Count < 15 Then
                TabControl1.ItemSize = New Size(TabControl1.Width / TabControl1.TabPages.Count - 1.5, 0)
                TabControl1.SizeMode = TabSizeMode.Fixed
            Else
                TabControl1.ItemSize = New Size(128, 0)
                TabControl1.SizeMode = TabSizeMode.Fixed
            End If
        Catch ex As Exception

        End Try
        Form1.WindowState = Me.WindowState
        Form1.Size = Me.Size
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        DocTitle.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        Link.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString
        TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url.ToString
        webIcons()
        If TextBox1.Text.Contains("about:") Then
            Link.ForeColor = Color.DodgerBlue
            Link.Text = "🌐  " & Link.Text
        ElseIf TextBox1.Text.Contains("/data/htmldoc/new-tab.html") Or TextBox1.Text.Contains("/data/htmldoc/welcome.html") Or TextBox1.Text.Contains("/data/htmldoc/private-mode.html") Or TextBox1.Text.Contains("/data/htmldoc/getting.html") Then
            Link.ForeColor = Color.DodgerBlue
            Link.Text = "🌐  Spez Browser Page"
            TextBox1.Text = Nothing
        ElseIf TextBox1.Text.Contains("https://") Then
            Link.ForeColor = Color.Green
            Link.Text = "🔒 " & Link.Text
        Else
            Link.ForeColor = Color.Gray
        End If
        TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        If (CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).CanGoBack = False) Then
            If My.Settings.Theme = "Windows Style" Then
                Button1.Enabled = False
            Else
                Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\backdis.png"))
            End If
        Else
            If My.Settings.Theme = "Windows Style" Then
                Button1.Enabled = True
            Else
                Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\back.png"))
            End If
        End If
        If (CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).CanGoForward = False) Then
            If My.Settings.Theme = "Windows Style" Then
                Button2.Enabled = False
            Else
                Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\nextdis.png"))
            End If
        Else
            If My.Settings.Theme = "Windows Style" Then
                Button2.Enabled = True
            Else
                Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\next.png"))
            End If
        End If
    End Sub

    Private Sub BrowCreateWindow(ByVal sender As Object, ByVal e As GeckoCreateWindowEventArgs)
        e.Cancel = True
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
        NewBrowser.Navigate(e.Uri)
        AddHandler NewBrowser.CreateWindow, AddressOf BrowCreateWindow
    End Sub

    Private Sub TextBox1_LostFocus1(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Panel2.Visible = True
    End Sub
End Class

Public Class CSharpImpl1
    <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
    Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class