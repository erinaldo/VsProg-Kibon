<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadRotasLim
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadRotasLim))
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.CipPasso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CondMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CondMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VazaoMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VazaoMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempoAjuste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.txtLimRev = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butAdd = New System.Windows.Forms.ToolStripButton()
        Me.butEdita = New System.Windows.Forms.ToolStripButton()
        Me.butFecha = New System.Windows.Forms.ToolStripButton()
        Me.txtPrcTempoMax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CipPasso, Me.Descr, Me.TempMax, Me.TempMin, Me.CondMax, Me.CondMin, Me.VazaoMax, Me.VazaoMin, Me.TempoAjuste})
        Me.gvItens.Location = New System.Drawing.Point(0, 112)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersVisible = False
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(778, 269)
        Me.gvItens.TabIndex = 5
        '
        'CipPasso
        '
        Me.CipPasso.DataPropertyName = "CipPasso"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CipPasso.DefaultCellStyle = DataGridViewCellStyle1
        Me.CipPasso.HeaderText = "CipPasso"
        Me.CipPasso.Name = "CipPasso"
        Me.CipPasso.ReadOnly = True
        Me.CipPasso.Width = 70
        '
        'Descr
        '
        Me.Descr.DataPropertyName = "Descr"
        Me.Descr.HeaderText = "Descr"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 150
        '
        'TempMax
        '
        Me.TempMax.DataPropertyName = "TempMax"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TempMax.DefaultCellStyle = DataGridViewCellStyle2
        Me.TempMax.HeaderText = "TempMax"
        Me.TempMax.Name = "TempMax"
        Me.TempMax.ReadOnly = True
        Me.TempMax.Width = 70
        '
        'TempMin
        '
        Me.TempMin.DataPropertyName = "TempMin"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TempMin.DefaultCellStyle = DataGridViewCellStyle3
        Me.TempMin.HeaderText = "TempMin"
        Me.TempMin.Name = "TempMin"
        Me.TempMin.ReadOnly = True
        Me.TempMin.Width = 70
        '
        'CondMax
        '
        Me.CondMax.DataPropertyName = "CondMax"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CondMax.DefaultCellStyle = DataGridViewCellStyle4
        Me.CondMax.HeaderText = "CondMax"
        Me.CondMax.Name = "CondMax"
        Me.CondMax.ReadOnly = True
        Me.CondMax.Width = 70
        '
        'CondMin
        '
        Me.CondMin.DataPropertyName = "CondMin"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CondMin.DefaultCellStyle = DataGridViewCellStyle5
        Me.CondMin.HeaderText = "CondMin"
        Me.CondMin.Name = "CondMin"
        Me.CondMin.ReadOnly = True
        Me.CondMin.Width = 70
        '
        'VazaoMax
        '
        Me.VazaoMax.DataPropertyName = "VazaoMax"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.VazaoMax.DefaultCellStyle = DataGridViewCellStyle6
        Me.VazaoMax.HeaderText = "VazaoMax"
        Me.VazaoMax.Name = "VazaoMax"
        Me.VazaoMax.ReadOnly = True
        Me.VazaoMax.Width = 70
        '
        'VazaoMin
        '
        Me.VazaoMin.DataPropertyName = "VazaoMin"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.VazaoMin.DefaultCellStyle = DataGridViewCellStyle7
        Me.VazaoMin.HeaderText = "VazaoMin"
        Me.VazaoMin.Name = "VazaoMin"
        Me.VazaoMin.ReadOnly = True
        Me.VazaoMin.Width = 70
        '
        'TempoAjuste
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TempoAjuste.DefaultCellStyle = DataGridViewCellStyle8
        Me.TempoAjuste.HeaderText = "TempoAjuste"
        Me.TempoAjuste.Name = "TempoAjuste"
        Me.TempoAjuste.ReadOnly = True
        Me.TempoAjuste.Width = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "RotaId"
        '
        'txtRotaId
        '
        Me.txtRotaId.BackColor = System.Drawing.Color.White
        Me.txtRotaId.Location = New System.Drawing.Point(107, 52)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.ReadOnly = True
        Me.txtRotaId.Size = New System.Drawing.Size(63, 20)
        Me.txtRotaId.TabIndex = 8
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescr
        '
        Me.txtDescr.BackColor = System.Drawing.Color.White
        Me.txtDescr.Location = New System.Drawing.Point(107, 78)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.ReadOnly = True
        Me.txtDescr.Size = New System.Drawing.Size(444, 20)
        Me.txtDescr.TabIndex = 13
        '
        'txtLimRev
        '
        Me.txtLimRev.BackColor = System.Drawing.Color.White
        Me.txtLimRev.Location = New System.Drawing.Point(234, 52)
        Me.txtLimRev.Name = "txtLimRev"
        Me.txtLimRev.ReadOnly = True
        Me.txtLimRev.Size = New System.Drawing.Size(63, 20)
        Me.txtLimRev.TabIndex = 15
        Me.txtLimRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Revisão"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Descr"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butAdd, Me.butEdita, Me.butFecha})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(778, 39)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butAdd
        '
        Me.butAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butAdd.Image = Global.KbCipRotas.My.Resources.Resources.document_new
        Me.butAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(36, 36)
        Me.butAdd.Text = "ToolStripButton3"
        Me.butAdd.ToolTipText = "Criar nova programação de CIP"
        '
        'butEdita
        '
        Me.butEdita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEdita.Image = Global.KbCipRotas.My.Resources.Resources.document_edit
        Me.butEdita.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEdita.Name = "butEdita"
        Me.butEdita.Size = New System.Drawing.Size(36, 36)
        Me.butEdita.Text = "ToolStripButton3"
        Me.butEdita.ToolTipText = "Criar nova programação de CIP"
        '
        'butFecha
        '
        Me.butFecha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butFecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butFecha.Image = CType(resources.GetObject("butFecha.Image"), System.Drawing.Image)
        Me.butFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butFecha.Name = "butFecha"
        Me.butFecha.Size = New System.Drawing.Size(36, 36)
        Me.butFecha.Text = "Fechar"
        '
        'txtPrcTempoMax
        '
        Me.txtPrcTempoMax.BackColor = System.Drawing.Color.White
        Me.txtPrcTempoMax.Location = New System.Drawing.Point(488, 52)
        Me.txtPrcTempoMax.Name = "txtPrcTempoMax"
        Me.txtPrcTempoMax.ReadOnly = True
        Me.txtPrcTempoMax.Size = New System.Drawing.Size(63, 20)
        Me.txtPrcTempoMax.TabIndex = 19
        Me.txtPrcTempoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Tempo máximo %"
        '
        'frmCadRotasLim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 381)
        Me.Controls.Add(Me.txtPrcTempoMax)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLimRev)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.txtRotaId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gvItens)
        Me.Name = "frmCadRotasLim"
        Me.Text = "Cadastro de limites de Rotas"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtLimRev As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents butFecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtPrcTempoMax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents butEdita As System.Windows.Forms.ToolStripButton
    Friend WithEvents CipPasso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CondMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CondMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VazaoMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VazaoMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempoAjuste As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
