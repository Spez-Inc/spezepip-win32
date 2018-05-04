Imports System.Drawing.Text
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports IWshRuntimeLibrary
Imports System.Media

Public Class Form1

    Dim a As String
    Dim b As String
    Dim c As New TextBox
    Dim d As String
    Dim e1 As Boolean
    Dim client As New WebClient

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Info.OSFullName.Contains("Windows XP") Then
            MsgBox("Spez Browser cannot be installed on Windows XP and Vista.", vbCritical, "Sorry for that.")
            End
        End If
        If My.Computer.Info.OSFullName.Contains("Windows Vista") Then
            MsgBox("Spez Browser cannot be installed on Windows XP and Vista.", vbCritical, "Sorry for that.")
            End
        End If
        IO.File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "/Font.ttf", My.Resources.Font)
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile(My.Computer.FileSystem.SpecialDirectories.Temp & "/Font.ttf")
        Me.Font = New Font(font.Families(0), 8)
        Label2.Font = New Font(font.Families(0), 18)
        Label3.Font = New Font(font.Families(0), 26)
        My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 1 Then
            Label3.Text = "Now installing"
            Label4.Text = "2 times faster than older version."
        End If
        If ProgressBar1.Value = 24 Then
            Label4.Text = ""
        End If
        If ProgressBar1.Value = 25 Then
            Label4.Text = "Customize the look with themes."
            copyfiles()
        End If
        If ProgressBar1.Value = 49 Then
            Label4.Text = ""
        End If
        If ProgressBar1.Value = 50 Then
            Label4.Text = "Navigate hidden with Private Browsing."
            createshortcutstart()
        End If
        If ProgressBar1.Value = 74 Then
            Label4.Text = ""
        End If
        If ProgressBar1.Value = 75 Then
            Label4.Text = "Same Spez Browser, just better."
            installappinreg()
        End If
        If ProgressBar1.Value = 100 Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\version.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            RunExe()
            End
        End If
    End Sub

    Public Sub RunExe()
        Dim p As Process = New Process()
        p.StartInfo.FileName = "Spez Browser.exe"
        p.StartInfo.WorkingDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\"
        p.Start()
    End Sub

    Public Sub geturl()
        a = "http://download"
        c.Text = WebBrowser1.DocumentText
        b = InStr(c.Text, a)
        If b Then
            c.Focus()
            c.SelectionStart = b - 1
            c.SelectionLength = Len(a) + 64
            d = c.SelectedText
            downloadzip()
        Else
            WebBrowser1.Navigate("about:blank")
            Label3.Text = "Uh oh!"
            Label4.Text = "Failed getting the required files. Please connect to network and restart installer!"
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub downloadzip()
        client.DownloadFileAsync(New Uri(c.SelectedText), My.Computer.FileSystem.SpecialDirectories.Temp + "\spez-browser.zip")
        AddHandler client.DownloadFileCompleted, AddressOf DownloadComplete
    End Sub

    Public Sub DownloadComplete()
        ProgressBar1.Style = ProgressBarStyle.Continuous
        Label3.Text = ""
        Label4.Text = ""
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Public Sub createshortcutstart()
        'Creating Path String, Shortcut Dim and WshShell
        Dim WshShell As WshShell = New WshShell()
        Dim ShortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Programs)
        Dim Shortcut As IWshShortcut = CType(WshShell.CreateShortcut(System.IO.Path.Combine(ShortcutPath, "Spez Browser") & ".lnk"), IWshShortcut)

        'Setting Values
        Shortcut.TargetPath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\Spez Browser.exe"
        Shortcut.WorkingDirectory = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser"
        Shortcut.Description = "Launch to the web."

        'Saving Shortcut
        Shortcut.Save()
    End Sub

    Public Sub copyfiles()
        'Creating Shell32
        Dim sc As New Shell32.Shell

        'Extracted To:
        Dim output As Shell32.Folder = sc.NameSpace(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser")

        'This File To Extract:
        Dim input As Shell32.Folder = sc.NameSpace(My.Computer.FileSystem.SpecialDirectories.Temp & "\spez-browser.zip")

        'Extracting Process
        output.CopyHere(input.Items, 4 + 16)
    End Sub

    Public Sub installappinreg()
        'Setting Values
        Dim ApplicationName As String = "Spez Browser"
        Dim ApplicationVersion As String = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\version.txt")
        Dim ApplicationIcon As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\Spez Browser.exe,0"
        Dim ApplicationPublisher As String = "Spez Inc."
        Dim HelpSitelink As String = "http://spezcomputerhelp.weebly.com/"
        Dim Sitelink As String = "http://spezcomputer.weebly.com/"
        Dim NoModifyApp As Integer = 1
        Dim NoRepairApp As Integer = 1
        Dim ApplicationInstallDirectory As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\"
        Dim ApplicationUninstall As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Spez Apps\Spez Browser\uninstall.exe"

        'Opening the Uninstall Registry Key
        With My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall", True)

            'Creating AppRegistryKey
            Dim AppKey As Microsoft.Win32.RegistryKey = .CreateSubKey(ApplicationName)

            'Adding values to AppRegistryKey
            AppKey.SetValue("DisplayName", ApplicationName, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("DisplayVersion", ApplicationVersion, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("DisplayIcon", ApplicationIcon, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("Publisher", ApplicationPublisher, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("UninstallString", ApplicationUninstall, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("InstallLocation", ApplicationInstallDirectory, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("HelpLink", HelpSitelink, Microsoft.Win32.RegistryValueKind.String)
            AppKey.SetValue("NoModify", NoModifyApp, Microsoft.Win32.RegistryValueKind.DWord)
            AppKey.SetValue("NoRepair", NoRepairApp, Microsoft.Win32.RegistryValueKind.DWord)
            AppKey.SetValue("URLInfoAbout", Sitelink, Microsoft.Win32.RegistryValueKind.String)
            AppKey.Close()

        End With
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.WindowState = 2 Then
            Me.WindowState = 0
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Label3.Text = "Now installing" Then
            e.Cancel = True
            SystemSounds.Asterisk.Play()
        ElseIf Label3.Text = "Uh oh!" Then
            End
        Else
            Select Case MsgBox("Do you want to cancel the installation?", MsgBoxStyle.YesNo + MessageBoxIcon.Asterisk, "Spez Browser Installer")
                Case MsgBoxResult.Yes
                    End
                Case MsgBoxResult.No
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        e1 = True
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If e1 = True Then
            Timer3.Enabled = False
            geturl()
        End If
    End Sub
End Class
