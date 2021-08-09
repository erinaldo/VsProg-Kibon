<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadAlergEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadAlergEdit))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.butOp = New System.Windows.Forms.Button()
        Me.butCancelar = New System.Windows.Forms.Button()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLetra = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descrição:"
        '
        'butOp
        '
        Me.butOp.Location = New System.Drawing.Point(238, 124)
        Me.butOp.Name = "butOp"
        Me.butOp.Size = New System.Drawing.Size(75, 23)
        Me.butOp.TabIndex = 10
        Me.butOp.Text = "Novo"
        Me.butOp.UseVisualStyleBackColor = True
        '
        'butCancelar
        '
        Me.butCancelar.Location = New System.Drawing.Point(320, 124)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(75, 23)
        Me.butCancelar.TabIndex = 11
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(71, 33)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(324, 20)
        Me.txtNome.TabIndex = 8
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(71, 59)
        Me.txtDescr.Multiline = True
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(324, 59)
        Me.txtDescr.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Letra:"
        '
        'txtLetra
        '
        Me.txtLetra.Location = New System.Drawing.Point(71, 7)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(57, 20)
        Me.txtLetra.TabIndex = 7
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmCadAlergEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 152)
        Me.Controls.Add(Me.txtLetra)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.butCancelar)
        Me.Controls.Add(Me.butOp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadAlergEdit"
        Me.Text = "Cadastro de Alergênicos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents butOp As System.Windows.Forms.Button
    Friend WithEvents butCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLetra As System.Windows.Forms.TextBox
End Class
