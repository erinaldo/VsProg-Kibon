<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadPtoCr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadPtoCr))
        Me.gvCadPtoCr = New System.Windows.Forms.DataGridView()
        Me.ColPtoCrId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPergunta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsBarraBotoes = New System.Windows.Forms.ToolStrip()
        Me.btnNovaPergunta = New System.Windows.Forms.ToolStripButton()
        Me.btnEdita = New System.Windows.Forms.ToolStripButton()
        Me.btnSair = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleta = New System.Windows.Forms.ToolStripButton()
        CType(Me.gvCadPtoCr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsBarraBotoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvCadPtoCr
        '
        Me.gvCadPtoCr.AllowUserToAddRows = False
        Me.gvCadPtoCr.AllowUserToDeleteRows = False
        Me.gvCadPtoCr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvCadPtoCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadPtoCr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPtoCrId, Me.ColPergunta})
        Me.gvCadPtoCr.Location = New System.Drawing.Point(0, 39)
        Me.gvCadPtoCr.Name = "gvCadPtoCr"
        Me.gvCadPtoCr.ReadOnly = True
        Me.gvCadPtoCr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadPtoCr.Size = New System.Drawing.Size(772, 304)
        Me.gvCadPtoCr.TabIndex = 2
        '
        'ColPtoCrId
        '
        Me.ColPtoCrId.HeaderText = "PtoCrId"
        Me.ColPtoCrId.Name = "ColPtoCrId"
        Me.ColPtoCrId.ReadOnly = True
        Me.ColPtoCrId.Width = 80
        '
        'ColPergunta
        '
        Me.ColPergunta.HeaderText = "Pergunta"
        Me.ColPergunta.Name = "ColPergunta"
        Me.ColPergunta.ReadOnly = True
        Me.ColPergunta.Width = 600
        '
        'tsBarraBotoes
        '
        Me.tsBarraBotoes.Dock = System.Windows.Forms.DockStyle.None
        Me.tsBarraBotoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovaPergunta, Me.btnEdita, Me.btnSair, Me.btnDeleta})
        Me.tsBarraBotoes.Location = New System.Drawing.Point(0, 0)
        Me.tsBarraBotoes.Name = "tsBarraBotoes"
        Me.tsBarraBotoes.Size = New System.Drawing.Size(280, 36)
        Me.tsBarraBotoes.Stretch = True
        Me.tsBarraBotoes.TabIndex = 4
        Me.tsBarraBotoes.Text = "ToolStrip1"
        '
        'btnNovaPergunta
        '
        Me.btnNovaPergunta.AutoSize = False
        Me.btnNovaPergunta.Image = CType(resources.GetObject("btnNovaPergunta.Image"), System.Drawing.Image)
        Me.btnNovaPergunta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovaPergunta.Name = "btnNovaPergunta"
        Me.btnNovaPergunta.Size = New System.Drawing.Size(70, 33)
        Me.btnNovaPergunta.Text = "Novo"
        Me.btnNovaPergunta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNovaPergunta.ToolTipText = "Novo Usuário"
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
        'frmCadPtoCr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 344)
        Me.Controls.Add(Me.tsBarraBotoes)
        Me.Controls.Add(Me.gvCadPtoCr)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadPtoCr"
        Me.Text = "frmCadPtoCr"
        CType(Me.gvCadPtoCr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsBarraBotoes.ResumeLayout(False)
        Me.tsBarraBotoes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvCadPtoCr As System.Windows.Forms.DataGridView
    Public WithEvents tsBarraBotoes As System.Windows.Forms.ToolStrip
    Public WithEvents btnSair As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdita As System.Windows.Forms.ToolStripButton
    Public WithEvents btnNovaPergunta As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDeleta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColPtoCrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPergunta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
