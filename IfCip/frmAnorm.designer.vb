<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnorm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnorm))
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRotaDescr = New System.Windows.Forms.TextBox()
        Me.txtRecCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRotaCirc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCipId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.butObsAceita = New System.Windows.Forms.Button()
        Me.butFecha = New System.Windows.Forms.Button()
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRecNum = New System.Windows.Forms.TextBox()
        Me.txtRecNome = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AnormId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Passo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Evento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsSts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obs = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AnormId, Me.DataHora, Me.BlkNum, Me.Passo, Me.Evento, Me.ObsSts, Me.Obs})
        Me.gvItens.Location = New System.Drawing.Point(12, 77)
        Me.gvItens.MultiSelect = False
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(925, 301)
        Me.gvItens.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Rota"
        '
        'txtRotaDescr
        '
        Me.txtRotaDescr.BackColor = System.Drawing.Color.White
        Me.txtRotaDescr.Location = New System.Drawing.Point(132, 15)
        Me.txtRotaDescr.Name = "txtRotaDescr"
        Me.txtRotaDescr.ReadOnly = True
        Me.txtRotaDescr.Size = New System.Drawing.Size(495, 20)
        Me.txtRotaDescr.TabIndex = 23
        '
        'txtRecCodigo
        '
        Me.txtRecCodigo.BackColor = System.Drawing.Color.White
        Me.txtRecCodigo.Location = New System.Drawing.Point(679, 41)
        Me.txtRecCodigo.Name = "txtRecCodigo"
        Me.txtRecCodigo.ReadOnly = True
        Me.txtRecCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtRecCodigo.TabIndex = 22
        Me.txtRecCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(633, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Código"
        '
        'txtRotaCirc
        '
        Me.txtRotaCirc.BackColor = System.Drawing.Color.White
        Me.txtRotaCirc.Location = New System.Drawing.Point(679, 15)
        Me.txtRotaCirc.Name = "txtRotaCirc"
        Me.txtRotaCirc.ReadOnly = True
        Me.txtRotaCirc.Size = New System.Drawing.Size(63, 20)
        Me.txtRotaCirc.TabIndex = 20
        Me.txtRotaCirc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(633, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Circ"
        '
        'txtCipId
        '
        Me.txtCipId.BackColor = System.Drawing.Color.White
        Me.txtCipId.Location = New System.Drawing.Point(831, 15)
        Me.txtCipId.Name = "txtCipId"
        Me.txtCipId.ReadOnly = True
        Me.txtCipId.Size = New System.Drawing.Size(64, 20)
        Me.txtCipId.TabIndex = 28
        Me.txtCipId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(786, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "CipId"
        '
        'txtObs
        '
        Me.txtObs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObs.Location = New System.Drawing.Point(13, 384)
        Me.txtObs.MaxLength = 256
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(828, 65)
        Me.txtObs.TabIndex = 30
        '
        'butObsAceita
        '
        Me.butObsAceita.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butObsAceita.Location = New System.Drawing.Point(862, 384)
        Me.butObsAceita.Name = "butObsAceita"
        Me.butObsAceita.Size = New System.Drawing.Size(75, 65)
        Me.butObsAceita.TabIndex = 31
        Me.butObsAceita.Text = "Aceita Observação"
        Me.butObsAceita.UseVisualStyleBackColor = True
        '
        'butFecha
        '
        Me.butFecha.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butFecha.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butFecha.Location = New System.Drawing.Point(275, 471)
        Me.butFecha.Name = "butFecha"
        Me.butFecha.Size = New System.Drawing.Size(390, 50)
        Me.butFecha.TabIndex = 34
        Me.butFecha.Text = "Fecha"
        Me.butFecha.UseVisualStyleBackColor = True
        '
        'txtRotaId
        '
        Me.txtRotaId.BackColor = System.Drawing.Color.White
        Me.txtRotaId.Location = New System.Drawing.Point(62, 15)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.ReadOnly = True
        Me.txtRotaId.Size = New System.Drawing.Size(64, 20)
        Me.txtRotaId.TabIndex = 35
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Receita"
        '
        'txtRecNum
        '
        Me.txtRecNum.BackColor = System.Drawing.Color.White
        Me.txtRecNum.Location = New System.Drawing.Point(62, 41)
        Me.txtRecNum.Name = "txtRecNum"
        Me.txtRecNum.ReadOnly = True
        Me.txtRecNum.Size = New System.Drawing.Size(64, 20)
        Me.txtRecNum.TabIndex = 37
        Me.txtRecNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRecNome
        '
        Me.txtRecNome.BackColor = System.Drawing.Color.White
        Me.txtRecNome.Location = New System.Drawing.Point(132, 41)
        Me.txtRecNome.Name = "txtRecNome"
        Me.txtRecNome.ReadOnly = True
        Me.txtRecNome.Size = New System.Drawing.Size(495, 20)
        Me.txtRecNome.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 452)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "(256 caracteres)"
        '
        'AnormId
        '
        Me.AnormId.DataPropertyName = "AnormId"
        Me.AnormId.HeaderText = "AnormId"
        Me.AnormId.Name = "AnormId"
        Me.AnormId.ReadOnly = True
        Me.AnormId.Visible = False
        '
        'DataHora
        '
        Me.DataHora.DataPropertyName = "DataHora"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataHora.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataHora.HeaderText = "Hora"
        Me.DataHora.Name = "DataHora"
        Me.DataHora.ReadOnly = True
        Me.DataHora.Width = 150
        '
        'BlkNum
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BlkNum.DefaultCellStyle = DataGridViewCellStyle2
        Me.BlkNum.HeaderText = "Bloco"
        Me.BlkNum.Name = "BlkNum"
        Me.BlkNum.ReadOnly = True
        Me.BlkNum.Width = 50
        '
        'Passo
        '
        Me.Passo.DataPropertyName = "Passo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Passo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Passo.HeaderText = "Passo"
        Me.Passo.Name = "Passo"
        Me.Passo.ReadOnly = True
        Me.Passo.Width = 50
        '
        'Evento
        '
        Me.Evento.DataPropertyName = "Evento"
        Me.Evento.HeaderText = "Evento"
        Me.Evento.Name = "Evento"
        Me.Evento.ReadOnly = True
        Me.Evento.Width = 200
        '
        'ObsSts
        '
        Me.ObsSts.DataPropertyName = "ObsSts"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ObsSts.DefaultCellStyle = DataGridViewCellStyle4
        Me.ObsSts.HeaderText = "Status"
        Me.ObsSts.Name = "ObsSts"
        Me.ObsSts.ReadOnly = True
        Me.ObsSts.Width = 50
        '
        'Obs
        '
        Me.Obs.DataPropertyName = "Obs"
        Me.Obs.HeaderText = "Obs"
        Me.Obs.Name = "Obs"
        Me.Obs.ReadOnly = True
        Me.Obs.Width = 350
        '
        'frmAnorm
        '
        Me.AcceptButton = Me.butObsAceita
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butFecha
        Me.ClientSize = New System.Drawing.Size(949, 533)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRecNome)
        Me.Controls.Add(Me.txtRecNum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRotaId)
        Me.Controls.Add(Me.butFecha)
        Me.Controls.Add(Me.butObsAceita)
        Me.Controls.Add(Me.txtObs)
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
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Name = "frmAnorm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Anormalidades"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRotaDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtRecCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRotaCirc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCipId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents butObsAceita As System.Windows.Forms.Button
    Friend WithEvents butFecha As System.Windows.Forms.Button
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRecNum As System.Windows.Forms.TextBox
    Friend WithEvents txtRecNome As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AnormId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlkNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Passo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Evento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObsSts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Obs As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
