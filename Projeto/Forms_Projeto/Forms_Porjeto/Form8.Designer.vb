<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Hide_F7 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Exit_F7 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(393, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(447, 70)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Nº Crimes Efetuados - Nº de Crimes já" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Efetuados anteriormente pelo Suspeito"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(393, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(349, 105)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Código da Detenção - Código" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "da Detenção do Suspeito " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(pode tomar valores null)"
        '
        'Hide_F7
        '
        Me.Hide_F7.Location = New System.Drawing.Point(737, 389)
        Me.Hide_F7.Name = "Hide_F7"
        Me.Hide_F7.Size = New System.Drawing.Size(128, 43)
        Me.Hide_F7.TabIndex = 87
        Me.Hide_F7.Text = "Hide"
        Me.Hide_F7.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Stencil", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(-9, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(888, 94)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Variáveis para Adicionar/Editar/Apagar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Suspeitos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(6, 362)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(321, 70)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Nº CC - Número do Cartão " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Cidadão do Suspeito"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(6, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(360, 70)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Data de Nascimento - Data de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nascimento do Suspeito"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(6, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(352, 35)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Morada - Morada do Suspeito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(6, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 35)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Sexo -  Sexo do Suspeito"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(6, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(316, 35)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Nome - Nome do Suspeito"
        '
        'Exit_F7
        '
        Me.Exit_F7.Location = New System.Drawing.Point(578, 389)
        Me.Exit_F7.Name = "Exit_F7"
        Me.Exit_F7.Size = New System.Drawing.Size(128, 43)
        Me.Exit_F7.TabIndex = 88
        Me.Exit_F7.Text = "Exit"
        Me.Exit_F7.UseVisualStyleBackColor = True
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 442)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Hide_F7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Exit_F7)
        Me.Name = "Form8"
        Me.Text = "Variaveis Suspeitos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Hide_F7 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Exit_F7 As Button
End Class
