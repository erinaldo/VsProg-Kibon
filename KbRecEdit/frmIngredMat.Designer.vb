<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngredMat
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngredMat))
        Me.colIngr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalRef = New System.Windows.Forms.TextBox()
        Me.colPeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalPrc = New System.Windows.Forms.TextBox()
        Me.colPesoRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butNovo = New System.Windows.Forms.ToolStripButton()
        Me.butEditar = New System.Windows.Forms.ToolStripButton()
        Me.butApagar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.butSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblPesoRef = New System.Windows.Forms.ToolStripTextBox()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colIngr
        '
        Me.colIngr.HeaderText = "Ingrediente"
        Me.colIngr.Name = "colIngr"
        Me.colIngr.ReadOnly = True
        Me.colIngr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIngr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colIngr.Width = 150
        '
        'txtTotalRef
        '
        Me.txtTotalRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRef.Location = New System.Drawing.Point(442, 359)
        Me.txtTotalRef.Name = "txtTotalRef"
        Me.txtTotalRef.Size = New System.Drawing.Size(120, 23)
        Me.txtTotalRef.TabIndex = 14
        Me.txtTotalRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'colPeso
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPeso.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPeso.HeaderText = "Peso"
        Me.colPeso.Name = "colPeso"
        Me.colPeso.ReadOnly = True
        Me.colPeso.Width = 120
        '
        'colCod
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCod.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCod.HeaderText = "Código"
        Me.colCod.Name = "colCod"
        Me.colCod.ReadOnly = True
        '
        'txtTotalPrc
        '
        Me.txtTotalPrc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrc.Location = New System.Drawing.Point(323, 359)
        Me.txtTotalPrc.Name = "txtTotalPrc"
        Me.txtTotalPrc.Size = New System.Drawing.Size(112, 23)
        Me.txtTotalPrc.TabIndex = 13
        Me.txtTotalPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'colPesoRef
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPesoRef.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPesoRef.HeaderText = "Peso Ref. (Kg)"
        Me.colPesoRef.Name = "colPesoRef"
        Me.colPesoRef.ReadOnly = True
        Me.colPesoRef.Width = 120
        '
        'colSeq
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colSeq.DefaultCellStyle = DataGridViewCellStyle8
        Me.colSeq.HeaderText = "Seq"
        Me.colSeq.Name = "colSeq"
        Me.colSeq.ReadOnly = True
        Me.colSeq.Width = 70
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(277, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Total"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butNovo, Me.butEditar, Me.butApagar, Me.ToolStripSeparator1, Me.butSair, Me.ToolStripLabel1, Me.lblPesoRef})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(596, 43)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 43)
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(97, 40)
        Me.ToolStripLabel1.Text = "Peso de referência"
        '
        'lblPesoRef
        '
        Me.lblPesoRef.BackColor = System.Drawing.Color.White
        Me.lblPesoRef.Name = "lblPesoRef"
        Me.lblPesoRef.ReadOnly = True
        Me.lblPesoRef.Size = New System.Drawing.Size(100, 43)
        Me.lblPesoRef.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSeq, Me.colCod, Me.colIngr, Me.colPeso, Me.colPesoRef})
        Me.gvItens.Location = New System.Drawing.Point(-1, 49)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersVisible = False
        Me.gvItens.RowHeadersWidth = 30
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(598, 303)
        Me.gvItens.TabIndex = 11
        '
        'frmIngredMat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 384)
        Me.Controls.Add(Me.txtTotalRef)
        Me.Controls.Add(Me.txtTotalPrc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gvItens)
        Me.Name = "frmIngredMat"
        Me.Text = "Ingredientes de Maturadores"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents colIngr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalRef As System.Windows.Forms.TextBox
    Friend WithEvents colPeso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalPrc As System.Windows.Forms.TextBox
    Friend WithEvents colPesoRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butApagar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPesoRef As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
End Class
