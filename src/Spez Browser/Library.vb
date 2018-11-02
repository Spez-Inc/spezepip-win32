Imports System.Drawing.Text
Imports Gecko

Public Class Library

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.History.Remove(ListBox1.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(ListBox1.SelectedItem)
        Try
            CType(PrivateForm1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(ListBox1.SelectedItem)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Library_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        Me.Font = New Font(font.Families(0), 9)
        For Each item In My.Settings.History
            ListBox1.Items.Add(item)
        Next
        For Each item In My.Settings.Bookmarks
            ListBox2.Items.Add(item)
        Next
        For Each item In My.Settings.Favorites
            ListBox3.Items.Add(item)
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        My.Settings.Bookmarks.Remove(ListBox2.SelectedItem)
        ListBox2.Items.Remove(ListBox2.SelectedItem)
        My.Settings.Save()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(ListBox2.SelectedItem)
        Try
            CType(PrivateForm1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(ListBox2.SelectedItem)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(ListBox3.SelectedItem)
        Try
            CType(PrivateForm1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate(ListBox3.SelectedItem)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        My.Settings.Favorites.Remove(ListBox3.SelectedItem)
        ListBox3.Items.Remove(ListBox3.SelectedItem)
        My.Settings.Save()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MoveTool.Dispose()
        MoveTool.ShowDialog()
    End Sub
End Class