Public Class Form2
    Private Sub GoBack_F2_Click(sender As Object, e As EventArgs) Handles GoBack_F2.Click
        Form1.Show()
        Me.Close()
        ''Me.Hide()
    End Sub

    Private Sub Exit_Forms2_Click(sender As Object, e As EventArgs) Handles Exit_Forms2.Click
        End
    End Sub

    Private Sub Pessoas_Click(sender As Object, e As EventArgs) Handles Pessoas.Click
        Form3.Show()
        Me.Close()
        ''Me.Hide()
        Form3.BttnOK.Visible = False
        Form3.BttnCancel.Visible = False
        Form3.txtNcc.ReadOnly = True
        Form3.txtNome.ReadOnly = True
        Form3.txtMorada.ReadOnly = True
        Form3.txtDataNasc.ReadOnly = True
        Form3.txtSexo.ReadOnly = True

    End Sub

    Private Sub Policias_Click(sender As Object, e As EventArgs) Handles Policias.Click
        Form4.Show()
        Me.Close()
        ''Me.Hide()
        Form4.bttnOK.Visible = False
        Form4.bttnCancel.Visible = False
        '' Pessoa
        Form4.txtNcc.ReadOnly = True
        Form4.txtNome.ReadOnly = True
        Form4.txtMorada.ReadOnly = True
        Form4.txtDataNasc.ReadOnly = True
        Form4.txtSexo.ReadOnly = True
        '' Policia
        Form4.txtIDP.ReadOnly = True
        Form4.txtIDE.ReadOnly = True
        Form4.txtLugar.ReadOnly = True
        Form4.txtTel.ReadOnly = True
    End Sub

    Private Sub Suspeitos_Click(sender As Object, e As EventArgs) Handles Suspeitos.Click
        Form5.Show()
        Me.Close()
        ''Me.Hide()
        Form5.bttnOK.Visible = False
        Form5.bttnCancel.Visible = False
        '' Pessoa
        Form5.txtNcc.ReadOnly = True
        Form5.txtNome.ReadOnly = True
        Form5.txtMorada.ReadOnly = True
        Form5.txtDataNasc.ReadOnly = True
        Form5.txtSexo.ReadOnly = True
        '' Suspeito
        Form5.txtCD.ReadOnly = True
        Form5.txtNC.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form11.Show()
        Me.Hide()
        Form11.ListBox1.Enabled = False
        Form11.ListBox2.Enabled = False
        Form11.ListBox3.Enabled = False
        Form11.ListBox4.Enabled = False
        Form11.ListBox5.Enabled = False
        Form11.ListBox6.Enabled = False
        Form11.ListBox7.Enabled = False
        Form11.ListBox8.Enabled = False
        Form11.ListBox9.Enabled = False
        Form11.ListBox10.Enabled = False
        Form11.ListBox11.Enabled = False
        Form11.ListBox12.Enabled = False
        Form11.ListBox13.Enabled = False

        Form11.ListBox1.Items.Clear()
        Form11.ListBox2.Items.Clear()
        Form11.ListBox3.Items.Clear()
        Form11.ListBox4.Items.Clear()
        Form11.ListBox5.Items.Clear()
        Form11.ListBox6.Items.Clear()
        Form11.ListBox7.Items.Clear()
        Form11.ListBox8.Items.Clear()
        Form11.ListBox9.Items.Clear()
        Form11.ListBox10.Items.Clear()
        Form11.ListBox11.Items.Clear()
        Form11.ListBox12.Items.Clear()
        Form11.ListBox13.Items.Clear()

        Form11.txtDetCod.Text = "Inserir código da detencao"
        Form11.txtIDP.Text = "Inserir ID Policia"
        Form11.txtLocal.Text = "Inserir detenção"
        Form11.txtLugarP.Text = "Inserir posição do Policia"
    End Sub
End Class