<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnormVw
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRecNome = New System.Windows.Forms.TextBox()
        Me.txtRecNum = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.txtCipId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRotaDescr = New System.Windows.Forms.TextBox()
        Me.txtRecCodigo = New System.Windows.Forms.TextBox()
        Me.BlkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Passo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnormId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Evento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ObsSts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtRotaCirc = New System.Windows.Forms.TextBox()
        Me.Obs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.butFecha = New System.Windows.Forms.Button()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRecNome
        '
        Me.txtRecNome.BackColor = System.Drawing.Color.White
        Me.txtRecNome.Location = New System.Drawing.Point(133, 39)
        Me.txtRecNome.Name = "txtRecNome"
        Me.txtRecNome.ReadOnly = True
        Me.txtRecNome.Size = New System.Drawing.Size(495, 20)
        Me.txtRecNome.TabIndex = 55
        '
        'txtRecNum
        '
        Me.txtRecNum.BackColor = System.Drawing.Color.White
        Me.txtRecNum.Location = New System.Drawing.Point(63, 39)
        Me.txtRecNum.Name = "txtRecNum"
        Me.txtRecNum.ReadOnly = True
        Me.txtRecNum.Size = New System.Drawing.Size(64, 20)
        Me.txtRecNum.TabIndex = 54
        Me.txtRecNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Receita"
        '
        'txtRotaId
        '
        Me.txtRotaId.BackColor = System.Drawing.Color.White
        Me.txtRotaId.Location = New System.Drawing.Point(63, 13)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.ReadOnly = True
        Me.txtRotaId.Size = New System.Drawing.Size(64, 20)
        Me.txtRotaId.TabIndex = 52
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCipId
        '
        Me.txtCipId.BackColor = System.Drawing.Color.White
        Me.txtCipId.Location = New System.Drawing.Point(832, 13)
        Me.txtCipId.Name = "txtCipId"
        Me.txtCipId.ReadOnly = True
        Me.txtCipId.Size = New System.Drawing.Size(64, 20)
        Me.txtCipId.TabIndex = 48
        Me.txtCipId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(787, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "CipId"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Rota"
        '
        'txtRotaDescr
        '
        Me.txtRotaDescr.BackColor = System.Drawing.Color.White
        Me.txtRotaDescr.Location = New System.Drawing.Point(133, 13)
        Me.txtRotaDescr.Name = "txtRotaDescr"
        Me.txtRotaDescr.ReadOnly = True
        Me.txtRotaDescr.Size = New System.Drawing.Size(495, 20)
        Me.txtRotaDescr.TabIndex = 45
        '
        'txtRecCodigo
        '
        Me.txtRecCodigo.BackColor = System.Drawing.Color.White
        Me.txtRecCodigo.Location = New System.Drawing.Point(680, 39)
        Me.txtRecCodigo.Name = "txtRecCodigo"
        Me.txtRecCodigo.ReadOnly = True
        Me.txtRecCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtRecCodigo.TabIndex = 44
        Me.txtRecCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BlkNum
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BlkNum.DefaultCellStyle = DataGridViewCellStyle17
        Me.BlkNum.HeaderText = "Bloco"
        Me.BlkNum.Name = "BlkNum"
        Me.BlkNum.ReadOnly = True
        Me.BlkNum.Width = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(634, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Circ"
        '
        'DataHora
        '
        Me.DataHora.DataPropertyName = "DataHora"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataHora.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataHora.HeaderText = "Hora"
        Me.DataHora.Name = "DataHora"
        Me.DataHora.ReadOnly = True
        Me.DataHora.Width = 150
        '
        'Passo
        '
        Me.Passo.DataPropertyName = "Passo"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Passo.DefaultCellStyle = DataGridViewCellStyle19
        Me.Passo.HeaderText = "Passo"
        Me.Passo.Name = "Passo"
        Me.Passo.ReadOnly = True
        Me.Passo.Width = 50
        '
        'AnormId
        '
        Me.AnormId.DataPropertyName = "AnormId"
        Me.AnormId.HeaderText = "AnormId"
        Me.AnormId.Name = "AnormId"
        Me.AnormId.ReadOnly = True
        Me.AnormId.Visible = False
        '
        'Evento
        '
        Me.Evento.DataPropertyName = "Evento"
        Me.Evento.HeaderText = "Evento"
        Me.Evento.Name = "Evento"
        Me.Evento.ReadOnly = True
        Me.Evento.Width = 200
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(634, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Código"
        '
        'ObsSts
        '
        Me.ObsSts.DataPropertyName = "ObsSts"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ObsSts.DefaultCellStyle = DataGridViewCellStyle20
        Me.ObsSts.HeaderText = "Status"
        Me.ObsSts.Name = "ObsSts"
        Me.ObsSts.ReadOnly = True
        Me.ObsSts.Width = 50
        '
        'txtRotaCirc
        '
        Me.txtRotaCirc.BackColor = System.Drawing.Color.White
        Me.txtRotaCirc.Location = New System.Drawing.Point(680, 13)
        Me.txtRotaCirc.Name = "txtRotaCirc"
        Me.txtRotaCirc.ReadOnly = True
        Me.txtRotaCirc.Size = New System.Drawing.Size(63, 20)
        Me.txtRotaCirc.TabIndex = 42
        Me.txtRotaCirc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Obs
        '
        Me.Obs.DataPropertyName = "Obs"
        Me.Obs.HeaderText = "Obs"
        Me.Obs.Name = "Obs"
        Me.Obs.ReadOnly = True
        Me.Obs.Width = 350
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AnormId, Me.DataHora, Me.BlkNum, Me.Passo, Me.Evento, Me.ObsSts, Me.Obs})
        Me.gvItens.Location = New System.Drawing.Point(13, 75)
        Me.gvItens.MultiSelect = False
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(925, 377)
        Me.gvItens.TabIndex = 40
        '
        'butFecha
        '
        Me.butFecha.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butFecha.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butFecha.Location = New System.Drawing.Point(284, 471)
        Me.butFecha.Name = "butFecha"
        Me.butFecha.Size = New System.Drawing.Size(390, 50)
        Me.butFecha.TabIndex = 56
        Me.butFecha.Text = "Fecha"
        Me.butFecha.UseVisualStyleBackColor = True
        '
        'frmAnormVw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 533)
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
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRotaCirc)
        Me.Controls.Add(Me.gvItens)
        Me.Name = "frmAnormVw"
        Me.Text = "Lista de Anormalidades Correntes"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecNome As System.Windows.Forms.TextBox
    Friend WithEvents txtRecNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents txtCipId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRotaDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtRecCodigo As System.Windows.Forms.TextBox
    Friend WithEvents BlkNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Passo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnormId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Evento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ObsSts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRotaCirc As System.Windows.Forms.TextBox
    Friend WithEvents Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents butFecha As System.Windows.Forms.Button
End Class
