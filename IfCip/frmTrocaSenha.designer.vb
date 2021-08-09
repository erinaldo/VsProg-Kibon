<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrocaSenha
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrocaSenha))
        Me.butCancela = New System.Windows.Forms.Button
        Me.butOk = New System.Windows.Forms.Button
        Me.txtSenha = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSenhaConf = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSenhaAtual = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'butCancela
        '
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(197, 124)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(149, 32)
        Me.butCancela.TabIndex = 4
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(24, 124)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(153, 32)
        Me.butOk.TabIndex = 3
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(118, 57)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(216, 20)
        Me.txtSenha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Nova senha"
        '
        'txtSenhaConf
        '
        Me.txtSenhaConf.Location = New System.Drawing.Point(118, 83)
        Me.txtSenhaConf.Name = "txtSenhaConf"
        Me.txtSenhaConf.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenhaConf.Size = New System.Drawing.Size(216, 20)
        Me.txtSenhaConf.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Confirmar senha"
        '
        'txtSenhaAtual
        '
        Me.txtSenhaAtual.Location = New System.Drawing.Point(118, 12)
        Me.txtSenhaAtual.Name = "txtSenhaAtual"
        Me.txtSenhaAtual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenhaAtual.Size = New System.Drawing.Size(216, 20)
        Me.txtSenhaAtual.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Senha Atual"
        '
        'frmTrocaSenha
        '
        Me.AcceptButton = Me.butOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancela
        Me.ClientSize = New System.Drawing.Size(380, 169)
        Me.Controls.Add(Me.txtSenhaAtual)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSenhaConf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTrocaSenha"
        Me.Text = "Alterar senha de usuário"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSenhaConf As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSenhaAtual As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
