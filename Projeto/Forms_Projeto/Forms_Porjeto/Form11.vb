Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient

Public Class Form11

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentContact As Integer
    Dim adding As Boolean
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        End
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Form11_Load() Handles MyBase.Load
        '' Change this line...
        CN = New SqlConnection("data source=localhost\SQLEXPRESS;integrated security=true;initial catalog=Projeto")

        CMD = New SqlCommand
        CMD.Connection = CN

        ListBox1.Enabled = False
        ListBox2.Enabled = False
        ListBox3.Enabled = False
        ListBox4.Enabled = False
        ListBox5.Enabled = False
        ListBox6.Enabled = False
        ListBox7.Enabled = False
        ListBox8.Enabled = False
        ListBox9.Enabled = False
        ListBox10.Enabled = False
        ListBox11.Enabled = False
        ListBox12.Enabled = False
        ListBox13.Enabled = False

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
        ListBox8.Items.Clear()
        ListBox9.Items.Clear()
        ListBox10.Items.Clear()
        ListBox11.Items.Clear()
        ListBox12.Items.Clear()
        ListBox13.Items.Clear()

        txtDetCod.Text = "Inserir código da detencao"
        txtIDP.Text = "Inserir ID Policia"
        txtLocal.Text = "Inserir crime"
        txtLugarP.Text = "Inserir posição do Policia"

        CN.Close()

    End Sub
    Private Sub LoadMap1()
        CMD.CommandText = "EXEC det_por_equipa"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Equipa
            C.Eid = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Eid")), "", RDR.Item("Eid")))
            C.Count = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Detenções")), "", RDR.Item("Detenções")))
            ListBox1.Items.Add(C)
        End While
    End Sub

    Private Sub LoadMap2()
        CMD.CommandText = "EXEC idade_media_pol"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox4.Items.Clear()
        While RDR.Read
            Dim C As New IdadeMed
            C.IdadeMed = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("IDMed")), "", RDR.Item("IDMed")))
            ListBox4.Items.Add(C)
        End While
    End Sub

    Private Sub LoadMap3()
        CMD.CommandText = "EXEC idade_media_susp"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox5.Items.Clear()
        While RDR.Read
            Dim C As New IdadeMed
            C.IdadeMed = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("IDMed")), "", RDR.Item("IDMed")))
            ListBox5.Items.Add(C)
        End While
    End Sub

    Private Sub LoadMap4()
        CMD.CommandText = "EXEC idade_media_people"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox6.Items.Clear()
        While RDR.Read
            Dim C As New IdadeMed
            C.IdadeMed = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("IDMed")), "", RDR.Item("IDMed")))
            ListBox6.Items.Add(C)
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CN.Close()
        ListBox1.Items.Clear()
        LoadMap1()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CN.Close()
        ListBox5.Items.Clear()
        LoadMap3()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CN.Close()
        ListBox4.Items.Clear()
        LoadMap2()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CN.Close()
        ListBox6.Items.Clear()
        LoadMap4()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CN.Close()
        ListBox7.Items.Clear()
        LoadMap5()
    End Sub

    Private Sub LoadMap5()
        CMD.CommandText = "EXEC police_equipa"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox7.Items.Clear()
        While RDR.Read
            Dim C As New Police_P_Equipa
            C.IDE = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("IDEquipa")), "", RDR.Item("IDEquipa")))
            C.Count = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Número de Policias")), "", RDR.Item("Número de Policias")))
            ListBox7.Items.Add(C)
        End While
    End Sub

    Private Sub ShowCrime_Click(sender As Object, e As EventArgs) Handles ShowCrime.Click
        Dim contact As New Pessoa
        CN.Close()
        ListBox2.Items.Clear()

        Dim IDnull As String
        IDnull = "Null"
        If txtDetCod.Text = "" Or txtDetCod.Text.ToUpper = IDnull.ToUpper Then
            MsgBox("Por favor insira um codigo")
        Else
            contact.Cod = txtDetCod.Text
            Try
                LoadMap5(contact.Cod)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub LoadMap5(ByVal cod As String)
        CMD.CommandText = "EXEC det_codigo_nome @DetCodigo"
        CN.Open()
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@DetCodigo", cod)
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox2.Items.Clear()
        While RDR.Read
            Dim C As New Pessoa
            C.Nome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            C.NCC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Ncc")), "", RDR.Item("Ncc")))
            ListBox2.Items.Add(C)
        End While
    End Sub

    Private Sub ShowIDP_Click(sender As Object, e As EventArgs) Handles ShowIDP.Click
        Dim contact As New Policia_Principal
        CN.Close()
        ListBox3.Items.Clear()

        Dim IDnull As String
        IDnull = "Null"
        If txtIDP.Text = "" Or txtIDP.Text.ToUpper = IDnull.ToUpper Then
            MsgBox("Por favor insira um ID")
        Else
            contact.ID = txtIDP.Text
            Try
                LoadMap6(contact.ID)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub LoadMap6(ByVal id As String)
        CMD.CommandText = "EXEC equipa_chefe @ID;"
        CN.Open()
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ID", id)
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox3.Items.Clear()
        While RDR.Read
            Dim C As New Policia_Principal
            C.Eid = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID Equipa")), "", RDR.Item("ID Equipa")))
            ListBox3.Items.Add(C)
        End While
    End Sub

    Private Sub ShowLugar_Click(sender As Object, e As EventArgs) Handles ShowLugar.Click
        Dim contact As New Policia_Lugar
        CN.Close()
        ListBox9.Items.Clear()

        Dim IDnull As String
        IDnull = "Null"
        If txtLugarP.Text = "" Or txtLugarP.Text.ToUpper = IDnull.ToUpper Then
            MsgBox("Por favor insira uma lugar")
        Else
            contact.lugar = txtLugarP.Text
            Try
                LoadMap8(contact.lugar)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form9.Show()
    End Sub

    Private Sub LoadMap8(ByVal lugar As String)
        CMD.CommandText = "EXEC policias_lugar @LUGAR"
        CN.Open()
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@LUGAR", lugar)
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox9.Items.Clear()
        While RDR.Read
            Dim C As New Policia_Lugar
            C.lugar = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Nº lugar")), "", RDR.Item("Nº lugar")))
            ListBox9.Items.Add(C)
        End While
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CN.Close()
        ListBox10.Items.Clear()
        LoadMap7()
    End Sub

    Private Sub LoadMap7()
        CMD.CommandText = "EXEC crimes_local"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox10.Items.Clear()
        While RDR.Read
            Dim C As New Local_Crime
            C.Count = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Nº Crimes")), "", RDR.Item("Nº Crimes")))
            C.local = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("localizacao")), "", RDR.Item("localizacao")))
            ListBox10.Items.Add(C)
        End While
    End Sub

    Private Sub ShowLocal_Click(sender As Object, e As EventArgs) Handles ShowLocal.Click
        Dim contact As New Veiculo
        CN.Close()
        ListBox8.Items.Clear()

        Dim IDnull As String
        IDnull = "Null"
        If txtLocal.Text = "" Or txtLocal.Text.ToUpper = IDnull.ToUpper Then
            MsgBox("Por favor insira um codigo de detenção")
        Else
            contact.Count = txtLocal.Text
            Try
                LoadMap9(contact.Count)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub LoadMap9(ByVal Count As String)
        CMD.CommandText = "EXEC crimes_veiculos @Count"
        CN.Open()
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Count", Count)
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox8.Items.Clear()
        While RDR.Read
            Dim C As New Veiculo
            C.Count = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("count")), "", RDR.Item("count")))
            ListBox8.Items.Add(C)
        End While
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CN.Close()
        ListBox11.Items.Clear()
        LoadMap10()
    End Sub

    Private Sub LoadMap10()
        CMD.CommandText = "EXEC Suspeitos_n_Detidos"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox11.Items.Clear()
        While RDR.Read
            Dim C As New SuspNDet
            C.Nome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            C.NCC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Ncc")), "", RDR.Item("Ncc")))
            C.Codigo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo")), "", RDR.Item("codigo")))
            ListBox11.Items.Add(C)
        End While
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CN.Close()
        ListBox12.Items.Clear()
        LoadMap11()
    End Sub


    Private Sub LoadMap11()
        CMD.CommandText = "EXEC Poli_inserem"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox12.Items.Clear()
        While RDR.Read
            Dim C As New PolInserem
            C.Nome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            C.Ncc = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Ncc")), "", RDR.Item("Ncc")))
            C.ID = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("id")), "", RDR.Item("id")))
            C.Count = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("COUNT")), "", RDR.Item("COUNT")))
            ListBox12.Items.Add(C)
        End While
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        CN.Close()
        ListBox13.Items.Clear()
        LoadMap12()
    End Sub


    Private Sub LoadMap12()
        CMD.CommandText = "EXEC Det_N_inseridos"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox13.Items.Clear()
        If RDR Is Nothing Then
            Dim C As New Det_Ninser
            C.Codigo = Convert.ToString("")
            ListBox13.Items.Add(C)
        Else
            While RDR.Read
                Dim C As New Det_Ninser
                C.Codigo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo")), "", RDR.Item("Codigo")))
                C.DataDet = RDR.Item("Data de Detenção")
                ListBox13.Items.Add(C)
            End While
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Form11_Load()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CN.Close()
        ListBox7.Items.Clear()
        LoadMap13()
    End Sub

    Private Sub LoadMap13()
        CMD.CommandText = "EXEC AddPol_To_Equipa"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox7.Items.Clear()
        While RDR.Read
            Dim C As New Police_P_Equipa
            C.IDE = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("IDEquipa")), "", RDR.Item("IDEquipa")))
            C.Count = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Número de Policias")), "", RDR.Item("Número de Policias")))
        End While
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Form10.Show()
        Form10.BttnOK.Visible = False
        Form10.BttnCancel.Visible = False
        Form10.txtNcc.ReadOnly = True
        Form10.txtNome.ReadOnly = True
        Form10.txtMorada.ReadOnly = True
        Form10.txtDataNasc.ReadOnly = True
        Form10.txtSexo.ReadOnly = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form4.Show()
        Form4.bttnOK.Visible = False
        Form4.bttnCancel.Visible = False
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

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Form5.Show()
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

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CN.Close()
        ListBox13.Items.Clear()
        LoadMap14()
    End Sub

    Private Sub LoadMap14()
        CMD.CommandText = "EXEC Inser_Det"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox13.Items.Clear()
        While RDR.Read
            Dim C As New Det_Ninser
            C.Codigo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo")), "", RDR.Item("codigo")))
            C.DataDet = RDR.Item("DataBD")
            ''ListBox13.Items.Add(C)
        End While
    End Sub

End Class