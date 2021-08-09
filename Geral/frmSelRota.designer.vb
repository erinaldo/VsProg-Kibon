<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelRota
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelRota))
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.colRotaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCirc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTQ1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTQ2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTQ3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbCircuito = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "UserId"
        Me.UserId.Name = "UserId"
        '
        'butCancela
        '
        Me.butCancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(486, 341)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(138, 30)
        Me.butCancela.TabIndex = 89
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butOk.Location = New System.Drawing.Point(130, 341)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(138, 30)
        Me.butOk.TabIndex = 88
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.AllowUserToResizeRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRotaID, Me.colDescr, Me.colCirc, Me.colTipo, Me.colTQ1, Me.colTQ2, Me.colTQ3, Me.colSeq})
        Me.gvItens.Location = New System.Drawing.Point(0, 58)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersWidth = 25
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(769, 273)
        Me.gvItens.TabIndex = 90
        '
        'colRotaID
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRotaID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRotaID.HeaderText = "RotaID"
        Me.colRotaID.Name = "colRotaID"
        Me.colRotaID.ReadOnly = True
        Me.colRotaID.Width = 60
        '
        'colDescr
        '
        Me.colDescr.HeaderText = "Descricao"
        Me.colDescr.Name = "colDescr"
        Me.colDescr.ReadOnly = True
        Me.colDescr.Width = 250
        '
        'colCirc
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCirc.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCirc.HeaderText = "Circuito"
        Me.colCirc.Name = "colCirc"
        Me.colCirc.ReadOnly = True
        Me.colCirc.Width = 50
        '
        'colTipo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTipo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 50
        '
        'colTQ1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTQ1.DefaultCellStyle = DataGridViewCellStyle4
        Me.colTQ1.HeaderText = "Tanque 1"
        Me.colTQ1.Name = "colTQ1"
        Me.colTQ1.ReadOnly = True
        '
        'colTQ2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTQ2.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTQ2.HeaderText = "Tanque 2"
        Me.colTQ2.Name = "colTQ2"
        Me.colTQ2.ReadOnly = True
        '
        'colTQ3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTQ3.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTQ3.HeaderText = "Tanque 3"
        Me.colTQ3.Name = "colTQ3"
        Me.colTQ3.ReadOnly = True
        '
        'colSeq
        '
        Me.colSeq.HeaderText = "Sequencia"
        Me.colSeq.Name = "colSeq"
        Me.colSeq.ReadOnly = True
        Me.colSeq.Visible = False
        '
        'cmbCircuito
        '
        Me.cmbCircuito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCircuito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCircuito.FormattingEnabled = True
        Me.cmbCircuito.Items.AddRange(New Object() {"*", "CA", "CB", "CC", "CD", "CE"})
        Me.cmbCircuito.Location = New System.Drawing.Point(79, 16)
        Me.cmbCircuito.Name = "cmbCircuito"
        Me.cmbCircuito.Size = New System.Drawing.Size(85, 28)
        Me.cmbCircuito.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Circuito"
        '
        'txtFiltro
        '
        Me.txtFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltro.Location = New System.Drawing.Point(232, 16)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(525, 26)
        Me.txtFiltro.TabIndex = 93
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Filtro"
        '
        'frmSelRota
        '
        Me.AcceptButton = Me.butOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancela
        Me.ClientSize = New System.Drawing.Size(769, 381)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.cmbCircuito)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelRota"
        Me.Text = "frmSelRota"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents GrupoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubgrupoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents colRotaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCirc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTQ1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTQ2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTQ3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbCircuito As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
