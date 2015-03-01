Public Class Form8

    ' Wenn Cancel Button geklickt wurde nur Form8 schließen '
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    ' Wenn Ok Button geklickt wurde alle Fenster schließen '
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Installer.Close()
        Form1.Close()
    End Sub

    ' wenn X Button geklickt wurde nur Form8 schließen '
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub
End Class