' Imports des Installers '
Imports ErendoraDownloader.Form1
Imports Ionic.Zip
Imports System.Net
Imports System.IO
Imports System.IO.Compression

Public Class Installer
    ' Deklaationen die benötigt werden ' 
    Dim Zip As String
    Dim Ordner As String

    ' Close Button untem im Fenster '
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
    End Sub

    ' Close Button oben im Fenster '
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Form8.Show()
    End Sub

    ' Minimize Button '
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MyBase.WindowState = FormWindowState.Minimized
    End Sub

    ' Beweglichkeit des Fensters '
    Dim Shadow As Point
    Dim DragPosition As Point
    Public Sub Installer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Shadow = Me.Location
            DragPosition = Me.PointToScreen(New Point(e.X, e.Y))
        End If
    End Sub

    Public Sub Installer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim CursorPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(Shadow.X + CursorPosition.X - DragPosition.X, _
            Shadow.Y + CursorPosition.Y - DragPosition.Y)
        End If
    End Sub

    ' Wenn Next geklickt wurde '
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If Me.TextBox1.Text <> "Please select a directory for installation!" Then
            ' Picture Box einblenden '
            PictureBox7.Visible = True
            PictureBox8.Visible = True
            ' Istall Text einblenden '
            InstallText.Visible = True
            Label1.Visible = True
            Label3.Visible = True
            ' Browse Button und Text Box ausblenden '
            TextBox1.Visible = False
            PictureBox6.Visible = False

            ' Sucht die den Speicherort uas Form1 (Downloader) '
            Dim pathOfErendoraZIP As String = Form1.TextBox1.Text



            ' Entpackt die Zip oder 7z Datei '
            Using zip As ZipFile = ZipFile.Read(pathOfErendoraZIP)
                AddHandler zip.ExtractProgress, AddressOf MyextractProgress

                Dim entry As ZipEntry
                For Each entry In zip
                    entry.Extract(TextBox1.Text, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using
            ' Wenn Textbox leer ist oder "Please select a directory for installation!" Zeigt fehler '
        Else
            Form2.Show()
        End If
    End Sub

    ' Back Button Hover '
    Private Sub PictureBox5_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox5.BackgroundImage = My.Resources.DownloadButtonBackHover
    End Sub

    ' Back Button Hover entfernen '
    Private Sub PictureBox5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.BackgroundImage = My.Resources.DownloadButtonBack
    End Sub

    ' Back Button '
    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        ' Progressbar ausblenden '
        PictureBox8.Visible = False
        PictureBox7.Visible = False
        ' Texte aufblenden '
        Label1.Visible = False
        Label3.Visible = False
        ' Browse Box anzeigen '
        PictureBox6.Visible = True
        TextBox1.Visible = True
    End Sub

    ' Browse Button '
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Dim Speichern = New FolderBrowserDialog
        Speichern.ShowDialog()
        Me.TextBox1.Text = Speichern.SelectedPath & "\Erendora\"
    End Sub

    Private Sub MyextractProgress(ByVal sender As Object, ByVal e As ExtractProgressEventArgs)
        ' Progressbar Größe '
        PictureBox8.Width = 544
        ' Progressbar soll Fortschritt anzeigen '
        If e.BytesTransferred > 0 AndAlso e.TotalBytesToTransfer > 0 Then
            ' Me.Invoke(Sub() PictureBox8.Width = CInt(e.BytesTransferred * 100 \ e.TotalBytesToTransfer)) '
            Me.PictureBox8.Width = e.BytesTransferred * 100 \ e.TotalBytesToTransfer
        End If
    End Sub

    ' Close Button Oben Hover '
    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BackgroundImage = My.Resources.DownloadButtonCancelHover
    End Sub

    ' Close Button Oben Hover entfernen '
    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.DownloadButtonCancel
    End Sub

    ' Close Button Hover '
    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BackgroundImage = My.Resources.DownloaderCloseHover
    End Sub

    ' Close Button Hover entfernen ' 
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackgroundImage = My.Resources.DownloaderClose
    End Sub

    ' Minimize Button Hover ' 
    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.BackgroundImage = My.Resources.DownloadMiniHover
    End Sub

    ' Minimize Button Hover entfernen ' 
    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BackgroundImage = My.Resources.DownloadMini
    End Sub

    ' Next Button Hover '
    Private Sub PictureBox4_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.BackgroundImage = My.Resources.DownloadButtonNextHover
    End Sub

    ' Next Button Hover entfernen '
    Private Sub PictureBox4_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.BackgroundImage = My.Resources.DownloadButtonNext
    End Sub

    Private Sub Installer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Textbox + Browse Button anzeigen lassen '
        PictureBox6.Visible = True
        TextBox1.Visible = True
        ' Form 5 Schließen, da sie nicht mehr benötigt wird '
        Form5.Close()
    End Sub
End Class