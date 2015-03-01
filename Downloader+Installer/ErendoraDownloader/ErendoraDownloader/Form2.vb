Public Class Form2

    ' Close Button '
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
    End Sub

    ' Beweglichkeit des Fensters '
    Dim Shadow As Point
    Dim DragPosition As Point
    Public Sub Form2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Shadow = Me.Location
            DragPosition = Me.PointToScreen(New Point(e.X, e.Y))
        End If
    End Sub

    Public Sub Form2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim CursorPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(Shadow.X + CursorPosition.X - DragPosition.X, _
            Shadow.Y + CursorPosition.Y - DragPosition.Y)
        End If
    End Sub

    ' Ok Button Hover '
    Private Sub PictureBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BackgroundImage = My.Resources.DownloadButtonOkHover
    End Sub

    ' Ok Button Hover entfernen '
    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackgroundImage = My.Resources.DownloadButtonOk
    End Sub

    ' Ok Button Funktion '
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Close()
    End Sub

    ' Close Button Hover '
    Private Sub PictureBox3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BackgroundImage = My.Resources.DownloaderCloseHover
    End Sub

    ' Close Button Hover entfernen '
    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.DownloaderClose
    End Sub

End Class