Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient

Public Class Form5

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentContact As Integer
    Dim adding As Boolean

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        ListBox1.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentContact = ListBox1.SelectedIndex
            If currentContact < 0 Then currentContact = 0
            ShowContact()
        Else
            ClearFields()
            LockControls()
        End If
        ShowButtons()
    End Sub

    Private Sub bttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOK.Click
        Try
            SaveContact()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListBox1.Enabled = True
        Dim idx As Integer = ListBox1.FindString(txtNcc.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                RemoveContact(CType(ListBox1.SelectedItem, Contact).SuspCC)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentContact = ListBox1.Items.Count Then currentContact = ListBox1.Items.Count - 1
            If currentContact = -1 Then
                ClearFields()
                MsgBox("There are no more contacts")
            Else
                ShowContact()
            End If
        End If
    End Sub

    Private Sub bttnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttnAdd.Click
        adding = True
        ClearFields()
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub Form5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            MsgBox("There are " & ListBox1.Items.Count.ToString &
                      " contacts in the database")
            e.Handled = True
        End If
    End Sub

    Private Sub Form5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        ' If we're not in EDIT mode, reject keystrokes
        If Not bttnOK.Visible Then
            e.Handled = True
        End If
    End Sub

    Private Function SaveContact() As Boolean
        Dim contact As New Contact
        Try
            '' Pessoa
            contact.Ncc = txtNcc.Text
            contact.Nome = txtNome.Text
            contact.Morada = txtMorada.Text
            contact.BDate = txtDataNasc.Text
            contact.Sexo = txtSexo.Text
            '' Suspeito
            contact.NCrimes = txtNC.Text
            contact.CodigoDet = txtCD.Text
            contact.SuspCC = txtNcc.Text



        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitContact(contact)
            ListBox1.Items.Add(contact)
        Else
            UpdateContact(contact)
            ListBox1.Items(currentContact) = contact
        End If
        Return True
    End Function

    Private Sub bttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnEdit.Click
        currentContact = ListBox1.SelectedIndex
        If currentContact < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentContact = ListBox1.SelectedIndex
            ShowContact()
        End If
    End Sub

    ' Helper routines
    Sub LockControls()
        '' Pessoa
        txtNcc.ReadOnly = True
        txtNome.ReadOnly = True
        txtMorada.ReadOnly = True
        txtDataNasc.ReadOnly = True
        txtSexo.ReadOnly = True
        '' Suspeito
        txtCD.ReadOnly = True
        txtNC.ReadOnly = True
    End Sub

    Sub UnlockControls()
        '' Pessoa
        txtNcc.ReadOnly = False
        txtNome.ReadOnly = False
        txtMorada.ReadOnly = False
        txtDataNasc.ReadOnly = False
        txtSexo.ReadOnly = False
        '' Suspeito
        txtCD.ReadOnly = False
        txtNC.ReadOnly = False
    End Sub

    Sub ShowButtons()
        LockControls()
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub ClearFields()
        '' Pessoa
        txtNcc.Text = ""
        txtNome.Text = ""
        txtMorada.Text = ""
        txtDataNasc.Text = ""
        txtSexo.Text = ""
        '' Suspeito
        txtNC.Text = ""
        txtCD.Text = ""
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim contact As New Contact
        contact = CType(ListBox1.Items.Item(currentContact), Contact)
        '' Pessoa
        txtNcc.Text = contact.Ncc
        txtNome.Text = contact.Nome
        txtMorada.Text = contact.Morada
        txtDataNasc.Text = contact.BDate
        txtSexo.Text = contact.Sexo
        '' Suspeito
        txtNC.Text = contact.NCrimes
        txtCD.Text = contact.CodigoDet
        txtNcc.Text = contact.SuspCC


    End Sub

    Sub HideButtons()
        UnlockControls()
        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = True
        bttnCancel.Visible = True
    End Sub
    Private Sub LoadMap()
        CMD.CommandText = "SELECT * FROM POLICE.SUSPEITO JOIN POLICE.PESSOA ON cc=Ncc LEFT OUTER JOIN POLICE.DETSUSP ON cc=SuspCC"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Contact
            '' Pessoa
            C.Ncc = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Ncc")), "", RDR.Item("Ncc")))
            C.BDate = RDR.Item("Bdate")
            C.Nome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            C.Morada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("morada")), "", RDR.Item("morada")))
            C.Sexo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("sexo")), "", RDR.Item("sexo")))
            '' Suspeito
            C.NCrimes = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NCrimesEfetuados")), "", RDR.Item("NCrimesEfetuados")))
            C.CodigoDet = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("DetCodigo")), "", RDR.Item("DetCodigo")))
            C.SuspCC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("cc")), "", RDR.Item("cc")))
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentContact = 0
        ShowContact()
    End Sub

    'Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
    '    LoadMap()
    'End Sub

    'Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
    '    End
    'End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Change this line...
        CN = New SqlConnection("data source=localhost\SQLEXPRESS;integrated security=true;initial catalog=Projeto")

        CMD = New SqlCommand
        CMD.Connection = CN
        LoadMap()
    End Sub

    Private Sub SubmitContact(ByVal C As Contact)
        Dim IDnull As String
        IDnull = "Null"

        If txtCD.Text = "" Or txtCD.Text.ToUpper = IDnull.ToUpper Then
            CMD.CommandText = "INSERT POLICE.PESSOA (nome,Ncc,Bdate,morada,sexo) VALUES (@nome, @cc, @Bdate, @morada,@sexo); " +
                                "INSERT POLICE.SUSPEITO (cc,NCrimesEfetuados) VALUES (@cc, @NCrimesEfetuados); "

            CMD.Parameters.Clear()
            '' Pessoa
            CMD.Parameters.AddWithValue("@nome", C.Nome)
            CMD.Parameters.AddWithValue("@Ncc", C.Ncc)
            CMD.Parameters.AddWithValue("@Bdate", C.BDate)
            CMD.Parameters.AddWithValue("@morada", C.Morada)
            CMD.Parameters.AddWithValue("@sexo", C.Sexo)
            '' Suspeito
            CMD.Parameters.AddWithValue("@cc", C.SuspCC)
            CMD.Parameters.AddWithValue("@NCrimesEfetuados", C.NCrimes)
            CMD.Parameters.AddWithValue("null", C.CodigoDet)
            CN.Open()
            Try
                CMD.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
            Finally
                CN.Close()
            End Try
            CN.Close()
        Else
            CMD.CommandText = "INSERT POLICE.PESSOA (nome,Ncc,Bdate,morada,sexo) VALUES (@nome, @cc, @Bdate, @morada,@sexo); " +
                            "INSERT POLICE.SUSPEITO (cc,NCrimesEfetuados) VALUES (@cc, @NCrimesEfetuados, @DetCodigo); " +
                          "INSERT POLICE.DETSUSP (SuspCC, DetCodigo) VALUES (@cc, @DetCodigo);"
            CMD.Parameters.Clear()
            '' Pessoa
            CMD.Parameters.AddWithValue("@nome", C.Nome)
            CMD.Parameters.AddWithValue("@Ncc", C.Ncc)
            CMD.Parameters.AddWithValue("@Bdate", C.BDate)
            CMD.Parameters.AddWithValue("@morada", C.Morada)
            CMD.Parameters.AddWithValue("@sexo", C.Sexo)
            '' Suspeito
            CMD.Parameters.AddWithValue("@cc", C.SuspCC)
            CMD.Parameters.AddWithValue("@NCrimesEfetuados", C.NCrimes)
            CMD.Parameters.AddWithValue("@DetCodigo", C.CodigoDet)
            CN.Open()
            Try
                CMD.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
            Finally
                CN.Close()
            End Try
            CN.Close()
        End If
    End Sub


    Private Sub UpdateContact(ByVal C As Contact)
        Dim IDnull As String
        IDnull = "Null"

        If txtCD.Text = "" Or txtCD.Text.ToUpper = IDnull.ToUpper Then
            CMD.CommandText = "UPDATE POLICE.SUSPEITO SET NCrimesEfetuados = @NCrimesEfetuados WHERE cc = @cc ; " +
                              "UPDATE POLICE.PESSOA SET Bdate = @Bdate, sexo = @sexo, morada = @morada, nome = @nome WHERE Ncc = @cc ;" +
                              "DELETE FROM POLICE.DETSUSP WHERE SuspCC=@cc"

            CMD.Parameters.Clear()
            '' Pessoa
            CMD.Parameters.AddWithValue("@nome", C.Nome)
            CMD.Parameters.AddWithValue("@Ncc", C.Ncc)
            CMD.Parameters.AddWithValue("@Bdate", C.BDate)
            CMD.Parameters.AddWithValue("@morada", C.Morada)
            CMD.Parameters.AddWithValue("@sexo", C.Sexo)
            '' Suspeito
            CMD.Parameters.AddWithValue("@NCrimesEfetuados", C.NCrimes)
            CMD.Parameters.AddWithValue("@cc", C.SuspCC)
            CMD.Parameters.AddWithValue("null", C.CodigoDet)
            CN.Open()

            Try
                CMD.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
            Finally
                CN.Close()
            End Try


        Else
            CMD.CommandText = "UPDATE POLICE.SUSPEITO SET NCrimesEfetuados = @NCrimesEfetuados WHERE cc = @cc ; " +
                              "UPDATE POLICE.PESSOA SET Bdate = @Bdate, sexo = @sexo, morada = @morada, nome = @nome WHERE Ncc = @cc ;" +
                              "INSERT POLICE.DETSUSP (SuspCC,DetCodigo) VALUES (@cc, @DetCodigo);"
            CMD.Parameters.Clear()
            '' Pessoa
            CMD.Parameters.AddWithValue("@nome", C.Nome)
            CMD.Parameters.AddWithValue("@Ncc", C.Ncc)
            CMD.Parameters.AddWithValue("@Bdate", C.BDate)
            CMD.Parameters.AddWithValue("@morada", C.Morada)
            CMD.Parameters.AddWithValue("@sexo", C.Sexo)
            '' Suspeito
            CMD.Parameters.AddWithValue("@NCrimesEfetuados", C.NCrimes)
            CMD.Parameters.AddWithValue("@cc", C.SuspCC)
            CMD.Parameters.AddWithValue("@DetCodigo", C.CodigoDet)
            CN.Open()

            Try
                CMD.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
            Finally
                CN.Close()
            End Try
        End If
    End Sub

    Private Sub RemoveContact(ByVal cc As String)
        CMD.CommandText = "EXEC remov_susp @cc "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@cc", cc)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub GoBack_F5_Click(sender As Object, e As EventArgs) Handles GoBack_F5.Click
        Form2.Show()
        Me.Close()
        Form8.Hide()
    End Sub

    Private Sub Exit_F5_Click(sender As Object, e As EventArgs) Handles Exit_F5.Click
        End
    End Sub

    Private Sub Help_F5_Click(sender As Object, e As EventArgs) Handles Help_F5.Click
        Form8.Show()
    End Sub

    Private Sub bttnPessoas_Click(sender As Object, e As EventArgs) Handles bttnPessoas.Click
        Form10.Show()
        Form10.BttnOK.Visible = False
        Form10.BttnCancel.Visible = False
        Form10.txtNcc.ReadOnly = True
        Form10.txtNome.ReadOnly = True
        Form10.txtMorada.ReadOnly = True
        Form10.txtDataNasc.ReadOnly = True
        Form10.txtSexo.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadMap()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class
