Imports System.IO
Imports System.Drawing.Text

Public Class MoveTool
    Dim s As Integer = 0

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PictureBox1.Image = My.Resources.aaaa
        Label1.Text = "1: Open Google Chrome and Click Customize and Control Google Chrome menu." & vbNewLine & vbNewLine & "2: Click Bookmarks and select Bookmarks manager." & vbNewLine & vbNewLine & "3: Tab on Organize > Export bookmarks to HTML file." & vbNewLine & vbNewLine & "4: Select a location and click Save." & vbNewLine & vbNewLine & "5: Close the Chrome and click 'Next' on bookmark import wizard."
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PictureBox1.Image = My.Resources.aaa
        Label1.Text = "1: Open Mozilla Firefox and Open bookmarks by" & vbNewLine & "Control + Shift + B." & vbNewLine & vbNewLine & "2: Click Import and Backup at the top of the screen, and from the drop down menu click on Export Bookmarks to HTML." & vbNewLine & vbNewLine & "3: Select a location and click Save." & vbNewLine & vbNewLine & "4: Close the Firefox and click 'Next' on bookmark import wizard."
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If s = 0 Then
            S1.Visible = True
            S2.Visible = False
            S3.Visible = False
            Back_button.Enabled = False
            Next_button.Enabled = True
            Next_button.Text = "Next >"
        ElseIf s = 1 Then
            S1.Visible = True
            S2.Visible = True
            S3.Visible = False
            Back_button.Enabled = True
            Next_button.Enabled = False
            Next_button.Text = "Import"
            If Label4.Text = "File: not selected" Then
                Next_button.Enabled = False
            Else
                Next_button.Enabled = True
            End If
        ElseIf s = 2 Then
            Try
                WebBrowser1.Navigate(OpenFileDialog1.FileName)
            Catch ex As Exception
            End Try
            Back_button.Enabled = False
            S1.Visible = True
            S2.Visible = True
            S3.Visible = True
            Next_button.Text = "Exit"
            Next_button.Enabled = False
            If ProgressBar1.Value = 100 Then
                Next_button.Enabled = True
                Label5.Text = "Imported!"
            End If
        ElseIf s >= 3 Then
            Me.Close()
            Me.Refresh()
            s = 0
        End If
    End Sub

    Public Sub ImportBookmarks()
        If RichTextBox1.Text = "" Then
            For Each Ele As HtmlElement In WebBrowser1.Document.GetElementsByTagName("a")
                Dim s As String = Ele.GetAttribute("href")
                If Not s.StartsWith("place") Then
                    If Not My.Settings.Bookmarks.Contains(s) Then
                        My.Settings.Bookmarks.Add(s)
                        RichTextBox1.AppendText("Bookmark ''" & s & "' added." & vbNewLine)
                    Else
                        RichTextBox1.AppendText("Bookmark ''" & s & "' skipped. So, don't add it." & vbNewLine)
                    End If
                End If
            Next
        End If
        RichTextBox1.AppendText("Finished.")
        My.Settings.Save()
        Library.ListBox2.Items.Clear()
        For Each item In My.Settings.Bookmarks
            Library.ListBox2.Items.Add(item)
        Next
        ProgressBar1.Value = 100
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Next_button_Click(sender As Object, e As EventArgs) Handles Next_button.Click
        s = s + 1
    End Sub

    Private Sub Back_button_Click(sender As Object, e As EventArgs) Handles Back_button.Click
        s = s - 1
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Label4.Text = "File: " & OpenFileDialog1.FileName
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If RichTextBox1.Text = "" Then
            ImportBookmarks()
        End If
    End Sub

    Private Sub MoveTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        Me.Font = New Font(font.Families(0), 8)
        T1.Font = New Font(font.Families(0), T1.Font.Size)
        Label1.Font = New Font(font.Families(0), Label1.Font.Size)
        Label2.Font = New Font(font.Families(0), Label2.Font.Size)
        Label3.Font = New Font(font.Families(0), Label3.Font.Size)
        Label4.Font = New Font(font.Families(0), Label4.Font.Size)
        Label5.Font = New Font(font.Families(0), Label5.Font.Size)
    End Sub
End Class