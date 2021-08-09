<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPtoCr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPtoCr))
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.txtRecNome = New System.Windows.Forms.TextBox()
        Me.txtRecNum = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.txtCipId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRotaDescr = New System.Windows.Forms.TextBox()
        Me.txtRecCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRotaCirc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.butFecha = New System.Windows.Forms.Button()
        Me.PtoCrId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pergunta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resposta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PtoCrId, Me.Pergunta, Me.Resposta})
        Me.gvItens.Location = New System.Drawing.Point(13, 76)
        Me.gvItens.MultiSelect = False
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(877, 213)
        Me.gvItens.TabIndex = 35
        '
        'txtRecNome
        '
        Me.txtRecNome.BackColor = System.Drawing.Color.White
        Me.txtRecNome.Location = New System.Drawing.Point(131, 36)
        Me.txtRecNome.Name = "txtRecNome"
        Me.txtRecNome.ReadOnly = True
        Me.txtRecNome.Size = New System.Drawing.Size(495, 20)
        Me.txtRecNome.TabIndex = 59
        '
        'txtRecNum
        '
        Me.txtRecNum.BackColor = System.Drawing.Color.White
        Me.txtRecNum.Location = New System.Drawing.Point(61, 36)
        Me.txtRecNum.Name = "txtRecNum"
        Me.txtRecNum.ReadOnly = True
        Me.txtRecNum.Size = New System.Drawing.Size(64, 20)
        Me.txtRecNum.TabIndex = 58
        Me.txtRecNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Receita"
        '
        'txtRotaId
        '
        Me.txtRotaId.BackColor = System.Drawing.Color.White
        Me.txtRotaId.Location = New System.Drawing.Point(61, 10)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.ReadOnly = True
        Me.txtRotaId.Size = New System.Drawing.Size(64, 20)
        Me.txtRotaId.TabIndex = 56
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCipId
        '
        Me.txtCipId.BackColor = System.Drawing.Color.White
        Me.txtCipId.Location = New System.Drawing.Point(830, 10)
        Me.txtCipId.Name = "txtCipId"
        Me.txtCipId.ReadOnly = True
        Me.txtCipId.Size = New System.Drawing.Size(64, 20)
        Me.txtCipId.TabIndex = 55
        Me.txtCipId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(785, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "CipId"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Rota"
        '
        'txtRotaDescr
        '
        Me.txtRotaDescr.BackColor = System.Drawing.Color.White
        Me.txtRotaDescr.Location = New System.Drawing.Point(131, 10)
        Me.txtRotaDescr.Name = "txtRotaDescr"
        Me.txtRotaDescr.ReadOnly = True
        Me.txtRotaDescr.Size = New System.Drawing.Size(495, 20)
        Me.txtRotaDescr.TabIndex = 52
        '
        'txtRecCodigo
        '
        Me.txtRecCodigo.BackColor = System.Drawing.Color.White
        Me.txtRecCodigo.Location = New System.Drawing.Point(678, 36)
        Me.txtRecCodigo.Name = "txtRecCodigo"
        Me.txtRecCodigo.ReadOnly = True
        Me.txtRecCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtRecCodigo.TabIndex = 51
        Me.txtRecCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(632, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Código"
        '
        'txtRotaCirc
        '
        Me.txtRotaCirc.BackColor = System.Drawing.Color.White
        Me.txtRotaCirc.Location = New System.Drawing.Point(678, 10)
        Me.txtRotaCirc.Name = "txtRotaCirc"
        Me.txtRotaCirc.ReadOnly = True
        Me.txtRotaCirc.Size = New System.Drawing.Size(63, 20)
        Me.txtRotaCirc.TabIndex = 49
        Me.txtRotaCirc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(632, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Circ"
        '
        'butFecha
        '
        Me.butFecha.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butFecha.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butFecha.Location = New System.Drawing.Point(254, 307)
        Me.butFecha.Name = "butFecha"
        Me.butFecha.Size = New System.Drawing.Size(390, 50)
        Me.butFecha.TabIndex = 60
        Me.butFecha.Text = "Fecha"
        Me.butFecha.UseVisualStyleBackColor = True
        '
        'PtoCrId
        '
        Me.PtoCrId.DataPropertyName = "PtoCrId"
        Me.PtoCrId.HeaderText = "PtoCrId"
        Me.PtoCrId.Name = "PtoCrId"
        Me.PtoCrId.ReadOnly = True
        Me.PtoCrId.Visible = False
        '
        'Pergunta
        '
        Me.Pergunta.DataPropertyName = "Pergunta"
        Me.Pergunta.HeaderText = "Pergunta"
        Me.Pergunta.Name = "Pergunta"
        Me.Pergunta.ReadOnly = True
        Me.Pergunta.Width = 700
        '
        'Resposta
        '
        Me.Resposta.DataPropertyName = "Resposta"
        Me.Resposta.HeaderText = "Resposta"
        Me.Resposta.Name = "Resposta"
        Me.Resposta.ReadOnly = True
        '
        'frmPtoCr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 364)
        Me.Controls.Add(Me.butFecha)
        Me.Controls.Add(Me.txtRecNome)
        Me.Controls.Add(Me.txtRecNum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRotaId)
        Me.Controls.Add(Me.txtCipId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRotaDescr)
        Me.Controls.Add(Me.txtRecCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRotaCirc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gvItens)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPtoCr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pontos Críticos"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents txtRecNome As System.Windows.Forms.TextBox
    Friend WithEvents txtRecNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents txtCipId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRotaDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtRecCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRotaCirc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents butFecha As System.Windows.Forms.Button
    Friend WithEvents PtoCrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pergunta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resposta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
