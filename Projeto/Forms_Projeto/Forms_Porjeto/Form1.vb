Public Class Form1
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Exit_Form1_Click(sender As Object, e As EventArgs) Handles Exit_Form1.Click
        End
    End Sub
End Class
