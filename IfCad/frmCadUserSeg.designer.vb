<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadUserSeg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadUserSeg))
        Me.gvCadUserSeg = New System.Windows.Forms.DataGridView()
        Me.ColSegId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsBarraBotoes = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.btnEdita = New System.Windows.Forms.ToolStripButton()
        Me.btnSalva = New System.Windows.Forms.ToolStripButton()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.btnSair = New System.Windows.Forms.ToolStripButton()
        CType(Me.gvCadUserSeg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsBarraBotoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvCadUserSeg
        '
        Me.gvCadUserSeg.AllowUserToAddRows = False
        Me.gvCadUserSeg.AllowUserToDeleteRows = False
        Me.gvCadUserSeg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvCadUserSeg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadUserSeg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSegId, Me.ColNome, Me.ColDescr})
        Me.gvCadUserSeg.Location = New System.Drawing.Point(2, 38)
        Me.gvCadUserSeg.Name = "gvCadUserSeg"
        Me.gvCadUserSeg.ReadOnly = True
        Me.gvCadUserSeg.Size = New System.Drawing.Size(528, 386)
        Me.gvCadUserSeg.TabIndex = 3
        '
        'ColSegId
        '
        Me.ColSegId.HeaderText = "SegId"
        Me.ColSegId.Name = "ColSegId"
        Me.ColSegId.ReadOnly = True
        '
        'ColNome
        '
        Me.ColNome.HeaderText = "Nome"
        Me.ColNome.Name = "ColNome"
        Me.ColNome.ReadOnly = True
        '
        'ColDescr
        '
        Me.ColDescr.HeaderText = "Descr"
        Me.ColDescr.Name = "ColDescr"
        Me.ColDescr.ReadOnly = True
        '
        'tsBarraBotoes
        '
        Me.tsBarraBotoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.btnEdita, Me.btnSalva, Me.btnRemove, Me.btnSair})
        Me.tsBarraBotoes.Location = New System.Drawing.Point(0, 0)
        Me.tsBarraBotoes.Name = "tsBarraBotoes"
        Me.tsBarraBotoes.Size = New System.Drawing.Size(532, 36)
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
        'btnRemove
        '
        Me.btnRemove.AutoSize = False
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(70, 33)
        Me.btnRemove.Text = "Remover"
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRemove.ToolTipText = "Remover o item selecionado"
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
        'frmCadUserSeg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 424)
        Me.Controls.Add(Me.tsBarraBotoes)
        Me.Controls.Add(Me.gvCadUserSeg)
        Me.Name = "frmCadUserSeg"
        Me.Text = "Áreas de Segurança"
        CType(Me.gvCadUserSeg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsBarraBotoes.ResumeLayout(False)
        Me.tsBarraBotoes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvCadUserSeg As System.Windows.Forms.DataGridView
    Friend WithEvents ColSegId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents tsBarraBotoes As System.Windows.Forms.ToolStrip
    Public WithEvents btnNovo As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdita As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSalva As System.Windows.Forms.ToolStripButton
    Public WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSair As System.Windows.Forms.ToolStripButton
End Class
