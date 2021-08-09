<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeraRelat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbRelat = New System.Windows.Forms.ProgressBar()
        Me.butCriaRelat = New System.Windows.Forms.Button()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "O relatório está sendo criado..."
        '
        'pbRelat
        '
        Me.pbRelat.Location = New System.Drawing.Point(39, 112)
        Me.pbRelat.Name = "pbRelat"
        Me.pbRelat.Size = New System.Drawing.Size(321, 23)
        Me.pbRelat.TabIndex = 1
        '
        'butCriaRelat
        '
        Me.butCriaRelat.Location = New System.Drawing.Point(86, 172)
        Me.butCriaRelat.Name = "butCriaRelat"
        Me.butCriaRelat.Size = New System.Drawing.Size(90, 35)
        Me.butCriaRelat.TabIndex = 2
        Me.butCriaRelat.Text = "Criar Relatório"
        Me.butCriaRelat.UseVisualStyleBackColor = True
        '
        'butCancela
        '
        Me.butCancela.Location = New System.Drawing.Point(224, 172)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(90, 35)
        Me.butCancela.TabIndex = 3
        Me.butCancela.Text = "Cancelar"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'frmGeraRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 244)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butCriaRelat)
        Me.Controls.Add(Me.pbRelat)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmGeraRelat"
        Me.Text = "Relatório"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbRelat As System.Windows.Forms.ProgressBar
    Friend WithEvents butCriaRelat As System.Windows.Forms.Button
    Friend WithEvents butCancela As System.Windows.Forms.Button
End Class
