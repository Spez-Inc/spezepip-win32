Imports Gecko

Public Class HTMLEdit

    Private Sub HTMLEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate(CType(Form1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Url)
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewToolStripMenuItem.Click
        WebBrowser1.DocumentText = RichTextBox1.Text
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Dim dlg As SaveFileDialog = New SaveFileDialog
            dlg.Title = "Save"
            dlg.Filter = "HTML|*.html"
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText)
            End If
        Catch ex As Exception
            MsgBox("Save Failed!", vbCritical, "Error")
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog
            dlg.Title = "Open"
            dlg.Filter = "HTML|*.html"
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.LoadFile(dlg.FileName)
                WebBrowser1.DocumentText = RichTextBox1.Text
            End If
        Catch ex As Exception
            MsgBox("Open Failed!", vbCritical, "Error")
        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        RichTextBox1.Text = WebBrowser1.DocumentText
    End Sub
End Class