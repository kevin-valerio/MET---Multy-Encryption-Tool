Public Class Form1
    Shared firstTimeSelected As Boolean = True
    Public Property HttpUtility As Object

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        MsgBox("MET - Multy Encryption Tool" & vbCrLf & vbCrLf &
                        "Created on 2017" & vbCrLf & vbCrLf &
                        "(C) Kevin VALERIO", "About!", MessageBoxButtons.OK)



    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim base64Encoded As String = RichTextBox1.Text
        Dim base64Decoded As String
        Dim data() As Byte
        Try
            data = System.Convert.FromBase64String(base64Encoded)
            base64Decoded = System.Text.Encoding.ASCII.GetString(data)
            RichTextBox2.Text = base64Decoded
        Catch ex As System.FormatException
            MsgBox("Error : not base64 input...", MsgBoxStyle.OkOnly, "Error!")

        End Try


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.Click
        If (firstTimeSelected) Then
            RichTextBox1.Text = String.Empty
            firstTimeSelected = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim decodedUrl As String = System.Uri.UnescapeDataString(RichTextBox1.Text)

        RichTextBox2.Text = decodedUrl
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim encodedUrl As String = System.Uri.EscapeDataString(RichTextBox1.Text)

        RichTextBox2.Text = encodedUrl
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(RichTextBox1.Text)
            RichTextBox2.Text = Convert.ToBase64String(byt)
        Catch ex As Exception
            MsgBox(ex.Message, "Error !", vbOK)
        End Try


    End Sub
End Class
