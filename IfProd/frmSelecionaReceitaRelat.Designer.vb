<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelecionaReceitaRelat
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
        Me.tbIdBatch = New System.Windows.Forms.TextBox()
        Me.btnImprimirRelatorio = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Batch:"
        '
        'tbIdBatch
        '
        Me.tbIdBatch.Location = New System.Drawing.Point(83, 36)
        Me.tbIdBatch.Name = "tbIdBatch"
        Me.tbIdBatch.Size = New System.Drawing.Size(339, 20)
        Me.tbIdBatch.TabIndex = 1
        '
        'btnImprimirRelatorio
        '
        Me.btnImprimirRelatorio.Location = New System.Drawing.Point(288, 62)
        Me.btnImprimirRelatorio.Name = "btnImprimirRelatorio"
        Me.btnImprimirRelatorio.Size = New System.Drawing.Size(125, 39)
        Me.btnImprimirRelatorio.TabIndex = 2
        Me.btnImprimirRelatorio.Text = "Imprimir Relatório"
        Me.btnImprimirRelatorio.UseVisualStyleBackColor = True
        '
        'frmSelecionaReceitaRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 113)
        Me.Controls.Add(Me.btnImprimirRelatorio)
        Me.Controls.Add(Me.tbIdBatch)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSelecionaReceitaRelat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleciona Receita"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbIdBatch As TextBox
    Friend WithEvents btnImprimirRelatorio As Button
End Class
