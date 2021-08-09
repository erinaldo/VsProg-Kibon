<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadCfgEdit
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
        Me.txtCfg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtCfg
        '
        Me.txtCfg.BackColor = System.Drawing.Color.White
        Me.txtCfg.Location = New System.Drawing.Point(106, 13)
        Me.txtCfg.Name = "txtCfg"
        Me.txtCfg.Size = New System.Drawing.Size(216, 20)
        Me.txtCfg.TabIndex = 59
        Me.txtCfg.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Cfg"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Valor"
        '
        'butCancela
        '
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(185, 103)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(149, 32)
        Me.butCancela.TabIndex = 62
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(12, 103)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(153, 32)
        Me.butOk.TabIndex = 61
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(106, 39)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(216, 20)
        Me.txtValor.TabIndex = 60
        '
        'frmCadCfgEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 138)
        Me.Controls.Add(Me.txtCfg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.txtValor)
        Me.Name = "frmCadCfgEdit"
        Me.Text = "frmCadCfgEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCfg As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
End Class
