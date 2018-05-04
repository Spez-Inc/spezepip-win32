Imports System.Windows.Forms
Imports System.Drawing.Text

Public Class About

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Hide()
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        Me.Font = New Font(font.Families(0), 10)
        Label1.Font = New Font(font.Families(0), 13, FontStyle.Bold)
        Label2.Font = New Font(font.Families(0), 10)
        Label3.Font = New Font(font.Families(0), 10)
        Label4.Font = New Font(font.Families(0), 10)
    End Sub

    Private Sub Button_Authors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Authors.Click
        RichTextBox1.Show()
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        RichTextBox1.LoadFile("data/Authors.rtf")
        RichTextBox1.Font = New Font(font.Families(0), 10)
    End Sub

    Private Sub Button_Lisence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Lisence.Click
        RichTextBox1.Show()
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        RichTextBox1.LoadFile("data/lisence.rtf")
        RichTextBox1.Font = New Font(font.Families(0), 10)
    End Sub
End Class
