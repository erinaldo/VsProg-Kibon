<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadPtoCrEdit
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
        Me.lblPtoCrLd = New System.Windows.Forms.Label()
        Me.txtPergunta = New System.Windows.Forms.TextBox()
        Me.lblPergunta = New System.Windows.Forms.Label()
        Me.txtPtoCrLd = New System.Windows.Forms.TextBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPtoCrLd
        '
        Me.lblPtoCrLd.AutoSize = True
        Me.lblPtoCrLd.Location = New System.Drawing.Point(34, 36)
        Me.lblPtoCrLd.Name = "lblPtoCrLd"
        Me.lblPtoCrLd.Size = New System.Drawing.Size(45, 13)
        Me.lblPtoCrLd.TabIndex = 0
        Me.lblPtoCrLd.Text = "PtoCrLd"
        '
        'txtPergunta
        '
        Me.txtPergunta.Location = New System.Drawing.Point(91, 77)
        Me.txtPergunta.Name = "txtPergunta"
        Me.txtPergunta.Size = New System.Drawing.Size(366, 20)
        Me.txtPergunta.TabIndex = 1
        '
        'lblPergunta
        '
        Me.lblPergunta.AutoSize = True
        Me.lblPergunta.Location = New System.Drawing.Point(29, 80)
        Me.lblPergunta.Name = "lblPergunta"
        Me.lblPergunta.Size = New System.Drawing.Size(50, 13)
        Me.lblPergunta.TabIndex = 2
        Me.lblPergunta.Text = "Pergunta"
        '
        'txtPtoCrLd
        '
        Me.txtPtoCrLd.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtPtoCrLd.Location = New System.Drawing.Point(91, 33)
        Me.txtPtoCrLd.Name = "txtPtoCrLd"
        Me.txtPtoCrLd.ReadOnly = True
        Me.txtPtoCrLd.Size = New System.Drawing.Size(72, 20)
        Me.txtPtoCrLd.TabIndex = 3
        '
        'btnSalva
        '
        Me.btnSalva.Location = New System.Drawing.Point(121, 141)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(105, 39)
        Me.btnSalva.TabIndex = 4
        Me.btnSalva.Text = "Salvar"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(281, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 39)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmCadPtoCrEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 226)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSalva)
        Me.Controls.Add(Me.txtPtoCrLd)
        Me.Controls.Add(Me.lblPergunta)
        Me.Controls.Add(Me.txtPergunta)
        Me.Controls.Add(Me.lblPtoCrLd)
        Me.Name = "frmCadPtoCrEdit"
        Me.Text = "Novo Cadastro PtoCr"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPtoCrLd As System.Windows.Forms.Label
    Friend WithEvents txtPergunta As System.Windows.Forms.TextBox
    Friend WithEvents lblPergunta As System.Windows.Forms.Label
    Friend WithEvents txtPtoCrLd As System.Windows.Forms.TextBox
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
