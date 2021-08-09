<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelValv
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbFlip = New System.Windows.Forms.ComboBox()
        Me.rdFlip = New System.Windows.Forms.RadioButton()
        Me.rdNac = New System.Windows.Forms.RadioButton()
        Me.rdAc = New System.Windows.Forms.RadioButton()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.lstValvulas = New System.Windows.Forms.ListBox()
        Me.butOk = New System.Windows.Forms.Button()
        Me.butCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtFiltro)
        Me.GroupBox1.Controls.Add(Me.lstValvulas)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 195)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Válvula"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Selecione"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Filtro"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbFlip)
        Me.GroupBox2.Controls.Add(Me.rdFlip)
        Me.GroupBox2.Controls.Add(Me.rdNac)
        Me.GroupBox2.Controls.Add(Me.rdAc)
        Me.GroupBox2.Location = New System.Drawing.Point(198, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(179, 125)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        '
        'cmbFlip
        '
        Me.cmbFlip.FormattingEnabled = True
        Me.cmbFlip.Location = New System.Drawing.Point(77, 71)
        Me.cmbFlip.Name = "cmbFlip"
        Me.cmbFlip.Size = New System.Drawing.Size(77, 21)
        Me.cmbFlip.TabIndex = 3
        '
        'rdFlip
        '
        Me.rdFlip.AutoSize = True
        Me.rdFlip.Location = New System.Drawing.Point(30, 72)
        Me.rdFlip.Name = "rdFlip"
        Me.rdFlip.Size = New System.Drawing.Size(41, 17)
        Me.rdFlip.TabIndex = 2
        Me.rdFlip.TabStop = True
        Me.rdFlip.Text = "Flip"
        Me.rdFlip.UseVisualStyleBackColor = True
        '
        'rdNac
        '
        Me.rdNac.AutoSize = True
        Me.rdNac.Location = New System.Drawing.Point(30, 49)
        Me.rdNac.Name = "rdNac"
        Me.rdNac.Size = New System.Drawing.Size(93, 17)
        Me.rdNac.TabIndex = 1
        Me.rdNac.TabStop = True
        Me.rdNac.Text = "Não Acionada"
        Me.rdNac.UseVisualStyleBackColor = True
        '
        'rdAc
        '
        Me.rdAc.AutoSize = True
        Me.rdAc.Location = New System.Drawing.Point(30, 26)
        Me.rdAc.Name = "rdAc"
        Me.rdAc.Size = New System.Drawing.Size(70, 17)
        Me.rdAc.TabIndex = 0
        Me.rdAc.TabStop = True
        Me.rdAc.Text = "Acionada"
        Me.rdAc.UseVisualStyleBackColor = True
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(19, 149)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(149, 20)
        Me.txtFiltro.TabIndex = 1
        '
        'lstValvulas
        '
        Me.lstValvulas.FormattingEnabled = True
        Me.lstValvulas.Location = New System.Drawing.Point(19, 35)
        Me.lstValvulas.Name = "lstValvulas"
        Me.lstValvulas.Size = New System.Drawing.Size(149, 95)
        Me.lstValvulas.TabIndex = 0
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(70, 221)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(134, 27)
        Me.butOk.TabIndex = 2
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'butCancelar
        '
        Me.butCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancelar.Location = New System.Drawing.Point(210, 221)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(134, 27)
        Me.butCancelar.TabIndex = 3
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'frmSelValv
        '
        Me.AcceptButton = Me.butOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancelar
        Me.ClientSize = New System.Drawing.Size(420, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.butCancelar)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSelValv"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Válvulas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents lstValvulas As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFlip As System.Windows.Forms.ComboBox
    Friend WithEvents rdFlip As System.Windows.Forms.RadioButton
    Friend WithEvents rdNac As System.Windows.Forms.RadioButton
    Friend WithEvents rdAc As System.Windows.Forms.RadioButton
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents butCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
