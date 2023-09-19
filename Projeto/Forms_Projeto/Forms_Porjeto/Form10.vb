Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient

Public Class Form10

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentContact As Integer
    Dim adding As Boolean

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnCancel.Click
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

    Private Sub bttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnOK.Click
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

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                RemoveContact(CType(ListBox1.SelectedItem, Contact).Ncc)
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

    Private Sub bttnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttnAdd.Click
        adding = True
        ClearFields()
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub Form10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            MsgBox("There are " & ListBox1.Items.Count.ToString &
                      " contacts in the database")
            e.Handled = True
        End If
    End Sub

    Private Sub Form10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        ' If we're not in EDIT mode, reject keystrokes
        If Not BttnOK.Visible Then
            e.Handled = True
        End If
    End Sub

    Private Function SaveContact() As Boolean
        Dim contact As New Contact
        Try
            contact.Ncc = txtNcc.Text
            contact.Nome = txtNome.Text
            contact.Morada = txtMorada.Text
            contact.BDate = txtDataNasc.Text
            contact.Sexo = txtSexo.Text

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

    Private Sub bttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnEdit.Click
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
        txtNcc.ReadOnly = True
        txtNome.ReadOnly = True
        txtMorada.ReadOnly = True
        txtDataNasc.ReadOnly = True
        txtSexo.ReadOnly = True
    End Sub

    Sub UnlockControls()
        txtNcc.ReadOnly = False
        txtNome.ReadOnly = False
        txtMorada.ReadOnly = False
        txtDataNasc.ReadOnly = False
        txtSexo.ReadOnly = False
    End Sub

    Sub ShowButtons()
        LockControls()
        BttnAdd.Visible = True
        BttnDelete.Visible = True
        BttnEdit.Visible = True
        BttnOK.Visible = False
        BttnCancel.Visible = False
    End Sub

    Sub ClearFields()
        txtNcc.Text = ""
        txtNome.Text = ""
        txtMorada.Text = ""
        txtDataNasc.Text = ""
        txtSexo.Text = ""
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim contact As New Contact
        contact = CType(ListBox1.Items.Item(currentContact), Contact)
        txtNcc.Text = contact.Ncc
        txtNome.Text = contact.Nome
        txtMorada.Text = contact.Morada
        txtDataNasc.Text = contact.BDate
        txtSexo.Text = contact.Sexo

    End Sub

    Sub HideButtons()
        UnlockControls()
        BttnAdd.Visible = False
        BttnDelete.Visible = False
        BttnEdit.Visible = False
        BttnOK.Visible = True
        BttnCancel.Visible = True
    End Sub
    Private Sub LoadMap()
        CMD.CommandText = "SELECT * FROM POLICE.PESSOA"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Contact
            C.Ncc = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Ncc")), "", RDR.Item("Ncc")))
            C.BDate = RDR.Item("Bdate")
            C.Nome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            C.Morada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("morada")), "", RDR.Item("morada")))
            C.Sexo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("sexo")), "", RDR.Item("sexo")))
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentContact = 0
        ShowContact()
    End Sub

    'Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LoadMap()
    'End Sub

    'Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    End
    'End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Change this line...
        CN = New SqlConnection("data source=localhost\SQLEXPRESS;integrated security=true;initial catalog=Projeto")

        CMD = New SqlCommand
        CMD.Connection = CN
        LoadMap()
    End Sub

    Private Sub SubmitContact(ByVal C As Contact)
        CMD.CommandText = "INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo) VALUES (@Nome,@Ncc,@BDate,@Morada,@Sexo)"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Ncc", C.Ncc)
        CMD.Parameters.AddWithValue("@BDate", C.BDate)
        CMD.Parameters.AddWithValue("@Morada", C.Morada)
        CMD.Parameters.AddWithValue("@Sexo", C.Sexo)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub


    Private Sub UpdateContact(ByVal C As Contact)
        CMD.CommandText = "UPDATE POLICE.PESSOA " &
            "SET nome = @Nome, " &
            "    Bdate = @BDate, " &
            "    morada = @Morada, " &
            "    sexo = @Sexo " &
            "WHERE Ncc = @Ncc"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Ncc", C.Ncc)
        CMD.Parameters.AddWithValue("@BDate", C.BDate)
        CMD.Parameters.AddWithValue("@Morada", C.Morada)
        CMD.Parameters.AddWithValue("@Sexo", C.Sexo)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub RemoveContact(ByVal Ncc As String)
        CMD.CommandText = "EXEC remov_person @Ncc "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Ncc", Ncc)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub Help_Button_Click(sender As Object, e As EventArgs) Handles Help_Button.Click
        Form6.Show()
    End Sub

    Private Sub Exit_F5_Click(sender As Object, e As EventArgs) Handles Exit_F5.Click
        End
    End Sub

    Private Sub GoBack_F5_Click(sender As Object, e As EventArgs) Handles GoBack_F5.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadMap()
    End Sub
End Class
