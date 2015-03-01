Imports ErendoraDownloader.Form1
Imports Ionic.Zip
Imports System.Net
Imports System.IO
Imports System.IO.Compression

Public Class Installer
    Dim Zip As String
    Dim Ordner As String

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MyBase.WindowState = FormWindowState.Minimized
    End Sub

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
            ProgressBar1.Visible = True
            Label1.Visible = True
            Label3.Visible = True
            TextBox1.Visible = False
            PictureBox6.Visible = False

            'Zip = Form1.TextBox1.Text
            Dim pathOfErendoraZIP As String = Form1.TextBox1.Text




            Using zip As ZipFile = ZipFile.Read(pathOfErendoraZIP)
                AddHandler zip.ExtractProgress, AddressOf MyextractProgress

                Dim entry As ZipEntry
                For Each entry In zip
                    entry.Extract(TextBox1.Text, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using

        Else
            Form2.Show()
        End If
    End Sub

    Private Sub PictureBox5_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox5.BackgroundImage = My.Resources.DownloadButtonBackHover
    End Sub


    Private Sub PictureBox5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.BackgroundImage = My.Resources.DownloadButtonBack
    End Sub


    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        ProgressBar1.Visible = False
        Label1.Visible = False
        Label3.Visible = False
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        SaveFileDialog1.ShowDialog()
        TextBox1.Text = SaveFileDialog1.FileName
    End Sub

    Private Sub MyextractProgress(ByVal sender As Object, ByVal e As ExtractProgressEventArgs)
        If e.BytesTransferred > 0 AndAlso e.TotalBytesToTransfer > 0 Then
            Me.Invoke(Sub() ProgressBar1.Value = CInt(e.BytesTransferred * 100 \ e.TotalBytesToTransfer))
        End If
    End Sub
End Class