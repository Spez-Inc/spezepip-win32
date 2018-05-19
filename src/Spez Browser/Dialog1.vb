Imports System.Windows.Forms
Imports System.Drawing.Text
Imports System.IO
Imports Gecko

Public Class Dialog1

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
            Form1.SettingsStripMenuItem1.Text = "Ayarlar"
            Form1.AboutSpezBrowserToolStripMenuItem.Text = "Spez Browser Hakkında"
            Form1.ExitToolStripMenuItem.Text = "Çık"
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
            Me.Text = "Ayarlar"
            GroupBox1.Text = "Dil"
            Label1.Text = "(Çeviriler %100 Değildir.)"
            GroupBox2.Text = "Ana Sayfa"
            Button1.Text = "Geçerli Olanı Uygula"
            Button2.Text = "Varsayılanı Uygula"
            OK_Button.Text = "Uygula"
            Cancel_Button.Text = "İptal"
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
            Form1.SettingsStripMenuItem1.Text = "Settings"
            Form1.AboutSpezBrowserToolStripMenuItem.Text = "About Spez Browser"
            Form1.ExitToolStripMenuItem.Text = "Exit"
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
            Me.Text = "Settings"
            GroupBox1.Text = "Language"
            Label1.Text = "(Translations are not 100%.)"
            GroupBox2.Text = "Homepage"
            Button1.Text = "Use Current"
            Button2.Text = "Use Deafult"
            OK_Button.Text = "Apply"
            Cancel_Button.Text = "Cancel"
        End If
        Try
            My.Settings.Theme = ListView1.SelectedItems(0).Text
        Catch ex As Exception
        End Try
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
End Class
