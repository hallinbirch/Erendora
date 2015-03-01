' Imports die benötigt werden '
Imports System.Net

Public Class Form1

    ' Deklarationen für den Downloader '
    Public WithEvents downloader As WebClient
    Private Info As ToolTip = New ToolTip()

    ' Browse Button ' 
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim Speichern = New FolderBrowserDialog
        Speichern.ShowDialog()
        Me.TextBox1.Text = Speichern.SelectedPath & "\ErendoraV2.zip"
    End Sub

    ' Download Button '
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ' Verändert auf "Please select a directory for installation!" '
        If Me.TextBox1.Text <> "Please select a directory for installation!" Then
            downloader = New WebClient
            downloader.DownloadFileAsync(New Uri("http://151.80.117.25/ErendoraV2.zip"), TextBox1.Text)
            Me.PictureBox1.Enabled = False
        Else
            Form2.Show()
        End If
    End Sub

    ' Progressbar nach download wieder auf "0" setzen '
    Private Sub downloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        Form5.Show()
        Me.PictureBox9.Width = 544
        Me.Label2.Text = "0 GB von 0 BG"
        Me.Label3.Text = "0 %"
        Me.PictureBox1.Enabled = True
    End Sub

    ' Progressbar durchlaufen lassen '
    Private Sub downloader_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        ' Picture durchlaufen lassen '
        PictureBox9.Width = 544
        Me.PictureBox9.Width = e.ProgressPercentage * 5.44
        Me.Label2.Text = Format((e.BytesReceived / 10 ^ 9), "0.000") & " von " & Format((e.TotalBytesToReceive / 10 ^ 9), "0.00") & "GB"
        Me.Label3.Text = e.ProgressPercentage & "%"
    End Sub

    ' Close Button ' 
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Form4.Show()
    End Sub

    ' Minimier Button '
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        MyBase.WindowState = FormWindowState.Minimized
    End Sub

    ' Beweglichkeit des Downloaders '
    Dim Shadow As Point
    Dim DragPosition As Point
    Public Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Shadow = Me.Location
            DragPosition = Me.PointToScreen(New Point(e.X, e.Y))
        End If
    End Sub

    Public Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim CursorPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(Shadow.X + CursorPosition.X - DragPosition.X, _
            Shadow.Y + CursorPosition.Y - DragPosition.Y)
        End If
    End Sub

    ' Bowse Box text verbieten '
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Me.TextBox1.Enabled = False
    End Sub

    ' Browse Button Hover + ToolTip '
    Private Sub PictureBox2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.BackgroundImage = My.Resources.DownloaderBrowseHover
        Me.Info.SetToolTip(Me.PictureBox2, "Please select the Installations directory")
    End Sub

    ' Browse Button Hover entfernen ' 
    Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BackgroundImage = My.Resources.DownloaderBrowse
    End Sub

    ' Download Button Hover + ToolTip '
    Private Sub PictureBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BackgroundImage = My.Resources.DownloadButtonHover
        Me.Info.SetToolTip(Me.PictureBox1, "Download Now!")
    End Sub

    ' Download Button Hover entfernen '
    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackgroundImage = My.Resources.DownloadButton
    End Sub

    ' Close Button Hover + ToolTip ' 
    Private Sub PictureBox3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BackgroundImage = My.Resources.DownloaderCloseHover
        Me.Info.SetToolTip(Me.PictureBox3, "Close the Program")
    End Sub

    ' Close Button Hover entfernen '
    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.DownloaderClose
    End Sub

    ' Minimize Button Hover + ToolTip' 
    Private Sub PictureBox4_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.BackgroundImage = My.Resources.DownloadMiniHover
        Me.Info.SetToolTip(Me.PictureBox4, "Minimize")
    End Sub

    ' Minimize Button Hover entfernen '
    Private Sub PictureBox4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.BackgroundImage = My.Resources.DownloadMini
    End Sub

    ' ToolTip für den Button I "Informationen" + Hover '
    Private Sub PictureBox5_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox5.BackgroundImage = My.Resources.DownloaderInfoHover
        Me.Info.SetToolTip(Me.PictureBox5, "See the Copyright and Information")
    End Sub

    ' Informations Button Hover '
    Private Sub PictureBox5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.BackgroundImage = My.Resources.DownloaderInfo
    End Sub

    ' Informations Fenster '
    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Form3.Show()
    End Sub

    ' Homepage Buttton die Verlinkung '
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        System.Diagnostics.Process.Start("http://erendora.org")
    End Sub

    ' Homepage Button Hover + ToolTip '
    Private Sub PictureBox7_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseHover
        PictureBox7.BackgroundImage = My.Resources.DownloadButtonHomeHover
        Me.Info.SetToolTip(Me.PictureBox7, "Go to the Website")
    End Sub

    ' Homepage Button Hover entfernen '
    Private Sub PictureBox7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        PictureBox7.BackgroundImage = My.Resources.DownloadButtonHome
    End Sub

    ' Wenn Fenster geöffnet wird soll Progressbar auf 0 Gesetzt werden '
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox9.Width = 0
    End Sub

End Class



