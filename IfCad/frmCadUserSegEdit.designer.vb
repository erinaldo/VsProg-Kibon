<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadUserSegEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadUserSegEdit))
        Me.txtSegId = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.lblSegId = New System.Windows.Forms.Label()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.lblDescr = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtSegId
        '
        Me.txtSegId.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSegId.Location = New System.Drawing.Point(80, 13)
        Me.txtSegId.Name = "txtSegId"
        Me.txtSegId.Size = New System.Drawing.Size(63, 20)
        Me.txtSegId.TabIndex = 0
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(80, 44)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(205, 20)
        Me.txtNome.TabIndex = 1
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(80, 74)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(205, 20)
        Me.txtDescr.TabIndex = 2
        '
        'lblSegId
        '
        Me.lblSegId.AutoSize = True
        Me.lblSegId.Location = New System.Drawing.Point(28, 19)
        Me.lblSegId.Name = "lblSegId"
        Me.lblSegId.Size = New System.Drawing.Size(35, 13)
        Me.lblSegId.TabIndex = 3
        Me.lblSegId.Text = "SegId"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.Location = New System.Drawing.Point(28, 50)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(35, 13)
        Me.lblNome.TabIndex = 4
        Me.lblNome.Text = "Nome"
        '
        'lblDescr
        '
        Me.lblDescr.AutoSize = True
        Me.lblDescr.Location = New System.Drawing.Point(8, 77)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.Size = New System.Drawing.Size(55, 13)
        Me.lblDescr.TabIndex = 5
        Me.lblDescr.Text = "Descricao"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(31, 108)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(110, 25)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(157, 108)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(110, 25)
        Me.btnCancela.TabIndex = 7
        Me.btnCancela.Text = "Cancela"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'frmCadUserSegEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 144)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblDescr)
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.lblSegId)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtSegId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadUserSegEdit"
        Me.Text = "Edita Area de Seguranca"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSegId As System.Windows.Forms.TextBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents lblSegId As System.Windows.Forms.Label
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents lblDescr As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
End Class
