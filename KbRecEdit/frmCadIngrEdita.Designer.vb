<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadIngrEdita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadIngrEdita))
        Me.txtIngrCodigo = New System.Windows.Forms.TextBox()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIngrNome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtIngrCodigo
        '
        Me.txtIngrCodigo.BackColor = System.Drawing.Color.White
        Me.txtIngrCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngrCodigo.Location = New System.Drawing.Point(93, 6)
        Me.txtIngrCodigo.Name = "txtIngrCodigo"
        Me.txtIngrCodigo.Size = New System.Drawing.Size(285, 23)
        Me.txtIngrCodigo.TabIndex = 41
        '
        'butCancela
        '
        Me.butCancela.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butCancela.Location = New System.Drawing.Point(304, 103)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(75, 23)
        Me.butCancela.TabIndex = 40
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butOk.Location = New System.Drawing.Point(223, 103)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(75, 23)
        Me.butOk.TabIndex = 39
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Código:"
        '
        'txtIngrNome
        '
        Me.txtIngrNome.BackColor = System.Drawing.Color.White
        Me.txtIngrNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngrNome.Location = New System.Drawing.Point(93, 35)
        Me.txtIngrNome.Multiline = True
        Me.txtIngrNome.Name = "txtIngrNome"
        Me.txtIngrNome.Size = New System.Drawing.Size(285, 63)
        Me.txtIngrNome.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Descrição:"
        '
        'frmCadIngrEdita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 132)
        Me.Controls.Add(Me.txtIngrNome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIngrCodigo)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadIngrEdita"
        Me.Text = "Cadastro de Ingredientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIngrCodigo As System.Windows.Forms.TextBox
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIngrNome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
