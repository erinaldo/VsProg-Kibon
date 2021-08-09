<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadIngred
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadIngred))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butNovo = New System.Windows.Forms.ToolStripButton()
        Me.butEditar = New System.Windows.Forms.ToolStripButton()
        Me.butApagar = New System.Windows.Forms.ToolStripButton()
        Me.butSair = New System.Windows.Forms.ToolStripButton()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.colCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIngr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butNovo, Me.butEditar, Me.butApagar, Me.butSair})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(540, 43)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butNovo
        '
        Me.butNovo.AutoSize = False
        Me.butNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butNovo.Image = CType(resources.GetObject("butNovo.Image"), System.Drawing.Image)
        Me.butNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butNovo.Name = "butNovo"
        Me.butNovo.Size = New System.Drawing.Size(40, 40)
        Me.butNovo.Text = "Novo"
        '
        'butEditar
        '
        Me.butEditar.AutoSize = False
        Me.butEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEditar.Image = CType(resources.GetObject("butEditar.Image"), System.Drawing.Image)
        Me.butEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEditar.Name = "butEditar"
        Me.butEditar.Size = New System.Drawing.Size(40, 40)
        Me.butEditar.Text = "Editar selecionado"
        '
        'butApagar
        '
        Me.butApagar.AutoSize = False
        Me.butApagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butApagar.Image = CType(resources.GetObject("butApagar.Image"), System.Drawing.Image)
        Me.butApagar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butApagar.Name = "butApagar"
        Me.butApagar.Size = New System.Drawing.Size(40, 40)
        Me.butApagar.Text = "Apagar selecionado"
        '
        'butSair
        '
        Me.butSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butSair.AutoSize = False
        Me.butSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSair.Image = CType(resources.GetObject("butSair.Image"), System.Drawing.Image)
        Me.butSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSair.Name = "butSair"
        Me.butSair.Size = New System.Drawing.Size(40, 40)
        Me.butSair.Text = "Sair"
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCod, Me.colIngr})
        Me.gvItens.Location = New System.Drawing.Point(-1, 49)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersVisible = False
        Me.gvItens.RowHeadersWidth = 30
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(542, 372)
        Me.gvItens.TabIndex = 11
        '
        'colCod
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCod.DefaultCellStyle = DataGridViewCellStyle1
        Me.colCod.HeaderText = "Código"
        Me.colCod.Name = "colCod"
        Me.colCod.ReadOnly = True
        '
        'colIngr
        '
        Me.colIngr.HeaderText = "Ingrediente"
        Me.colIngr.Name = "colIngr"
        Me.colIngr.ReadOnly = True
        Me.colIngr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIngr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colIngr.Width = 400
        '
        'frmCadIngred
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 421)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gvItens)
        Me.Name = "frmCadIngred"
        Me.Text = "Cadastro de ingredientes"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butApagar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents colCod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIngr As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
