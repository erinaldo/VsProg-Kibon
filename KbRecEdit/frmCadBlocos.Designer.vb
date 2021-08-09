<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadBlocos
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadBlocos))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.butFechar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gvBlocos = New System.Windows.Forms.DataGridView()
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMnemonico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butBlkNovo = New System.Windows.Forms.ToolStripButton()
        Me.butBlkEditar = New System.Windows.Forms.ToolStripButton()
        Me.butBlkApagar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gvParam = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.butPrmNovo = New System.Windows.Forms.ToolStripButton()
        Me.butPrmEditar = New System.Windows.Forms.ToolStripButton()
        Me.butPrmApagar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gvBlocos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvParam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'butFechar
        '
        Me.butFechar.Location = New System.Drawing.Point(273, 452)
        Me.butFechar.Name = "butFechar"
        Me.butFechar.Size = New System.Drawing.Size(128, 40)
        Me.butFechar.TabIndex = 10
        Me.butFechar.Text = "Fechar"
        Me.butFechar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gvBlocos)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(662, 215)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Blocos"
        '
        'gvBlocos
        '
        Me.gvBlocos.AllowUserToAddRows = False
        Me.gvBlocos.AllowUserToDeleteRows = False
        Me.gvBlocos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvBlocos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumero, Me.colDesc, Me.colMnemonico})
        Me.gvBlocos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvBlocos.Location = New System.Drawing.Point(44, 16)
        Me.gvBlocos.Name = "gvBlocos"
        Me.gvBlocos.ReadOnly = True
        Me.gvBlocos.RowHeadersVisible = False
        Me.gvBlocos.RowHeadersWidth = 30
        Me.gvBlocos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvBlocos.Size = New System.Drawing.Size(615, 196)
        Me.gvBlocos.TabIndex = 6
        '
        'colNumero
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colNumero.DefaultCellStyle = DataGridViewCellStyle11
        Me.colNumero.HeaderText = "Numero"
        Me.colNumero.Name = "colNumero"
        Me.colNumero.ReadOnly = True
        Me.colNumero.Width = 80
        '
        'colDesc
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colDesc.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDesc.HeaderText = "Descrição"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 300
        '
        'colMnemonico
        '
        Me.colMnemonico.HeaderText = "Mnemonico"
        Me.colMnemonico.Name = "colMnemonico"
        Me.colMnemonico.ReadOnly = True
        Me.colMnemonico.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colMnemonico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMnemonico.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butBlkNovo, Me.butBlkEditar, Me.butBlkApagar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(41, 196)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butBlkNovo
        '
        Me.butBlkNovo.AutoSize = False
        Me.butBlkNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butBlkNovo.Image = CType(resources.GetObject("butBlkNovo.Image"), System.Drawing.Image)
        Me.butBlkNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butBlkNovo.Name = "butBlkNovo"
        Me.butBlkNovo.Size = New System.Drawing.Size(40, 40)
        Me.butBlkNovo.Text = "Novo"
        '
        'butBlkEditar
        '
        Me.butBlkEditar.AutoSize = False
        Me.butBlkEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butBlkEditar.Image = CType(resources.GetObject("butBlkEditar.Image"), System.Drawing.Image)
        Me.butBlkEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butBlkEditar.Name = "butBlkEditar"
        Me.butBlkEditar.Size = New System.Drawing.Size(40, 40)
        Me.butBlkEditar.Text = "Editar selecionado"
        '
        'butBlkApagar
        '
        Me.butBlkApagar.AutoSize = False
        Me.butBlkApagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butBlkApagar.Image = CType(resources.GetObject("butBlkApagar.Image"), System.Drawing.Image)
        Me.butBlkApagar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butBlkApagar.Name = "butBlkApagar"
        Me.butBlkApagar.Size = New System.Drawing.Size(40, 40)
        Me.butBlkApagar.Text = "Apagar selecionado"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvParam)
        Me.GroupBox2.Controls.Add(Me.ToolStrip2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 233)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(662, 213)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parametros"
        '
        'gvParam
        '
        Me.gvParam.AllowUserToAddRows = False
        Me.gvParam.AllowUserToDeleteRows = False
        Me.gvParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvParam.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column1, Me.DataGridViewTextBoxColumn3, Me.Column2})
        Me.gvParam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvParam.Location = New System.Drawing.Point(44, 16)
        Me.gvParam.Name = "gvParam"
        Me.gvParam.ReadOnly = True
        Me.gvParam.RowHeadersVisible = False
        Me.gvParam.RowHeadersWidth = 30
        Me.gvParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvParam.Size = New System.Drawing.Size(615, 194)
        Me.gvParam.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn1.HeaderText = "Numero"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descrição"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 170
        '
        'Column1
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle15
        Me.Column1.HeaderText = "Valor Default"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unit. Eng."
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'Column2
        '
        Me.Column2.HeaderText = "Flag Peso"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butPrmNovo, Me.butPrmEditar, Me.butPrmApagar})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(41, 194)
        Me.ToolStrip2.TabIndex = 6
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'butPrmNovo
        '
        Me.butPrmNovo.AutoSize = False
        Me.butPrmNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butPrmNovo.Image = CType(resources.GetObject("butPrmNovo.Image"), System.Drawing.Image)
        Me.butPrmNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butPrmNovo.Name = "butPrmNovo"
        Me.butPrmNovo.Size = New System.Drawing.Size(40, 40)
        Me.butPrmNovo.Text = "Novo"
        '
        'butPrmEditar
        '
        Me.butPrmEditar.AutoSize = False
        Me.butPrmEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butPrmEditar.Image = CType(resources.GetObject("butPrmEditar.Image"), System.Drawing.Image)
        Me.butPrmEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butPrmEditar.Name = "butPrmEditar"
        Me.butPrmEditar.Size = New System.Drawing.Size(40, 40)
        Me.butPrmEditar.Text = "Editar selecionado"
        '
        'butPrmApagar
        '
        Me.butPrmApagar.AutoSize = False
        Me.butPrmApagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butPrmApagar.Image = CType(resources.GetObject("butPrmApagar.Image"), System.Drawing.Image)
        Me.butPrmApagar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butPrmApagar.Name = "butPrmApagar"
        Me.butPrmApagar.Size = New System.Drawing.Size(40, 40)
        Me.butPrmApagar.Text = "Apagar selecionado"
        '
        'frmCadBlocos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 499)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butFechar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCadBlocos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Blocos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gvBlocos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gvParam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butFechar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gvBlocos As System.Windows.Forms.DataGridView
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMnemonico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butBlkNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents butBlkEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butBlkApagar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gvParam As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents butPrmNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents butPrmEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butPrmApagar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
