﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Exit_Form1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(4, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(486, 57)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Base de Dados da Polícia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(115, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(243, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Gonçalo Freitas e Nuno Capão"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(142, 153)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(216, 57)
        Me.StartButton.TabIndex = 4
        Me.StartButton.Text = "Iniciar"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(12, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(261, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "P8G4 - BD - Ano Lectivo 2021/22"
        '
        'Exit_Form1
        '
        Me.Exit_Form1.Location = New System.Drawing.Point(399, 252)
        Me.Exit_Form1.Name = "Exit_Form1"
        Me.Exit_Form1.Size = New System.Drawing.Size(96, 30)
        Me.Exit_Form1.TabIndex = 6
        Me.Exit_Form1.Text = "Exit"
        Me.Exit_Form1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 294)
        Me.Controls.Add(Me.Exit_Form1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Início"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents StartButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Exit_Form1 As Button
End Class
