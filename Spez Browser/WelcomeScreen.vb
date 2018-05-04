Imports System.Drawing.Text

Public Class WelcomeScreen
    Dim font1 As PrivateFontCollection = New PrivateFontCollection
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim lang As String
    Dim a As Integer
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

    Private Sub Close_Button_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.MouseHover
        Close_Button.BackgroundImage = My.Resources.closehover
    End Sub

    Private Sub Close_Button_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close_Button.MouseLeave
        Close_Button.BackgroundImage = My.Resources.close
    End Sub

    Private Sub Minimize_Button_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Minimaze_Button.MouseHover
        Minimaze_Button.BackgroundImage = My.Resources.minimizehover
    End Sub

    Private Sub Minimize_Button_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Minimaze_Button.MouseLeave
        Minimaze_Button.BackgroundImage = My.Resources.minimize
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub WelcomeScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        font1.AddFontFile("data/Font.ttf")
        Label1.Font = New Font(font1.Families(0), 1, FontStyle.Bold)
        Label4.Font = New Font(font1.Families(0), 1, FontStyle.Bold)
        Label2.Font = New Font(font1.Families(0), 1)
        Label3.Font = New Font(font1.Families(0), 1)
        Button1.Font = New Font(font1.Families(0), 10)
        Button2.Font = New Font(font1.Families(0), 10)
        Me.Font = New Font(font1.Families(0), 8)
    End Sub

    Private Sub Close_Button_Click(sender As System.Object, e As System.EventArgs) Handles Close_Button.Click
        End
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Minimaze_Button.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Visible = True
        Label2.Visible = True
        Try
            If Label2.Font.Size >= 8 Then
                Label2.Font = New Font(font1.Families(0), 8)
            End If
            If Label1.Font.Size >= 22 Then
                Timer1.Interval = Timer1.Interval + 25
            End If
            If Label1.Font.Size = 22 Then
                Button1.Visible = True
                Button2.Visible = True
            End If
            If Label1.Font.Size = 24 Then
                Timer1.Enabled = False
                Timer1.Interval = 1
            End If
            Label1.Font = New Font(font1.Families(0), Label1.Font.Size + 1, FontStyle.Bold)
            Label2.Font = New Font(font1.Families(0), Label2.Font.Size + 0.3)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Try
            If Label2.Font.Size = 1 Then
                Label2.Visible = False
            End If
            If Label1.Font.Size = 1 Then
                Timer1.Enabled = False
                Timer1.Stop()
            End If
            If Timer1.Interval < 10 Then
                Timer1.Interval = Timer1.Interval + 1
            End If
            If Label1.Font.Size >= 19 Then
                Timer1.Interval = Timer1.Interval + 5
            End If
            If Label1.Font.Size = 22 Then
                Button1.Visible = False
                Button2.Visible = False
            End If
            If Label1.Font.Size = 5 Then
                Timer1.Enabled = False
                Label1.Visible = False
                Label2.Visible = False
                Timer3.Enabled = True
                Timer3.Start()
                Timer2.Interval = 1
            End If
            Label1.Font = New Font(font1.Families(0), Label1.Font.Size - 1, FontStyle.Bold)
            Label2.Font = New Font(font1.Families(0), Label2.Font.Size - 0.3)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer2.Enabled = True
        lang = "en"

        Label4.Text = "Welcome To Spez Browser!"
        Label3.Text = "You Finally Found The Fastest, Advanced And Best Web Browser!"
        btn_next_001.Text = "Next"
        Timer3.Interval = 1
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Timer2.Enabled = True
        lang = "tr"

        Label4.Text = "Spez Browser'e Hoşgeldiniz!"
        Label3.Text = "Sonunda Hızlı, Gelişmiş Ve En İyi Web Tarayıcıyı Buldun!"
        btn_next_001.Text = "İleri"
        Timer3.Interval = 1
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Label3.Visible = True
        Label4.Visible = True
        Try
            If Label3.Font.Size >= 8 Then
                Label3.Font = New Font(font1.Families(0), 8)
            End If
            If Label4.Font.Size >= 22 Then
                Timer3.Interval = Timer1.Interval + 15
            End If
            If Label4.Font.Size = 22 Then
                PictureBox1.Visible = True
                btn_next_001.Visible = True
                btn_next_001.Show()
            End If
            If Label4.Font.Size = 24 Then
                Timer3.Enabled = False
                Timer3.Interval = 1
            End If
            Label4.Font = New Font(font1.Families(0), Label4.Font.Size + 1, FontStyle.Bold)
            Label3.Font = New Font(font1.Families(0), Label3.Font.Size + 0.6)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        Try
            If Label3.Font.Size = 1 Then
                Label3.Visible = False
            End If
            If Label4.Font.Size = 1 Then
                Timer3.Enabled = False
                Timer3.Stop()
            End If
            If Timer3.Interval < 10 Then
                Timer3.Interval = Timer3.Interval + 0.5
            End If
            If Label4.Font.Size >= 19 Then
                Timer3.Interval = Timer3.Interval + 1
            End If
            If Label4.Font.Size = 22 Then
                PictureBox1.Hide()
                btn_next_001.Hide()
            End If
            If Label4.Font.Size = 1 Then
                Timer3.Enabled = False
                Label4.Visible = False
                Label3.Visible = False
                If a = 2 Then
                    If lang = "en" Then
                        Label4.Text = "Faster Than Ohter Browsers."
                        Label3.Text = "Try Spez Browser. Spez Browser Opens Fast And Loads Pages Fast. So You Can Save Time."
                        PictureBox1.BackgroundImage = My.Resources.ss2
                    Else
                        Label4.Text = "Diğer Tarayıcılardan Daha Hızlı."
                        Label3.Text = "Spez Browser'ı Dene. Spez Browser Hem Hızlı Açılır Hemde Sayfaları Hızlı Yükler." & vbNewLine & " Böylece Zamandan Tasarruf Edersin."
                        PictureBox1.BackgroundImage = My.Resources.ss2
                    End If
                End If
                If a = 3 Then
                    If lang = "en" Then
                        Label4.Text = "Your Spez Browser Is Everywhere!"
                        Label3.Text = "The Spez Browser also has a Phone and Tablet (Mobile) Version. So you can" & vbNewLine & "experience the Spez Browser in the Time of the Computer." & vbNewLine & vbNewLine & "Download from here: ''http://spezcomputer.weebly.com/spez-browser.html''"
                        PictureBox1.BackgroundImage = My.Resources.ss3
                        btn_next_001.Text = "Start"
                    Else
                        Label4.Text = "Senin Spez Browser'ın Her Yerde!"
                        Label3.Text = "Spez Browser'ın Ayrıca Telefon ve Tablet (Mobil) Versiyonu da bulunur. Böylece" & vbNewLine & "Bilgisayarın Olmadağı Zamanlarda da Spez Browser Keyifini de yaşayabilirsin." & vbNewLine & vbNewLine & "Buradan İndir: ''http://spezcomputer.weebly.com/spez-browser.html''"
                        PictureBox1.BackgroundImage = My.Resources.ss3
                        btn_next_001.Text = "Başla"
                    End If
                End If
                If a = 4 Then
                    If lang = "en" Then
                        My.Settings.Lang = "English"
                        My.Settings.WelcomeScreen = False
                        My.Settings.Homepage = "file:\\\" & Application.StartupPath & "\data\htmldoc\new-tab.html"
                        My.Settings.Save()
                        My.Settings.Save()
                        My.Settings.Save()
                        Threading.Thread.Sleep(1000)
                        Application.Restart()
                    Else
                        My.Settings.Lang = "Türkçe"
                        My.Settings.Homepage = "file:\\\" & Application.StartupPath & "\data\htmldoc\new-tab.html"
                        My.Settings.WelcomeScreen = False
                        My.Settings.Save()
                        My.Settings.Save()
                        My.Settings.Save()
                        Threading.Thread.Sleep(1000)
                        Application.Restart()
                    End If
                End If
                Timer4.Enabled = False
                Timer5.Enabled = True
                Timer5.Start()
                Timer4.Interval = 1
            End If
            Label4.Font = New Font(font1.Families(0), Label4.Font.Size - 1, FontStyle.Bold)
            Label3.Font = New Font(font1.Families(0), Label3.Font.Size - 0.3)
        Catch ex As Exception
        End Try
        End Sub

    Private Sub btn_next_001_Click(sender As System.Object, e As System.EventArgs) Handles btn_next_001.Click
        If a = 0 Then
            a = 1
        End If
        a = a + 1
        Timer5.Interval = 1
        Timer4.Interval = 1
        Timer4.Enabled = True
        Timer4.Start()
    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        Label3.Visible = True
        Label4.Visible = True
        Try
            If Label3.Font.Size >= 8 Then
                Label3.Font = New Font(font1.Families(0), 8)
            End If
            If Label4.Font.Size >= 22 Then
                Timer5.Interval = Timer1.Interval + 15
            End If
            If Label4.Font.Size = 22 Then
                PictureBox1.Visible = True
                btn_next_001.Visible = True
                btn_next_001.Show()
            End If
            If Label4.Font.Size = 24 Then
                Timer5.Enabled = False
                Timer5.Interval = 1
                Timer5.Interval = 1
                Timer5.Interval = 1
            End If
            Label4.Font = New Font(font1.Families(0), Label4.Font.Size + 1, FontStyle.Bold)
            Label3.Font = New Font(font1.Families(0), Label3.Font.Size + 0.6)
        Catch ex As Exception
        End Try
    End Sub
End Class