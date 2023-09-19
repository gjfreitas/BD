<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GoBack_F5 = New System.Windows.Forms.Button()
        Me.Exit_F5 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSexo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDataNasc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNcc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMorada = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bttnAdd = New System.Windows.Forms.Button()
        Me.bttnEdit = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCD = New System.Windows.Forms.TextBox()
        Me.Help_F5 = New System.Windows.Forms.Button()
        Me.bttnPessoas = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GoBack_F5
        '
        Me.GoBack_F5.Location = New System.Drawing.Point(632, 286)
        Me.GoBack_F5.Name = "GoBack_F5"
        Me.GoBack_F5.Size = New System.Drawing.Size(95, 29)
        Me.GoBack_F5.TabIndex = 65
        Me.GoBack_F5.Text = "Go Back"
        Me.GoBack_F5.UseVisualStyleBackColor = True
        '
        'Exit_F5
        '
        Me.Exit_F5.Location = New System.Drawing.Point(531, 286)
        Me.Exit_F5.Name = "Exit_F5"
        Me.Exit_F5.Size = New System.Drawing.Size(95, 29)
        Me.Exit_F5.TabIndex = 64
        Me.Exit_F5.Text = "Exit"
        Me.Exit_F5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 20)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Suspeitos na Base de Dados"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(291, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 20)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Sexo"
        '
        'txtSexo
        '
        Me.txtSexo.Location = New System.Drawing.Point(291, 178)
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.Size = New System.Drawing.Size(98, 27)
        Me.txtSexo.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(599, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 20)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Data de Nascimento"
        '
        'txtDataNasc
        '
        Me.txtDataNasc.Location = New System.Drawing.Point(598, 178)
        Me.txtDataNasc.Name = "txtDataNasc"
        Me.txtDataNasc.Size = New System.Drawing.Size(167, 27)
        Me.txtDataNasc.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(586, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 20)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Nº CC"
        '
        'txtNcc
        '
        Me.txtNcc.Location = New System.Drawing.Point(587, 44)
        Me.txtNcc.Name = "txtNcc"
        Me.txtNcc.Size = New System.Drawing.Size(178, 27)
        Me.txtNcc.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(290, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Morada"
        '
        'txtMorada
        '
        Me.txtMorada.Location = New System.Drawing.Point(290, 109)
        Me.txtMorada.Name = "txtMorada"
        Me.txtMorada.Size = New System.Drawing.Size(238, 27)
        Me.txtMorada.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(290, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(290, 44)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(238, 27)
        Me.txtNome.TabIndex = 52
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(12, 31)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(238, 244)
        Me.ListBox1.TabIndex = 51
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(12, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 19)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "P8G4 - BD - Ano Lectivo 2021/22"
        '
        'bttnAdd
        '
        Me.bttnAdd.Location = New System.Drawing.Point(261, 222)
        Me.bttnAdd.Name = "bttnAdd"
        Me.bttnAdd.Size = New System.Drawing.Size(164, 54)
        Me.bttnAdd.TabIndex = 70
        Me.bttnAdd.Text = "Add"
        Me.bttnAdd.UseVisualStyleBackColor = True
        '
        'bttnEdit
        '
        Me.bttnEdit.Location = New System.Drawing.Point(443, 222)
        Me.bttnEdit.Name = "bttnEdit"
        Me.bttnEdit.Size = New System.Drawing.Size(164, 54)
        Me.bttnEdit.TabIndex = 67
        Me.bttnEdit.Text = "Edit"
        Me.bttnEdit.UseVisualStyleBackColor = True
        '
        'bttnDelete
        '
        Me.bttnDelete.Location = New System.Drawing.Point(622, 222)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(164, 54)
        Me.bttnDelete.TabIndex = 71
        Me.bttnDelete.Text = "Delete"
        Me.bttnDelete.UseVisualStyleBackColor = True
        '
        'bttnOK
        '
        Me.bttnOK.Location = New System.Drawing.Point(580, 222)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(185, 54)
        Me.bttnOK.TabIndex = 68
        Me.bttnOK.Text = "Ok"
        Me.bttnOK.UseVisualStyleBackColor = True
        '
        'bttnCancel
        '
        Me.bttnCancel.Location = New System.Drawing.Point(298, 222)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(185, 54)
        Me.bttnCancel.TabIndex = 69
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 20)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Nº Crimes Efetuados"
        '
        'txtNC
        '
        Me.txtNC.Location = New System.Drawing.Point(414, 178)
        Me.txtNC.Name = "txtNC"
        Me.txtNC.Size = New System.Drawing.Size(145, 27)
        Me.txtNC.TabIndex = 72
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(586, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 20)
        Me.Label7.TabIndex = 75
        Me.Label7.Text = "Código da Detenção"
        '
        'txtCD
        '
        Me.txtCD.Location = New System.Drawing.Point(587, 109)
        Me.txtCD.Name = "txtCD"
        Me.txtCD.Size = New System.Drawing.Size(178, 27)
        Me.txtCD.TabIndex = 74
        '
        'Help_F5
        '
        Me.Help_F5.Location = New System.Drawing.Point(776, 2)
        Me.Help_F5.Name = "Help_F5"
        Me.Help_F5.Size = New System.Drawing.Size(37, 33)
        Me.Help_F5.TabIndex = 76
        Me.Help_F5.Text = "?"
        Me.Help_F5.UseVisualStyleBackColor = True
        '
        'bttnPessoas
        '
        Me.bttnPessoas.Location = New System.Drawing.Point(261, 286)
        Me.bttnPessoas.Name = "bttnPessoas"
        Me.bttnPessoas.Size = New System.Drawing.Size(164, 29)
        Me.bttnPessoas.TabIndex = 77
        Me.bttnPessoas.Text = "Consultar Pessoas"
        Me.bttnPessoas.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(431, 286)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 83
        Me.Button1.Text = "Reload"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(733, 286)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 29)
        Me.Button2.TabIndex = 84
        Me.Button2.Text = "Hide"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 324)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bttnPessoas)
        Me.Controls.Add(Me.Help_F5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNC)
        Me.Controls.Add(Me.bttnAdd)
        Me.Controls.Add(Me.bttnEdit)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GoBack_F5)
        Me.Controls.Add(Me.Exit_F5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSexo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDataNasc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNcc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMorada)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form5"
        Me.Text = "Suspeitos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GoBack_F5 As Button
    Friend WithEvents Exit_F5 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSexo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDataNasc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNcc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMorada As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents bttnAdd As Button
    Friend WithEvents bttnEdit As Button
    Friend WithEvents bttnDelete As Button
    Friend WithEvents bttnOK As Button
    Friend WithEvents bttnCancel As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNC As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCD As TextBox
    Friend WithEvents Help_F5 As Button
    Friend WithEvents bttnPessoas As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
