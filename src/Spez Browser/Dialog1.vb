Imports System.Windows.Forms
Imports System.Drawing.Text
Imports System.IO
Imports Gecko

Public Class Dialog1
    Dim Check1Checked As Boolean = False
    Dim Check2Checked As Boolean = False
    Dim Check3Checked As Boolean = False

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        My.Settings.Homepage = TextBox1.Text
        My.Settings.Lang = ComboBox1.Text
        If My.Settings.Lang = "Türkçe" Then
            Form1.DocTitle.Text = "Belge Başlığı Burada Görünür."
            Form1.Link.Text = "Link/URL Burada Görünür."
            Form1.NewTabToolStripMenuItem1.Text = "Yeni Sekme"
            Form1.NewWindowToolStripMenuItem.Text = "Yeni Pencere"
            Form1.NewPrivateBrowsingWindowToolStripMenuItem.Text = "Yeni Gizli Gezinme Pencresi"
            Form1.PrintToolStripMenuItem.Text = "Yazdır"
            Form1.PrintPreviewToolStripMenuItem.Text = "Baskı Önizleme"
            Form1.ExitPrintPreviewToolStripMenuItem.Text = "Baskı Önizlemesinden Çık"
            Form1.SavePageToolStripMenuItem.Text = "Sayfayı kaydet"
            Form1.HTMLEditorToolStripMenuItem.Text = "HTML Editör"
            Form1.HistoryToolStripMenuItem.Text = "Geçmiş"
            Form1.BookmarksToolStripMenuItem.Text = "Yer imleri"
            Form1.AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Bu Web Sitesini Yer İmlerine Ekle"
            Form1.ShowBookmarksToolStripMenuItem.Text = "Yer İmlerini Göster"
            Form1.FavoritesToolStripMenuItem.Text = "Favoriler"
            Form1.AddThisWebsiteToFavoritesToolStripMenuItem.Text = "Bu Web Sitesini Favorilere Ekle"
            Form1.ShowFavoritesToolStripMenuItem.Text = "Favorileri Göster"
            Form1.SettingsStripMenuItem1.Text = "Tercihler"
            Form1.SupportToolStripMenuItem.Text = "Destek"
            Form1.AboutSpezBrowserToolStripMenuItem.Text = "Spez Browser Hakkında"
            Form1.ExitToolStripMenuItem.Text = "Çık"
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
            Me.Text = "Tercihler"
            GroupBox1.Text = "Dil"
            Label1.Text = "(Çeviriler %100 Değildir.)"
            GroupBox2.Text = "Ana Sayfa"
            Button1.Text = "Geçerli Olanı Uygula"
            Button2.Text = "Varsayılanı Uygula"
            OK_Button.Text = "Uygula"
            Cancel_Button.Text = "İptal"
            GeckoPreferences.User("intl.accept_languages") = "tr"
        End If
        If My.Settings.Lang = "English" Then
            Form1.DocTitle.Text = "Document Title Appears Here."
            Form1.Link.Text = "Link/URL Appears Here."
            Form1.NewTabToolStripMenuItem1.Text = "New Tab"
            Form1.NewWindowToolStripMenuItem.Text = "New Window"
            Form1.NewPrivateBrowsingWindowToolStripMenuItem.Text = "New Private Browsing Window"
            Form1.PrintToolStripMenuItem.Text = "Print"
            Form1.PrintPreviewToolStripMenuItem.Text = "Print Preview"
            Form1.ExitPrintPreviewToolStripMenuItem.Text = "Exit Print Preview"
            Form1.SavePageToolStripMenuItem.Text = "Save Page"
            Form1.HTMLEditorToolStripMenuItem.Text = "HTML Editor"
            Form1.HistoryToolStripMenuItem.Text = "History"
            Form1.BookmarksToolStripMenuItem.Text = "Bookmarks"
            Form1.AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Add This Website To Bookmarks"
            Form1.ShowBookmarksToolStripMenuItem.Text = "Show Bookmarks"
            Form1.FavoritesToolStripMenuItem.Text = "Favorites"
            Form1.AddThisWebsiteToFavoritesToolStripMenuItem.Text = "Add This Website To Favorites"
            Form1.ShowFavoritesToolStripMenuItem.Text = "Show Favorites"
            Form1.SettingsStripMenuItem1.Text = "Preferences"
            Form1.SupportToolStripMenuItem.Text = "Support"
            Form1.AboutSpezBrowserToolStripMenuItem.Text = "About Spez Browser"
            Form1.ExitToolStripMenuItem.Text = "Exit"
            Library.TabPage1.Text = "History"
            Library.TabPage2.Text = "Bookmarks"
            Library.TabPage2.Text = "Favorites"
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
            Me.Text = "Preferences"
            GroupBox1.Text = "Language"
            Label1.Text = "(Translations are not 100%.)"
            GroupBox2.Text = "Homepage"
            Button1.Text = "Use Current"
            Button2.Text = "Use Deafult"
            OK_Button.Text = "Apply"
            Cancel_Button.Text = "Cancel"
            GeckoPreferences.User("intl.accept_languages") = "en-us"
        End If
        If My.Settings.Lang = "Deutsch" Then
            Form1.DocTitle.Text = "Der Dokumentkopf erscheint hier."
            Form1.Link.Text = "Link/URL hier sichtbar."
            Form1.NewTabToolStripMenuItem1.Text = "Neuer Tab"
            Form1.NewWindowToolStripMenuItem.Text = "Neues Fenster"
            Form1.NewPrivateBrowsingWindowToolStripMenuItem.Text = "Neues Inkognito-Navigationsfenster"
            Form1.PrintToolStripMenuItem.Text = "Drucken"
            Form1.PrintPreviewToolStripMenuItem.Text = "Druckvorschau"
            Form1.ExitPrintPreviewToolStripMenuItem.Text = "Beenden Sie die Druckvorschau"
            Form1.SavePageToolStripMenuItem.Text = "Seite speichern"
            Form1.HTMLEditorToolStripMenuItem.Text = "HTML Editor"
            Form1.HistoryToolStripMenuItem.Text = "Geschichte"
            Form1.BookmarksToolStripMenuItem.Text = "Lesezeichen"
            Form1.AddThisWebsiteToBookmarksToolStripMenuItem.Text = "Lesezeichen dieser Website"
            Form1.ShowBookmarksToolStripMenuItem.Text = "Lesezeichen anzeigen"
            Form1.FavoritesToolStripMenuItem.Text = "Favoriten"
            Form1.AddThisWebsiteToFavoritesToolStripMenuItem.Text = "Fügen Sie diese Website Ihren Favoriten hinzu"
            Form1.ShowFavoritesToolStripMenuItem.Text = "Favoriten anzeigen"
            Form1.SettingsStripMenuItem1.Text = "Voreinstellungen"
            Form1.SupportToolStripMenuItem.Text = "Unterstützung"
            Form1.AboutSpezBrowserToolStripMenuItem.Text = "Über Spez Browser"
            Form1.ExitToolStripMenuItem.Text = "Ausfahrt"
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
            Me.Text = "Voreinstellungen"
            GroupBox1.Text = "Sprache"
            Label1.Text = "(Übersetzt ist nicht 100%.)"
            GroupBox2.Text = "Startseite"
            Button1.Text = "Übernehmen Current"
            Button2.Text = "Übernehmen Standard"
            OK_Button.Text = "Anwenden"
            Cancel_Button.Text = "Stornierung"
            GeckoPreferences.User("intl.accept_languages") = "de"
        End If
        Try
            My.Settings.Theme = ListView1.SelectedItems(0).Text
        Catch ex As Exception
        End Try
        My.Settings.Save()
        My.Settings.Save()
        My.Settings.Save()
        Me.Close()
        If My.Settings.Theme = "Windows Style" Then

            'text
            Form1.DocTitle.ForeColor = Color.Black

            'form
            Form1.BackgroundImage = Nothing
            Form1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable

            'buttonmain
            Form1.Button1.BackgroundImage = Nothing
            Form1.Button1.Text = "<"
            Form1.Button1.FlatStyle = FlatStyle.Standard
            Form1.Button2.BackgroundImage = Nothing
            Form1.Button2.Text = ">"
            Form1.Button2.FlatStyle = FlatStyle.Standard
            Form1.Button3.BackgroundImage = Nothing
            Form1.Button3.Text = "⟳"
            Form1.Button3.FlatStyle = FlatStyle.Standard
            Form1.Button6.BackgroundImage = Nothing
            Form1.Button6.Text = "+"
            Form1.Button6.FlatStyle = FlatStyle.Standard
            Form1.Button5.BackgroundImage = Nothing
            Form1.Button5.Text = "☰"
            Form1.Button5.FlatStyle = FlatStyle.Standard

            'buttoncm
            Form1.Button4.BackgroundImage = Nothing
            Form1.Button7.BackgroundImage = Nothing
            Form1.Button8.BackgroundImage = Nothing
            Form1.Button4.Text = "X"
            Form1.Button4.FlatStyle = FlatStyle.Standard
            Form1.Button7.Text = "+"
            Form1.Button7.FlatStyle = FlatStyle.Standard
            Form1.Button8.Text = "-"
            Form1.Button8.FlatStyle = FlatStyle.Standard

        ElseIf My.Settings.Theme = "Dark" Then

            'text
            Form1.DocTitle.ForeColor = Color.White

            'form
            Form1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\bg.png"))
            Form1.FormBorderStyle = Nothing

            'buttonmain
            Form1.Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\back.png"))
            Form1.Button1.Text = ""
            Form1.Button1.FlatStyle = FlatStyle.Flat
            Form1.Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\next.png"))
            Form1.Button2.Text = ""
            Form1.Button2.FlatStyle = FlatStyle.Flat
            Form1.Button3.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\reload.png"))
            Form1.Button3.Text = ""
            Form1.Button3.FlatStyle = FlatStyle.Flat
            Form1.Button6.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\addtab.png"))
            Form1.Button6.Text = ""
            Form1.Button6.FlatStyle = FlatStyle.Flat
            Form1.Button5.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\menu.png"))
            Form1.Button5.Text = ""
            Form1.Button5.FlatStyle = FlatStyle.Flat

            'buttoncm
            Form1.Button4.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\Close.png"))
            Form1.Button7.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\fullscreen.png"))
            Form1.Button8.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\minimize.png"))
            Form1.Button4.Text = ""
            Form1.Button4.FlatStyle = FlatStyle.Flat
            Form1.Button7.Text = ""
            Form1.Button7.FlatStyle = FlatStyle.Flat
            Form1.Button8.Text = ""
            Form1.Button8.FlatStyle = FlatStyle.Flat

        Else
            'text
            Form1.DocTitle.ForeColor = Color.Black

            'form
            Form1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\bg.png"))
            Form1.FormBorderStyle = Nothing

            'buttonmain
            Form1.Button1.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\back.png"))
            Form1.Button1.Text = ""
            Form1.Button1.FlatStyle = FlatStyle.Flat
            Form1.Button2.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\next.png"))
            Form1.Button2.Text = ""
            Form1.Button2.FlatStyle = FlatStyle.Flat
            Form1.Button3.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\reload.png"))
            Form1.Button3.Text = ""
            Form1.Button3.FlatStyle = FlatStyle.Flat
            Form1.Button6.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\addtab.png"))
            Form1.Button6.Text = ""
            Form1.Button6.FlatStyle = FlatStyle.Flat
            Form1.Button5.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\menu.png"))
            Form1.Button5.Text = ""
            Form1.Button5.FlatStyle = FlatStyle.Flat

            'buttoncm
            Form1.Button4.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\Close.png"))
            Form1.Button7.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\fullscreen.png"))
            Form1.Button8.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "themes\" & My.Settings.Theme & "\minimize.png"))
            Form1.Button4.Text = ""
            Form1.Button4.FlatStyle = FlatStyle.Flat
            Form1.Button7.Text = ""
            Form1.Button7.FlatStyle = FlatStyle.Flat
            Form1.Button8.Text = ""
            Form1.Button8.FlatStyle = FlatStyle.Flat

        End If
        My.Settings.Save()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        TextBox1.Text = Form1.TextBox1.Text
        On Error Resume Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error Resume Next
        TextBox1.Text = "file:\\\" & Application.StartupPath & "\data\htmldoc\new-tab.html"
        On Error Resume Next
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        Me.Font = New Font(font.Families(0), 9)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("spezappsthemes.weebly.com")
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        My.Settings.Homepage = "file:\\\" & Application.StartupPath & "\data\htmldoc\new-tab.html"
        My.Settings.Lang = "English"
        My.Settings.Theme = "Default"
        My.Settings.WelcomeScreen = True
        My.Settings.Save()
        Dim result As Integer = MessageBox.Show("The Spez Browser needs to be restarted to finish the process. Press ''OK'' to continue.", "Spez Browser", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If result = DialogResult.OK Then
            Application.Restart()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Settings.History.Clear()
        Library.ListBox1.Items.Clear()
        My.Settings.Save()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim CookieMan As nsICookieManager
        CookieMan = Xpcom.GetService(Of nsICookieManager)("@mozilla.org/cookiemanager;1")
        CookieMan = Xpcom.QueryInterface(Of nsICookieManager)(CookieMan)
        CookieMan.RemoveAll()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim CookieMan As nsICookieManager
        CookieMan = Xpcom.GetService(Of nsICookieManager)("@mozilla.org/cookiemanager;1")
        CookieMan = Xpcom.QueryInterface(Of nsICookieManager)(CookieMan)
        CookieMan.RemoveAll()
        My.Settings.History.Clear()
        Library.ListBox1.Items.Clear()
        My.Settings.Save()
        My.Settings.Homepage = "file:\\\" & Application.StartupPath & "\data\htmldoc\new-tab.html"
        My.Settings.Lang = "English"
        My.Settings.Theme = "Default"
        My.Settings.WelcomeScreen = True
        My.Settings.Save()
        Dim result As Integer = MessageBox.Show("The Spez Browser needs to be restarted to finish the process. Press ''OK'' to continue.", "Spez Browser", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If result = DialogResult.OK Then
            Application.Restart()
        End If
    End Sub
End Class
