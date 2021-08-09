<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadProduto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadProduto))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSair = New System.Windows.Forms.ToolStripButton()
        Me.gvCadPtoCrRota = New System.Windows.Forms.DataGridView()
        Me.RotaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PtoCrId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PtoCrDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdita = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleta = New System.Windows.Forms.ToolStripButton()
        Me.btnNova = New System.Windows.Forms.ToolStripButton()
        Me.tsBarraBotoes = New System.Windows.Forms.ToolStrip()
        CType(Me.gvCadPtoCrRota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsBarraBotoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSair
        '
        Me.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSair.AutoSize = False
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(60, 33)
        Me.btnSair.Text = "Sair"
        Me.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'gvCadPtoCrRota
        '
        Me.gvCadPtoCrRota.AllowUserToAddRows = False
        Me.gvCadPtoCrRota.AllowUserToDeleteRows = False
        Me.gvCadPtoCrRota.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvCadPtoCrRota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadPtoCrRota.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RotaID, Me.PtoCrId, Me.PtoCrDescr, Me.Seq})
        Me.gvCadPtoCrRota.Location = New System.Drawing.Point(1, 40)
        Me.gvCadPtoCrRota.Name = "gvCadPtoCrRota"
        Me.gvCadPtoCrRota.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gvCadPtoCrRota.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gvCadPtoCrRota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadPtoCrRota.Size = New System.Drawing.Size(863, 406)
        Me.gvCadPtoCrRota.TabIndex = 5
        '
        'RotaID
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RotaID.DefaultCellStyle = DataGridViewCellStyle1
        Me.RotaID.HeaderText = "Rota Id"
        Me.RotaID.Name = "RotaID"
        Me.RotaID.ReadOnly = True
        Me.RotaID.Width = 80
        '
        'PtoCrId
        '
        Me.PtoCrId.HeaderText = "PtoCrId"
        Me.PtoCrId.Name = "PtoCrId"
        Me.PtoCrId.ReadOnly = True
        Me.PtoCrId.Visible = False
        '
        'PtoCrDescr
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.PtoCrDescr.DefaultCellStyle = DataGridViewCellStyle2
        Me.PtoCrDescr.HeaderText = "Pto Critico Descr"
        Me.PtoCrDescr.Name = "PtoCrDescr"
        Me.PtoCrDescr.ReadOnly = True
        Me.PtoCrDescr.Width = 500
        '
        'Seq
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Seq.DefaultCellStyle = DataGridViewCellStyle3
        Me.Seq.HeaderText = "Sequencia"
        Me.Seq.Name = "Seq"
        Me.Seq.ReadOnly = True
        Me.Seq.Width = 80
        '
        'btnEdita
        '
        Me.btnEdita.AutoSize = False
        Me.btnEdita.Image = CType(resources.GetObject("btnEdita.Image"), System.Drawing.Image)
        Me.btnEdita.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdita.Name = "btnEdita"
        Me.btnEdita.Size = New System.Drawing.Size(70, 33)
        Me.btnEdita.Text = "Alterar"
        Me.btnEdita.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEdita.ToolTipText = "Alterar Usuário"
        '
        'btnDeleta
        '
        Me.btnDeleta.AutoSize = False
        Me.btnDeleta.Image = CType(resources.GetObject("btnDeleta.Image"), System.Drawing.Image)
        Me.btnDeleta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleta.Name = "btnDeleta"
        Me.btnDeleta.Size = New System.Drawing.Size(70, 33)
        Me.btnDeleta.Text = "Remover"
        Me.btnDeleta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDeleta.ToolTipText = "Remover o item selecionado"
        '
        'btnNova
        '
        Me.btnNova.AutoSize = False
        Me.btnNova.Image = CType(resources.GetObject("btnNova.Image"), System.Drawing.Image)
        Me.btnNova.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNova.Name = "btnNova"
        Me.btnNova.Size = New System.Drawing.Size(70, 33)
        Me.btnNova.Text = "Novo"
        Me.btnNova.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNova.ToolTipText = "Novo Usuário"
        '
        'tsBarraBotoes
        '
        Me.tsBarraBotoes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsBarraBotoes.AutoSize = False
        Me.tsBarraBotoes.Dock = System.Windows.Forms.DockStyle.None
        Me.tsBarraBotoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNova, Me.btnEdita, Me.btnDeleta, Me.btnSair})
        Me.tsBarraBotoes.Location = New System.Drawing.Point(1, 1)
        Me.tsBarraBotoes.Name = "tsBarraBotoes"
        Me.tsBarraBotoes.Size = New System.Drawing.Size(863, 36)
        Me.tsBarraBotoes.Stretch = True
        Me.tsBarraBotoes.TabIndex = 6
        Me.tsBarraBotoes.Text = "ToolStrip1"
        '
        'frmCadPtoCritRota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 447)
        Me.Controls.Add(Me.gvCadPtoCrRota)
        Me.Controls.Add(Me.tsBarraBotoes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadPtoCritRota"
        Me.Text = "Ponto Crítico por Rota"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gvCadPtoCrRota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsBarraBotoes.ResumeLayout(False)
        Me.tsBarraBotoes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btnSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvCadPtoCrRota As System.Windows.Forms.DataGridView
    Public WithEvents btnEdita As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDeleta As System.Windows.Forms.ToolStripButton
    Public WithEvents btnNova As System.Windows.Forms.ToolStripButton
    Public WithEvents tsBarraBotoes As System.Windows.Forms.ToolStrip
    Friend WithEvents RotaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PtoCrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PtoCrDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seq As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
