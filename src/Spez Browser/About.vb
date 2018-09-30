Imports System.Windows.Forms
Imports System.Drawing.Text
Imports Gecko

Public Class About
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

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile("data/about-authors.rtf")
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        RichTextBox1.Font = New Font(font.Families(0), 8)
        Me.Font = New Font(font.Families(0), 8)
        Label1.Font = New Font(font.Families(0), 13, FontStyle.Bold)
        Label2.Font = New Font(font.Families(0), 10)
        Label3.Font = New Font(font.Families(0), 10)
        Label4.Font = New Font(font.Families(0), 10)
        Label5.Font = New Font(font.Families(0), 8)
        LinkLabel1.Font = New Font(font.Families(0), 8)
    End Sub

    Private Sub Button_Authors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RichTextBox1.Show()
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        'RichTextBox1.LoadFile("data/Authors.rtf")
        'RichTextBox1.Font = New Font(font.Families(0), 10)
    End Sub

    Private Sub Button_Lisence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' RichTextBox1.Show()
        Dim font As PrivateFontCollection = New PrivateFontCollection
        font.AddFontFile("data/Font.ttf")
        ' RichTextBox1.LoadFile("data/lisence.rtf")
        ' RichTextBox1.Font = New Font(font.Families(0), 10)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Navigate("https://www.gnu.org/licenses/gpl-3.0.en.html")
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.Click
        Close()
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = System.Windows.Forms.Cursor.Position.X - Me.Left
        mousey = System.Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If Not Form1.WindowState = FormWindowState.Maximized Then
            If drag Then
                Me.Top = System.Windows.Forms.Cursor.Position.Y - mousey
                Me.Left = System.Windows.Forms.Cursor.Position.X - mousex
                Dim args As String() = Environment.GetCommandLineArgs()
                If args.Contains("--priv") Then
                    PrivateForm1.Location = New Point(Me.Location.X + Me.Width \ 2 - Form1.Width \ 2, Me.Location.Y + Me.Height \ 2 - Form1.Height \ 2)
                Else
                    Form1.Location = New Point(Me.Location.X + Me.Width \ 2 - Form1.Width \ 2, Me.Location.Y + Me.Height \ 2 - Form1.Height \ 2)
                End If
            End If
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub Close_Button_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.MouseHover
        Close_Button.BackgroundImage = My.Resources.closehover
    End Sub

    Private Sub Close_Button_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close_Button.MouseLeave
        Close_Button.BackgroundImage = My.Resources.close
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.BackgroundImage = My.Resources.utabbuttonstart
        Button1.ForeColor = Color.Black
        Panel2.Visible = False

        Button2.BackgroundImage = My.Resources.tabbuttonend
        Button2.ForeColor = Color.White
        Panel3.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackgroundImage = My.Resources.tabbuttonstart
        Button1.ForeColor = Color.White
        Panel2.Visible = True

        Button2.BackgroundImage = My.Resources.utabbuttonend
        Button2.ForeColor = Color.Black
        Panel3.Visible = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class
