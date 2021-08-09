<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelCip
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
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRotaDescr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butSelRota = New System.Windows.Forms.Button()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCirc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.burtSelRec = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecNome = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRecDescr = New System.Windows.Forms.TextBox()
        Me.txtRecNum = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRotaId
        '
        Me.txtRotaId.BackColor = System.Drawing.Color.White
        Me.txtRotaId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotaId.ForeColor = System.Drawing.Color.Black
        Me.txtRotaId.Location = New System.Drawing.Point(71, 27)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.ReadOnly = True
        Me.txtRotaId.Size = New System.Drawing.Size(88, 26)
        Me.txtRotaId.TabIndex = 51
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Rota"
        '
        'txtRotaDescr
        '
        Me.txtRotaDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotaDescr.Location = New System.Drawing.Point(71, 59)
        Me.txtRotaDescr.Name = "txtRotaDescr"
        Me.txtRotaDescr.Size = New System.Drawing.Size(494, 26)
        Me.txtRotaDescr.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Descr:"
        '
        'butCancela
        '
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(451, 260)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(149, 32)
        Me.butCancela.TabIndex = 49
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(109, 260)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(153, 32)
        Me.butOk.TabIndex = 48
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butSelRota)
        Me.GroupBox1.Controls.Add(Me.txtTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCirc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRotaDescr)
        Me.GroupBox1.Controls.Add(Me.txtRotaId)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 114)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rota de CIP"
        '
        'butSelRota
        '
        Me.butSelRota.Image = Global.Geral.My.Resources.Resources.book_blue_find
        Me.butSelRota.Location = New System.Drawing.Point(571, 27)
        Me.butSelRota.Name = "butSelRota"
        Me.butSelRota.Size = New System.Drawing.Size(73, 58)
        Me.butSelRota.TabIndex = 57
        Me.butSelRota.UseVisualStyleBackColor = True
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.White
        Me.txtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.ForeColor = System.Drawing.Color.Black
        Me.txtTipo.Location = New System.Drawing.Point(477, 27)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(88, 26)
        Me.txtTipo.TabIndex = 55
        Me.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(443, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Tipo"
        '
        'txtCirc
        '
        Me.txtCirc.BackColor = System.Drawing.Color.White
        Me.txtCirc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCirc.ForeColor = System.Drawing.Color.Black
        Me.txtCirc.Location = New System.Drawing.Point(286, 27)
        Me.txtCirc.Name = "txtCirc"
        Me.txtCirc.ReadOnly = True
        Me.txtCirc.Size = New System.Drawing.Size(88, 26)
        Me.txtCirc.TabIndex = 53
        Me.txtCirc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(255, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Circ"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.burtSelRec)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtRecNome)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtRecDescr)
        Me.GroupBox2.Controls.Add(Me.txtRecNum)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 132)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(650, 109)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Receita"
        '
        'burtSelRec
        '
        Me.burtSelRec.Image = Global.Geral.My.Resources.Resources.book_blue_view
        Me.burtSelRec.Location = New System.Drawing.Point(571, 24)
        Me.burtSelRec.Name = "burtSelRec"
        Me.burtSelRec.Size = New System.Drawing.Size(73, 58)
        Me.burtSelRec.TabIndex = 66
        Me.burtSelRec.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.Black
        Me.txtCodigo.Location = New System.Drawing.Point(477, 24)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(88, 26)
        Me.txtCodigo.TabIndex = 64
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(431, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Código"
        '
        'txtRecNome
        '
        Me.txtRecNome.BackColor = System.Drawing.Color.White
        Me.txtRecNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecNome.ForeColor = System.Drawing.Color.Black
        Me.txtRecNome.Location = New System.Drawing.Point(226, 24)
        Me.txtRecNome.Name = "txtRecNome"
        Me.txtRecNome.ReadOnly = True
        Me.txtRecNome.Size = New System.Drawing.Size(199, 26)
        Me.txtRecNome.TabIndex = 62
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(185, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Nome"
        '
        'txtRecDescr
        '
        Me.txtRecDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecDescr.Location = New System.Drawing.Point(71, 56)
        Me.txtRecDescr.Name = "txtRecDescr"
        Me.txtRecDescr.Size = New System.Drawing.Size(494, 26)
        Me.txtRecDescr.TabIndex = 58
        '
        'txtRecNum
        '
        Me.txtRecNum.BackColor = System.Drawing.Color.White
        Me.txtRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecNum.ForeColor = System.Drawing.Color.Black
        Me.txtRecNum.Location = New System.Drawing.Point(71, 24)
        Me.txtRecNum.Name = "txtRecNum"
        Me.txtRecNum.ReadOnly = True
        Me.txtRecNum.Size = New System.Drawing.Size(88, 26)
        Me.txtRecNum.TabIndex = 60
        Me.txtRecNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Descr:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Rec"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(633, 292)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "V1.0"
        '
        'frmSelCip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 314)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Name = "frmSelCip"
        Me.Text = "Seleção de CIP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRotaDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butSelRota As System.Windows.Forms.Button
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCirc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents burtSelRec As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRecNome As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRecDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtRecNum As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
