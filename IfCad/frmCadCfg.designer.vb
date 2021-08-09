<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadCfg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadCfg))
        Me.gvCadCfg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsBarraBotoes = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.btnEdita = New System.Windows.Forms.ToolStripButton()
        Me.btnSair = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleta = New System.Windows.Forms.ToolStripButton()
        Me.btnSalva = New System.Windows.Forms.ToolStripButton()
        CType(Me.gvCadCfg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsBarraBotoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvCadCfg
        '
        Me.gvCadCfg.AllowUserToAddRows = False
        Me.gvCadCfg.AllowUserToDeleteRows = False
        Me.gvCadCfg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvCadCfg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadCfg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.gvCadCfg.Location = New System.Drawing.Point(0, 39)
        Me.gvCadCfg.Name = "gvCadCfg"
        Me.gvCadCfg.ReadOnly = True
        Me.gvCadCfg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadCfg.Size = New System.Drawing.Size(562, 315)
        Me.gvCadCfg.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cfg"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'Column2
        '
        Me.Column2.HeaderText = "Valor"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 300
        '
        'tsBarraBotoes
        '
        Me.tsBarraBotoes.Dock = System.Windows.Forms.DockStyle.None
        Me.tsBarraBotoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.btnEdita, Me.btnSair, Me.btnDeleta, Me.btnSalva})
        Me.tsBarraBotoes.Location = New System.Drawing.Point(0, 0)
        Me.tsBarraBotoes.Name = "tsBarraBotoes"
        Me.tsBarraBotoes.Size = New System.Drawing.Size(352, 36)
        Me.tsBarraBotoes.Stretch = True
        Me.tsBarraBotoes.TabIndex = 5
        Me.tsBarraBotoes.Text = "ToolStrip1"
        '
        'btnNovo
        '
        Me.btnNovo.AutoSize = False
        Me.btnNovo.Image = CType(resources.GetObject("btnNovo.Image"), System.Drawing.Image)
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(70, 33)
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNovo.ToolTipText = "Novo Usuário"
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
        'btnSalva
        '
        Me.btnSalva.AutoSize = False
        Me.btnSalva.Image = CType(resources.GetObject("btnSalva.Image"), System.Drawing.Image)
        Me.btnSalva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(70, 33)
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSalva.ToolTipText = "Gravar alterações"
        '
        'frmCadCfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 353)
        Me.Controls.Add(Me.tsBarraBotoes)
        Me.Controls.Add(Me.gvCadCfg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadCfg"
        Me.Text = "frmCadCfg"
        CType(Me.gvCadCfg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsBarraBotoes.ResumeLayout(False)
        Me.tsBarraBotoes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvCadCfg As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents tsBarraBotoes As System.Windows.Forms.ToolStrip
    Public WithEvents btnNovo As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdita As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSair As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDeleta As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSalva As System.Windows.Forms.ToolStripButton
End Class
