Imports System.Drawing.Text
Imports System.Media

Public Class Form1
    Dim deletedatauser As Boolean

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.WindowState = 2 Then
            Me.WindowState = 0
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile(My.Computer.FileSystem.SpecialDirectories.Temp & "/Font.ttf")
        Me.Font = New Font(font.Families(0), 8)
        Label2.Font = New Font(font.Families(0), 18)
        Label3.Font = New Font(font.Families(0), 26)
    End Sub

    Private Sub btn_next_001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBar1.Size = New Size(403, 3)
        Label3.Text = ""
        Label4.Text = ""
        CheckBox1.Visible = False
        Button1.Visible = False
        Timer1.Enabled = True
        Label4.Visible = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 1 Then
            Label3.Text = "Now Uninstalling"
            Label4.Text = "Please Wait..."
        End If
        If ProgressBar1.Value = 25 Then
            removeappfromreg()
        End If
        If ProgressBar1.Value = 50 Then
            removeshortcut()
        End If
        If ProgressBar1.Value = 75 Then
            removefiles()
        End If
        If ProgressBar1.Value = 100 Then
            Dim Info As New ProcessStartInfo()
            Info.Arguments = "/C choice /C Y /N /D Y /T 3 & rd /s /q " + Application.StartupPath
            Info.WindowStyle = ProcessWindowStyle.Hidden
            Info.CreateNoWindow = True
            Info.FileName = "cmd.exe"
            Process.Start(Info)
            Process.Start("http://spezcomputer.weebly.com/spez-browser-basariyla-silindi.html")
            End
        End If
    End Sub

    Public Sub removeappfromreg()
        Try
            My.Computer.Registry.LocalMachine.DeleteSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\Spez Browser")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub removeshortcut()
        Try
            IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Spez Browser.lnk")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub removefiles()
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\data", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\themes", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\Geckofx-Core.dll", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\Geckofx-Winforms.dll", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\Spez Browser.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            If deletedatauser = False Then
                My.Computer.FileSystem.DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Spez", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                My.Computer.FileSystem.DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Geckofx", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Label3.Text = "Now Uninstalling" Then
            e.Cancel = True
            SystemSounds.Asterisk.Play()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            deletedatauser = True
        Else
            deletedatauser = False
        End If
    End Sub
End Class
