<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Pessoas = New System.Windows.Forms.Button()
        Me.Policias = New System.Windows.Forms.Button()
        Me.Suspeitos = New System.Windows.Forms.Button()
        Me.Exit_Forms2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GoBack_F2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(44, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(459, 57)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "O que pretende editar?"
        '
        'Pessoas
        '
        Me.Pessoas.Location = New System.Drawing.Point(44, 99)
        Me.Pessoas.Name = "Pessoas"
        Me.Pessoas.Size = New System.Drawing.Size(135, 50)
        Me.Pessoas.TabIndex = 5
        Me.Pessoas.Text = "Pessoas"
        Me.Pessoas.UseVisualStyleBackColor = True
        '
        'Policias
        '
        Me.Policias.Location = New System.Drawing.Point(212, 99)
        Me.Policias.Name = "Policias"
        Me.Policias.Size = New System.Drawing.Size(135, 50)
        Me.Policias.TabIndex = 6
        Me.Policias.Text = "Polícias"
        Me.Policias.UseVisualStyleBackColor = True
        '
        'Suspeitos
        '
        Me.Suspeitos.Location = New System.Drawing.Point(379, 99)
        Me.Suspeitos.Name = "Suspeitos"
        Me.Suspeitos.Size = New System.Drawing.Size(135, 50)
        Me.Suspeitos.TabIndex = 7
        Me.Suspeitos.Text = "Suspeitos"
        Me.Suspeitos.UseVisualStyleBackColor = True
        '
        'Exit_Forms2
        '
        Me.Exit_Forms2.Location = New System.Drawing.Point(458, 206)
        Me.Exit_Forms2.Name = "Exit_Forms2"
        Me.Exit_Forms2.Size = New System.Drawing.Size(79, 30)
        Me.Exit_Forms2.TabIndex = 8
        Me.Exit_Forms2.Text = "Exit"
        Me.Exit_Forms2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(12, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(261, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "P8G4 - BD - Ano Lectivo 2021/22"
        '
        'GoBack_F2
        '
        Me.GoBack_F2.Location = New System.Drawing.Point(360, 205)
        Me.GoBack_F2.Name = "GoBack_F2"
        Me.GoBack_F2.Size = New System.Drawing.Size(79, 30)
        Me.GoBack_F2.TabIndex = 10
        Me.GoBack_F2.Text = "Go Back"
        Me.GoBack_F2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(212, 164)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 29)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Estatisticas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 247)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GoBack_F2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Exit_Forms2)
        Me.Controls.Add(Me.Suspeitos)
        Me.Controls.Add(Me.Policias)
        Me.Controls.Add(Me.Pessoas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form2"
        Me.Text = "Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Pessoas As Button
    Friend WithEvents Policias As Button
    Friend WithEvents Suspeitos As Button
    Friend WithEvents Exit_Forms2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents GoBack_F2 As Button
    Friend WithEvents Button1 As Button
End Class
