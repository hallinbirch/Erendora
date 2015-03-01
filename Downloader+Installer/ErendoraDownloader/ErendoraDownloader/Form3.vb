Public Class Form3

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
    End Sub

    Dim Shadow As Point
    Dim DragPosition As Point
    Public Sub Form3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Shadow = Me.Location
            DragPosition = Me.PointToScreen(New Point(e.X, e.Y))
        End If
    End Sub

    Public Sub Form3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim CursorPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(Shadow.X + CursorPosition.X - DragPosition.X, _
            Shadow.Y + CursorPosition.Y - DragPosition.Y)
        End If
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BackgroundImage = My.Resources.DownloadButtonCreditsHover
    End Sub

    ' Hover entfernen '
    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.DownloadButtonCredits
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form7.Show()
    End Sub

End Class