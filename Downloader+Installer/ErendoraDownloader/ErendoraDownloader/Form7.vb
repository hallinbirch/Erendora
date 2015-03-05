﻿Public Class Form7

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Close()
    End Sub

    Dim Shadow As Point
    Dim DragPosition As Point
    Public Sub Form7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Shadow = Me.Location
            DragPosition = Me.PointToScreen(New Point(e.X, e.Y))
        End If
    End Sub

    Public Sub Form7_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim CursorPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(Shadow.X + CursorPosition.X - DragPosition.X, _
            Shadow.Y + CursorPosition.Y - DragPosition.Y)
        End If
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.BackgroundImage = My.Resources.DownloaderCloseHover
    End Sub

    Private Sub Label9_MouseLeave(sender As Object, e As EventArgs) Handles Label9.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.DownloaderClose
    End Sub
End Class