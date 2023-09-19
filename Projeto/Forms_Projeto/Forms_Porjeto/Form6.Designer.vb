<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Hide_F6 = New System.Windows.Forms.Button()
        Me.Exit_F6 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(26, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome - Nome da Pessoa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(26, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(268, 35)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sexo -  Sexo da Pessoa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(26, 269)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(331, 35)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Morada - Morada da Pessoa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(26, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(360, 70)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Data de Nascimento - Data de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nascimento da Pessoa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(26, 402)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(321, 70)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nº CC - Número do Cartão " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Cidadão da Pessoa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Stencil", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(2, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(562, 141)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Variáveis para " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Adicionar/Editar/Apagar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pessoas"
        '
        'Hide_F6
        '
        Me.Hide_F6.Location = New System.Drawing.Point(450, 443)
        Me.Hide_F6.Name = "Hide_F6"
        Me.Hide_F6.Size = New System.Drawing.Size(95, 29)
        Me.Hide_F6.TabIndex = 67
        Me.Hide_F6.Text = "Hide"
        Me.Hide_F6.UseVisualStyleBackColor = True
        '
        'Exit_F6
        '
        Me.Exit_F6.Location = New System.Drawing.Point(450, 402)
        Me.Exit_F6.Name = "Exit_F6"
        Me.Exit_F6.Size = New System.Drawing.Size(95, 29)
        Me.Exit_F6.TabIndex = 68
        Me.Exit_F6.Text = "Exit"
        Me.Exit_F6.UseVisualStyleBackColor = True
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 482)
        Me.Controls.Add(Me.Exit_F6)
        Me.Controls.Add(Me.Hide_F6)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form6"
        Me.Text = "Variaveis Pessoas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Hide_F6 As Button
    Friend WithEvents Exit_F6 As Button
End Class
