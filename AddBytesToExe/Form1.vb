Imports System
Imports System.IO

Public Class Form1
    Dim load_exe As New OpenFileDialog()
    Dim absolute_path As String
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox1.Text = 0
        End If
        Try
            If TextBox1.Text > 1000000000000000000 Then
                TextBox1.Text = 1000000000000000000
                MessageBox.Show("maximum exeeded")
            Else
                Dim dummy As Integer = TextBox1.Text / 1000000000
            End If

        Catch ex As Exception
            MessageBox.Show("Connot get letters in numbers!")
        End Try
        Label5.Text = (TextBox1.Text / 1000).ToString("N1")
        Label6.Text = (TextBox1.Text / 1000000).ToString("N1")
        Label7.Text = (TextBox1.Text / 1000000000).ToString("N1")
        Label9.Text = (TextBox1.Text / 1000000000000).ToString("N1")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        load_exe.Filter = "Exe Files | *.exe"
        load_exe.Title = "Choose File..."
        load_exe.ShowDialog()

        If load_exe.SafeFileName = "" Then
            Label10.Text = "No file chosen"
        Else
            Label10.Text = load_exe.SafeFileName
            absolute_path = load_exe.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim by2add(TextBox1.Text) As Byte
        Try
            Using stream = New FileStream(absolute_path, FileMode.Append)
                stream.Write(by2add, 0, by2add.Length)
            End Using
        Catch
            MessageBox.Show("Someone is already running this file.")
        End Try
    End Sub
End Class
